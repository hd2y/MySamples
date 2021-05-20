## 执行

`run.cmd` 内容：

```text
dotnet run
```

如果想要查看完整构建与执行过程，请使用如下命令：

```text
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe" -t:Build,Copy,Run
```

请根据 `MSBuild` 文件路径进行修改，执行目的为编译 `HowToLib` 项目并将项目内容拷贝到当前运行程序集路径，编译后运行当前程序，为方法织入日志输出代码。

## 输出

```text
C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples>run.cmd

C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples>dotnet run
============ Start ============
--> 注入日志输出代码完成！
Mono.Cecil.AssemblyDefinition HowToLib.CecilHowTo::GetExecutingAssembly() Start.
返回类型为: null
============ End ============

C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples>
```
