# Mono.Cecil

`Cecil` 是一个用来生成与检查基于 `ECMA CIL` 标准格式程序与库文件的工具库。其完全支持泛型、支持 `pdb` 与 `mdb` 格式的调试符文件，并且其有很广泛的应用场景。

简单来说，用 `Cecil` 可以加载现有的托管程序集，浏览并检查其所包含的所有类型，动态的对其进行修改并保存回原程序集。

如果想要使用 `Mono.Cecil` 的包，可以直接从 NuGet 上下载：`Install-Package Mono.Cecil`。

## 编译

`Cecil` 当前必须使用 `.NET Core 3.1` 的 SDK 来进行编译，其支持两个目标框架，分别是 `.NET 4.0` 以及 `.NET Standard 2.0`。

如果想要编译 `Cecil` 只需要运行以下命令：

```bash
dotnet build -c:Release
```

如果想要在本地创建 `NuGet` 包，则可以使用以下命令：

```bash
dotnet build -c:Release
nuget pack Mono.Cecil.nuspec
```

以上命令运行完成后，将会获得一个名为 `Mono.Cecil.(version).nupkg` 的文件。

这个文件可以使用以下命令进行安装：

```bash
nuget install Mono.Cecil -Source <directory with Mono.Cecil.(version).nupkg> -OutputDirectory <install directory>
```

然后你就可以在安装目录看到一个名为 `Mono.Cecil.(version)` 的文件夹。

## 调试符号

`Cecil` 支持调试符号依赖于 `Mono.Cecil.Pdb.dll`、`Mono.Cecil.Mdb.dll` 两个程序集。使用他们可以实现对 `.NET` 的 `pdb` 以及 `Mono` 的 `mdb` 文件的读写。

+ `Mono.Cecil.Mdb.dll` 是一个纯净的托管程序集，其可以用于 `.NET` 与 `Mono`，在任何系统上。
+ `Mono.Cecil.Pdb.dll` 是一个托管的 `pdb` 读取器，但是其依赖于 `COM` 组件进行写入，这意味着虽然可以在任意平台读取 `pdb` 文件，但是只能在 `Windows` 上写入 `pdb` 文件，托管程序读取功能使用了 `CCI` 项目的代码。

从 API 来说，与这两种调试符号交互最简单的方式就是将 `True` 传递给 `ReaderParameters.ReadSymbols` 或 `WriterParameters.WriteSymbols` 属性。`Ceil` 将尝试根据运行时(`.NET` 的 `pdb`，`Mono` 的 `mdb`)加载合适的程序集对调试符号进行读写。

以下代码就是一个读写程序集符号文件的示例：

```cs
var readerParameters = new ReaderParameters { ReadSymbols = true };
var assemblyDefinition = AssemblyDefinition.ReadAssembly (fileName, readerParameters);

// 进行了必要的更改

var writerParameters = new WriterParameters { WriteSymbols = true };
assemblyDefinition.Write (outputFile, writerParameters);
```

如果需要使用更多功能，可以查看 `ReaderParameters.SymbolReaderProvider` 与 `WriterParameters.SymbolWriterProvider`。其分别控制了 `Mono.Cecil.Cil.ISymbolReader` 与 `Mono.Cecil.Cil.ISymbolWriter` 接口的创建。

## 常见问题

**Q: 可以使用 `Cecil` 用于我自己的闭源程序吗？**

