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
                MessageBox.Show("ФИО верно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveWordFile("ФИО не содержит запрещенные символы");
            }
            else
            {
                MessageBox.Show("ФИО неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                wrongNameLabel.Text = "ФИО содержит запрещенные символы";
                SaveWordFile("ФИО содержит запрещенные символы");
            }
        }
        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export To Word";
            saveFileDialog.Filter = "To Word (Word)|*.docx";
            saveFileDialog.FileName = "word";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //SaveWordFile(saveFileDialog.FileName);
            }
        }
        private void SaveWordFile(string result)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Document document = wordApp.Documents.Open(OpenWord());

            int start = document.Bookmarks["start"].Start;
            int end = document.Bookmarks["end"].End;
            document.Bookmarks["end"].Delete();
            Range range = document.Range(start,end);
            range.Select();
            range.Font.Size = 14f;
            range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            range.Text = result;
            document.Bookmarks.Add("end", document.Range(range.End-1,range.End));
            document.Save();
            document.Close();
            wordApp.Quit();
        }
        private string OpenWord()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word files (*.docx)|*.docx";
            openFileDialog.Title = "Open word file";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
        
       
        
    
    public class UserName
    {
        public string value { get; set; }
    }

