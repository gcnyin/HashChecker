# HashChecker - 文件校验和计算工具

![.NET Version](https://img.shields.io/badge/.NET-10.0-blue)
![License](https://img.shields.io/badge/License-MIT-green)
![Platform](https://img.shields.io/badge/Platform-Linux%20%7C%20Windows%20%7C%20macOS-lightgrey)

一个使用 C# 和 GTK3 开发的跨平台桌面应用程序，用于计算文件的哈希校验和。支持多种哈希算法，提供直观的图形界面。

## 功能特性

- 支持多种哈希算法：MD5、SHA1、SHA256、SHA384、SHA512
- 直观的图形界面：基于 GTK3，操作简单便捷
- 一键复制结果：快速复制计算出的校验和到剪贴板
- 跨平台支持：在 Linux、Windows 和 macOS 上均可运行

## 系统要求

### .NET SDK
- .NET 10.0 SDK 或更高版本

### GTK3 依赖

#### Linux (Ubuntu/Debian)
```bash
sudo apt-get update
sudo apt-get install -y libgtk-3-0
```

#### Linux (Fedora/RHEL)
```bash
sudo dnf install gtk3
```

#### Linux (Arch Linux)
```bash
sudo pacman -S gtk3
```

#### macOS
```bash
brew install gtk+3
```

#### Windows
GTK3 通常随 NuGet 包自动安装，无需额外配置。

## 安装和运行

### 1. 克隆仓库

```bash
git clone https://github.com/gcnyin/HashChecker.git
cd HashChecker
```

### 2. 还原依赖

```bash
dotnet restore
```

### 3. 构建项目

```bash
dotnet build
```

### 4. 运行程序

开发环境运行：

```bash
dotnet run
```

### 5. 发布为独立可执行文件（可选）

发布为单文件可执行程序（包含 .NET 运行时）：

Linux:
```bash
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true
```

Windows:
```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

macOS:
```bash
# m1
dotnet publish -c Release -r osx-arm64 --self-contained true -p:PublishSingleFile=true
# intel
dotnet publish -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true
```

发布后的可执行文件位于 `bin/Release/net10.0/{runtime}/publish/` 目录下。

## 许可证

本项目采用 MIT 许可证。详见 [LICENSE](LICENSE) 文件。
