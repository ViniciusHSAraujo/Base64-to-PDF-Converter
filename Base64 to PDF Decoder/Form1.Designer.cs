namespace Base64_to_PDF_Decoder
{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConverter = new System.Windows.Forms.Button();
            this.lblNomeArquivo = new System.Windows.Forms.Label();
            this.tbNomeDoArquivo = new System.Windows.Forms.TextBox();
            this.lblExtensaoPDF = new System.Windows.Forms.Label();
            this.lblHashDoPDF = new System.Windows.Forms.Label();
            this.tbBase64 = new System.Windows.Forms.TextBox();
            this.tbLocalArquivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chkLimparNome = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnConverter
            // 
            this.btnConverter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConverter.Location = new System.Drawing.Point(13, 456);
            this.btnConverter.Name = "btnConverter";
            this.btnConverter.Size = new System.Drawing.Size(776, 30);
            this.btnConverter.TabIndex = 3;
            this.btnConverter.Text = "Converter";
            this.btnConverter.UseVisualStyleBackColor = true;
            this.btnConverter.Click += new System.EventHandler(this.btnConverter_Click);
            // 
            // lblNomeArquivo
            // 
            this.lblNomeArquivo.AutoSize = true;
            this.lblNomeArquivo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNomeArquivo.Location = new System.Drawing.Point(12, 11);
            this.lblNomeArquivo.Name = "lblNomeArquivo";
            this.lblNomeArquivo.Size = new System.Drawing.Size(137, 21);
            this.lblNomeArquivo.TabIndex = 1;
            this.lblNomeArquivo.Text = "Nome do Arquivo:";
            // 
            // tbNomeDoArquivo
            // 
            this.tbNomeDoArquivo.Location = new System.Drawing.Point(155, 9);
            this.tbNomeDoArquivo.Name = "tbNomeDoArquivo";
            this.tbNomeDoArquivo.Size = new System.Drawing.Size(597, 23);
            this.tbNomeDoArquivo.TabIndex = 1;
            // 
            // lblExtensaoPDF
            // 
            this.lblExtensaoPDF.AutoSize = true;
            this.lblExtensaoPDF.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblExtensaoPDF.Location = new System.Drawing.Point(753, 11);
            this.lblExtensaoPDF.Name = "lblExtensaoPDF";
            this.lblExtensaoPDF.Size = new System.Drawing.Size(36, 21);
            this.lblExtensaoPDF.TabIndex = 1;
            this.lblExtensaoPDF.Text = ".pdf";
            // 
            // lblHashDoPDF
            // 
            this.lblHashDoPDF.AutoSize = true;
            this.lblHashDoPDF.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHashDoPDF.Location = new System.Drawing.Point(12, 83);
            this.lblHashDoPDF.Name = "lblHashDoPDF";
            this.lblHashDoPDF.Size = new System.Drawing.Size(121, 21);
            this.lblHashDoPDF.TabIndex = 3;
            this.lblHashDoPDF.Text = "Base 64 do PDF:";
            // 
            // tbBase64
            // 
            this.tbBase64.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbBase64.Location = new System.Drawing.Point(12, 107);
            this.tbBase64.MaxLength = 999999;
            this.tbBase64.Multiline = true;
            this.tbBase64.Name = "tbBase64";
            this.tbBase64.Size = new System.Drawing.Size(775, 321);
            this.tbBase64.TabIndex = 2;
            // 
            // tbLocalArquivo
            // 
            this.tbLocalArquivo.HideSelection = false;
            this.tbLocalArquivo.Location = new System.Drawing.Point(155, 49);
            this.tbLocalArquivo.Name = "tbLocalArquivo";
            this.tbLocalArquivo.ReadOnly = true;
            this.tbLocalArquivo.Size = new System.Drawing.Size(632, 23);
            this.tbLocalArquivo.TabIndex = 99;
            this.tbLocalArquivo.Click += new System.EventHandler(this.tbLocalArquivo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local dos arquivos:";
            // 
            // chkLimparNome
            // 
            this.chkLimparNome.AutoSize = true;
            this.chkLimparNome.Checked = true;
            this.chkLimparNome.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLimparNome.Location = new System.Drawing.Point(13, 433);
            this.chkLimparNome.Name = "chkLimparNome";
            this.chkLimparNome.Size = new System.Drawing.Size(167, 19);
            this.chkLimparNome.TabIndex = 100;
            this.chkLimparNome.Text = "Limpar o nome do arquivo";
            this.chkLimparNome.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.chkLimparNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLocalArquivo);
            this.Controls.Add(this.tbBase64);
            this.Controls.Add(this.lblHashDoPDF);
            this.Controls.Add(this.lblExtensaoPDF);
            this.Controls.Add(this.tbNomeDoArquivo);
            this.Controls.Add(this.lblNomeArquivo);
            this.Controls.Add(this.btnConverter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base64 to PDF Converter by ViniciusHSAraujo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConverter;
        private System.Windows.Forms.Label lblNomeArquivo;
        private System.Windows.Forms.TextBox tbNomeDoArquivo;
        private System.Windows.Forms.Label lblExtensaoPDF;
        private System.Windows.Forms.Label lblHashDoPDF;
        private System.Windows.Forms.TextBox tbBase64;
        private System.Windows.Forms.TextBox tbLocalArquivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox chkLimparNome;
    }
}

