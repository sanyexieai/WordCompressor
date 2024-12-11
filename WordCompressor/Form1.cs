using System;
using System.Windows.Forms;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnSelectFile_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Word 文档|*.docx;*.doc";
            openFileDialog.Title = "选择要压缩的 Word 文档";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }
    }

    private void btnCompress_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtFilePath.Text))
        {
            MessageBox.Show("请先选择文件！");
            return;
        }

        int compressionLevel = trackBarCompression.Value;
        string outputPath = Path.Combine(
            Path.GetDirectoryName(txtFilePath.Text),
            Path.GetFileNameWithoutExtension(txtFilePath.Text) + "_compressed" + Path.GetExtension(txtFilePath.Text)
        );

        try
        {
            File.Copy(txtFilePath.Text, outputPath, true);
            CompressWordDocument(outputPath, compressionLevel);
            MessageBox.Show("压缩完成！\n保存路径：" + outputPath);
        }
        catch (Exception ex)
        {
            MessageBox.Show("压缩过程中出错：" + ex.Message);
        }
    }

    private void CompressWordDocument(string filePath, int compressionLevel)
    {
        using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, true))
        {
            var mainPart = doc.MainDocumentPart;
            if (mainPart == null) return;

            // 获取所有图片部分
            var imageParts = mainPart.ImageParts.ToList();
            foreach (var imagePart in imageParts)
            {
                using (Stream imageStream = imagePart.GetStream())
                using (MemoryStream ms = new MemoryStream())
                {
                    imageStream.CopyTo(ms);
                    ms.Position = 0;  // 重置流的位置到开始

                    // 压缩图片
                    using (MemoryStream compressedMs = new MemoryStream())
                    {
                        try
                        {
                            using (Image img = Image.FromStream(ms))
                            {
                                // 计算新的尺寸，保持长宽比
                                int quality = Math.Max(1, compressionLevel);
                                
                                // 创建图片编码器参数
                                var encoderParameters = new EncoderParameters(1);
                                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);

                                // 获取图片编码器
                                ImageCodecInfo jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                                if (jpegEncoder == null)
                                {
                                    continue; // 跳过无法处理的图片格式
                                }

                                // 保存压缩后的图片
                                img.Save(compressedMs, jpegEncoder, encoderParameters);
                            }

                            // 替换原图片
                            imageStream.SetLength(0);
                            compressedMs.Position = 0;
                            compressedMs.CopyTo(imageStream);
                        }
                        catch (ArgumentException)
                        {
                            // 跳过无法处理的图片
                            continue;
                        }
                    }
                }
            }
        }
    }

    private ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        return codecs.FirstOrDefault(codec => codec.FormatID == format.Guid);
    }
}