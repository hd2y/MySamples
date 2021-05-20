## <img src="./images/AsyncErrorHandler.png" height="28px"> AsyncErrorHandler

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
