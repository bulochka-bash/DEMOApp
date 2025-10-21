namespace api_transfer
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
            this.BtnGet = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.CheckName = new System.Windows.Forms.Button();
            this.wrongNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnGet
            // 
            this.BtnGet.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnGet.Location = new System.Drawing.Point(160, 159);
            this.BtnGet.Name = "BtnGet";
            this.BtnGet.Size = new System.Drawing.Size(275, 45);
            this.BtnGet.TabIndex = 0;
            this.BtnGet.Text = "Получить данные";
            this.BtnGet.UseVisualStyleBackColor = true;
            this.BtnGet.Click += new System.EventHandler(this.button1_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name.Location = new System.Drawing.Point(500, 169);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(0, 25);
            this.name.TabIndex = 1;
            // 
            // CheckName
            // 
            this.CheckName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckName.Location = new System.Drawing.Point(160, 224);
            this.CheckName.Name = "CheckName";
            this.CheckName.Size = new System.Drawing.Size(275, 44);
            this.CheckName.TabIndex = 2;
            this.CheckName.Text = "Отправить результат теста";
            this.CheckName.UseVisualStyleBackColor = true;
            this.CheckName.Click += new System.EventHandler(this.CheckName_Click);
            // 
            // isWrongName
            // 
            this.wrongNameLabel.AutoSize = true;
            this.wrongNameLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wrongNameLabel.Location = new System.Drawing.Point(503, 233);
            this.wrongNameLabel.Name = "isWrongName";
            this.wrongNameLabel.Size = new System.Drawing.Size(0, 25);
            this.wrongNameLabel.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wrongNameLabel);
            this.Controls.Add(this.CheckName);
            this.Controls.Add(this.name);
            this.Controls.Add(this.BtnGet);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGet;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button CheckName;
        private System.Windows.Forms.Label wrongNameLabel;
    }
}

