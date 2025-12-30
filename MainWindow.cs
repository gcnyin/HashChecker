using System;
using System.IO;
using System.Security.Cryptography;
using Gtk;

namespace HashChecker;

public class MainWindow : Window
{
    private string? selectedFilePath;
    private Entry txtFilePath;
    private ComboBoxText cboAlgorithm;
    private Entry txtResult;
    private Button btnSelectFile;
    private Button btnCalculate;
    private Button btnCopy;
    
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值
#pragma warning disable CS0612 // HBox/VBox 已过时
#pragma warning disable CS0618 // SetAlignment 已过时

    public MainWindow() : base("HashChecker - 文件校验和计算工具")
    {
        SetDefaultSize(600, 250);
        SetPosition(WindowPosition.Center);
        DeleteEvent += OnDeleteEvent;

        CreateWidgets();
        SetupLayout();
    }

    private void CreateWidgets()
    {
        // 文件路径相关控件
        var fileBox = new HBox(false, 5);
        var lblFilePath = new Label("文件路径：")
        {
            WidthChars = 10
        };
        lblFilePath.SetAlignment(0, 0.5f);

        txtFilePath = new Entry
        {
            IsEditable = false,
            PlaceholderText = "未选择文件"
        };

        btnSelectFile = new Button("选择文件");
        btnSelectFile.Clicked += OnBtnSelectFileClicked;

        fileBox.PackStart(lblFilePath, false, false, 0);
        fileBox.PackStart(txtFilePath, true, true, 0);
        fileBox.PackStart(btnSelectFile, false, false, 0);

        // 算法选择相关控件
        var algoBox = new HBox(false, 5);
        var lblAlgorithm = new Label("哈希算法：")
        {
            WidthChars = 10
        };
        lblAlgorithm.SetAlignment(0, 0.5f);

        cboAlgorithm = new ComboBoxText();
        cboAlgorithm.AppendText("MD5");
        cboAlgorithm.AppendText("SHA1");
        cboAlgorithm.AppendText("SHA256");
        cboAlgorithm.AppendText("SHA384");
        cboAlgorithm.AppendText("SHA512");
        cboAlgorithm.Active = 2; // 默认选择 SHA256

        algoBox.PackStart(lblAlgorithm, false, false, 0);
        algoBox.PackStart(cboAlgorithm, true, true, 0);

        // 结果相关控件
        var resultBox = new HBox(false, 5);
        var lblResult = new Label("计算结果：")
        {
            WidthChars = 10
        };
        lblResult.SetAlignment(0, 0.5f);

        txtResult = new Entry
        {
            IsEditable = false,
            PlaceholderText = "点击计算按钮获取结果"
        };

        btnCopy = new Button("复制");
        btnCopy.Clicked += OnBtnCopyClicked;
        btnCopy.Sensitive = false;

        resultBox.PackStart(lblResult, false, false, 0);
        resultBox.PackStart(txtResult, true, true, 0);
        resultBox.PackStart(btnCopy, false, false, 0);

        // 计算按钮
        btnCalculate = new Button("计算校验和");
        btnCalculate.Clicked += OnBtnCalculateClicked;

        // 主容器
        var mainBox = new VBox(false, 10);
        mainBox.BorderWidth = 10;
        mainBox.PackStart(fileBox, false, false, 0);
        mainBox.PackStart(algoBox, false, false, 0);
        mainBox.PackStart(resultBox, false, false, 0);
        mainBox.PackStart(btnCalculate, false, false, 10);

        Add(mainBox);
    }

    private void SetupLayout()
    {
        ShowAll();
    }

    private void OnBtnSelectFileClicked(object? sender, EventArgs e)
    {
        var fileChooserDialog = new FileChooserDialog(
            "选择要计算校验和的文件",
            this,
            FileChooserAction.Open,
            "取消", ResponseType.Cancel,
            "选择", ResponseType.Accept
        );

        fileChooserDialog.Filter = new FileFilter
        {
            Name = "所有文件"
        };
        fileChooserDialog.Filter.AddPattern("*");

        if (fileChooserDialog.Run() == (int)ResponseType.Accept)
        {
            selectedFilePath = fileChooserDialog.Filename;
            txtFilePath.Text = selectedFilePath;
            txtResult.Text = string.Empty;
            btnCopy.Sensitive = false;
        }

        fileChooserDialog.Destroy();
    }

    private void OnBtnCalculateClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(selectedFilePath))
        {
            ShowMessageDialog("提示", "请先选择一个文件！", MessageType.Info);
            return;
        }

        if (!File.Exists(selectedFilePath))
        {
            ShowMessageDialog("错误", "选中的文件不存在！", MessageType.Error);
            return;
        }

        string algorithm = cboAlgorithm.ActiveText ?? "SHA256";

        try
        {
            string hashValue = CalculateFileHash(selectedFilePath, algorithm);
            txtResult.Text = hashValue;
            btnCopy.Sensitive = true;
        }
        catch (Exception ex)
        {
            ShowMessageDialog("错误", $"计算校验和时出错：{ex.Message}", MessageType.Error);
        }
    }

    private void OnBtnCopyClicked(object? sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtResult.Text))
        {
            var clipboard = GetClipboard(Gdk.Selection.Clipboard);
            clipboard.Text = txtResult.Text;
            ShowMessageDialog("提示", "校验和已复制到剪贴板！", MessageType.Info);
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

    private void ShowMessageDialog(string title, string message, MessageType messageType)
    {
        var dialog = new MessageDialog(
            this,
            DialogFlags.Modal,
            messageType,
            ButtonsType.Ok,
            message
        );
        dialog.Title = title;
        dialog.Run();
        dialog.Destroy();
    }

    private void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
    
#pragma warning restore CS8618
#pragma warning restore CS0612
#pragma warning restore CS0618
}