A: 简单来说：可以。具体内容可以阅读 `Cecil` 的 [授权协议](https://github.com/jbevain/cecil/wiki/License)。

**Q: `Cecil` 是 `Mono` 的一部分，我可以用在 `.NET` 上吗？**

A: 当然可以。

**Q: `Cecil` 支持 `.NET 4.0` 吗？**

A: 可以，没有任何问题。

**Q: 可以使用 `.NET 4.0` 的 `Cecil` 用在 `.NET 2.0` 的程序集上吗？**

A: 可以，`Cecil` 都语里运行时。可以使用 `.NET 4.0` 的 `Cecil` 加载 `.NET 2.0` 的程序集，反之亦然。

**Q: `Cecil` 可以用在 `Silverlight` / `Moonlight` 上吗？**

A: 要在 `Silverlight` 上使用 `Mono.Cecil`，只需在进行编译时定义 `@SILVERLIGHT@` 编译符号。 除了不能用于强命名程序集以外，其他的所有功能都可以正常使用。

**Q: `Cecil` 可以用在 `Compact Framework` 上吗？**

A: 要在 `Compact Framework` 上使用 `Mono.Cecil`，只需编译并定义 `@CF@` 编译符号。 但是同样也不能在强命名程序集上使用。

**Q: `Cecil` 支持 `PE32+` 的程序集吗？**

A: `Cecil` 同时支持 `AMD64` 和 `IA64` 的特定程序集。只需将模块的 `Architecture` 属性设置为适当的 `TargetArchitecture` 枚举成员即可。

**Q: `Cecil` 是否支持混合模式程序集？**

`Cecil` 可以读取混合模式程序集，但不支持编写混合模式程序集。

## 使用说明

### 打开一个模块并浏览其中的公开类型

```cs
public void PrintTypes (string fileName)
{
    ModuleDefinition module = ModuleDefinition.ReadModule (fileName);
    foreach (TypeDefinition type in module.Types) {
        if (!type.IsPublic)
            continue;

        Console.WriteLine (type.FullName);
    }
}
```

### 获取类型的自定义特性

```cs
public static bool TryGetCustomAttribute(TypeDefinition type,
    string attributeType, out CustomAttribute result)
{
    result = null;
    if (!type.HasCustomAttributes)
        return false;

    foreach (CustomAttribute attribute in type.CustomAttributes) 
    {
        if (attribute.AttributeType.FullName != attributeType)
            continue;

        result = attribute;
        return true;
    }

    return false;
}
```

定义一个如下类型：

```cs
[Foo.Ignore("Not working yet")]
public class Fixture
{
}
```

用法：

```cs
public static string GetIgnoreReason(TypeDefinition type)
{
    CustomAttribute ignoreAttribute;
    if (!TryGetCustomAttribute(type, "Foo.IgnoreAttribute", out ignoreAttribute))
        return string.Empty;

   if (ignoreAttribute.ConstructorArguments.Count != 1)
        return string.Empty;

    return (string) ignoreAttribute.ConstructorArguments[0].Value;
}
```

### 在一条指令之前插入 IL 指令

以下代码演示如何在一个方法的方法体第一行中增加另一个方法的调用：

```cs
var processor = method.Body.GetILProcessor();
var newInstruction = processor.Create(OpCodes.Call, someMethodReference);
var firstInstruction = method.Body.Instructions[0];
		
processor.InsertBefore(firstInstruction, newInstruction);
```


## 导入

当你修改一个程序集时，你要注入的代码通常来自另一个程序集。例如，当你要注入记录日志的代码，你应该需要添加的代码应该来自一个日志记录组件的程序集。为你注入的代码创建必须的外部引用的过程就被成为导入(importing)。

引用的作用域是 `ModuleDefinition`。因此所有导入方法都是在 `ModuleDefinition` 上定义的，并且允许用在 `.NET` 运行时的类型 (`System.Type`、`System.Reflection.MethodBase`、`System.Reflection.FieldInfo`) 以及 `Cecil` 的类型 (`TypeReference`、`MethodReference`、`FieldReference`)。

下面的例子演示了如何在一个 `MethodDefinition` 方法体的首行注入一行调用 `Console.WriteLine` 的代码。

```cs
using Mono.Cecil;
using Mono.Cecil.Cil;

// ...

var method = GetMethodDefinition(...);
var il = method.Body.GetILProcessor();

var ldstr = il.Create(OpCodes.Ldstr, method.Name);
var call = il.Create(OpCodes.Call,
	method.Module.Import(
		typeof (Console).GetMethod("WriteLine", new[] { typeof (string) })));

il.InsertBefore(method.Body.Instructions[0], ldstr);
il.InsertAfter(method.Body.Instructions[0], call);
```

无论何时向程序集添加元数据，导入都是非常有必要的。让我们向一个模块添加一个静态类，它将包含一个静态方法。

```cs
var module = GetModuleDefinition(...);

var type = new TypeDefinition(
	"Foo.Bar",
	"Baz",
	TypeAttributes.Public | TypeAttributes.Abstract | TypeAttributes.Sealed,
	module.Import(typeof(object)));

module.Types.Add(type);

var method = new MethodDefinition(
	"Bang",
	MethodAttributes.Public | MethodAttributes.Static,
	module.Import(typeof(void)));

type.Methods.Add(method);

method.Parameters.Add(new ParameterDefinition(module.Import(typeof(string))));
```

请注意，导入获取 `System.Object` 类型的 `TypeReference`，作为 `Foo.Bar.Baz` 类型的基类型。它还将 `Bang` 方法的返回类型设置为 `System.Void`，并向该方法添加一个类型为 `System.String` 的参数。


## 开源许可

`Mono.Cecil` 的开源许可基于 `MIT/X11`：

```text
Copyright (c) 2008 - 2011, Jb Evain

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
```

`MIT/X11` 是一个宽容的许可证，与 `GPL` 兼容。并且只要此许可与软件一起分发，就可以在私有软件中使用。


## 迁移

在 `Mono.Cecil` 的 `0.6` 和`0.9` 版本之间，`API` 有以下几个方面的调整：

+ `API` 更易于使用。
+ 更好的反射程序集中的内容。
+ 应用了 `.NET 2.0` 中 `.NET` 的功能 (例如泛型)。

将应用程序移植到新版的 `Mono.Cecil` 很简单。我们建议您使用了 `Cecil` 分支的项目及时更新 `Mono.Cecil` 到最新版本。对于我亲自移植的大多数项目，半天的时间就足以使其运行并享受新版本的 `Cecil`。

更新时的注意事项：

+ `AssemblyFactory` 不可用。你可以用 `ModuleDefinition.ReadModule` 以及 `AssemblyDefinition.ReadAssembly` 静态方法，然后调用它们的 `Write` 方法进行回写。
+ `ModuleDefinition.Types` 现在仅返回顶级 (非嵌套) 类型。 如果要遍历程序集中定义的所有类型，则可以使用 `ModuleDefinition.GetTypes()` 方法。
+ `TypeDefinition.Constructors` 合并在 `TypeDefinition.Methods` 内。这是 `Cecil` 的问题，它打乱了在类型中定义方法的顺序。
+ `ParameterDefinition.Sequence` 是参数从 1 开始的索引。它已被从 0 开始的 `ParameterDefinition.Index` 取代。为了帮助您移植应用程序，可以将使用 `Sequence` 属性替换为使用扩展方法 `Mono.Cecil.Rocks.ParameterReferenceRocks.GetSequence` (`ParameterReference` 对象调用)。
+ `IMethodSignature.ReturnType`（会影响诸如 `MethodReference` 或 `MethodDefinition` 之类的类型，现在直接返回 `TypeReference`。它避免经常出现的以下代码：`method.ReturnType.ReturnType`，该内容在先前的 `Cecil` 代码中很常见。如果您仍想访问自定义特性或返回类型上指定的排列信息，可以使用 `method.MethodReturnType`。实际上，`method.ReturnType` 只是缩短了对 `method.MethodReturnType.ReturnType` 访问路径。
+ `TypeDefinitionCollection` 上有一个字符串索引器属性，用于根据其全名检索 `TypeDefinition`。它已被 `ModuleDefinition.GetType` 方法代替。
+ 自定义特性 `API` 发生了很大变化。旧的版本虽然较为直接，但并未为所有情况提供足够的信息。使用旧的 `Cecil` 的大多数代码看起来像 `(string)attribute.ConstructorParameters[0]`。它已被替换为 `(string)attribute.ConstructorArguments[0].Value`。 `.ConstructorArgument[0]` 返回 `CustomAttributeArgument` 类型，其具有 `TypeReference Type`的属性和 `object Value` 属性。
+ `CilWorker` 不再存在，它已重命名为 `ILProcessor`，您可以通过在 `MethodBody` 上调用 `GetILProcessor` 来获得一个实例。
+ 现在，您必须调用 `TypeReference.GetElementType` 和 `MethodReference.GetElementMethod` 而不是 `TypeReference.GetOriginalType` 和 `MethodReference.GetOriginalMethod`。


## Mono.Cecil.Rocks

`Mono.Cecil.Rocks` 是一个程序集，包含 `Mono.Cecil` 的常用扩展方法和额外功能，而核心程序集 `Mono.Cecil` 则不需要这些功能。它提供了帮助以方便迁移到新的代码库以及新的功能。


## 解析

您可以通过传统的反射操作 `.NET` 系统类型，消除引用和定义之间的差异。它仅为您提供已解析的类型，字段和方法。在元数据级别，以及在 `Cecil` 级别，我们需要在引用和定义之间进行区分。

它们都按 `ModuleDefinition` 定义范围。因此，在 `ModuleDefinition` 中，定义是在模块本身中被定义的元数据元素，而引用是在另一个模块中定义的元数据元素。例如，如果您有一个程序集 `Foo.dll`，其中包含类型 `Foo.Bar`。此类型 `Foo.Bar` 公开了一个方法 `Baz`，该方法返回 `System.String`。

如果使用 `Cecil` 加载 `Foo.dll`，则 `Foo.Bar` 将是 `TypeDefinition`，而方法 `Baz` 的返回类型将是对 `System.String` 的 `TypeReference`。`System.String` 在程序集 `mscorlib.dll` 中定义，这意味着如果使用 `Cecil` 打开 `mscorlib.dll`，则其中将包含 `System.String` 的 `TypeDefinition`。

从引用中获取定义的过程称为解析。`Cecil` 中所有可解析的引用都具有 `Resolve` 方法。例如，假设您已经在 `Cecil` 中加载了 `Foo.dll`，并且您想解析 `Baz` 方法的返回类型：

```cs
ModuleDefinition module = ModuleDefinition.ReadModule("Foo.dll");

TypeDefinition foo_bar = module.Types.First(t => t.FullName == "Foo.Bar");
MethodDefinition baz = foo_bar.Methods.First(m => m.Name == "Baz");

TypeReference string_reference = baz.ReturnType;

// resolve into a definition:

TypeDefinition string_definition = string_reference.Resolve();
ModuleDefinition corlib = string_definition.Module;
```

在此示例中，`string_definition` 是 `TypeDefinition`，其模块是 `mscorlib.dll` 的 `ModuleDefinition`。若要查找定义引用的程序集，`Cecil` 需要对 `Foo.dll` 使用 `ModuleDefinition` 的 `IAssemblyResolver`。

我们强烈建议您在读取 `ModuleDefinition` 时指定自己的 `IAssemblyResolver`。这样，您可以控制所加载模块的生命周期以及所解析的关联引用。

如果您未指定自定义解析器，则每个模块都会有自己的解析器，这将导致更多的内存被使用。


## 强命名

可以使用 `Cecil` 修改具有强命名的程序集，但要加载该程序集，必须将其重新签名。这里有不同的选择。

(一) 默认情况下，如果您未指定任何内容，则程序集将以延迟签名的形式保存。 `Cecil` 将为强命名腾出一些空间，但是签名并不存在。您必须使用 `.NET SDK` 或 `Mono` 随附的 `sn` 工具将程序集重新签名。

```bash
sn -R foo.dll
```

在 `.NET` 上，您可以将程序集添加到程序集列表中，`.NET` 运行时不会在其中验证其强命名。 这也可以通过 `sn` 工具完成：

```bash
sn -Vr foo.dll
```

(二) 如果您有权访问密钥对，则可以要求 `Cecil` 直接对其进行签名。这是通过在编写模块时指定 `System.Reflection.StrongNameKeyPair` 来完成的：

```cs
var module = ...;

module.Write("Foo.dll", new WriterParameters{
  StrongNameKeyPair = new StrongNameKeyPair(File.ReadAllBytes("Foo.snk"))
});
```

(三) 您可以决定完全删除该强命名。但这意味着引用了您要修改的程序集的每个程序集都需要更新其引用。为此，您必须清除其公共密钥，并指出未签名：

```cs
var assembly = ...;
var name = assembly.Name;

name.HasPublicKey = false;
name.PublicKey = new byte [0];
module.Attributes &= ~ModuleAttributes.StrongNameSigned;
```


## 使用者

我们很高兴地注意到以下项目和产品正在使用 `Mono.Cecil`。请与我们联系以改进或更正此列表。

### 开源

**编译器**

+ [vbnc](http://mono-project.com/VisualBasic): `Mono` 的 `Visual Basic` 编译器。
+ [brainfucker](http://code.google.com/p/brainfucker/): 用于 `CLI` 的 `Brainfuck` 编译器。
+ [JaCIL](http://www.cs.rit.edu/~atg2335/project/): `CLI-to-JVM` 编译器。
+ [Ja.NET](http://www.janetdev.org/): `JVM-to-CLI` 编译器。
+ [JSIL](https://github.com/kevingadd/JSIL): `CIL-to-JavaScript` 编译器。
+ [WebSharper](http://www.websharper.com/home): `F#-to-JavaScript` 编译器。
+ [Lexa-JSM](http://code.google.com/p/lexa-jsm/): `C#-to-JavaScript` 转换器。

**反编译工具**

+ [ILSpy](http://www.ilspy.com/): `ILSpy` 是 `SharpDevelop` 团队基于 `Cecil` 的反编译工具。
+ [Cecil.Decompiler](http://github.com/mono/cecil/tree/master/decompiler): `Cecil.Decompiler` 是基于 `Cecil` 的库，用于从 `CIL` 到 `C#` 或其他语言的反编译。
+ [Cecil Studio](http://code.google.com/p/cecilstudio): `Cecil Studio` 是 `Cecil` 和 `Cecil.Decompiler` 的接口。

**开发环境**

+ [SharpDevelop](http://www.icsharpcode.net/OpenSource/SD/): `#develop` (`SharpDevelop` 的缩写) 是一个免费的 `IDE`，用于微软 `.NET` 平台上的 `C#`、`VB.NET`和 `Boo` 项目。
+ [MonoDevelop](http://www.monodevelop.com/): `MonoDevelop` 是免费的 `GNOME` `IDE`，主要用于 `C#` 和其他 `.NET` 语言。
+ [MonoUML](http://www.monouml.org/doku.php/reverseengineering-cil): `CIL` 逆向工程插件。
+ [Reflexil](http://reflexil.net/): `.NET Reflector` 的插件，允许您修改程序集。
+ [LINQPad](http://www.linqpad.net/): 该工具使您可以使用 `LINQ` 交互式查询 `SQL` 数据库。
+ [NDasm](http://ndasm.codeplex.com/): 显示 `.NET` 方法的 `CIL` 的 `Visual Studio` 插件。
+ [CShell](http://cshell.net/): 交互式 `C＃` 脚本环境。

**代码质量与度量**

+ [Gendarme](http://mono-project.com/Gendarme): `Gendarme` 是一个在程序中查找问题的工具。
+ [Monoxide](http://mono-project.com/Monoxide): `Monoxide` 是可扩展的程序集查看器。
+ [DrivenMetrics](http://github.com/garrensmith/DrivenMetrics): `.NET` 命令行度量工具。
+ [Lokad Shared Libraries](http://code.google.com/p/lokad-shared-libraries/): 高效构建 `.NET` 应用程序的库和引导。

**文档**

+ [monodoc](http://www.mono-project.com/Monodoc): `Monodoc` 是一组用于查看和编辑 `Mono` 类库文档的库和应用程序。
+ [ImmDoc .Net](http://immdocnet.codeplex.com/): `ImmDoc .NET` 是一个命令行实用程序，用于从一组 `.NET` 程序集和由编译器创建的 `XML` 文件中生成 `HTML` 文档。

**测试**

+ [MbUnit v3 / Gallio](http://www.gallio.org/): `Gallio` 自动化平台是一个用于 `.NET` 的开放、可扩展且中立的系统，它提供可由许多测试框架可以使用的通用对象模型、运行时服务和工具 (例如测试运行器)。
+ [MoMA](http://www.mono-project.com/MoMA): `Mono` 迁移分析器 (`MoMA`) 工具可帮助您确定将 `.NET` 应用程序移植到 `Mono` 时可能遇到的问题。
+ [OpenCover](http://sawilde.github.com/opencover/): 一个开源的代码覆盖工具。
+ [NinjaTurtles](http://ninjaturtles.codeplex.com/): `.NET` / `Mono` 变异测试。
+ [Smocks](https://github.com/vanderkleij/Smocks): `Smocks` 是用于模仿通常不可模仿的库。它可以模拟静态和非虚拟的方法和属性等。
+ [NUnit](https://github.com/nunit/nunit): `.NET` 的经典测试框架，使用 `Cecil` 来确定在运行测试时使用哪个运行时和框架版本，以及在何处以及如何执行它们。

**切面编织工具**

+ [SheepAOP](http://sheepaop.codeplex.com/): `SheepAOP` 是受 `AspectJ` 启发的另一个用于 `.NET` 环境的 `AOP` 工具。
+ [AspectDNG](http://aspectdng.tigris.org/): `AspectDNG` 是一个静态 `.NET` 切面编织工具。
+ [LinFu](https://github.com/philiplaureano/LinFu/): 一个向公共语言运行时添加 `mixin`、控制反转、`DbC` 和其他语言功能的框架。
+ [SetPoint](http://setpoint.codehaus.org/): `SetPoint` 是另一个 `AOP` 引擎。
+ [Compose*](http://janus.cs.utwente.nl:8000/twiki/bin/view/Composer/WebHome): `ComposeStar` 是一个旨在增强基于组件和基于对象的编程功能的项目。
+ [PostCrap](http://postcrap.codeplex.com/): `PostCrap` 是一个轻量级的基于特性实现切面注入的 `.NET` 后编译器。
+ [NSurgeon](http://nsurgeon.codeplex.com/): 一个静态的切面编织工具。




> 参考：
> + GitHub: https://github.com/jbevain/cecil