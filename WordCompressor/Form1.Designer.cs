partial class Form1
{
    private void InitializeComponent()
    {
        btnSelectFile = new Button();
        txtFilePath = new TextBox();
        trackBarCompression = new TrackBar();
        lblCompression = new Label();
        btnCompress = new Button();
        ((System.ComponentModel.ISupportInitialize)trackBarCompression).BeginInit();
        SuspendLayout();
        // 
        // btnSelectFile
        // 
        btnSelectFile.Location = new Point(20, 20);
        btnSelectFile.Name = "btnSelectFile";
        btnSelectFile.Size = new Size(75, 23);
        btnSelectFile.TabIndex = 0;
        btnSelectFile.Text = "选择文件";
        btnSelectFile.Click += btnSelectFile_Click;
        // 
        // txtFilePath
        // 
        txtFilePath.Location = new Point(120, 20);
        txtFilePath.Name = "txtFilePath";
        txtFilePath.ReadOnly = true;
        txtFilePath.Size = new Size(400, 23);
        txtFilePath.TabIndex = 1;
        // 
        // trackBarCompression
        // 
        trackBarCompression.Location = new Point(20, 60);
        trackBarCompression.Maximum = 100;
        trackBarCompression.Name = "trackBarCompression";
        trackBarCompression.Size = new Size(500, 45);
        trackBarCompression.TabIndex = 2;
        trackBarCompression.Value = 50;
        // 
        // lblCompression
        // 
        lblCompression.Location = new Point(20, 108);
        lblCompression.Name = "lblCompression";
        lblCompression.Size = new Size(100, 37);
        lblCompression.TabIndex = 3;
        lblCompression.Text = "压缩率 (0-100)";
        // 
        // btnCompress
        // 
        btnCompress.Location = new Point(20, 159);
        btnCompress.Name = "btnCompress";
        btnCompress.Size = new Size(75, 23);
        btnCompress.TabIndex = 4;
        btnCompress.Text = "开始压缩";
        btnCompress.Click += btnCompress_Click;
        // 
        // Form1
        // 
        ClientSize = new Size(584, 261);
        Controls.Add(btnSelectFile);
        Controls.Add(txtFilePath);
        Controls.Add(trackBarCompression);
        Controls.Add(lblCompression);
        Controls.Add(btnCompress);
        Name = "Form1";
        Text = "Word文档图片压缩工具";
        ((System.ComponentModel.ISupportInitialize)trackBarCompression).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Button btnSelectFile;
    private TextBox txtFilePath;
    private TrackBar trackBarCompression;
    private Label lblCompression;
    private Button btnCompress;
}