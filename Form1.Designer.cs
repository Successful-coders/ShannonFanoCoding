namespace Encryption_Lab2
{
    partial class ShannonFano
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadAlphabetFile = new System.Windows.Forms.Button();
            this.loadProbabilityFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CompressButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.compressedTextBox = new System.Windows.Forms.TextBox();
            this.uncompressButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadAlphabetFile
            // 
            this.loadAlphabetFile.Location = new System.Drawing.Point(12, 12);
            this.loadAlphabetFile.Name = "loadAlphabetFile";
            this.loadAlphabetFile.Size = new System.Drawing.Size(158, 38);
            this.loadAlphabetFile.TabIndex = 0;
            this.loadAlphabetFile.Text = "Загрузить алфавит";
            this.loadAlphabetFile.UseVisualStyleBackColor = true;
            this.loadAlphabetFile.Click += new System.EventHandler(this.LoadAlphabetFile_Click);
            // 
            // loadProbabilityFile
            // 
            this.loadProbabilityFile.Location = new System.Drawing.Point(176, 12);
            this.loadProbabilityFile.Name = "loadProbabilityFile";
            this.loadProbabilityFile.Size = new System.Drawing.Size(158, 38);
            this.loadProbabilityFile.TabIndex = 1;
            this.loadProbabilityFile.Text = "Загрузить вероятности";
            this.loadProbabilityFile.UseVisualStyleBackColor = true;
            this.loadProbabilityFile.Click += new System.EventHandler(this.LoadProbabilityFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(466, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(322, 187);
            this.textBox1.TabIndex = 2;
            // 
            // CompressButton
            // 
            this.CompressButton.Location = new System.Drawing.Point(12, 344);
            this.CompressButton.Name = "CompressButton";
            this.CompressButton.Size = new System.Drawing.Size(322, 38);
            this.CompressButton.TabIndex = 3;
            this.CompressButton.Text = "Архивировать";
            this.CompressButton.UseVisualStyleBackColor = true;
            this.CompressButton.Click += new System.EventHandler(this.CompressButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите строку для сжатия:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // compressedTextBox
            // 
            this.compressedTextBox.Location = new System.Drawing.Point(12, 318);
            this.compressedTextBox.Name = "compressedTextBox";
            this.compressedTextBox.Size = new System.Drawing.Size(322, 20);
            this.compressedTextBox.TabIndex = 5;
            // 
            // uncompressButton
            // 
            this.uncompressButton.Location = new System.Drawing.Point(12, 388);
            this.uncompressButton.Name = "uncompressButton";
            this.uncompressButton.Size = new System.Drawing.Size(322, 38);
            this.uncompressButton.TabIndex = 6;
            this.uncompressButton.Text = "Разархивировать";
            this.uncompressButton.UseVisualStyleBackColor = true;
            this.uncompressButton.Click += new System.EventHandler(this.UncompressButton_Click);
            // 
            // ShannonFano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uncompressButton);
            this.Controls.Add(this.compressedTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CompressButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.loadProbabilityFile);
            this.Controls.Add(this.loadAlphabetFile);
            this.Name = "ShannonFano";
            this.Text = "Shannon-Fano compression";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button loadAlphabetFile;
        private System.Windows.Forms.Button loadProbabilityFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CompressButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox compressedTextBox;
        private System.Windows.Forms.Button uncompressButton;
    }
}

