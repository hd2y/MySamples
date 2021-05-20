using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using MethodAttributes = Mono.Cecil.MethodAttributes;
using ParameterAttributes = Mono.Cecil.ParameterAttributes;
using TypeAttributes = Mono.Cecil.TypeAttributes;

namespace ImportingSamples
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("============ {0} ============", "Start");

            // 需要注入的程序集
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "HowToLib.dll");

            // 注入成功后返回的程序集内容
            var binary = CreateLog(fileName);

            // 写入到本地方便反编译
            //File.WriteAllBytes("temp.dll", binary);
            Console.WriteLine("--> 注入日志输出代码完成！");

            // 随机找到一个符合条件方法进行反射调用
            var assemblyInfo = Assembly.Load(binary);
            var methodInfo = assemblyInfo.GetTypes().Where(a => a.IsPublic && a.IsClass && !a.IsSpecialName)
                .SelectMany(a => a.GetMethods()).FirstOrDefault(a =>
                    a.IsPublic && a.IsStatic && !a.IsSpecialName && !a.IsVirtual && !a.IsConstructor &&
                    a.GetParameters().Length == 0);
            if (methodInfo != null)
            {
                object retValue = methodInfo.Invoke(null, null);
                Console.WriteLine("返回类型为: {0}", retValue?.GetType().FullName ?? "null");
            }

            Console.WriteLine("============ {0} ============", "End");
        }

        private static byte[] CreateLog(string fileName)
        {
            // 加载到内存，避免占用文件
            using var stream = new MemoryStream(File.ReadAllBytes(fileName));
            using var assembly = AssemblyDefinition.ReadAssembly(stream);

            // 为程序集注入一个输出日志的类型，方便后续基于此进行扩展
            // 返回内容为该类型输出日志的方法，入参为一个字符串
            var logMethod = CreateLogger(assembly);

            // 循环便利指定类型的方法注入内容
            foreach (var module in assembly.Modules)
            {
                foreach (var type in module.Types)
                {
                    if (!type.IsPublic || !type.IsClass || type.IsSpecialName ||
                        type.Namespace == "__CustomLogger__") continue;

                    foreach (var method in type.Methods)
                    {
                        if (!method.IsPublic || method.IsSpecialName || method.IsVirtual || method.IsConstructor ||
                            !method.HasBody) continue;

                        var il = method.Body.GetILProcessor();

                        // 注入类型名称开始执行的代码
                        il.InsertBefore(method.Body.Instructions[0],
                            il.Create(OpCodes.Ldstr, method.FullName + " Start."));
                        il.InsertAfter(method.Body.Instructions[0], il.Create(OpCodes.Call, logMethod));
                    }
                }
            }

            using var returnStream = new MemoryStream();
            assembly.Write(returnStream);
            return returnStream.ToArray();
        }

        private static MethodDefinition CreateLogger(AssemblyDefinition assembly)
        {
            if (assembly.Modules.Count == 0)
                throw new ArgumentException("Assembly don't have modules.", nameof(assembly));
            var objType = assembly.Modules[0].ImportReference(typeof(object));
            var strType = assembly.Modules[0].ImportReference(typeof(string));
            var voidType = assembly.Modules[0].ImportReference(typeof(void));
            var writeMethod = assembly.Modules[0]
                .ImportReference(typeof(Console).GetMethod("WriteLine", new[] {typeof(string)}));

            // 静态类型
            var typeAttributes = TypeAttributes.AnsiClass | TypeAttributes.NotPublic | TypeAttributes.AutoLayout |
                                 TypeAttributes.Public | TypeAttributes.Abstract | TypeAttributes.Sealed |
                                 TypeAttributes.BeforeFieldInit;

            // 静态方法
            var methodAttributes = MethodAttributes.CompilerControlled | MethodAttributes.Public |
                                   MethodAttributes.Static | MethodAttributes.HideBySig;

            var @namespace = $"__CustomLogger__";
            var typeName = "Logger";
            var methodName = "Write";

            var type = assembly.Modules.SelectMany(a => a.Types)
                .FirstOrDefault(a => a.Namespace == @namespace && a.Name == typeName);
            if (type != null)
            {
                if ((type.Attributes & typeAttributes) != typeAttributes)
                    throw new Exception("Type attributes error!");
            }
            else
            {
                type = new TypeDefinition(@namespace, typeName, typeAttributes, objType);

                assembly.Modules[0].Types.Add(type);
            }

            var method = type.Methods.FirstOrDefault(a =>
                a.Name == methodName && a.Parameters.Count == 1 && a.Parameters[0].ParameterType == strType);
            if (method != null)
            {
                if ((method.Attributes & methodAttributes) != methodAttributes)
                    throw new Exception("Method attributes error!");
            }
            else
            {
                method = new MethodDefinition(methodName, methodAttributes, voidType);

                method.Parameters.Add(new ParameterDefinition("message", ParameterAttributes.None, strType));
                var il = method.Body.GetILProcessor();
                il.Append(il.Create(OpCodes.Nop));
                il.Append(il.Create(OpCodes.Ldarg_0));
                il.Append(il.Create(OpCodes.Call, writeMethod));
                il.Append(il.Create(OpCodes.Ret));

                type.Methods.Add(method);
            }

            return method;
        }
    }
}