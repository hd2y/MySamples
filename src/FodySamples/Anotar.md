# <img src="./images/Anotar.png" height="28px"> Anotar

[![Gitter 聊天室](https://img.shields.io/gitter/room/fody/fody.svg)](https://gitter.im/Fody/Fody)

[Anotar](https://github.com/Fody/Anotar) 简化日志记录，直接使用静态类而无需创建 `ILogger` / `ILog` 等对象。

### 这是一个 [Fody](https://github.com/Fody/Home/) 插件

**It is expected that all developers using Fody either [become a Patron on OpenCollective](https://opencollective.com/fody/contribute/patron-3059), or have a [Tidelift Subscription](https://tidelift.com/subscription/pkg/nuget-fody?utm_source=nuget-fody&utm_medium=referral&utm_campaign=enterprise). [See Licensing/Patron FAQ](https://github.com/Fody/Home/blob/master/pages/licensing-patron-faq.md) for more information.**


## 支持的日志库

+ [Catel](http://www.catelproject.com/)
+ 自定义 (用于自定义的日志记录框架或包)
+ [CommonLogging](http://netcommon.sourceforge.net/)
+ [NLog](http://nlog-project.org/)
+ [NServiceBus](http://particular.net/nservicebus)
+ [Serilog](http://serilog.net/)
+ [Splat](https://github.com/paulcbetts/splat)


## 用途

查看 [Fody 用途](https://github.com/Fody/Home/blob/master/pages/usage.md)。

### NuGet 安装

安装 [Anotar.xxx.Fody NuGet 程序包](https://www.nuget.org/packages?q=anotar) 并更新 [Fody NuGet 程序包](https://nuget.org/packages/Fody/):

```powershell
PM> Install-Package Fody
PM> Install-Package Anotar.xxx.Fody
```

`Install-Package Fody` 命令必须执行，因为默认为旧版本并且很可能是有 `BUG` 的版本。

### 你的代码

```csharp
public class MyClass
{
    void MyMethod()
    {
        LogTo.Debug("TheMessage");
    }
}
```

### 编译后代码

#### 使用 Catel

```csharp
public class MyClass
{
    static ILog logger = LogManager.GetLogger(typeof(MyClass));

    void MyMethod()
    {
        logger.WriteWithData("Method: 'Void MyMethod()'. Line: ~12. TheMessage", null, LogEvent.Debug);
    }
}
```

#### 使用 CommonLogging

```csharp
public class MyClass
{
    static ILog logger = LoggerManager.GetLogger("MyClass");

    void MyMethod()
    {
        logger.Debug("Method: 'Void MyMethod()'. Line: ~12. TheMessage");
    }
}
```

#### 自定义

```csharp
public class MyClass
{
    static ILogger AnotarLogger = LoggerFactory.GetLogger<MyClass>();

    void MyMethod()
    {
        AnotarLogger.Debug("Method: 'Void MyMethod()'. Line: ~12. TheMessage");
    }
}
```

#### 使用 NLog

```csharp
public class MyClass
{
    static Logger logger = LogManager.GetLogger("MyClass");

    void MyMethod()
    {
        logger.Debug("Method: 'Void MyMethod()'. Line: ~12. TheMessage");
    }
}
```

#### 使用 NServiceBus

```csharp
public class MyClass
{
    static ILog logger = LogManager.GetLogger("MyClass");

    void MyMethod()
    {
        logger.DebugFormat("Method: 'Void MyMethod()'. Line: ~12. TheMessage");
    }
}
```

#### 使用 Serilog

```csharp
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

#### 使用 Splat

```csharp
public class MyClass
{
    static IFullLogger logger = ((ILogManager) Locator.Current.GetService(typeof(ILogManager), null))
                                .GetLogger(typeof(ClassWithLogging));

    void MyMethod()
    {
        logger.Debug("Method: 'Void MyMethod()'. Line: ~12. TheMessage");
    }
}
```

### 其他日志方法的重载

其还提供了适用于每个日志框架的警告、信息、错误等方法。

每个方法都提供了 `message`、`params`、`exception` 等参数的重载。


## 检查日志级别

`LogTo` 类型具有 `IsLevelEnabled` 用于确定每种日志框架各自的日志输出级别。

### 你的代码

```csharp
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

### 编译后的代码

```csharp
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


## 委托记录日志

`LogTo` 都提供了委托方法的重载，这些方法的参数为 `Func<string>` 而非 `string`。该委托用于需要构造的消息使用大量资源时使用。在编译时，日志记录的语句将被包装在 `IsEnabled` 检查中，以便仅在需要该级别的日志记录时才产生资源消耗。

### 你的代码

```csharp
public class MyClass
{
    void MyMethod()
    { 
        LogTo.Debug(()=>"TheMessage");
    }
}
```

### 编译后的代码

```csharp
public class MyClass
{
    static Logger logger = LogManager.GetLogger("MyClass");

    void MyMethod()
    {
        if (logger.IsDebugEnabled)
        {
            Func<string> messageConstructor = () => "TheMessage";
            logger.Debug("Method: 'Void DebugStringFunc()'. Line: ~58. " + messageConstructor());
        }
    }
}
```


## 记录异常

### 你的代码

```csharp
[LogToErrorOnException]
void MyMethod(string param1, int param2)
{
    //Do Stuff
}
```

### 编译后的代码

#### 使用 NLog

```csharp
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