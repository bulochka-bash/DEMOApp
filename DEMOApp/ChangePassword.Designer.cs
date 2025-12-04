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
            this.changeBtn = new System.Windows.Forms.Button();
            this.currentPasText = new System.Windows.Forms.TextBox();
            this.newPasLabel = new System.Windows.Forms.Label();
            this.newPasText = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.errorLabel2 = new System.Windows.Forms.Label();
            this.Edit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // confirmPasLabel
            // 
            this.confirmPasLabel.AutoSize = true;
            this.confirmPasLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.confirmPasLabel.ForeColor = System.Drawing.Color.White;
            this.confirmPasLabel.Location = new System.Drawing.Point(62, 320);
            this.confirmPasLabel.Name = "confirmPasLabel";
            this.confirmPasLabel.Size = new System.Drawing.Size(261, 30);
            this.confirmPasLabel.TabIndex = 9;
            this.confirmPasLabel.Text = "Подтверждение пароля";
            // 
            // confirmPasswordText
            // 
            this.confirmPasswordText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.confirmPasswordText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirmPasswordText.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.confirmPasswordText.ForeColor = System.Drawing.Color.White;
            this.confirmPasswordText.Location = new System.Drawing.Point(67, 353);
            this.confirmPasswordText.Name = "confirmPasswordText";
            this.confirmPasswordText.Size = new System.Drawing.Size(245, 35);
            this.confirmPasswordText.TabIndex = 8;
            this.confirmPasswordText.TextChanged += new System.EventHandler(this.ConfirmPaswordTextChange);
            // 
            // currentPasLabel
            // 
            this.currentPasLabel.AutoSize = true;
            this.currentPasLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.currentPasLabel.ForeColor = System.Drawing.Color.White;
            this.currentPasLabel.Location = new System.Drawing.Point(62, 144);
            this.currentPasLabel.Name = "currentPasLabel";
            this.currentPasLabel.Size = new System.Drawing.Size(183, 30);
            this.currentPasLabel.TabIndex = 7;
            this.currentPasLabel.Text = "Текущий пароль";
            // 
            // changeBtn
            // 
            this.changeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(41)))), ((int)(((byte)(120)))));
            this.changeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changeBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.changeBtn.ForeColor = System.Drawing.Color.White;
            this.changeBtn.Location = new System.Drawing.Point(67, 404);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(245, 63);
            this.changeBtn.TabIndex = 6;
            this.changeBtn.Text = "Сменить пароль";
            this.changeBtn.UseVisualStyleBackColor = false;
            this.changeBtn.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // currentPasText
            // 
            this.currentPasText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.currentPasText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentPasText.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.currentPasText.Location = new System.Drawing.Point(67, 177);
            this.currentPasText.Name = "currentPasText";
            this.currentPasText.Size = new System.Drawing.Size(245, 35);
            this.currentPasText.TabIndex = 5;
            this.currentPasText.TextChanged += new System.EventHandler(this.CurrentPaswordTextChange);
            // 
            // newPasLabel
            // 
            this.newPasLabel.AutoSize = true;
            this.newPasLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.newPasLabel.ForeColor = System.Drawing.Color.White;
            this.newPasLabel.Location = new System.Drawing.Point(62, 215);
            this.newPasLabel.Name = "newPasLabel";
            this.newPasLabel.Size = new System.Drawing.Size(165, 30);
            this.newPasLabel.TabIndex = 11;
            this.newPasLabel.Text = "Новый пароль";
            // 
            // newPasText
            // 
            this.newPasText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.newPasText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newPasText.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.newPasText.ForeColor = System.Drawing.Color.White;
            this.newPasText.Location = new System.Drawing.Point(67, 250);
            this.newPasText.Name = "newPasText";
            this.newPasText.Size = new System.Drawing.Size(245, 35);
            this.newPasText.TabIndex = 10;
            this.newPasText.TextChanged += new System.EventHandler(this.NewPaswordTextChange);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorLabel.Location = new System.Drawing.Point(452, 108);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 25);
            this.errorLabel.TabIndex = 12;
            // 
            // errorLabel2
            // 
            this.errorLabel2.AutoSize = true;
            this.errorLabel2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorLabel2.Location = new System.Drawing.Point(452, 218);
            this.errorLabel2.Name = "errorLabel2";
            this.errorLabel2.Size = new System.Drawing.Size(0, 25);
            this.errorLabel2.TabIndex = 13;
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(41)))), ((int)(((byte)(120)))));
            this.Edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Edit.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.Edit.ForeColor = System.Drawing.Color.White;
            this.Edit.Location = new System.Drawing.Point(67, 484);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(245, 77);
            this.Edit.TabIndex = 14;
            this.Edit.Text = "Редактирование данных";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.currentPasLabel);
            this.panel1.Controls.Add(this.Edit);
            this.panel1.Controls.Add(this.currentPasText);
            this.panel1.Controls.Add(this.changeBtn);
            this.panel1.Controls.Add(this.confirmPasswordText);
            this.panel1.Controls.Add(this.newPasLabel);
            this.panel1.Controls.Add(this.confirmPasLabel);
            this.panel1.Controls.Add(this.newPasText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(30, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 592);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(50);
            this.panel2.Size = new System.Drawing.Size(393, 100);
            this.panel2.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 65);
            this.label1.TabIndex = 8;
            this.label1.Text = "Сброс пароля";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(453, 652);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.errorLabel2);
            this.Controls.Add(this.errorLabel);
            this.Name = "ChangePassword";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label confirmPasLabel;
        private System.Windows.Forms.TextBox confirmPasswordText;
        private System.Windows.Forms.Label currentPasLabel;
        private System.Windows.Forms.Button changeBtn;
        private System.Windows.Forms.TextBox currentPasText;
        private System.Windows.Forms.Label newPasLabel;
        private System.Windows.Forms.TextBox newPasText;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label errorLabel2;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}