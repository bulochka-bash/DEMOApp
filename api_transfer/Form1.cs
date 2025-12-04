using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace api_transfer
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }
        async private Task<string> GetName(string path)
        {
            string resp = "";
            HttpResponseMessage responce = await client.GetAsync(path);
            if (responce.IsSuccessStatusCode)
            {
                resp = await responce.Content.ReadAsStringAsync();
            }
            return resp;
        }

        async private void button1_Click(object sender, EventArgs e)
        {/// test
            string path = "http://localhost:4444/TransferSimulator/fullName";
            string outputJson = await GetName(path);
            UserName name =  JsonSerializer.Deserialize<UserName>(outputJson);
            
            this.name.Text = name.value;
        }
        private bool IsValidName(string name) 
        {
            char[] nameByChars = name.ToCharArray();
            foreach (char c in nameByChars)
            {
                
                if (!Char.IsLetter(c))
                {
                    if (Char.IsWhiteSpace(c))
                    {

                    }
                    else
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        }

        private void CheckName_Click(object sender, EventArgs e)
        {
            if (IsValidName(name.Text))
            {
                MessageBox.Show("ФИО верно","Успех",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ФИО неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                wrongNameLabel.Text = "ФИО содержит запрещенные символы";
            }
        }
        
    }
    public class UserName
    {
        public string value { get; set; }
    }
}
