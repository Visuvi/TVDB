using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TVDBAdder
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TvRegistration;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("TvAdd",sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Title",txtTitle.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Actor",txtActor.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Genre",txtGenre.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Released",txtReleased.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Duration",txtDuration.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Language",txtLanguage.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@DayAiring",txtAir.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@RetDate", txtRetDate.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Registration is Successful");
                Clear();
            }
        }

        void Clear()
        {
            txtTitle.Text = txtActor.Text = txtGenre.Text = txtReleased.Text = txtDuration.Text = txtLanguage.Text = txtAir.Text = txtRetDate.Text = "";
        }
    }
}
