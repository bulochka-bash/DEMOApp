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
    public partial class EditInfo : Form
    {
        public EditInfo()
        {
            InitializeComponent();
        }

        private void EditInfo_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from users", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            dataTable.Load(reader);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
        }
        private void SaveChanges(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.conString))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    dataTable = dataGridView1.DataSource as DataTable;
                    using (SqlDataAdapter adapter = new SqlDataAdapter("select * from users", connection))
                    {
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                        adapter.Update(dataTable);
                        MessageBox.Show("Изменения сохранены", "Ура!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
