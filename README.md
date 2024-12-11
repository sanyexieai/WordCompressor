# Word文档图片压缩工具

一个简单的 Windows 桌面应用程序，用于压缩 Word 文档（.doc/.docx）中的图片，从而减小文档体积。

## 功能特点

- 支持 .doc 和 .docx 格式的 Word 文档
- 可调节压缩率（0-100）
- 保持图片原有长宽比
- 自动跳过不支持的图片格式
- 生成新文件，不影响原文档

## 系统要求

- Windows 操作系统
- .NET 6.0 或更高版本
- Microsoft Word（建议安装）

## 使用方法

1. 运行程序
2. 点击"选择文件"按钮，选择要压缩的 Word 文档
3. 使用滑动条调整压缩率：
   - 0：最大压缩（图片质量最低）
   - 100：最小压缩（图片质量最高）
4. 点击"开始压缩"按钮
5. 程序会在原文件所在目录生成一个新的压缩后的文件，文件名后缀为"_compressed"

## 注意事项

- 压缩过程会生成新文件，原文件不会被修改
- 某些特殊格式的图片（如 EMF、WMF）可能会被跳过
- 建议在压缩重要文档前先备份
- 压缩过程中请勿打开目标文档

## 开发环境

- Visual Studio 2022
- .NET 6.0
- Windows Forms
- DocumentFormat.OpenXml 3.2.0
- System.Drawing.Common 7.0.0

## 构建方法

1. 克隆仓库：  
    ```
    git clone [repository-url]
    ```
2. 使用 Visual Studio 2022 打开解决方案文件 `WordCompressor.sln`

3. 还原 NuGet 包

4. 编译并运行项目

## 许可证

MIT License

## 贡献

欢迎提交 Issue 和 Pull Request！

## 常见问题

Q: 为什么有些图片没有被压缩？  
A: 程序目前主要支持常见的图片格式（如 JPG、PNG 等），对于一些特殊格式的图片会自动跳过以避免出错。

Q: 压缩后的文件打不开怎么办？  
A: 请确保：
1. 原文件没有被加密或损坏
2. 压缩过程中没有打开目标文件
3. 系统已安装 Microsoft Word

