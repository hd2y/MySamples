## 执行

`run.cmd` 内容：

```text
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe" -t:build,Copy,run ImportingSamples.csproj
```

请根据 `MSBuild` 文件路径进行修改，执行目的为编译 `HowToLib` 项目并将项目内容拷贝到当前运行程序集路径，编译后运行当前程序，为方法织入日志输出代码。

## 输出

```text
C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples>run.cmd

C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples>"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe" -t:build,Copy,run ImportingSamples.csproj
用于 .NET Framework 的 Microsoft (R) 生成引擎版本 16.9.0+5e4b48a27
版权所有(C) Microsoft Corporation。保留所有权利。

生成启动时间为 2021/5/20 8:51:31。
项目“C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples\ImportingSamples.csproj”在节点 1 上(build;Copy;run 个 目标)。
GenerateTargetFrameworkMonikerAttribute:
正在跳过目标“GenerateTargetFrameworkMonikerAttribute”，因为所有输出文件相对于输入文件而言都是最新的。
CoreGenerateAssemblyInfo:
正在跳过目标“CoreGenerateAssemblyInfo”，因为所有输出文件相对于输入文件而言都是最新的。
CoreCompile:
  C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\Roslyn\csc.exe /noconfig /unsafe-
  /checked- /nowarn:1701,1702,1701,1702 /fullpaths /nostdlib+ /errorreport:prompt /warn:5 /define:TRACE;DEBUG;NET;NET5_
  0;NETCOREAPP;NET5_0_OR_GREATER;NETCOREAPP1_0_OR_GREATER;NETCOREAPP1_1_OR_GREATER;NETCOREAPP2_0_OR_GREATER;NETCOREAPP2
  _1_OR_GREATER;NETCOREAPP2_2_OR_GREATER;NETCOREAPP3_0_OR_GREATER;NETCOREAPP3_1_OR_GREATER /highentropyva+ /reference:"
  C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\Microsoft.CSharp.dll" /reference:"C:\Program
   Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\Microsoft.VisualBasic.Core.dll" /reference:"C:\Program
   Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\Microsoft.VisualBasic.dll" /reference:"C:\Program File
  s\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\Microsoft.Win32.Primitives.dll" /reference:C:\Users\hd2y\.n
  uget\packages\mono.cecil\0.11.3\lib\netstandard2.0\Mono.Cecil.dll /reference:C:\Users\hd2y\.nuget\packages\mono.cecil
  \0.11.3\lib\netstandard2.0\Mono.Cecil.Mdb.dll /reference:C:\Users\hd2y\.nuget\packages\mono.cecil\0.11.3\lib\netstand
  ard2.0\Mono.Cecil.Pdb.dll /reference:C:\Users\hd2y\.nuget\packages\mono.cecil\0.11.3\lib\netstandard2.0\Mono.Cecil.Ro
  cks.dll /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\mscorlib.dll" /reference
  :"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\netstandard.dll" /reference:"C:\Program Fi
  les\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.AppContext.dll" /reference:"C:\Program Files\dotne
  t\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Buffers.dll" /reference:"C:\Program Files\dotnet\packs\Micr
  osoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Collections.Concurrent.dll" /reference:"C:\Program Files\dotnet\packs\M
  icrosoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Collections.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft
  .NETCore.App.Ref\5.0.0\ref\net5.0\System.Collections.Immutable.dll" /reference:"C:\Program Files\dotnet\packs\Microso
  ft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Collections.NonGeneric.dll" /reference:"C:\Program Files\dotnet\packs\Micr
  osoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Collections.Specialized.dll" /reference:"C:\Program Files\dotnet\packs\
  Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.ComponentModel.Annotations.dll" /reference:"C:\Program Files\dotnet
  \packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.ComponentModel.DataAnnotations.dll" /reference:"C:\Program F
  iles\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.ComponentModel.dll" /reference:"C:\Program Files\
  dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.ComponentModel.EventBasedAsync.dll" /reference:"C:\Pro
  gram Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.ComponentModel.Primitives.dll" /reference:"
  C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.ComponentModel.TypeConverter.dll" /re
  ference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Configuration.dll" /referenc
  e:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Console.dll" /reference:"C:\Progra
  m Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Core.dll" /reference:"C:\Program Files\dotnet\
  packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Data.Common.dll" /reference:"C:\Program Files\dotnet\packs\Mi
  crosoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Data.DataSetExtensions.dll" /reference:"C:\Program Files\dotnet\packs
  \Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Data.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETC
  ore.App.Ref\5.0.0\ref\net5.0\System.Diagnostics.Contracts.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NE
  TCore.App.Ref\5.0.0\ref\net5.0\System.Diagnostics.Debug.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETC
  ore.App.Ref\5.0.0\ref\net5.0\System.Diagnostics.DiagnosticSource.dll" /reference:"C:\Program Files\dotnet\packs\Micro
  soft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Diagnostics.FileVersionInfo.dll" /reference:"C:\Program Files\dotnet\pac
  ks\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Diagnostics.Process.dll" /reference:"C:\Program Files\dotnet\pac
  ks\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Diagnostics.StackTrace.dll" /reference:"C:\Program Files\dotnet\
  packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Diagnostics.TextWriterTraceListener.dll" /reference:"C:\Progr
  am Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Diagnostics.Tools.dll" /reference:"C:\Program
   Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Diagnostics.TraceSource.dll" /reference:"C:\Pro
  gram Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Diagnostics.Tracing.dll" /reference:"C:\Pro
  gram Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.dll" /reference:"C:\Program Files\dotnet\pa
  cks\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Drawing.dll" /reference:"C:\Program Files\dotnet\packs\Microsof
  t.NETCore.App.Ref\5.0.0\ref\net5.0\System.Drawing.Primitives.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft
  .NETCore.App.Ref\5.0.0\ref\net5.0\System.Dynamic.Runtime.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NET
  Core.App.Ref\5.0.0\ref\net5.0\System.Formats.Asn1.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.Ap
  p.Ref\5.0.0\ref\net5.0\System.Globalization.Calendars.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCor
  e.App.Ref\5.0.0\ref\net5.0\System.Globalization.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.
  Ref\5.0.0\ref\net5.0\System.Globalization.Extensions.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore
  .App.Ref\5.0.0\ref\net5.0\System.IO.Compression.Brotli.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCo
  re.App.Ref\5.0.0\ref\net5.0\System.IO.Compression.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.Ap
  p.Ref\5.0.0\ref\net5.0\System.IO.Compression.FileSystem.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETC
  ore.App.Ref\5.0.0\ref\net5.0\System.IO.Compression.ZipFile.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.N
  ETCore.App.Ref\5.0.0\ref\net5.0\System.IO.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.
  0.0\ref\net5.0\System.IO.FileSystem.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\re
  f\net5.0\System.IO.FileSystem.DriveInfo.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.
  0\ref\net5.0\System.IO.FileSystem.Primitives.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref
  \5.0.0\ref\net5.0\System.IO.FileSystem.Watcher.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.R
  ef\5.0.0\ref\net5.0\System.IO.IsolatedStorage.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Re
  f\5.0.0\ref\net5.0\System.IO.MemoryMappedFiles.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.R
  ef\5.0.0\ref\net5.0\System.IO.Pipes.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\re
  f\net5.0\System.IO.UnmanagedMemoryStream.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0
  .0\ref\net5.0\System.Linq.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\S
  ystem.Linq.Expressions.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\Syst
  em.Linq.Parallel.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Lin
  q.Queryable.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Memory.d
  ll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Net.dll" /reference:"
  C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Net.Http.dll" /reference:"C:\Program
  Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Net.Http.Json.dll" /reference:"C:\Program Files\
  dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Net.HttpListener.dll" /reference:"C:\Program Files\dot
  net\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Net.Mail.dll" /reference:"C:\Program Files\dotnet\packs\M
  icrosoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Net.NameResolution.dll" /reference:"C:\Program Files\dotnet\packs\Mi
  crosoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Net.NetworkInformation.dll" /reference:"C:\Program Files\dotnet\packs
  \Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Net.Ping.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.
  NETCore.App.Ref\5.0.0\ref\net5.0\System.Net.Primitives.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCo
  re.App.Ref\5.0.0\ref\net5.0\System.Net.Requests.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.
  Ref\5.0.0\ref\net5.0\System.Net.Security.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0
  .0\ref\net5.0\System.Net.ServicePoint.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\
  ref\net5.0\System.Net.Sockets.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5
  .0\System.Net.WebClient.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\Sys
  tem.Net.WebHeaderCollection.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0
  \System.Net.WebProxy.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System
  .Net.WebSockets.Client.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\Syst
  em.Net.WebSockets.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Nu
  merics.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Numerics.Vect
  ors.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.ObjectModel.dll"
   /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Reflection.DispatchProxy
  .dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Reflection.dll" /re
  ference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Reflection.Emit.dll" /refere
  nce:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Reflection.Emit.ILGeneration.dll
  " /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Reflection.Emit.Lightwe
  ight.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Reflection.Exte
  nsions.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Reflection.Me
  tadata.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Reflection.Pr
  imitives.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Reflection.
  TypeExtensions.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Resou
  rces.Reader.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Resource
  s.ResourceManager.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Re
  sources.Writer.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Runti
  me.CompilerServices.Unsafe.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\
  System.Runtime.CompilerServices.VisualC.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.
  0\ref\net5.0\System.Runtime.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0
  \System.Runtime.Extensions.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\
  System.Runtime.Handles.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\Syst
  em.Runtime.InteropServices.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\
  System.Runtime.InteropServices.RuntimeInformation.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.Ap
  p.Ref\5.0.0\ref\net5.0\System.Runtime.Intrinsics.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App
  .Ref\5.0.0\ref\net5.0\System.Runtime.Loader.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\
  5.0.0\ref\net5.0\System.Runtime.Numerics.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0
  .0\ref\net5.0\System.Runtime.Serialization.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5
  .0.0\ref\net5.0\System.Runtime.Serialization.Formatters.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETC
  ore.App.Ref\5.0.0\ref\net5.0\System.Runtime.Serialization.Json.dll" /reference:"C:\Program Files\dotnet\packs\Microso
  ft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Runtime.Serialization.Primitives.dll" /reference:"C:\Program Files\dotnet\
  packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Runtime.Serialization.Xml.dll" /reference:"C:\Program Files\d
  otnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Security.Claims.dll" /reference:"C:\Program Files\dotne
  t\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Security.Cryptography.Algorithms.dll" /reference:"C:\Progra
  m Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Security.Cryptography.Csp.dll" /reference:"C:\
  Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Security.Cryptography.Encoding.dll" /ref
  erence:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Security.Cryptography.Primiti
  ves.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Security.Cryptog
  raphy.X509Certificates.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\Syst
  em.Security.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Security
  .Principal.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Security.
  SecureString.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Service
  Model.Web.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.ServicePro
  cess.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Text.Encoding.C
  odePages.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Text.Encodi
  ng.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Text.Encoding.Ext
  ensions.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Text.Encodin
  gs.Web.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Text.Json.dll
  " /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Text.RegularExpressions
  .dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Threading.Channels.
  dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Threading.dll" /refe
  rence:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Threading.Overlapped.dll" /ref
  erence:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Threading.Tasks.Dataflow.dll"
   /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Threading.Tasks.dll" /re
  ference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Threading.Tasks.Extensions.d
  ll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Threading.Tasks.Paral
  lel.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Threading.Thread
  .dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Threading.ThreadPoo
  l.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Threading.Timer.dl
  l" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Transactions.dll" /ref
  erence:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Transactions.Local.dll" /refe
  rence:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.ValueTuple.dll" /reference:"C:
  \Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Web.dll" /reference:"C:\Program Files\d
  otnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Web.HttpUtility.dll" /reference:"C:\Program Files\dotne
  t\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Windows.dll" /reference:"C:\Program Files\dotnet\packs\Micr
  osoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Xml.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.Ap
  p.Ref\5.0.0\ref\net5.0\System.Xml.Linq.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0
  \ref\net5.0\System.Xml.ReaderWriter.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\re
  f\net5.0\System.Xml.Serialization.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\
  net5.0\System.Xml.XDocument.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0
  \System.Xml.XmlDocument.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\Sys
  tem.Xml.XmlSerializer.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\Syste
  m.Xml.XPath.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\System.Xml.XPat
  h.XDocument.dll" /reference:"C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\5.0.0\ref\net5.0\WindowsBase.dll
  " /debug+ /debug:portable /filealign:512 /optimize- /out:obj\Debug\net5.0\ImportingSamples.dll /refout:obj\Debug\net5
  .0\ref\ImportingSamples.dll /target:exe /warnaserror- /utf8output /deterministic+ /langversion:9.0 /analyzerconfig:ob
  j\Debug\net5.0\ImportingSamples.GeneratedMSBuildEditorConfig.editorconfig /analyzerconfig:"C:\Program Files\dotnet\sd
  k\5.0.203\Sdks\Microsoft.NET.Sdk\analyzers\build\config\AnalysisLevel_5_Default.editorconfig" /analyzer:"C:\Program F
  iles\dotnet\sdk\5.0.203\Sdks\Microsoft.NET.Sdk\targets\..\analyzers\Microsoft.CodeAnalysis.CSharp.NetAnalyzers.dll" /
  analyzer:"C:\Program Files\dotnet\sdk\5.0.203\Sdks\Microsoft.NET.Sdk\targets\..\analyzers\Microsoft.CodeAnalysis.NetA
  nalyzers.dll" Program.cs "obj\Debug\net5.0\.NETCoreApp,Version=v5.0.AssemblyAttributes.cs" obj\Debug\net5.0\Importing
  Samples.AssemblyInfo.cs /warnaserror+:NU1605
  对来自后列目录的编译器使用共享编译: C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\Roslyn
_CreateAppHost:
正在跳过目标“_CreateAppHost”，因为所有输出文件相对于输入文件而言都是最新的。
_CopyFilesMarkedCopyLocal:
  正在对“C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples\obj\Debug\net5.0\ImportingSamples.csproj.CopyComplete”
  执行 Touch 任务。
_CopyOutOfDateSourceItemsToOutputDirectory:
正在跳过目标“_CopyOutOfDateSourceItemsToOutputDirectory”，因为所有输出文件相对于输入文件而言都是最新的。
GenerateBuildRuntimeConfigurationFiles:
正在跳过目标“GenerateBuildRuntimeConfigurationFiles”，因为所有输出文件相对于输入文件而言都是最新的。
CopyFilesToOutputDirectory:
  正在将文件从“C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples\obj\Debug\net5.0\ImportingSamples.dll”复制到“C:\Code\G
  itHub\MySamples\src\CecilSamples\ImportingSamples\bin\Debug\net5.0\ImportingSamples.dll”。
  ImportingSamples -> C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples\bin\Debug\net5.0\ImportingSamples.dll
  正在将文件从“C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples\obj\Debug\net5.0\ImportingSamples.pdb”复制到“C:\Code\G
  itHub\MySamples\src\CecilSamples\ImportingSamples\bin\Debug\net5.0\ImportingSamples.pdb”。
Copy:
  dotnet build C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples\..\HowToLib\HowToLib.csproj
  用于 .NET 的 Microsoft (R) 生成引擎版本 16.9.0+57a23d249
  版权所有(C) Microsoft Corporation。保留所有权利。

    正在确定要还原的项目…
    所有项目均是最新的，无法还原。
    HowToLib -> C:\Code\GitHub\MySamples\src\CecilSamples\HowToLib\bin\Debug\netstandard2.0\HowToLib.dll

  已成功生成。
      0 个警告
      0 个错误

  已用时间 00:00:01.01
  正在将文件从“C:\Code\GitHub\MySamples\src\CecilSamples\HowToLib\bin\Debug\netstandard2.0\HowToLib.deps.json”复制到“C:\Code\Git
  Hub\MySamples\src\CecilSamples\ImportingSamples\bin\Debug\net5.0\HowToLib.deps.json”。
  正在将文件从“C:\Code\GitHub\MySamples\src\CecilSamples\HowToLib\bin\Debug\netstandard2.0\HowToLib.pdb”复制到“C:\Code\GitHub\My
  Samples\src\CecilSamples\ImportingSamples\bin\Debug\net5.0\HowToLib.pdb”。
  正在将文件从“C:\Code\GitHub\MySamples\src\CecilSamples\HowToLib\bin\Debug\netstandard2.0\HowToLib.dll”复制到“C:\Code\GitHub\My
  Samples\src\CecilSamples\ImportingSamples\bin\Debug\net5.0\HowToLib.dll”。
Run:
  C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples\bin\Debug\net5.0\ImportingSamples.exe
  ============ Start ============
  --> 注入日志输出代码完成！
  Mono.Cecil.AssemblyDefinition HowToLib.CecilHowTo::GetExecutingAssembly() Start.
  返回类型为: null
  ============ End ============
已完成生成项目“C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples\ImportingSamples.csproj”(build;Copy;run 个目标)的操作。


已成功生成。
    0 个警告
    0 个错误

已用时间 00:00:03.03

C:\Code\GitHub\MySamples\src\CecilSamples\ImportingSamples>
```
