using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEMOApp
{
    public partial class ChangePassword : Form
    {
        string _userId = string.Empty;
        string _userPassword = string.Empty;

        bool _isCanChangePassword = true;
        public ChangePassword()
        {
            InitializeComponent();
        }
        public void GetUserInfo(string id,string password)
        {
            _userId = id;
            _userPassword = password;
        }
        private void CurrentPaswordTextChange(object sender, EventArgs e)
        {
            if (currentPasText.Text == newPasText.Text)
            {
                errorLabel.Text = "Текущий пароль не может совпадат с новым";
                _isCanChangePassword = false;
            }
            else
            {
                errorLabel.Text = "";
                _isCanChangePassword = true;
            }
        }
        private void NewPaswordTextChange(object sender, EventArgs e)
        {
            if (newPasText.Text == currentPasText.Text)
            {
                errorLabel.Text = "Текущий пароль не может совпадат с новым";
                _isCanChangePassword = false;
            }
            else
            {
                errorLabel.Text = "";
                _isCanChangePassword = true;
            }
        }
        private void ConfirmPaswordTextChange(object sender, EventArgs e)
        {
            if (newPasText.Text != confirmPasswordText.Text)
            {
                errorLabel2.Text = "Новый пароль и подтверждение пароля должны совпадать";
                _isCanChangePassword = false;
            }
            else
            {
                errorLabel2.Text = "";
                _isCanChangePassword = true;
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            currentPasText.Text = _userPassword;
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            if (_isCanChangePassword) 
            {
                using(SqlConnection con = new SqlConnection(ConnectionString.conString))
                {
                    con.Open();
                    using(SqlCommand cmd = new SqlCommand("update users set пароль = @pas where id =@id", con))
                    {
                        cmd.Parameters.Add("@pas",SqlDbType.NVarChar).Value = newPasText.Text;
                        cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = _userId;
                        try
                        {
                            int changedRows = cmd.ExecuteNonQuery();
                            if (changedRows > 0)
                            {
                                MessageBox.Show("Пароль изменен", "Ура!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Блин", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                }
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            EditInfo edit = new EditInfo();
            edit.Show();
        }
    }
}
