<div align="center">
  
<img src="https://github.com/BadBC-Studio/BadMC_Launcher/blob/Release/BadMC_Launcher/Assets/Icons/appicon_full.png"/>

# BadMC Launcher

某不正经小怪物搞出来的启动器🤪

**[Starcloudsea](https://github.com/Starcloudsea) 的作品(要累死我QAQ)**

**特别鸣谢: 
[Drowned.Get](https://github.com/DrownedGet) |
[YangSpring 429](https://github.com/YangSpring429) |
[Gen123](https://github.com/geenh) |
[FlowerSacrifice](https://github.com/FlowerSacrifice)**

![GitHub Repo stars](https://img.shields.io/github/stars/BadBC-Studio/BadMC_Launcher?style=for-the-badge&logo=github&logoColor=0077FF&labelColor=F3F3F3&color=0077ff)
![GitHub forks](https://img.shields.io/github/forks/BadBC-Studio/BadMC_Launcher?style=for-the-badge&logo=github&logoColor=0077FF&labelColor=F3F3F3&color=0077FF)
![GitHub Release](https://img.shields.io/github/v/release/BadBC-Studio/BadMC_Launcher?include_prereleases&sort=date&display_name=release&style=for-the-badge&logo=github&logoColor=0077FF&labelColor=f3f3f3&color=0077ff)
![GitHub Downloads (all assets, all releases)](https://img.shields.io/github/downloads/BadBC-Studio/BadMC_Launcher/total?style=for-the-badge&logo=github&logoColor=0077FF&labelColor=F3F3F3&color=0077FF)
![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/BadBC-Studio/BadMC-Launcher/ci.yml?branch=Release&style=for-the-badge&logo=github&logoColor=0077FF&labelColor=F3F3F3&color=0077FF)
![GitHub repo size](https://img.shields.io/github/repo-size/BadBC-Studio/BadMC_Launcher?style=for-the-badge&logo=github&logoColor=0077FF&labelColor=F3F3F3&color=0077FF)

![Discord](https://img.shields.io/discord/1025379148304240690?style=for-the-badge&logo=discord&logoColor=FF0000&label=Discord&labelColor=F3F3F3&color=FF0000&link=https%3A%2F%2Fdiscord.gg%2FjfZPPpC3Av)
![Website](https://img.shields.io/website?url=https%3A%2F%2FBadBC-Studio.github.io%2FBadMC_Launcher&style=for-the-badge&logo=Vite&logoColor=FF0000&label=Pages&labelColor=F3F3F3&color=FF0000&link=https%3A%2F%2FBadBC-Studio.github.io%2FBadMC_Launcher)
![Starcloudsea Bilibili](https://img.shields.io/badge/Bilibili-Starcloudsea-FF0000?style=for-the-badge&logo=bilibili&logoColor=FF0000&labelColor=F3F3F3&link=https%3A%2F%2Fspace.bilibili.com%2F2123349162)
![Drowned.Get Bilibili](https://img.shields.io/badge/Bilibili-Drowned.Get-FF0000?style=for-the-badge&logo=bilibili&logoColor=FF0000&labelColor=F3F3F3&link=https%3A%2F%2Fspace.bilibili.com%2F527675045)

![Alt](https://repobeats.axiom.co/api/embed/0b7fadbd7ecc0d0650374fded18845b77630e3a1.svg "Repobeats analytics image")
</div>

<details>
<summary> View README in other languages </summary>
<br/>

[**English**](https://github.com/BadBC-Studio/BadMC_Launcher/blob/Release/docs/README_enUS.md)

> Want to contribute more languages? Please try opening a new pull request.
<br/>
</details>

> [!TIP]
> Release分支意味着这个分支的内容用于正式版本，它接收的更新最稳定，也最晚收到更新。
> 但是根据Starcloudsea的更新速度来看你可能需要等待一个世纪才能等到一个更新(。・ω・。)（不是）

> [!CAUTION]
> 不要明确向主要贡献者询问关于这个项目的问题，因为他们不希望参与这个项目太多.

## 简介

带有 Fluent 的 UI 风格的跨平台的 Minecraft 启动器，
旨在简化你的Minecraft体验。

## 应用截图
> [!NOTE]
> 等会项目准备好了再传QAQ

## 功能
- Minecraft
  - [ ] 启动 Minecraft Java

### 为新功能投票！

现在转到 GitHub Discussions，你可以提出一个新功能或为新功能投票，在审查通过后就等下世纪出现在你的启动器上吧！（喜）

## 安装

> [!IMPORTANT]
> 首先，你需要确保你的电脑已安装 .NET 9 的附带 .NET 9 Runtime 的任意版本.
> [如果没有，在此处下载.](https://dotnet.microsoft.com/zh-cn/download/dotnet/9.0)

> [!TIP]
> 我们还没钱买各个商店的开发者账号QAQ

在 Release 下载对应你的系统和架构的应用程序，对于安装包，直接安装即可，对于压缩包，解压后直接运行BadMC_Launcher.exe或主程序的可执行文件。

### 各个配置的区别

| 配置         | 支持的系统                     | 注解                  |
|--------------|--------------------------------|-----------------------|
| WinUI        | Windows 10/11+                 | 包含完整的 WinUI 支持 |
| Desktop      | Windows 8/10/11+, MacOS, Linux | 包含类 WinUI 支持     |
| Mac Catalyst | MacOS                          | 未知（没编译过QAQ）   |

<details>
<summary> 在此查看详细教程 </summary>
<br/>

### Windows

> 适用范围
> 
> WinUI: Windows 10/11+
> 
> Desktop: Windows 8/10/11+
> 
> Arm64, x64, x86

安装包: `BadMC_Launcher.\<你的系统架构\>-WinUIPackaged.msix` `BadMC_Launcher.\<你的系统架构\>-DesktopWindows.exe`
下载后直接直接运行程序即可进入安装流程。

压缩包: `BadMC_Launcher.\<你的系统架构\>-WinUIUnpackaged.zip` `BadMC_Launcher.\<你的系统架构\>-DesktopWindows.zip`
下载后解压然后运行BadMC_Launcher.exe.（**这不是安装程序！**）

### macOS

> 适用范围
> 
> 所有支持 .NET 9 和 Mac Catalyst 的 macOS（macOS 10.15+）
> 
> Arm64, x64, x86

安装包: `BadMC_Launcher.\<你的系统架构\>-DesktopMacOS.dmg` `BadMC_Launcher.\<你的系统架构\>-MacCatalyst.pkg`
下载后直接直接运行程序即可进入安装流程.

压缩包: `BadMC_Launcher.\<你的系统架构\>-DesktopMacOS.zip` `BadMC_Launcher.\<你的系统架构\>-MacCatalyst.zip`
下载后解压然后运行BadMC_Launcher.app.（**这不是安装程序！**）

> [!IMPORTANT]
> 如果无法安装，请在终端运行这行命令.
> ```bash
> sudo spctl  --master-disable
> ```
> 然后打开`系统偏好设置 \> 隐私与安全性 \> 安全性`，点击`任何来源`.
> 这将允许MacOS从任何来源安装软件，你可以在设置将其关闭.
> 
> 如果依然无法安装，请尝试在终端运行这行命令.
> sudo xattr -rd com.apple.quarantine \<你的dmg文件的路径，你可以直接将dmg文件拖到这里.\>
>
> 运行这些命令可能会要求你输入管理员密码已验证身份，不过注意，在你输入密码时，终端不会显示你的输入.

### Linux

> 适用范围
> 
> 所有支持 .NET 9 的 Linux
> 
> Arm64, x64, x86

安装包: `BadMC_Launcher.\<你的系统架构\>-DesktopLinux.snap`
下载后定位到安装包所在位置，使用snap安装BadMC_Launcher.
```bash
sudo snap install BadMC_Launcher.\<你的系统架构\>-DesktopLinux.snap --dangerous --classic
```

Snap应用商店: 
直接在命令行输入这段命令以安装BadMC Launcher.
```bash
sudo snap install BadMC_Launcher
```

<br/>
</details>

## 构建

由于 BadMC_Launcher 使用 Uno Platform 开发，所以在构建之前最好使用Uno.Check来设置环境:

```bash
dotnet tool install Uno.Check -g

//如果需要更新
dotnet tool update Uno.Check -g

uno-check
```
无需修复 Android 或 ASP.NET 问题，我们没有用到这些.

如果只是简单构建，请参考 [Uno Platform 的构建](https://platform.uno/docs/articles/uno-development/building-uno-ui.html)
如果需要发布，请最好参考 [Uno Platform 的发布流程](https://platform.uno/docs/articles/uno-publishing-overview.html).

## 寻求帮助 & 报告问题

> [!WARNING]
> 1. 请在继续时使用 Bing 搜索你的问题
> 2. **我们不对 `怎么解压`, `手机能用吗`, `怎么下载`, `桌面在哪`, `下载下来运行不了它说没有关联的程序打开zip文件`, `为什么我的 Windows 7 没法运行`, `我的 Windows 8.1 没法运行WinUIPackaged怎么回事`, `说好的免费为啥解压要钱啊`, `我电脑不是 i9 级吗怎么玩 MC 这么卡啊`, `这是怎么回事（附上一个缺少 .NET 运行时的截图）`, `装 .NET 9 怎么要 48 块钱啊`, `什么是微软账号`, `我要玩我的世界为什么上面显示"启动 Minecraft!"啊我不玩 Minecraft 啊`, `Java 是什么`, `JDK 是什么`, `这压缩包我看不懂啊（把源码下载下来了）`, `Forge 是什么`, `我Mod装上去崩了咋办啊（Mod问题问我们干嘛？？？(＃°Д°)）`, `它说要管理员权限，我得找我爸妈要吗`, `显卡和CPU是什么`, `为什么打不开啊（没附报错截图）`之类的问题进行解答，你是嫌我们的血压还不够高是吧(╬▔皿▔)╯**
> 4. 搜索有没有人提过类似的问题
> 
> **再乱搞你可要赔偿我们一顿 KFC 疯狂星期四降压套餐（恼😡）**

你可以在 Issues 或者 Discussions 的 Q&A 板块提出问题，如果你的问题符合规则，我们会帮助你 awa

**或者即刻加入我们的 QQ 群或 Discord 以获取帮助！q(≧▽≦q)（最快）**

![Discord](https://img.shields.io/discord/1025379148304240690?style=for-the-badge&logo=discord&logoColor=0077FF&label=Discord&labelColor=F3F3F3&color=0077FF&link=https%3A%2F%2Fdiscord.gg%2FjfZPPpC3Av)
![BadBC Developer](https://img.shields.io/badge/BadBC%20Developer-%E7%94%B3%E8%AF%B7%20BadBC%20Developer%20%E6%88%90%E5%91%98-0077FF?style=for-the-badge&labelColor=F3F3F3&link=https%3A%2F%2Fforms.office.com%2Fr%2Fmp5madSnHi)
![Starcloudsea 的团伙窝点 (雾)](https://img.shields.io/badge/Starcloudsea%20%E7%9A%84%E5%9B%A2%E4%BC%99%E7%AA%9D%E7%82%B9%20(%E9%9B%BE)-631610017-0077FF?style=for-the-badge&labelColor=F3F3F3&link=https%3A%2F%2Fqm.qq.com%2Fq%2FtLesvcJCa4)

## 主要引用项 & 参考

### [WonderLab.Override](https://github.com/Bless-Studio/WonderLab.Override)

真正的下一代跨平台 Minecraft 启动器

开源协议: [AGPL-3.0 license](https://github.com/Bless-Studio/WonderLab.Override/blob/master/LICENSE)

### [Natsurainko.FluentLauncher](https://github.com/Xcube-Studio/Natsurainko.FluentLauncher)

基于 .NET 8 以及 WinUI3 技术开发的 Minecraft Java 版启动器
专为 Windows 11 设计的 Minecraft 启动器
提供简洁、流畅的视觉体验

开源协议: [MIT license](https://github.com/Xcube-Studio/Natsurainko.FluentLauncher/blob/main/LICENSE)

### [MinecraftLaunch](https://github.com/Bless-Studio/MinecraftLaunch)

The next-generation versatile and modular high-performance Minecraft startup core.

开源协议: [MIT license](https://github.com/Bless-Studio/MinecraftLaunch/blob/4.0.x/LICENSE)

### [Uno Platform](https://github.com/unoplatform/uno)

Pixel-Perfect. Multi-Platform. C# & Windows XAML. Today.

开源协议: [Apache-2.0 license](https://github.com/unoplatform/uno/blob/master/License.md)

### [WindowsAppSDK](https://github.com/microsoft/WindowsAppSDK)

The Windows App SDK empowers all Windows desktop apps with modern Windows UI, APIs, and platform features, including back-compat support, shipped via NuGet.

开源协议: [MIT license](https://github.com/microsoft/WindowsAppSDK/blob/main/LICENSE)

### [WinUI 3](https://github.com/microsoft/microsoft-ui-xaml)

WinUI: a modern UI framework with a rich set of controls and styles to build dynamic and high-performing Windows applications.

开源协议: [MIT license](https://github.com/microsoft/microsoft-ui-xaml/blob/main/LICENSE)

### [Windows Community Toolkit](https://github.com/CommunityToolkit/Windows)

Collection of controls for WinUI 2, WinUI 3, and Uno Platform developers. Simplifies and demonstrates common developer tasks building experiences for Windows with .NET.

开源协议: [MIT license](https://github.com/CommunityToolkit/Windows/blob/main/License.md)

## 鸣谢

感谢 bangbang93 提供 Minecraft 的镜像服务.
[赞助 bangbang93](https://afdian.net/@bangbang93)

## 开源协议
[MPL-2.0 license](https://github.com/BadBC-Studio/BadMC_Launcher/blob/Release/LICENSE)，在二次分发时请务必遵守该协议.

Starcloudsea 的作品.
Copyright (c) 2019-2025 XadBC.
