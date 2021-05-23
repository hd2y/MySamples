# 用途

使用 [NuGet](https://docs.microsoft.com/en-au/nuget/) 安装。有关更多信息，请阅读 [使用程序包管理器控制台](https://docs.microsoft.com/en-au/nuget/tools/package-manager-console) 。

`Fody` 分为两个部分:

1. [Fody 的 NuGet 软件包](https://www.nuget.org/packages/Fody/) 包含其核心的“引擎”。
2. 许多 [“插件”或“编织工具”](https://github.com/Fody/Home/blob/master/pages/usage.md#addins-list) 均由它们自己的 NuGet 软件包提供。

## 安装 Fody

 由于 NuGet 经常默认会使用可能有很多问题的旧版本，所以在安装编织工具后使用 [NuGet 安装](https://docs.microsoft.com/en-us/nuget/tools/ps-ref-install-package) 最新版本的 `Fody` 是很有必要的。

```text
Install-Package Fody
```

在 [Libraries.io](https://libraries.io/) 上 [订阅 Fody](https://libraries.io/nuget/Fody) 可以获取 `Fody` 发布的通知。

## 添加 NuGet 包

在项目中 [安装](https://docs.microsoft.com/en-us/nuget/tools/ps-ref-install-package) 包:

```text
Install-Package WeaverName.Fody
```

例如:

```text
Install-Package Virtuosity.Fody
```

## 将 `Fody` 添加到生成 `NuGet` 包的项目中

将 `Fody` 添加到生成 `NuGet` 包的项目中时，产生的包将依赖于 `Fody`。如果生成 `.nupkg` 文件时依赖项需要被移除，然后在项目的 `.csproj` 文件将:

```xml
<PackageReference Include="Fody" Version="xxx" />
```

替换为:

```xml
<PackageReference Include="Fody" Version="xxx" >
  <PrivateAssets>all</PrivateAssets>
</PackageReference>
```

## 添加 `FodyWeavers.xml`

为了指定运行的编织工具以及在项目中的顺序，需要在项目文件同级目录下使用一个 `FodyWeavers.xml` 文件。需要手动添加，它采用以下形式:

```xml
<Weavers>
  <WeaverName/>
</Weavers>
```

例如:

```xml
<Weavers>
  <Virtuosity/>
</Weavers>
```

有关的其他配置项，请参见 [配置](./Configuration.md) 。