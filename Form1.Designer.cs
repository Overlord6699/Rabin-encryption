
namespace WindowsFormsApp1
{
    partial class Form1
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
            this.InputTB = new System.Windows.Forms.TextBox();
            this.OutputTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OpenFile = new System.Windows.Forms.Button();
            this.SaveFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PTextBox = new System.Windows.Forms.TextBox();
            this.QTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Encrypt = new System.Windows.Forms.Button();
            this.Decrypt = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BTextBox = new System.Windows.Forms.TextBox();
            this.Generate = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OstBox = new System.Windows.Forms.TextBox();
            this.Swapbutton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SizeTB = new System.Windows.Forms.TextBox();
            this.Switch = new System.Windows.Forms.Button();
            this.SwitchLabel = new System.Windows.Forms.Label();
            this.BuferTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputTB
            // 
            this.InputTB.Location = new System.Drawing.Point(33, 273);
            this.InputTB.Multiline = true;
            this.InputTB.Name = "InputTB";
            this.InputTB.Size = new System.Drawing.Size(242, 149);
            this.InputTB.TabIndex = 0;
            // 
            // OutputTB
            // 
            this.OutputTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutputTB.Location = new System.Drawing.Point(359, 273);
            this.OutputTB.Multiline = true;
            this.OutputTB.Name = "OutputTB";
            this.OutputTB.Size = new System.Drawing.Size(242, 149);
            this.OutputTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ввод";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вывод";
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(170, 171);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(133, 42);
            this.OpenFile.TabIndex = 4;
            this.OpenFile.Text = "Открыть файл";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.Location = new System.Drawing.Point(320, 171);
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(133, 42);
            this.SaveFile.TabIndex = 5;
            this.SaveFile.Text = "Записать в файл";
            this.SaveFile.UseVisualStyleBackColor = true;
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Введите p:";
            // 
            // PTextBox
            // 
            this.PTextBox.Location = new System.Drawing.Point(79, 9);
            this.PTextBox.MaxLength = 50;
            this.PTextBox.Name = "PTextBox";
            this.PTextBox.Size = new System.Drawing.Size(253, 20);
            this.PTextBox.TabIndex = 7;
            // 
            // QTextBox
            // 
            this.QTextBox.Location = new System.Drawing.Point(79, 38);
            this.QTextBox.MaxLength = 50;
            this.QTextBox.Name = "QTextBox";
            this.QTextBox.Size = new System.Drawing.Size(253, 20);
            this.QTextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Введите q:";
            // 
            // Encrypt
            // 
            this.Encrypt.Location = new System.Drawing.Point(15, 171);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(133, 42);
            this.Encrypt.TabIndex = 10;
            this.Encrypt.Text = "Шифровать";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // Decrypt
            // 
            this.Decrypt.Location = new System.Drawing.Point(468, 171);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(133, 42);
            this.Decrypt.TabIndex = 11;
            this.Decrypt.Text = "Дешифровать";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Введите b(опционально):";
            // 
            // BTextBox
            // 
            this.BTextBox.Location = new System.Drawing.Point(79, 87);
            this.BTextBox.MaxLength = 50;
            this.BTextBox.Name = "BTextBox";
            this.BTextBox.Size = new System.Drawing.Size(253, 20);
            this.BTextBox.TabIndex = 13;
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(369, 26);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(130, 58);
            this.Generate.TabIndex = 14;
            this.Generate.Text = "Ввод";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // OstBox
            // 
            this.OstBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OstBox.Location = new System.Drawing.Point(546, 38);
            this.OstBox.Multiline = true;
            this.OstBox.Name = "OstBox";
            this.OstBox.Size = new System.Drawing.Size(242, 127);
            this.OstBox.TabIndex = 15;
            this.OstBox.Visible = false;
            // 
            // Swapbutton
            // 
            this.Swapbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Swapbutton.Location = new System.Drawing.Point(278, 309);
            this.Swapbutton.Name = "Swapbutton";
            this.Swapbutton.Size = new System.Drawing.Size(75, 48);
            this.Swapbutton.TabIndex = 16;
            this.Swapbutton.Text = "<--";
            this.Swapbutton.UseVisualStyleBackColor = true;
            this.Swapbutton.Click += new System.EventHandler(this.Swapbutton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(543, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Остатки:";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(642, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Байт\\число:";
            // 
            // SizeTB
            // 
            this.SizeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeTB.Location = new System.Drawing.Point(645, 289);
            this.SizeTB.Name = "SizeTB";
            this.SizeTB.Size = new System.Drawing.Size(38, 23);
            this.SizeTB.TabIndex = 19;
            this.SizeTB.Text = "1";
            // 
            // Switch
            // 
            this.Switch.Location = new System.Drawing.Point(635, 176);
            this.Switch.Name = "Switch";
            this.Switch.Size = new System.Drawing.Size(75, 32);
            this.Switch.TabIndex = 20;
            this.Switch.Text = "Mode";
            this.Switch.UseVisualStyleBackColor = true;
            this.Switch.Click += new System.EventHandler(this.Switch_Click);
            // 
            // SwitchLabel
            // 
            this.SwitchLabel.AutoSize = true;
            this.SwitchLabel.Location = new System.Drawing.Point(726, 186);
            this.SwitchLabel.Name = "SwitchLabel";
            this.SwitchLabel.Size = new System.Drawing.Size(28, 13);
            this.SwitchLabel.TabIndex = 21;
            this.SwitchLabel.Text = "Text";
            // 
            // BuferTB
            // 
            this.BuferTB.Location = new System.Drawing.Point(645, 357);
            this.BuferTB.Name = "BuferTB";
            this.BuferTB.Size = new System.Drawing.Size(50, 20);
            this.BuferTB.TabIndex = 22;
            this.BuferTB.Text = "10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(645, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Буфер:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BuferTB);
            this.Controls.Add(this.SwitchLabel);
            this.Controls.Add(this.Switch);
            this.Controls.Add(this.SizeTB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Swapbutton);
            this.Controls.Add(this.OstBox);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.BTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.QTextBox);
            this.Controls.Add(this.PTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SaveFile);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputTB);
            this.Controls.Add(this.InputTB);
            this.Name = "Form1";
            this.Text = "Рабин";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTB;
        private System.Windows.Forms.TextBox OutputTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button SaveFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PTextBox;
        private System.Windows.Forms.TextBox QTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox BTextBox;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox OstBox;
        private System.Windows.Forms.Button Swapbutton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox SizeTB;
        private System.Windows.Forms.Button Switch;
        private System.Windows.Forms.Label SwitchLabel;
        private System.Windows.Forms.TextBox BuferTB;
        private System.Windows.Forms.Label label8;
    }
}

