# HTUtility
日常学习或做项目常用的小工具（一键导出、一键重启、编辑脚本模板等，持续更新...）

# 版本记录

## v0.0.7

- [x] 新增测试脚本使用的计时器服务（TimerServiceForTest）
- [x] 新增自定义的日志输出服务（CustomLoggerService）

## v0.0.6

- [x] 新增普通类的单例模板（HTSingleton）
- [x] 新增通用 Log 接口
- [x] 增加消息打印开关（LoggerSwitch）

## v0.0.5

- [x] 增加项目导出时候的进度条。

## v0.0.4

- [x] 新增一键创建常用文件夹目录结构（升级版），可以自定义名称，同时会创建同名脚本。
- [x] 修复新建脚本Unity无法识别的Bug。

## v0.0.3

- [x] 文件夹结构中增加"Textures"。

## v0.0.2

- [x] 新增一键创建常用文件夹目录结构

## v0.0.1

- [x] 导出器
- [x] 一键打开MarkDown
- [x] 一键重启项目
- [x] 设置脚本模板

# 使用指南

花了点时间做了一个学习使用的小工具，代码量很少，注释详尽，非常轻量级，主要是个人学习使用。现在分享出来，可以花点时间稍加修改，都是些很实用的小工具。

包含有以下**功能**：

![picture1](https://huskytgame.github.io/images/in-post/framework/2019-09-11-日常学习使用的小工具/ScreenShot001.png)

#### 1.**一键导出项目为UnityPackage文件。**

* **名称**：Expoter
* **快捷键**：Ctrl+E
* **说明**：会将所有Assets文件夹下的文件全部导出；导出文件结构：***项目名称_日期(年月日)_小时.unitypackage***。

#### 2.一键打开"版本记录"MarkDown文件。

* **名称**：OpenMarkDown
* **快捷键**：Ctrl+M
* **说明**：一键打开版本记录，便于修改。

#### 3.一键重启当前项目。

* **名称**：ReopenProject
* **快捷键**：Alt+R
* **说明**：重启当前项目。

#### 4.设置脚本模板。

* **名称**：OpenMarkDown
* **快捷键**：Alt+S
* **说明**：可在EditorWindow中设置命名空间和是否开启此功能；至于详细的模板设置，由于时间有限暂时没做，可在脚本**"EditScriptTemplate"**中修改，脚本很简单，注释详尽，一看就懂，修改起来也算方便。

#### 5.创建文件夹目录结构

* **名称**：GenerateDirectoryStructure
* **快捷键**：Shift+Alt+G
* **说明**：主要是学习Rendering配置的文件夹结构。可根据自身需求在脚本"GenerateDirectoryStructure"中自行配置，代码简单，注释详尽。

#### 6.创建指定名称的文件夹目录结构（同时创建一个同名脚本）

- **名称**：GenerateDirectoryStructurePlus
- **快捷键**：Shift+Alt+P
- **说明**：有时候会遇到学习某个API，需要单独的测试场景和测试脚本，此时使用该功能能快速创建指定名称的场景、脚本、文件夹结构，十分便于小知识点的测试、学习、积累。本功能配合脚本模板设置共同使用。

#### 7.通用打印日志接口

- **名称**：HTLogger

- **快捷键**：无

- **说明**：为消息打印添加多个信息频道（Channel），每个频道可以独立注册各自的消息打印方法，同时也拥有独立的频道开关。

  为整个自定义消息打印模块添加了总开关——*“菜单栏--HTUtility--7.LoggerSwitch”*

  使用前需要在 Unity 中添加打印消息方法的监听（注册），详细使用方法可见 Script：HTLogger.cs

#### 8.测试脚本使用的计时器服务

- **名称**：TimerServiceForTest
- **快捷键**：无
- **说明**：测试脚本使用的计时器服务（TimerServiceForTest），内含例子。