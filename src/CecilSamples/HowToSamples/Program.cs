#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace HowToSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new {name = "Kangkang", age = 16};

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Newtonsoft.Json.dll");
            var newName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "new.dll");

            var rawMethod = Assembly.LoadFile(fileName).GetType("Newtonsoft.Json.JsonConvert")
                ?.GetMethod("SerializeObject", new[] {typeof(object)});
            var json = rawMethod?.Invoke(null, new object[] {obj}) as string;
            Console.WriteLine(json);


            Sample.InsertInstructions(fileName, newName, a => a.Name == "JsonConvert",
                a => a.Name == "SerializeObject" && a.Parameters.Count == 1 &&
                     a.Parameters[0].ParameterType.FullName == "System.Object", "hello cecil.");

            var newMethod = Assembly.LoadFile(newName).GetType("Newtonsoft.Json.JsonConvert")
                ?.GetMethod("SerializeObject", new[] {typeof(object)});
            json = newMethod?.Invoke(null, new object[] {obj}) as string;
            Console.WriteLine(json);
        }
    }

    public static class Sample
    {
        public static ModuleDefinition GetModule(string fileName)
        {
            return ModuleDefinition.ReadModule(fileName);
        }

        public static void InsertInstructions(string fileName, string newName, Func<TypeDefinition, bool> predicateType,
            Func<MethodDefinition, bool> predicateMethod, string message)
        {
            // 获取到 SerializeObject 序列化对象方法
            var module = GetModule(fileName);
            foreach (var type in module.GetTypes().Where(predicateType))
            {
                foreach (var method in type?.GetMethods().Where(predicateMethod)!)
                {
                    // 导入 Console.WriteLine 方法
                    var writeLineMethod =
                        type?.Module.ImportReference(
                            typeof(Console).GetMethod("WriteLine", new Type[] {typeof(string)}));

                    // 注入 Console.WriteLine("调用了序列化方法。");
                    var processor = method.Body.GetILProcessor();
                    var firstInstruction = method.Body.Instructions[0];
                    processor.InsertBefore(firstInstruction, processor.Create(OpCodes.Ldstr, message));
                    processor.InsertBefore(firstInstruction, processor.Create(OpCodes.Call, writeLineMethod));
                    processor.InsertBefore(firstInstruction, processor.Create(OpCodes.Nop));
                }
            }

            module.Write(newName);
        }
    }
}