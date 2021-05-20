## 执行

`run.cmd` 内容：

```text
dotnet msbuild -t:build,Copy,run ImportingSamples.csproj
```

请根据 `MSBuild` 文件路径进行修改，执行目的为编译 `HowToLib` 项目并将项目内容拷贝到当前运行程序集路径，编译后运行当前程序，为方法织入日志输出代码。

## 输出

```text
C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples>run.cmd

C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples>dotnet msbuild -t:build,Copy,run ImportingSamples.csproj
用于 .NET 的 Microsoft (R) 生成引擎版本 16.9.0+57a23d249
版权所有(C) Microsoft Corporation。保留所有权利。

  ImportingSamples -> C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples\bin\Debug\net5.0\ImportingSamples.dll
  用于 .NET 的 Microsoft (R) 生成引擎版本 16.9.0+57a23d249
  版权所有(C) Microsoft Corporation。保留所有权利。

    正在确定要还原的项目…
    所有项目均是最新的，无法还原。
    HowToLib -> C:\Code\GitHub\MySamples\src\CecilSamples\HowToLib\bin\Debug\netstandard2.0\HowToLib.dll

  已成功生成。
      0 个警告
      0 个错误

  已用时间 00:00:00.89
  ============ Start ============
  --> 注入日志输出代码完成！
  Mono.Cecil.AssemblyDefinition HowToLib.CecilHowTo::GetExecutingAssembly() Start.
  返回类型为: null
  ============ End ============

C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples>
```
