# 插件列表

+ [Anotar](https://github.com/Fody/Anotar) 通过静态类和一些 `IL` 代码的修改简化了日志记录。
+ [AsyncErrorHandler](https://github.com/Fody/AsyncErrorHandler) 将异常处理集成到异步和 [TPL](https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-parallel-library-tpl) 代码中。
+ [AutoProperties](https://github.com/tom-englert/AutoProperties.Fody) 扩展对自动属性的控制，例如直接访问后备字段或拦截 `getter` 和 `setter` 方法。
+ [BasicFodyAddin](https://github.com/Fody/Home/blob/master/BasicFodyAddin) 用于说明如何构建插件。
+ [Caseless](https://github.com/Fody/Caseless) 将字符串比较更改为不区分大小写。
+ [Catel](https://github.com/Catel/Catel.Fody) 用于将自动属性转换为 [Catel](https://github.com/Catel/Catel) 属性。
+ [ConfigureAwait](https://github.com/Fody/ConfigureAwait) 设置全局的 `async` 方法 `ConfigureAwait` 的 `await` 调用。
+ [Costura](https://github.com/Fody/Costura/) 将引用嵌入到资源文件。
+ [EmptyConstructor](https://github.com/Fody/EmptyConstructor) 即使定义了一个非空的构造函数，也将一个空的构造函数添加到类中。
+ [Equals](https://github.com/Fody/Equals) 使用属性生成 `Equals`、`GetHashCode` 和运算符方法。
+ [Equatable](https://github.com/tom-englert/Equatable.Fody) 从显式特性指定的字段和属性生成 `Equals`，`GetHashCode` 和运算符方法。
+ [ExtraConstraints](https://github.com/Fody/ExtraConstraints) 便于为类型或方法的泛型参数添加枚举或委托约束。
+ [InfoOf](https://github.com/Fody/InfoOf) 提供等效于 `typeof` 的 `methodof`、`propertyof` 和 `fieldof`。
+ [InlineIL](https://github.com/ltrzesniewski/InlineIL.Fody) 提供一种在现有代码中嵌入任意 `IL` 指令的方法。
+ [Ionad](https://github.com/Fody/Ionad) 替换静态方法调用。
+ [Janitor](https://github.com/Fody/Janitor) 简化 [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable) 的实现。
+ [JetBrainsAnnotations](https://github.com/tom-englert/JetBrainsAnnotations.Fody) 将所有 `JetBrains ReSharper` 代码注释属性转换为 [外部注释](https://www.jetbrains.com/help/resharper/Code_Analysis__External_Annotations.html#how_it_works)。
+ [Lazy](https://github.com/tom-englert/Lazy.Fody) 使 `System.Lazy` 的过程自动化。
+ [LoadAssembliesOnStartup](https://github.com/Fody/LoadAssembliesOnStartup) 使用模块初始化程序中的类型在启动时加载引用。
+ [LocalsInit](https://github.com/ltrzesniewski/LocalsInit.Fody) 控制方法上的 `localsinit` 标志的值，以提高例如 `stackalloc` 的性能。
+ [LoggerIsEnabled](https://github.com/wazowsk1/LoggerIsEnabled.Fody) 在 `Microsoft.Extensions.Logging` 的日志记录语句前添加 [ILogger.IsEnabled](https://github.com/aspnet/Logging) 检查。
+ [MethodBoundaryAspect](https://github.com/vescon/MethodBoundaryAspect.Fody) 允许装饰方法并在方法的开始、结束以及异常时添加钩子 (就像 `PostSharp` 组件一样)。
+ [MethodCache](https://github.com/SpatialFocus/MethodCache.Fody/) 缓存 `[Cache]` 特性修饰的方法的返回值。 与 `.NET` 的扩展 `IMemoryCache` 接口集成。
+ [MethodDecorator](https://github.com/Fody/MethodDecorator) 装饰任意方法以在被调用前和调用后运行代码。
+ [MethodTimer](https://github.com/Fody/MethodTimer) 注入方法计时的代码。
+ [ModuleInit](https://github.com/Fody/ModuleInit) 在程序集中添加一个模块初始化器。
+ [NullGuard](https://github.com/Fody/NullGuard) 向程序集添加空参数检查。
+ [Obsolete](https://github.com/Fody/Obsolete) 帮助保持 `ObsoleteAttribute` 的用法是一致的。
+ [PropertyChanged](https://github.com/Fody/PropertyChanged) 在属性中注入 `INotifyPropertyChanged` 代码。
+ [PropertyChanging](https://github.com/Fody/PropertyChanging) 在属性中注入 `INotifyPropertyChanging` 代码。
+ [Publicize](https://github.com/Fody/Publicize) 将非公共成员转换为公共的隐藏成员。
+ [ReactiveUI.Fody](https://github.com/reactiveui/ReactiveUI) 为 [ReactiveUI](https://reactiveui.net/) 的属性和 `OAPH` 生成 `RaisePropertyChanged` 通知。
+ [Resourcer](https://github.com/Fody/Resourcer) 简化了从程序集中读取嵌入式资源的过程。
+ [RuntimeNullables](https://github.com/Singulink/RuntimeNullables) `C#` `8.0+` 运行时可空引用类型 (NRT) 约定验证。
+ [SplashScreen](https://github.com/tom-englert/SplashScreen.Fody) 使 `WPF` 控件作为 `WPF` 初始画面而非静态位图。
+ [StampSvn](https://github.com/krk/Stamp) 标记程序集使用 `SVN` 的数据。
+ [Substitute](https://github.com/tom-englert/Substitute.Fody) 用其他类型替换指定类型，例如拦截代码生成。
+ [SwallowExceptions](https://github.com/duaneedwards/SwallowExceptions) 在目标方法中吞下抛出的异常。
+ [Throttle](https://github.com/tom-englert/Throttle.Fody) 使用最少的代码限制方法的调用阈值。
+ [ToString](https://github.com/Fody/ToString) 使用公共属性生成 `ToString` 方法。
+ [Tracer](https://github.com/csnemes/tracer) 为选定的方法的调用和离开添加跟踪日志记录。
+ [Undisposed](https://github.com/ermshiperete/undisposed-fody) 跟踪未完成释放对象的调试工具。
+ [Validar](https://github.com/Fody/Validar) 在编译时将 `IDataErrorInfo` 或 `INotifyDataErrorInfo` 代码注入到类中。
+ [Vandelay](https://github.com/jasonwoods-7/Vandelay) 简化 `MEF` 的导入与导出。
+ [Visualize](https://github.com/Fody/Visualize) 添加调试特性帮助可视化对象。
+ [Virtuosity](https://github.com/Fody/Virtuosity) 所有成员更改为 `virtual`。
+ [WeakEventHandler](https://github.com/tom-englert/WeakEventHandler.Fody) 通过在源和订阅者之间编织一个弱事件适配器，将常规事件处理程序更改为弱事件处理程序。
+ [WeakEvents](https://github.com/adbancroft/WeakEvents.Fody) 通过在编译时进行代码编织以及使用支持的运行时库自动发布弱事件。
+ [With](https://github.com/mikhailshilkov/With.Fody) 一个用于返回修改了一个属性的不可变对象副本的方法。

