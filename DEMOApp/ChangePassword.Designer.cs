namespace DEMOApp
{
    partial class ChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.confirmPasLabel = new System.Windows.Forms.Label();
            this.confirmPasswordText = new System.Windows.Forms.TextBox();
            this.currentPasLabel = new System.Windows.Forms.Label();
            this.enterBtn = new System.Windows.Forms.Button();
            this.currentPasText = new System.Windows.Forms.TextBox();
            this.newPasLabel = new System.Windows.Forms.Label();
            this.newPasText = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.errorLabel2 = new System.Windows.Forms.Label();
            this.Edit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // confirmPasLabel
            // 
            this.confirmPasLabel.AutoSize = true;
            this.confirmPasLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirmPasLabel.Location = new System.Drawing.Point(171, 218);
            this.confirmPasLabel.Name = "confirmPasLabel";
            this.confirmPasLabel.Size = new System.Drawing.Size(220, 25);
            this.confirmPasLabel.TabIndex = 9;
            this.confirmPasLabel.Text = "Подтверждение пароля";
            // 
            // confirmPasswordText
            // 
            this.confirmPasswordText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirmPasswordText.Location = new System.Drawing.Point(176, 246);
            this.confirmPasswordText.Name = "confirmPasswordText";
            this.confirmPasswordText.Size = new System.Drawing.Size(215, 33);
            this.confirmPasswordText.TabIndex = 8;
            this.confirmPasswordText.TextChanged += new System.EventHandler(this.ConfirmPaswordTextChange);
            // 
            // currentPasLabel
            // 
            this.currentPasLabel.AutoSize = true;
            this.currentPasLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentPasLabel.Location = new System.Drawing.Point(171, 42);
            this.currentPasLabel.Name = "currentPasLabel";
            this.currentPasLabel.Size = new System.Drawing.Size(156, 25);
            this.currentPasLabel.TabIndex = 7;
            this.currentPasLabel.Text = "Текущий пароль";
            // 
            // enterBtn
            // 
            this.enterBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterBtn.Location = new System.Drawing.Point(176, 285);
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Size = new System.Drawing.Size(215, 43);
            this.enterBtn.TabIndex = 6;
            this.enterBtn.Text = "Войти";
            this.enterBtn.UseVisualStyleBackColor = true;
            this.enterBtn.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // currentPasText
            // 
            this.currentPasText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentPasText.Location = new System.Drawing.Point(176, 70);
            this.currentPasText.Name = "currentPasText";
            this.currentPasText.Size = new System.Drawing.Size(215, 33);
            this.currentPasText.TabIndex = 5;
            this.currentPasText.TextChanged += new System.EventHandler(this.CurrentPaswordTextChange);
            // 
            // newPasLabel
            // 
            this.newPasLabel.AutoSize = true;
            this.newPasLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newPasLabel.Location = new System.Drawing.Point(171, 115);
            this.newPasLabel.Name = "newPasLabel";
            this.newPasLabel.Size = new System.Drawing.Size(138, 25);
            this.newPasLabel.TabIndex = 11;
            this.newPasLabel.Text = "Новый пароль";
            // 
            // newPasText
            // 
            this.newPasText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newPasText.Location = new System.Drawing.Point(176, 143);
            this.newPasText.Name = "newPasText";
            this.newPasText.Size = new System.Drawing.Size(215, 33);
            this.newPasText.TabIndex = 10;
            this.newPasText.TextChanged += new System.EventHandler(this.NewPaswordTextChange);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorLabel.Location = new System.Drawing.Point(422, 78);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 25);
            this.errorLabel.TabIndex = 12;
            // 
            // errorLabel2
            // 
            this.errorLabel2.AutoSize = true;
            this.errorLabel2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorLabel2.Location = new System.Drawing.Point(422, 188);
            this.errorLabel2.Name = "errorLabel2";
            this.errorLabel2.Size = new System.Drawing.Size(0, 25);
            this.errorLabel2.TabIndex = 13;
            // 
            // Edit
            // 
            this.Edit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Edit.Location = new System.Drawing.Point(176, 377);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(215, 42);
            this.Edit.TabIndex = 14;
            this.Edit.Text = "Редактирование данных";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.errorLabel2);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.newPasLabel);
            this.Controls.Add(this.newPasText);
            this.Controls.Add(this.confirmPasLabel);
            this.Controls.Add(this.confirmPasswordText);
            this.Controls.Add(this.currentPasLabel);
            this.Controls.Add(this.enterBtn);
            this.Controls.Add(this.currentPasText);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label confirmPasLabel;
        private System.Windows.Forms.TextBox confirmPasswordText;
        private System.Windows.Forms.Label currentPasLabel;
        private System.Windows.Forms.Button enterBtn;
        private System.Windows.Forms.TextBox currentPasText;
        private System.Windows.Forms.Label newPasLabel;
        private System.Windows.Forms.TextBox newPasText;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label errorLabel2;
        private System.Windows.Forms.Button Edit;
    }
}