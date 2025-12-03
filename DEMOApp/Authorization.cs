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
using WindowsFormsApp2;

namespace DEMOApp
{
    public partial class Authorization : Form
    {

        public static string login = string.Empty;
        public Authorization()
        {
            InitializeComponent();
        }

        async private void enterBtn_Click(object sender, EventArgs e)
        {
            if (IsLoginOrPassowordEmpty(loginText.Text,passwordText.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           using(SqlConnection con = ConnectionString.GetConnection())
           {
               con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Пользователи where логин =@log and пароль=@pas",con))
                {
                    cmd.Parameters.Add("@log",SqlDbType.NVarChar).Value= loginText.Text;
                    cmd.Parameters.Add("@pas", SqlDbType.NVarChar).Value = passwordText.Text;
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                login = loginText.Text;
                                while (reader.Read())
                                {
                                    
                                    string id = reader.GetValue(reader.GetOrdinal("id")).ToString();
                                    bool isBlocked = reader.GetBoolean(reader.GetOrdinal("isBlocked"));
                                    int wrongTriesToLog = reader.GetInt32(reader.GetOrdinal("количество_неправильных_попыток_входа"));
                                    if (!IsBlocked(wrongTriesToLog, isBlocked))
                                    {
                                        Captcha _captcha = new Captcha(wrongTriesToLog);
                                        bool isCapthcaSucces = await _captcha.IsCaptchaSucces();
                                        if (!isCapthcaSucces)
                                        {
                                            BlockAccountInDB(con, id);
                                            MessageBox.Show("Аккаунт заблокирован потому что вы 3 раза неправильно собрали каптчу", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        ChangeLastAuthDate(id, con);
                                        string role = reader.GetString(reader.GetOrdinal("должность"));
                                        MessageBox.Show("Все Норм", "Ура!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (role.Equals("Администратор"))
                                        {

                                            string password = reader.GetString(reader.GetOrdinal("пароль"));
                                            ChangePassword changePassword = new ChangePassword();
                                            changePassword.GetUserInfo(id, password);
                                            changePassword.Show();
                                        }
                                    }
                                    else
                                    {
                                        BlockAccountInDB(con, id);
                                        return;
                                    }
                                    
                                    
                                }
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                WrongTryToLog(con,login);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Блин", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
           }
        }
        private bool IsLoginOrPassowordEmpty(string login,string password)
        {
            if (string.IsNullOrEmpty(login)||string.IsNullOrEmpty(password))
            {
                return true;
            }
            return false;
        }
        public static void WrongTryToLog(SqlConnection con,string login)
        {
            using(SqlCommand cmd = new SqlCommand("select * from Пользователи where логин=@log", con))
            {
                cmd.Parameters.Add("@log", SqlDbType.NVarChar).Value = login;
                using (SqlDataReader reader2 = cmd.ExecuteReader())
                {
                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            int tries = reader2.GetInt32(reader2.GetOrdinal("количество_неправильных_попыток_входа"));
                            //if (IsBlocked(tries, false)) return;
                        }
                        using (SqlCommand cmd2 = new SqlCommand("update Пользователи set количество_неправильных_попыток_входа +=1 where логин =@log ", con))
                        {
                            reader2.Close();
                            cmd2.Parameters.Add("@log", SqlDbType.NVarChar).Value = login;
                            int changedRows = cmd2.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        MessageBox.Show("nuul");
                    }
                }
            }
        }
        public static bool IsBlocked(int wrongTries, bool isBlocked)
        {
            if (wrongTries >= 3 || isBlocked)
            {
                MessageBox.Show("Аккаунт заблокирован", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        private void BlockAccountInDB(SqlConnection con,string id)
        {
            using (SqlCommand cmd = new SqlCommand("update Пользователи set isBlocked = 1 where id=@id", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                int changedRows = cmd.ExecuteNonQuery();
            }
        }
        private bool CheckLastAuth(DateTime date)
        {
            DateTime inDB = date.AddMonths(1);
            if (inDB > DateTime.Now)
            {
                //
            }
            else
            {
                return true;
            }
            return false;
        }
        
        private void ChangeLastAuthDate(string id,SqlConnection con)
        {
            using (SqlCommand cmd = new SqlCommand("update Пользователи set дата_последнего_захода = @date where id=@id", con))
            {
                cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Today;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                int changedRows = cmd.ExecuteNonQuery();
            }
        }

        
        
       
     
        
       

    

        
        
        

            
    }
}
