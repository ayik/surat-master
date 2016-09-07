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
    public partial class FormKlasifikasiSurat : DevComponents.DotNetBar.OfficeForm
    {
        public string id_jenis, nama_jenis;
 
        public FormKlasifikasiSurat()
        {
            InitializeComponent();
        }

        public void loadComboBox()
        {
            JenisSurat jenis_surat = new JenisSurat();
            DataTable tabel = new DataTable();
            tabel.Load(jenis_surat.getAllJenisSurat());
            List<string> jenis = new List<string>();
            comboBoxJenisSurat.Items.Clear();
            for (int i = 0; i < tabel.Rows.Count; i++)
            {
                comboBoxJenisSurat.Items.Add(tabel.Rows[i][1].ToString());
            }
        }

        public void setDataTable(MySqlDataReader reader)
        {
            DataTable jenis_surat = new DataTable();
            jenis_surat.Load(reader);
            jenis_surat.Columns[0].ColumnName = "ID Jenis Surat";
            jenis_surat.Columns[1].ColumnName = "Jenis Surat";

            dataGridViewJenisSurat.ClearSelection();
            dataGridViewJenisSurat.DataSource = jenis_surat;
        }

        private void FormKlasifikasiSurat_Load(object sender, EventArgs e)
        {
            JenisSurat jenis_surat = new JenisSurat();
            setDataTable(jenis_surat.getAllJenisSurat());
            //comboBoxJenisSurat.SelectedIndex = 0;
            loadComboBox();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormKlasifikasiSuratTambah formTambah = new FormKlasifikasiSuratTambah(this);
            formTambah.ShowDialog();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            JenisSurat jenis_surat = new JenisSurat();
            setDataTable(jenis_surat.cariJenisSurat(textBoxCari.Text));
        }

        private void dataGridViewJenisSurat_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewJenisSurat.SelectedRows)
            {
                id_jenis = row.Cells[0].Value.ToString();
                nama_jenis = row.Cells[1].Value.ToString();
            }
        }

        private void buttonEditJenisSurat_Click(object sender, EventArgs e)
        {
            FormKlasifikasiSuratEdit form = new FormKlasifikasiSuratEdit(id_jenis, nama_jenis, this);
            form.ShowDialog();
        }

        private void buttonHapusJenisSurat_Click(object sender, EventArgs e)
        {
            JenisSurat jenis_surat = new JenisSurat();
            string title = "Konfirmasi Penghapusan Data";
            string konten = "Apakah Anda yakin ingin menghapus data?";

            DialogResult result = MessageBox.Show(konten, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                jenis_surat.hapusJenisSurat(id_jenis);
                setDataTable(jenis_surat.getAllJenisSurat());
                loadComboBox();
            }
        }

        private void comboBoxJenisSurat_SelectedIndexChanged(object sender, EventArgs e)
        {
            JenisSurat jenis_surat = new JenisSurat();
            setDataTable(jenis_surat.cariJenisSurat(comboBoxJenisSurat.GetItemText(comboBoxJenisSurat.SelectedItem)));
        }

        private void comboBoxJenisSurat_TextChanged(object sender, EventArgs e)
        {
            JenisSurat jenis_surat = new JenisSurat();
            setDataTable(jenis_surat.cariJenisSurat(comboBoxJenisSurat.Text));
        }

        private void FormKlasifikasiSurat_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (user.hak_akses == "admin")
            {
                FormMainAdmin form_main = new FormMainAdmin();
                form_main.Show();
            }
            else
            {
                FormMain form_main = new FormMain();
                form_main.Show();
            }
        }
    }
}