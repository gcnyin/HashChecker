namespace HashChecker;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.btnSelectFile = new Button();
        this.txtFilePath = new TextBox();
        this.lblAlgorithm = new Label();
        this.cboAlgorithm = new ComboBox();
        this.btnCalculate = new Button();
        this.lblResult = new Label();
        this.txtResult = new TextBox();
        this.btnCopy = new Button();
        this.SuspendLayout();
        // 
        // btnSelectFile
        // 
        this.btnSelectFile.Location = new Point(20, 20);
        this.btnSelectFile.Name = "btnSelectFile";
        this.btnSelectFile.Size = new Size(100, 30);
        this.btnSelectFile.TabIndex = 0;
        this.btnSelectFile.Text = "选择文件";
        this.btnSelectFile.UseVisualStyleBackColor = true;
        this.btnSelectFile.Click += new EventHandler(this.BtnSelectFile_Click);
        // 
        // txtFilePath
        // 
        this.txtFilePath.Location = new Point(130, 22);
        this.txtFilePath.Name = "txtFilePath";
        this.txtFilePath.Size = new Size(530, 25);
        this.txtFilePath.TabIndex = 1;
        this.txtFilePath.ReadOnly = true;
        // 
        // lblAlgorithm
        // 
        this.lblAlgorithm.AutoSize = true;
        this.lblAlgorithm.Location = new Point(20, 70);
        this.lblAlgorithm.Name = "lblAlgorithm";
        this.lblAlgorithm.Size = new Size(68, 18);
        this.lblAlgorithm.TabIndex = 2;
        this.lblAlgorithm.Text = "选择算法：";
        // 
        // cboAlgorithm
        // 
        this.cboAlgorithm.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboAlgorithm.FormattingEnabled = true;
        this.cboAlgorithm.Items.AddRange(new object[] {
            "MD5",
            "SHA1",
            "SHA256",
            "SHA384",
            "SHA512"
        });
        this.cboAlgorithm.Location = new Point(94, 68);
        this.cboAlgorithm.Name = "cboAlgorithm";
        this.cboAlgorithm.Size = new Size(150, 26);
        this.cboAlgorithm.TabIndex = 3;
        this.cboAlgorithm.SelectedIndex = 2; // 默认选择 SHA256
        // 
        // btnCalculate
        // 
        this.btnCalculate.Location = new Point(20, 120);
        this.btnCalculate.Name = "btnCalculate";
        this.btnCalculate.Size = new Size(100, 30);
        this.btnCalculate.TabIndex = 4;
        this.btnCalculate.Text = "计算校验和";
        this.btnCalculate.UseVisualStyleBackColor = true;
        this.btnCalculate.Click += new EventHandler(this.BtnCalculate_Click);
        // 
        // lblResult
        // 
        this.lblResult.AutoSize = true;
        this.lblResult.Location = new Point(20, 170);
        this.lblResult.Name = "lblResult";
        this.lblResult.Size = new Size(92, 18);
        this.lblResult.TabIndex = 5;
        this.lblResult.Text = "校验和结果：";
        // 
        // txtResult
        // 
        this.txtResult.Location = new Point(20, 195);
        this.txtResult.Multiline = true;
        this.txtResult.Name = "txtResult";
        this.txtResult.ReadOnly = true;
        this.txtResult.ScrollBars = ScrollBars.Vertical;
        this.txtResult.Size = new Size(540, 150);
        this.txtResult.TabIndex = 6;
        this.txtResult.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
        // 
        // btnCopy
        // 
        this.btnCopy.Location = new Point(570, 195);
        this.btnCopy.Name = "btnCopy";
        this.btnCopy.Size = new Size(90, 30);
        this.btnCopy.TabIndex = 7;
        this.btnCopy.Text = "复制结果";
        this.btnCopy.UseVisualStyleBackColor = true;
        this.btnCopy.Click += new EventHandler(this.BtnCopy_Click);
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new SizeF(7F, 18F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(680, 370);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.MaximizeBox = false;
        this.Controls.Add(this.btnCopy);
        this.Controls.Add(this.txtResult);
        this.Controls.Add(this.lblResult);
        this.Controls.Add(this.btnCalculate);
        this.Controls.Add(this.cboAlgorithm);
        this.Controls.Add(this.lblAlgorithm);
        this.Controls.Add(this.txtFilePath);
        this.Controls.Add(this.btnSelectFile);
        this.Name = "Form1";
        this.Text = "文件校验和计算器";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private Button btnSelectFile;
    private TextBox txtFilePath;
    private Label lblAlgorithm;
    private ComboBox cboAlgorithm;
    private Button btnCalculate;
    private Label lblResult;
    private TextBox txtResult;
    private Button btnCopy;

    #endregion
}
