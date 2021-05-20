## <img src="./images/BasicFodyAddin.png" height="28px"> BasicFodyAddin

[BasicFodyAddin](https://github.com/Fody/Home/tree/master/BasicFodyAddin) 项目用于演示如何编写 Fody 插件。

### 💖 测试示例项目的使用效果

创建一个控制台项目，引用 `BasicFodyAddin.Fody`，修改程序入口代码：

```cs
class Program
{
    static void Main(string[] args)
    {
        var assembly = Assembly.GetEntryAssembly();
        var type = assembly?.GetType("Hello");
        if (type == null)
            Console.WriteLine("错误！");
        else
        {
            var hello = Activator.CreateInstance(type);
            var method = type.GetMethod("World");
            var result = method?.Invoke(hello, null) as string;
            Console.WriteLine(result);
        }
    }
}
```

运行该控制台程序，将输出 `Hello World`。

> 注意：如果无法正常编译，错误与 `Mono.Cecil` 有关，尝试 nuget 引用最新的 `Fody` 即可。

这里例子就是在当前程序集织入一个类型 `Hello`，该类型有一个 `World` 方法返回 `Hello World`。

使用 `ILSpy` 反编译改控制台程序可以看到下图内容：

![](https://hd2y.oss-cn-beijing.aliyuncs.com/hello-world-ilspy_1619675065938.png)

### 💖 按照官方教程写一个 Fody 插件

创建一个 `.NET Standard 2.0` 的类库，注意项目名称必须要以 `.Fody` 结尾。

项目引用 `FodyHelpers`，项目中不应有任何运行时依赖，`Mono Cecil` 除外。

程序集中应该包含一个名为 `ModuleWeaver` 的公共类型，放在任何命名空间下都没有关系。需要注意的是这个类型必须继承自 `BaseModuleWeaver`，并且是非静态不能是抽象类，必须有一个空构造函数。

```cs
public class ModuleWeaver : BaseModuleWeaver
{
    public override void Execute()
    {
        throw new NotImplementedException();
    }
    public override IEnumerable<string> GetAssembliesForScanning()
    {
        throw new NotImplementedException();
    }
}
```

**BaseModuleWeaver.Execute:** 用于执行实现模块的功能，可以通过 `BaseModuleWeaver.ModuleDefinition` 访问与操作当前模块。

**BaseModuleWeaver.GetAssembliesForScanning:** 用于缓存需要使用的类型，以便在实现具体功能时 Fody 能够使用这些程序集中的类型。这个方法应当返回向程序集注入功能时所有可能用到类型的程序集。例如，程序中需要使用 `System.Object` 时，该方法需要返回 `netstandard`、`mscorlib`。如果返回的程序集是未被使用的程序集，这些程序集的名称将被忽略，功能不受影响。如果要使用程序集中的类型，可以在 `Execute` 方法中调用 `BaseModuleWeaver.FindType`。

**BaseModuleWeaver.ShouldCleanReference:** 当引用我们编写的 Fody 插件模块仅应用于向程序集织入代码，在程序运行时不需要依赖这个插件模块，我们可以指定该属性值为 `true`，这样在编译完成后将删除对该插件模块的引用。

**Logging:** `BaseModuleWeaver` 类型中存在许多向 `MSBuild` 中写入日志的方法，例如 `WriteMessage`、`WriteDebug`、`WriteInfo`、`WriteWarning`、`WriteError`。

**关于异常处理:** 所编写的插件抛出异常需要注意以下几点。

+ 插件中引发的异常将被捕获并被认为是编译错误，所以如果出现异常将停止编译。
+ 异常日志将记录到 `MSBuild` 的 `BuildEngine.LogErrorEvent` 方法中。
+ 如果异常的类型是 `WeavingException` 将被解释为 `error`。所以当插件抛出该类型异常，目的应该是停止处理并将消息记录到生成日志中。在这种情况下，`WeavingException.Message` 属性的内容就是消息的内容。如果 `WeavingException.SequencePoint` 属性设置了值，则这个信息会传递到编译引擎，方便用户导航到具体的错误。
+ 如果异常的类型不是 `WeavingException`，这个异常消息会被解释为“未经处理的异常”，因此插件可能出现了非常严重的错误，这很可能是一个 `bug`。在这种情况下消息的内容将非常冗长，其包含了异常的全部内容。可以在 [ExceptionExtensions](https://github.com/Fody/Fody/blob/master/FodyCommon/ExceptionExtensions.cs) 看到异常消息处理的源代码。

