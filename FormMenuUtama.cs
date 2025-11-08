using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManajemenToko
{
    using static GlobalVariable;
    public partial class FormMenuUtama : Form
    {

        public FormMenuUtama()
        {
            InitializeComponent();
        }

        private void FormMenuUtama_Load(object sender, EventArgs e)
        {
            lblHalo.Text = $"Halo, {LoggedInUsername}!";
            lblWaktuLogin.Text = $"Login pada: {FormLogin.WaktuLogin:dd MMM yyyy HH:mm:ss}";
            picProfile.Image = Properties.Resources.default_user;
            picProfile.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void btnProduk_Click(object sender, EventArgs e)
        {
            FormProdukUtama form = new FormProdukUtama();
            form.ShowDialog();
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            FormTransaksiPenjualan form = new FormTransaksiPenjualan();
            form.ShowDialog();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            FormLaporan form = new FormLaporan();
            form.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Konfirmasi logout
            DialogResult result = MessageBox.Show("Apakah kamu yakin ingin logout?",
                "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoggedInUserId = 0;
                LoggedInUsername = null;

                this.Hide();
                FormLogin formLogin = new FormLogin();
                formLogin.ShowDialog();
                this.Close();
            }
        }



        private void picProfile_Click(object sender, EventArgs e)
        {

        }
    }
}
