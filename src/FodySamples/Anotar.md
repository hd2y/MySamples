## <img src="./images/Anotar.png" height="28px"> Anotar

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