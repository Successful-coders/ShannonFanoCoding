namespace Encryption_Lab2
{
    partial class ShannonFanoForm
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
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.CompressButton = new System.Windows.Forms.Button();
            this.compressedTextBox = new System.Windows.Forms.TextBox();
            this.uncompressButton = new System.Windows.Forms.Button();
            this.openProbabilites = new System.Windows.Forms.OpenFileDialog();
            this.openAlphabet = new System.Windows.Forms.OpenFileDialog();
            this.infoLabel = new System.Windows.Forms.Label();
            this.enterTextLabel = new System.Windows.Forms.Label();
            this.hamingButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(12, 97);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infoTextBox.Size = new System.Drawing.Size(322, 187);
            this.infoTextBox.TabIndex = 2;
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
            // openProbabilites
            // 
            this.openProbabilites.FileName = "Probabilities";
            this.openProbabilites.Filter = "Text files (*.txt)|*.txt";
            this.openProbabilites.Title = "Open probabilities file";
            // 
            // openAlphabet
            // 
            this.openAlphabet.FileName = "Alphabet";
            this.openAlphabet.Filter = "Text files (*.txt)|*.txt";
            this.openAlphabet.Title = "Open alphabet file";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(131, 73);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(109, 17);
            this.infoLabel.TabIndex = 7;
            this.infoLabel.Text = "Информация:";
            // 
            // enterTextLabel
            // 
            this.enterTextLabel.AutoSize = true;
            this.enterTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterTextLabel.Location = new System.Drawing.Point(110, 298);
            this.enterTextLabel.Name = "enterTextLabel";
            this.enterTextLabel.Size = new System.Drawing.Size(130, 17);
            this.enterTextLabel.TabIndex = 8;
            this.enterTextLabel.Text = "Введите строку:";
            // 
            // hamingButton
            // 
            this.hamingButton.Location = new System.Drawing.Point(12, 432);
            this.hamingButton.Name = "hamingButton";
            this.hamingButton.Size = new System.Drawing.Size(322, 38);
            this.hamingButton.TabIndex = 9;
            this.hamingButton.Text = "Кодирование методом Хэмминга";
            this.hamingButton.UseVisualStyleBackColor = true;
            this.hamingButton.Click += new System.EventHandler(this.HamingButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(322, 38);
            this.button1.TabIndex = 10;
            this.button1.Text = "Декодирование методом Хэмминга";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.UnHamingButton_Click);
            // 
            // ShannonFanoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 533);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hamingButton);
            this.Controls.Add(this.enterTextLabel);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.uncompressButton);
            this.Controls.Add(this.compressedTextBox);
            this.Controls.Add(this.CompressButton);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.loadProbabilityFile);
            this.Controls.Add(this.loadAlphabetFile);
            this.Name = "ShannonFanoForm";
            this.Text = "Shannon-Fano compression";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadAlphabetFile;
        private System.Windows.Forms.Button loadProbabilityFile;
        private System.Windows.Forms.TextBox infoTextBox;
        private System.Windows.Forms.Button CompressButton;
        private System.Windows.Forms.TextBox compressedTextBox;
        private System.Windows.Forms.Button uncompressButton;
        private System.Windows.Forms.OpenFileDialog openProbabilites;
        private System.Windows.Forms.OpenFileDialog openAlphabet;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label enterTextLabel;
        private System.Windows.Forms.Button hamingButton;
        private System.Windows.Forms.Button button1;
    }
}

