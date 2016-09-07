using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Surat
{
    public partial class FormMainAdmin : DevComponents.DotNetBar.OfficeForm
    {
        public FormMainAdmin()
        {
            InitializeComponent();
        }

        public static string id_user;

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            this.Hide();
            login.Show();
        }

        private void buttonKlasifikasiSurat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKlasifikasiSurat klasifikasi = new FormKlasifikasiSurat();
            klasifikasi.Show();
        }

        private void ButtonManajemenUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUser users = new FormUser();
            users.Show();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSuratMasukAdmin surat_masuk = new FormSuratMasukAdmin();
            surat_masuk.Show();
        }

        private void buttonSuratDisposisi_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSuratDisposisiAdmin form_disposisi = new FormSuratDisposisiAdmin();
            form_disposisi.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            id_user = FormLogin.id_user;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSuratKeluarAdmin keluar = new FormSuratKeluarAdmin();
            keluar.Show();   
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            FormBackup backup = new FormBackup();
            backup.Show();
            this.Hide();
        }
    }
}