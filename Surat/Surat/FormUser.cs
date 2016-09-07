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
    public partial class FormUser : DevComponents.DotNetBar.OfficeForm
    {
        public string id_user, username, password, nama;
        public FormUser()
        {
            InitializeComponent();
        }

        public void setDataTable(MySqlDataReader reader)
        {
            DataTable user = new DataTable();
            user.Load(reader);
            user.Columns[0].ColumnName = "ID User";
            user.Columns[1].ColumnName = "Username";
            user.Columns[2].ColumnName = "Nama";
            user.Columns[3].ColumnName = "Hak Akses";

            dataGridUser.ClearSelection();
            dataGridUser.DataSource = user;
        }

        private void ButtonTambahUser_Click(object sender, EventArgs e)
        {
            FormTambahUser tambahs = new FormTambahUser(this);
            tambahs.ShowDialog();
        }

        private void ButtonKembaliUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            user u = new user();
            setDataTable(u.getAllUser());
        }

        private void ButtonEditUser_Click(object sender, EventArgs e)
        {
            FormEditUser edits = new FormEditUser(id_user, username, nama, password, this);
            edits.Show();
        }

        private void dataGridUser_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridUser.SelectedRows)
            {
                id_user = row.Cells[0].Value.ToString();
                username = row.Cells[1].Value.ToString();
                //password = row.Cells[2].Value.ToString();
                nama = row.Cells[2].Value.ToString();
            }
        }

        private void ButtonHapusUser_Click(object sender, EventArgs e)
        {
            user u = new user();
            string title = "Konfirmasi Penghapusan Data";
            string konten = "Apakah Anda yakin ingin menghapus data?";

            DialogResult result = MessageBox.Show(konten, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                u.hapusUser(id_user);
                setDataTable(u.getAllUser());
            }
        }

        private void FormUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMainAdmin form_main = new FormMainAdmin();
            form_main.Show();
        }

        private void txtboxsearch_TextChanged(object sender, EventArgs e)
        {
            user u = new user();
            setDataTable(u.cariuser(txtboxsearch.Text));
        }
    }
}