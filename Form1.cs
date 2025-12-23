using System.Security.Cryptography;

namespace HashChecker;

public partial class Form1 : Form
{
    private string? selectedFilePath;

    public Form1()
    {
        InitializeComponent();
    }

    private void BtnSelectFile_Click(object? sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            Filter = "所有文件 (*.*)|*.*",
            Title = "选择要计算校验和的文件"
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            selectedFilePath = openFileDialog.FileName;
            txtFilePath.Text = selectedFilePath;
            txtResult.Clear();
        }
    }

    private void BtnCalculate_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(selectedFilePath))
        {
            MessageBox.Show("请先选择一个文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (!File.Exists(selectedFilePath))
        {
            MessageBox.Show("选中的文件不存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        string algorithm = cboAlgorithm.SelectedItem?.ToString() ?? "SHA256";

        try
        {
            string hashValue = CalculateFileHash(selectedFilePath, algorithm);
            txtResult.Text = hashValue;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"计算校验和时出错：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnCopy_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtResult.Text))
        {
            Clipboard.SetText(txtResult.Text);
            MessageBox.Show("校验和已复制到剪贴板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private string CalculateFileHash(string filePath, string algorithmName)
    {
        HashAlgorithm hashAlgorithm = algorithmName.ToUpperInvariant() switch
        {
            "MD5" => MD5.Create(),
            "SHA1" => SHA1.Create(),
            "SHA256" => SHA256.Create(),
            "SHA384" => SHA384.Create(),
            "SHA512" => SHA512.Create(),
            _ => throw new NotSupportedException($"不支持的哈希算法：{algorithmName}")
        };

        using (hashAlgorithm)
        {
            using FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] hashBytes = hashAlgorithm.ComputeHash(fileStream);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }
}
