# HashChecker - 文件校验和计算工具

一个简单易用的跨平台桌面应用程序，用于计算文件的校验和（哈希值），支持多种哈希算法。

## 功能特性

- 📁 选择任意文件进行校验和计算
- 🔐 支持多种哈希算法：
  - MD5
  - SHA1
  - SHA256
  - SHA384
  - SHA512
- 📋 一键复制校验和结果到剪贴板
- 🎨 简洁直观的用户界面
- 🌐 跨平台支持（Windows、Linux 等）

## 技术栈

- .NET 10.0
- GTK# (GTK3)
- C# 10.0

## 环境要求

- **操作系统**:
  - Windows 10 或更高版本
  - Linux（需安装 GTK3）
- **运行时**: .NET 10.0 Runtime（如果使用独立发布的版本则无需安装）

### Windows 环境准备

在 Windows 上运行 GTK# 应用程序，需要安装 GTK 运行时环境：

1. 下载并安装 [GTK for Windows Runtime](https://github.com/tschoonj/GTK-for-Windows-Runtime-Environment-Installer)
2. 或者使用 MSYS2 安装：
   ```bash
   pacman -S mingw-w64-x86_64-gtk3
   ```

### Linux 环境准备

在 Linux 上，确保已安装 GTK3：

```bash
# Ubuntu/Debian
sudo apt-get install libgtk-3-dev

# Fedora
sudo dnf install gtk3-devel

# Arch Linux
sudo pacman -S gtk3
```

## 快速开始

### 运行项目

如果您已安装 .NET SDK ，可以直接运行：

```
dotnet run
```

### 编译项目

```
dotnet build -c Release
```

结果在 `bin/Release/net10.0` 中

打包成单体文件（Windows平台）

```
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```

## 开发

### 环境配置

确保已安装以下工具：
- [.NET SDK 10.0](https://dotnet.microsoft.com/download)
- GTK 运行时环境（根据您的操作系统）

### 代码说明

项目使用 GTK# (GTK3 的 .NET 绑定) 构建跨平台图形界面：

- **MainWindow.cs**: 主窗口类，包含所有 UI 控件和事件处理
- **Program.cs**: 应用程序入口，初始化 GTK 应用
- 哈希计算逻辑使用 .NET 的 `System.Security.Cryptography` 命名空间

## 许可证

[MIT License](LICENSE)
