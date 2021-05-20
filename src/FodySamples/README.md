# <img src="./images/Fody.png" height="28px"> Fody: 编织 `.NET` 程序集的可扩展工具。

将修改程序集 IL 代码作为编译项目的一部分工作需要大量的衔接代码，这些衔接代码涉及 `MSBuild` 与 `Visual Studio API` 相关的知识，而 [Fody](https://github.com/Fody/Fody) 尝试通过可扩展的加载模型消除这些衔接代码。

这是 Fody 项目核心引擎代码库的说明，更多关于 Fody 项目信息可以到 [Home](https://github.com/Fody/Home) 项目查看。


## 社区支持

`Fody` 需要花费大量的精力来进行维护，因此，它需要一定的资金支持以确保其长期稳定的发展。

希望使用 `Fody` 的开发者可以 [成为 OpenCollective 的资助者](https://opencollective.com/fody/contribute/patron-3059)，或者 [订阅 Tidelift](https://tidelift.com/subscription/pkg/nuget-fody?utm_source=nuget-fody&utm_medium=referral&utm_campaign=enterprise) 进行赞助。

更多信息可以阅读 [许可 / 赞助 常见问题与解答](https://github.com/Fody/Home/blob/master/pages/licensing-patron-faq.md) 进行了解。


## 企业版 `Fody`

作为 `Tidelift` 订阅的一部分提供。

`Fody` 项目的维护者和数以千计的其他软件包开发者与 `Tidelift` 合作，为您构建应用程序所需要使用的开源依赖项提供商业支持和维护。节省时间、降低风险并改善代码运行状况，同时为您所使用的依赖项的维护者支付费用，[点此](https://tidelift.com/subscription/pkg/nuget-fody?utm_source=nuget-fody&utm_medium=referral&utm_campaign=enterprise&utm_term=repo) 了解更多。

### 金牌赞助商

通过 [成为金牌赞助商](https://opencollective.com/fody/contribute/silver-7086) 来支持该项目。 一个大号的公司 Logo 图片将添加到此处，并带有指向您网站的链接。

<a href="https://www.postsharp.net?utm_source=fody&utm_medium=referral"><img alt="PostSharp" src="./images/postsharp.png"></a>

### 银牌赞助者

通过 [成为银牌赞助商](https://opencollective.com/fody/contribute/silver-7086) 来支持该项目。 一个中等的公司 Logo 图片将添加到此处，并带有指向您网站的链接。

<a href="https://www.gresearch.co.uk/"><img alt="G-Research" width="120px" src="./images/g-research.svg?sanitize=true"></a> <a href="https://particular.net/"><img alt="Particular Software" width="200px" src="./images/particular.svg?sanitize=true"></a>

### 铜牌赞助者

通过 [成为铜牌赞助商](https://opencollective.com/fody/contribute/bronze-7085) 来支持该项目。 一个头像大小的公司 Logo 图片将添加到此处，并带有指向您网站的链接。

<a href="https://opencollective.com/fody/tiers/bronze/0/website"><img src="https://opencollective.com/fody/tiers/bronze/0/avatar.svg?avatarHeight=100"></a> 
<a href="https://opencollective.com/fody/tiers/bronze/1/website"><img src="https://opencollective.com/fody/tiers/bronze/1/avatar.svg?avatarHeight=100"></a>

### 赞助人和赞助商

感谢所有的支持者和赞助商！可以通过 [成为赞助人](https://opencollective.com/fody/contribute/patron-3059) 来支持该项目。

<a href="https://opencollective.com/fody#contributors"><img src="https://opencollective.com/fody/sponsor.svg?width=890&avatarHeight=50&button=false"><img src="https://opencollective.com/fody/backer.svg?width=890&avatarHeight=50&button=false"></a>


## 文档与进一步了解

+ [许可与用户常见问题](https://github.com/Fody/Home/tree/master/pages/licensing-patron-faq.md)<br>
  **希望所有使用 `Fody` 的开发者可以 [成为 OpenCollective 的资助者](https://opencollective.com/fody/contribute/patron-3059)。** 更多信息可以阅读 [许可 / 赞助 常见问题与解答](https://github.com/Fody/Home/blob/master/pages/licensing-patron-faq.md) 进行了解。
+ [用途](https://github.com/Fody/Home/tree/master/pages/usage.md)<br>
  使用 `Fody` 的简介。
+ [配置](https://github.com/Fody/Home/tree/master/pages/configuration.md)<br>
  所有关于 `Fody` 的配置项信息。
+ [插件发现](https://github.com/Fody/Home/tree/master/pages/addin-discovery.md)<br>
  插件如何被识别。
+ [Fody 编织工具与插件列表](https://github.com/Fody/Home/tree/master/pages/addins.md)
+ [更新日志](https://github.com/Fody/Fody/milestones?state=closed)
+ [FodyAddinSamples](https://github.com/Fody/FodyAddinSamples)<br>
  一个在 `GitHub` 上的代码仓，其中包含了每个 `Fody` 插件的工作示例。
+ [常见错误](https://github.com/Fody/Home/tree/master/pages/common-errors.md)
+ [在解决方案中编织代码](https://github.com/Fody/Home/tree/master/pages/in-solution-weaving.md)<br>
  在同一个解决方案内编写修改 IL 代码的插件。
+ [ProcessedByFody 类](https://github.com/Fody/Home/tree/master/pages/processedbyfody-class.md)
  标记类型添加到目标程序集中以进行诊断。
+ [强命名](https://github.com/Fody/Home/tree/master/pages/strong-naming.md)
+ [支持的运行时与 IDE](https://github.com/Fody/Home/tree/master/pages/supported-runtimes-and-ide.md)
+ [插件开发](https://github.com/Fody/Home/tree/master/pages/addin-development.md)
  构建一个新的 Fody 插件。
+ [插件打包](https://github.com/Fody/Home/tree/master/pages/addin-packaging.md)
  `Fody` 编织工具的打包与部署。
+ [BasicFodyAddin](BasicFodyAddin)<br>
  一个简单的 `Fody` 项目旨在演示如何构建一个插件。
+ [Fody 项目配置管理器](https://github.com/tom-englert/ProjectConfigurationManager/wiki/6.-Fody)<br>
  提供可支持配置编织工具的交互式工具，这在许多项目的解决方案中特别有用。
+ [支持者跟踪与信息](https://github.com/Fody/Home/tree/master/pages/backers.md)
+ [捐助](https://github.com/Fody/Home/tree/master/pages/donations.md)
  每月，`Fody` 项目都会将筹集的部分资金捐赠给慈善机构或其他事业。


## 贡献者

这个项目的存在要归功于所有的贡献者。 [[贡献者](https://github.com/Fody/Fody/blob/master/CONTRIBUTING.md)]

<a href="https://github.com/Fody/Fody/graphs/contributors"><img src="https://opencollective.com/fody/contributors.svg?width=890&button=false" /></a>


> 参考：
> + `Mono.Cecil` @ GitHub: https://github.com/jbevain/cecil
> + `MSBuild` @ MSDN: https://docs.microsoft.com/en-us/visualstudio/msbuild