# Fody

在编译过程中向程序集织入 IL 代码，以实现特定功能。

## ⚙ Anotar

[Anotar](https://github.com/Fody/Anotar) 简化日志记录，直接使用静态类而无需创建 `ILogger` / `ILog` 等对象。

### 💖 直接使用 `LogTo` 静态类的方法记录日志

*你的代码:*

```cs
public class MyClass
{
    void MyMethod()
    {
        LogTo.Debug("TheMessage");
    }
}
```

*编译后的代码:*

```cs
// NLog
public class MyClass
{
    static Logger logger = LogManager.GetLogger("MyClass");

    void MyMethod()
    {
        logger.Debug("Method: 'Void MyMethod()'. Line: ~12. TheMessage");
    }
}

// Serilog
public class MyClass
{
    static ILogger logger = Log.ForContext<MyClass>();

    void MyMethod()
    {
        if (logger.IsEnabled(LogEventLevel.Debug))
        {
            logger
                .ForContext("MethodName", "Void MyMethod()")
                .ForContext("LineNumber", 8)
                .Debug("TheMessage");
        }
    }
}
```

> 支持的日志组件：Catel、CommonLogging、NLog、NServiceBus、Serilog、Splat、自定义

### 💖 检查日志级别

`LogTo` 有 `IsLevelEnabled` 可以使用当前日志框架的方案检测日志输出级别。

*你的代码:*

```cs
public class MyClass
{
    void MyMethod()
    { 
        if (LogTo.IsDebugEnabled)
        {
            LogTo.Debug("TheMessage");
        }
    }
}
```

*编译后的代码:*

```cs
public class MyClass
{
    static Logger logger = LogManager.GetLogger("MyClass");

    void MyMethod()
    {
        if (logger.IsDebugEnabled)
        {
            logger.Debug("Method: 'Void MyMethod()'. Line: ~12. TheMessage");
        }
    }
}
```

> 如果输出日志字符串信息会占用大量资源，建议使用 `IsLevelEnabled` 进行检查，简化写法可以使用 `委托` 记录日志，例如 `LogTo.Debug(()=>"TheMessage");`，编译后代码将自动添加 `IsLevelEnabled` 检查。

### 💖 异常日志记录

*你的代码:*

```cs
[LogToErrorOnException]
void MyMethod(string param1, int param2)
{
    //Do Stuff
}
```

*编译后的代码:*

```cs
void MyMethod(string param1, int param2)
{
    try
    {
        //Do Stuff
    }
    catch (Exception exception)
    {
        if (logger.IsErrorEnabled)
        {
            var message = string.Format("Exception occurred in SimpleClass.MyMethod. param1 '{0}', param2 '{1}'", param1, param2);
            logger.ErrorException(message, exception);
        }
        throw;
    }
}
```

> 如果不需要额外信息(方法名称与行号)，可以在 `AssemblyInfo.cs` 中设定 `[assembly: LogMinimalMessage]`。


### 💖 自定义日志记录工具

如果所使用的日志组件不是以上所提供的 `NLog`、`Serilog` 等，可以自行进行实现。

首先需要定义一个日志工厂类 `LoggerFactory`，其提供一个静态方法 `GetLogger`:

```cs
public class LoggerFactory
{
    public static Logger GetLogger<T>()
    {
        return new Logger();
    }
}
```

所返回构造的 `Logger` 实例是负责进行日志记录的类型，其可以实现下列方法：

```cs
public class Logger
{
    public void Trace(string message){}
    public void Trace(string format, params object[] args){}
    public void Trace(Exception exception, string format, params object[] args){}
    public bool IsTraceEnabled { get; private set; }
    public void Debug(string message){}
    public void Debug(string format, params object[] args){}
    public void Debug(Exception exception, string format, params object[] args){}
    public bool IsDebugEnabled { get; private set; }
    public void Information(string message){}
    public void Information(string format, params object[] args){}
    public void Information(Exception exception, string format, params object[] args){}
    public bool IsInformationEnabled { get; private set; }
    public void Warning(string message){}
    public void Warning(string format, params object[] args){}
    public void Warning(Exception exception, string format, params object[] args){}
    public bool IsWarningEnabled { get; private set; }
    public void Error(string message){}
    public void Error(string format, params object[] args){}
    public void Error(Exception exception, string format, params object[] args){}
    public bool IsErrorEnabled { get; private set; }
    public void Fatal(string message){}
    public void Fatal(string format, params object[] args){}
    public void Fatal(Exception exception, string format, params object[] args){}
    public bool IsFatalEnabled { get; private set; }
}
```

**注意:** 以上方法可以选择需要使用的进行实现，如果没有实现不能调用，否则构建项目可能会出现错误。


## ⚙ AsyncErrorHandler

[AsyncErrorHandler](https://github.com/Fody/AsyncErrorHandler) 可以将异常处理代码植入到异步程序中，从而统一进行处理。

### 💖 异步方法异常拦截与处理

*你的代码:*

```cs
public class DataStorage
{
    public async Task WriteFile(string key, object value)
    {
        var jsonValue = JsonConvert.SerializeObject(value);
        using (var file = await folder.OpenStreamForWriteAsync(key, CreationCollisionOption.ReplaceExisting))
        using (var stream = new StreamWriter(file))
            await stream.WriteAsync(jsonValue);
    }
}
```

*编译后的代码:*

```cs
public class DataStorage
{
    public async Task WriteFile(string key, object value)
    {
        try 
        {
            var jsonValue = JsonConvert.SerializeObject(value);
            using (var file = await folder.OpenStreamForWriteAsync(key, CreationCollisionOption.ReplaceExisting))
            using (var stream = new StreamWriter(file))
                await stream.WriteAsync(jsonValue);
        }
        catch (Exception exception)
        {
            AsyncErrorHandler.HandleException(exception);
        } 
    }
}
```

然后你的程序中可以提供自己实现的错误处理模块：

```cs
public static class AsyncErrorHandler
{
    public static void HandleException(Exception exception)
    {
        Debug.WriteLine(exception);
    }
}
```

这使您可以在运行时拦截异常。

## ⚙ AutoProperties

[AutoProperties](https://github.com/tom-englert/AutoProperties.Fody) 用于扩展对于自动属性的控制，可以访问自动属性编译后的备用字段，或用于拦截属性的 `getter` 与 `setter` 方法。

### 💖 拦截自动属性的 `getter` 与 `setter`

例如属性信息来自配置:

```cs
public class MyConfiguration
{
    public string Value1
    {
        get => ConfigurationManager.AppSettings[nameof(Value1)];
        set => ConfigurationManager.AppSettings[nameof(Value1)] = value;
    }
    public string Value2
    {
        get => ConfigurationManager.AppSettings[nameof(Value2)];
        set => ConfigurationManager.AppSettings[nameof(Value2)] = value;
    }
}
```

可以使用以下代码重写:

```cs
public class MyConfiguration
{
    [GetInterceptor]
    private object GetValue(string name) => ConfigurationManager.AppSettings[name];
    [SetInterceptor]
    private void SetValue(string name, object value) => ConfigurationManager.AppSettings[name] = value?.ToString();

    public string Value1 { get; set; }
    public string Value2 { get; set; }
}
```

### 💖 拦截自动属性编译后的备用字段

通常情况是不需要访问自动属性的备用字段的，但是使用 `Fody.PropertyChanged` 插件以后这种情况就发生了变化。

例如以下代码调用 `new Derived(new List<string>())` 将出现 `NullReferenceException` 异常:

> 类型 `Derived` 初始化会先初始化父类 `Class`，调用了父类的构造函数为属性 `Property1`、`Property2` 赋值，然而因为重写了 `OnPropertyChanged` 方法，赋值时还会向 `_changes` 添加内容，但是此时 `_changes` 还没赋值，所以会抛出 `NullReferenceException` 异常。 

```cs
public class Class : ObservableObject
{
    public Class(string property1, string property2)
    {
        Property1 = property1;
        Property2 = property2;
    }

    public string Property1 { get; set; }
    public string Property2 { get; set; }
}

public class Derived : Class
{
    private readonly IList<string> _changes;

    public Derived(IList<string> changes)
        : base("Test1", "Test2")
    {
        if (changes == null)
            throw new ArgumentNullException(nameof(changes));

        _changes = changes;
    }

    protected override void OnPropertyChanged(string propertyName)
    {
        _changes.Add(propertyName);

        base.OnPropertyChanged(propertyName);
    }
}
```

通常 `MVVM` 架构下的 `ViewModel` 不使用自动属性，而应该使用字段加属性，在属性的 `setter` 方法中触发 `PropertyChanged` 进行通知。

但是使用 `Fody.PropertyChanged` 插件以后，就可以在使用自动属性，其会自动帮我们注入 `PropertyChanged`。

但是例如以上代码希望在构造函数中不是为属性赋值，不希望触发 `PropertyChanged`，就需要使用 `AutoProperties` 插件辅助完成。

可以通过两种方式来避免这个问题，第一是使用 `SetBackingField` 方法，如果想要全局为某一个类型或某个程序集设置，可以使用 `BypassAutoPropertySettersInConstructors` 特性(绕过构造函数中自动属性设置，在构造函数中将直接为构造函数的备用字段赋值)。

详细的说明 [点此](https://github.com/tom-englert/AutoProperties.Fody/blob/master/BackingFieldAccess.md) 阅读了解如何使用。


## BasicFodyAddin

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

> 注意：如果无法正常编译，错误与 `Mono Cecil` 有关，尝试 nuget 引用最新的 `Fody` 即可。

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