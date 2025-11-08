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

namespace ManajemenToko
{
    using static GlobalVariable;


    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        public static DateTime WaktuLogin;


        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                "SELECT Id, Username FROM [User] WHERE Username = @user AND Password = @pass", conn);
                cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    LoggedInUserId = Convert.ToInt32(reader["Id"]);
                    LoggedInUsername = reader["Username"].ToString();
                    FormMenuUtama formMenu = new FormMenuUtama();
                    this.Hide();
                    formMenu.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Login gagal. Cek username dan password.");
                }
            }

            WaktuLogin = DateTime.Now;
        }
    }
}
