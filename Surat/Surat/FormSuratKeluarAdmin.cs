using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.IO;

namespace Surat
{
    public partial class FormSuratKeluarAdmin : DevComponents.DotNetBar.OfficeForm
    {
        private string kriteria, cari;
        public static string nomor_surat;
        public static string status;

        public FormSuratKeluarAdmin()
        {
            InitializeComponent();
        }

        public void setDataTable(MySqlDataReader reader)
        {
            DataTable jenis_surat = new DataTable();
            jenis_surat.Load(reader);
            jenis_surat.Columns[0].ColumnName = "Nomor Urut";
            jenis_surat.Columns[1].ColumnName = "Nomor Surat";
            jenis_surat.Columns[2].ColumnName = "Tanggal Surat";
            jenis_surat.Columns[3].ColumnName = "Perihal";
            jenis_surat.Columns[4].ColumnName = "Jenis Surat";
            jenis_surat.Columns[5].ColumnName = "Sifat Surat";

            dataGridViewSuratKeluar.ClearSelection();
            dataGridViewSuratKeluar.DataSource = jenis_surat;

            dataGridViewSuratKeluar.AutoResizeColumns();
            labelJumlahSurat.Text = "Jumlah Surat Keluar : "+dataGridViewSuratKeluar.RowCount.ToString();
        }

        private void FormSuratKeluar_Load(object sender, EventArgs e)
        {
            suratKeluar surat_keluar = new suratKeluar();
            setDataTable(surat_keluar.getAllSuratKeluar());
            kriteria = "nomor_surat_keluar";
        }

        private void radioButtonNomorSuratKeluar_CheckedChanged(object sender, EventArgs e)
        {
            suratKeluar surat_keluar = new suratKeluar();
            dateTimeInputSuratKeluar.SendToBack();
            textBoxCariSuratKeluar.BringToFront();
            kriteria = "nomor_surat_keluar";
            setDataTable(surat_keluar.getAllSuratKeluar());
        }

        private void radioButtonPerihalSuratKeluar_CheckedChanged(object sender, EventArgs e)
        {
            suratKeluar surat_keluar = new suratKeluar();
            dateTimeInputSuratKeluar.SendToBack();
            textBoxCariSuratKeluar.BringToFront();
            kriteria = "perihal";
            setDataTable(surat_keluar.getAllSuratKeluar());
        }

        private void textBoxCariSuratKeluar_TextChanged(object sender, EventArgs e)
        {
            suratKeluar surat_keluar = new suratKeluar();
            string cari;
            cari = textBoxCariSuratKeluar.Text;
            setDataTable(surat_keluar.cariSuratKeluar(kriteria, cari));
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuratKeluar_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMainAdmin form_main = new FormMainAdmin();
            form_main.Show();
        }

        private void dataGridViewSuratKeluar_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewSuratKeluar.SelectedRows)
            {
                nomor_surat = row.Cells[1].Value.ToString();
            }
        }

        private void radioButtonTanggal_CheckedChanged(object sender, EventArgs e)
        {
            suratKeluar surat_keluar = new suratKeluar();
            kriteria = "tanggal_surat";
            textBoxCariSuratKeluar.SendToBack();
            dateTimeInputSuratKeluar.BringToFront();
            setDataTable(surat_keluar.getAllSuratKeluar());
        }

        private void dateTimeInputSuratKeluar_MonthCalendar_DateChanged(object sender, EventArgs e)
        {
            suratKeluar surat_keluar = new suratKeluar();
            cari = dateTimeInputSuratKeluar.Value.Date.ToString("yyyy-MM-dd");
            setDataTable(surat_keluar.cariSuratKeluar(kriteria, cari));
        }

        private void buttondetailsuratkeluar_Click(object sender, EventArgs e)
        {
            FormDetailSuratKeluar detail = new FormDetailSuratKeluar();
            detail.Show();
        }
       
    }
}