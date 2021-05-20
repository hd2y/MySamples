## <img src="./images/AutoProperties.png" height="28px"> AutoProperties

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

