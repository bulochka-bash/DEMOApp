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
using Microsoft.Office.Interop.Word;

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
        {
            string path = "http://localhost:4444/TransferSimulator/fullName";
            string outputJson = await GetName(path);
            UserName name = JsonSerializer.Deserialize<UserName>(outputJson);

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
                SaveFile();
            }
            else
            {
                MessageBox.Show("ФИО неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                wrongNameLabel.Text = "ФИО содержит запрещенные символы";
            }
        }
        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export To Word";
            saveFileDialog.Filter = "To Word (Word)|*.docx";
            saveFileDialog.FileName = "tables";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateWordFile(saveFileDialog.FileName);
            }
        }
        private void CreateWordFile(string fileName)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document wordDocument = wordApp.Documents.Add();

            Microsoft.Office.Interop.Word.Paragraph paragraph =  wordDocument.Paragraphs.Add();
            Microsoft.Office.Interop.Word.Range range = paragraph.Range;

            range.Text = name.Text;
            wordDocument.SaveAs2(fileName);
            wordDocument.Close();
            wordApp.Quit();
        }
        
    }
    public class UserName
    {
        public string value { get; set; }
    }
}
