using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Surat
{
    public partial class FormTambahUser : DevComponents.DotNetBar.OfficeForm
    {
        private readonly FormUser frm2;
        public FormTambahUser(FormUser frm)
        {
            InitializeComponent();
            frm2 = frm;
        }

        private bool cekValid()
        {
            bool error = false;
            if (txtBoxusername.Text == "")
            {
                error = true;
                MessageBox.Show("Username harus diisi. Proses peyimpanan data dibatalkan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtBoxnama.Text == "")
            {
                error = true;
                MessageBox.Show("Nama harus diisi. Proses peyimpanan data dibatalkan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtBoxpassword.Text == "")
            {
                error = true;
                MessageBox.Show("Password harus diisi. Proses peyimpanan data dibatalkan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxPasswordLagi.Text == "")
            {
                error = true;
                MessageBox.Show("Password harus diisi. Proses peyimpanan data dibatalkan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxPasswordLagi.Text != txtBoxpassword.Text)
            {
                error = true;
                MessageBox.Show("Password yang diisikan tidak sama dengan password yang diisikan lainnya. Proses peyimpanan data dibatalkan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return error;
        }
        
        private void ButtonKembaliTambahUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSimpanTambah_Click(object sender, EventArgs e)
        {
            user u = new user();
            user.hak_akses = comboBoxHakAkses.GetItemText(comboBoxHakAkses.SelectedItem);
            u.username = txtBoxusername.Text;
            u.nama = txtBoxnama.Text;
            u.password = txtBoxpassword.Text;

            if (cekValid())
            {
                return;
            }
            else
            {
                u.tambahUser();
                frm2.setDataTable(u.getAllUser());
            }
        }

        private void FormTambahUser_Load(object sender, EventArgs e)
        {
            comboBoxHakAkses.SelectedIndex = 0;
        }
    }
}