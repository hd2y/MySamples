# 插件发现

每个编制工具必须在编译时将其二进制文件的位置 (`WaverName.Fody.dll`) 作为 `MSBuild` 项发布，以便 `Fody` 能够找到它。

这是通过为 `.props` 文件提供具有以下默认内容的 `NuGet` 包来实现的:

```xml
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <ItemGroup>
    <WeaverFiles Include="$(MsBuildThisFileDirectory)..\weaver\$(MSBuildThisFileName).dll" />
  </ItemGroup>
</Project>
```

如果使用 [FodyPackaging NuGet](https://github.com/Fody/Home/blob/master/pages/addin-packaging.md#FodyPackaging-NuGet-Package) 创建插件工具包，则会自动添加此文件。

然而根据需求可能需要自定义依赖文件，重要的是需要提供一个名为 `WeaverFiles` 项，该项指向编译链中编织工具程序集的位置在何处。

例如，要替换旧的 `SolutionDir / Tool` 或约定 [在解决方案中编织](https://github.com/Fody/Home/blob/master/pages/in-solution-weaving.md)，请将 `WeaverFiles` 项添加到需要使用它的所有项目中:

```
<ItemGroup>
  <WeaverFiles
    Include="$(SolutionDir)SampleWeaver.Fody\bin\$(Configuration)\netstandard2.0\SampleWeaver.Fody.dll" />
</ItemGroup>
```

## 旧版策略

旧版策略已经在 `Fody` 的 `4.0` 及以上版本中不受支持。

使用目录搜索找到 `FodyWeavers.xml` 文件中列出的但 `WeaverFiles` `MSBuild` 项中没有显示的旧版编织工具。

旧版编织工具会在以下目录中检索:

+ `NuGet` 包文件夹
+ `SolutionDir / Tools`
+ 解决方案中名为 `Weavers` 的项目，详情查看 [在解决方案中编织](https://github.com/Fody/Home/blob/master/pages/in-solution-weaving.md)

仅使用找到的每个编织工具中最新版的程序集 (由 `Assembly.Version` 定义)。

由于这可能会导致随机结果，具体取决于文件夹的实际内容，请避免使用此类旧版编织工具，建议使用者更新编织工具到新版。
