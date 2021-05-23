# 配置

## 配置编织工具

`Fody` 必须一个 `XML` 配置文件，该配置列出所有项目中的使用的编织工具。

+ 配置文件指定应该在项目中使用的编织工具的列表。
+ 编织工具以配置文件中的顺序被应用于项目。
+ 编织工具也可以在这里配置。请参阅每个编织工具的文档，以了解其可以配置的选项。

配置文件格式为:

```xml
<Weavers>
  <WeaverA />
  <WeaverB ConfigForWeaverB="Value" />
</Weavers>
```

在配置文件中 `<Weavers>` 节点必须被指定，并且支持以下属性:

+ `VerifyAssembly`: 设置为 `true` 会运行 `PEVerify` 检查编译结果。详情可以查看 [验证程序集](https://github.com/Fody/Home/blob/master/pages/configuration.md#assembly-verification) 。
+ `VerifyIgnoreCodes`: 逗号分隔的错误代码列表，在程序集验证期间会忽略这些错误代码。详情可以查看 [验证程序集](https://github.com/Fody/Home/blob/master/pages/configuration.md#assembly-verification) 。
+ `GenerateXsd`: 设置为 `false` 可禁止 `FodyWeavers.xsd` 文件的生成，该文件为 `FodyWeavers.xml` 提供了 [IntelliSense](https://docs.microsoft.com/en-us/visualstudio/ide/using-intellisense) 支持。这将覆盖 `FodyGenerateXsd` 的 `MSBuild` 属性。

`<Weavers>` 下的节点内容是所有编织工具的列表。节点的名称与编织工具的名称一一对应。

### 配置选项

有以下几种方法可以指定配置:

**在每个项目文件夹下的文件**

默认是在每个项目文件夹下使用一个名为 `FodyWeavers.xml` 的配置文件。

+ 假如这个配置文件不存在并且没有其他配置文件，当项目第一次被编译时这个默认文件会被自动创建。
+ 一个描述 `XML` 文档结构的文件会同时被创建，用于支持当编辑 `FodyWeavers.xml` 时支持 [IntelliSense](https://docs.microsoft.com/en-us/visualstudio/ide/using-intellisense) 功能。
+ 文件中指定的项目不能包含没有被安装的编织工具。然而如果这是一个备用的配置文件，那么这些配置会被忽略。

**在项目文件中配置一个 `MSBuild` 属性**

另外一种方式是在项目文件中添加名为 `WeaverConfiguration` 的属性:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    ...
    <SomeProperty>Some Value</SomeProperty>
    <WeaverConfiguration>
      <Weavers>
        <WeaverA />
        <WeaverB ConfigForWeaverB="$(SomeProperty)" />
      </Weavers>
    </WeaverConfiguration>
  </PropertyGroup>
  ...
</Project>
```

这个属性的内容如上所示。

+ 这样配置的优先级最高，这个配置会覆盖其他的配置文件。
+ 会使用 `MSBuild` 功能动态控制项目编译的过程。
+ 可以定义一个例如名为 `Directory.build.props` 的文件，在多个项目上共享相同的配置。
+ 为了支持在多个项目之间共享配置，将忽略未为特定项目安装的编织工具，配置项是编织工具的超集。
+ 如果这样配置，[IntelliSense](https://docs.microsoft.com/en-us/visualstudio/ide/using-intellisense) 会无法使用。

**一个在解决方案文件夹中的文件**

通过在解决方案目录下创建一个名为 `FodyWeavers.xml` 的配置文件，可以让解决方案中所有的项目间共享一个配置文件。

+ 如果这样配置，[IntelliSense](https://docs.microsoft.com/en-us/visualstudio/ide/using-intellisense) 会无法使用。
+ 配置文件中没有被项目安装的编织工具将会被忽略，所以配置文件中的配置项其实是在全部项目中需要安装编织工具的超集。
+ 这些配置项的优先级最低，将会被其他配置项覆写。


## 合并配置

当提供多种配置时，优先级较低的配置文件会决定编织工具的执行顺序，而优先级较高的配置文件会覆盖这些节点的内容。

例如以下配置项:

解决方案文件夹中的 `FodyWeavers.xml` 配置文件:

```xml
<Weavers>
  <WeaverA />
  <WeaverB />
</Weavers>
```

---

项目文件夹中的 `FodyWeavers.xml` 配置文件:

```xml
<Weavers>
  <WeaverC />
  <WeaverB Property1="B1" />
  <WeaverA Property1="A1" Property2="A2" />
</Weavers>
```

---

项目文件中的 `WeaverConfiguration` 属性:

```xml
<WeaverConfiguration Condition="'$(Configuration)' == 'Debug'">
  <Weavers>
    <WeaverC Property1="C1" />
    <WeaverA Property3="A3" />
  </Weavers>
</WeaverConfiguration>
```

---

以下将是调试模式下最终有效的配置内容:

```xml
<Weavers>
  <WeaverA Property1="A1" Property2="A2" />
  <WeaverB Property1="B1" />
  <WeaverC />
</Weavers>
```

而非调试模式编译配置内容如下:

```xml
<Weavers>
  <WeaverA Property3="A3" />
  <WeaverB Property1="B1" />
  <WeaverC Property1="C1" />
</Weavers>
```

要验证哪个配置处于活动状态，请在配置源中将日志输出级别设置为“详细”。


## 控制 `Fody` 的行为

要达到控制 `Fody` 行为的目的可以通过在项目中定义一个名为 `FodyDependsOnTargets` 的属性组。 然后，此属性的内容将传递到 `Fody` 编织任务的 `DependsOnTargets`。

> DependsOnTargets: 必须先执行这些 `FodyDependsOnTargets` 才能执行这个 `DependsOnTargets`，否则可能会发生顶级依赖项分析冲突，多个 `Target` 之间要用分号分隔。

下面是一个强制指定 `Fody` 在 [CodeContracts](https://docs.microsoft.com/en-us/dotnet/framework/debug-trace-profile/code-contracts) 之后运行的例子。

```xml
<PropertyGroup>
  <FodyDependsOnTargets>
    CodeContractRewrite
  </FodyDependsOnTargets>
</PropertyGroup>
```


## 程序集验证

支持通过 [PeVerify](https://docs.microsoft.com/en-us/dotnet/framework/tools/peverify-exe-peverify-tool) 执行编译结果验证。

可以通过以下内容启用:

在配置文件 `FodyWeavers.xml` 中添加 `VerifyAssembly="true"`:

```xml
<Weavers VerifyAssembly="true">
  <Anotar.Custom />
</Weavers>
```

添加一个值为 `FodyVerifyAssembly` 的编译常量，可以使用 `VerifyIgnoreCodes` 将忽略代码发送到 `PeVerify`。

```xml
<Weavers VerifyAssembly="true"
         VerifyIgnoreCodes="0x80131869">
  <Anotar.Custom />
</Weavers>
```


> 参考:
> + `Target` @ MSDN: https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-targets
> + `IntelliSense` @ MSDN: https://docs.microsoft.com/en-us/visualstudio/ide/using-intellisense