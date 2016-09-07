using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Collections.Generic;

namespace Surat
{
    public partial class FormSuratMasukAdmin : DevComponents.DotNetBar.OfficeForm
    {
        private string kriteria;
        public static string nomor_surat, cari;
        public static string status;

        public FormSuratMasukAdmin()
        {
            InitializeComponent();
        }

        public void setDataTable(MySqlDataReader reader)
        {
            DataTable jenis_surat = new DataTable();
            suratMasuk surat_masuk = new suratMasuk();
            jenis_surat.Load(reader);
            jenis_surat.Columns[0].ColumnName = "Nomor Urut";
            jenis_surat.Columns[1].ColumnName = "Nomor Surat";
            jenis_surat.Columns[2].ColumnName = "Tanggal Surat";
            jenis_surat.Columns[3].ColumnName = "Tanggal Terima";
            jenis_surat.Columns[4].ColumnName = "Perihal";
            jenis_surat.Columns[5].ColumnName = "Pengirim";
            jenis_surat.Columns[6].ColumnName = "Sifat Surat";
            jenis_surat.Columns[7].ColumnName = "Jenis Surat";

            dataGridViewSuratMasuk.ClearSelection();
            dataGridViewSuratMasuk.DataSource = jenis_surat;
            dataGridViewSuratMasuk.AutoResizeColumns();
            labelJumlahSurat.Text = "Jumlah Surat Masuk : "+dataGridViewSuratMasuk.RowCount.ToString();
        }

        private void FormSuratMasuk_Load(object sender, EventArgs e)
        {
            suratMasuk surat_masuk = new suratMasuk();
            setDataTable(surat_masuk.getAllSuratMasuk());
            kriteria = "nomor_surat_masuk";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            kriteria = "nomor_surat_masuk";
            textBoxCariSuratMasuk.BringToFront();
            suratMasuk surat_masuk = new suratMasuk();
            setDataTable(surat_masuk.getAllSuratMasuk());
        }

        private void radioButtonPerihalSuratMasuk_CheckedChanged(object sender, EventArgs e)
        {
            kriteria = "perihal";
            textBoxCariSuratMasuk.BringToFront();
            suratMasuk surat_masuk = new suratMasuk();
            setDataTable(surat_masuk.getAllSuratMasuk());
        }

        private void radioButtonInstansiPengirim_CheckedChanged(object sender, EventArgs e)
        {
            kriteria = "pengirim";
            textBoxCariSuratMasuk.BringToFront();
            suratMasuk surat_masuk = new suratMasuk();
            setDataTable(surat_masuk.getAllSuratMasuk());
        }

        private void textBoxCariSuratMasuk_TextChanged(object sender, EventArgs e)
        {
            cari = textBoxCariSuratMasuk.Text;
            suratMasuk surat_masuk = new suratMasuk();
            setDataTable(surat_masuk.cariSuratMasuk(kriteria, cari));
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormSuratMasuk_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMainAdmin form_main = new FormMainAdmin();
            form_main.Show();
        }

        private void dataGridViewSuratMasuk_SelectionChanged(object sender, EventArgs e)
        {
            suratMasuk surat_masuk = new suratMasuk();
            foreach (DataGridViewRow row in dataGridViewSuratMasuk.SelectedRows)
            {
                 nomor_surat = row.Cells[1].Value.ToString();
            }
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            FormSuratMasukDetail form_detail = new FormSuratMasukDetail();
            status = "Detail";
            form_detail.ShowDialog();
        }

        private void radioButtonTanggalSurat_CheckedChanged(object sender, EventArgs e)
        {
            kriteria = "tanggal_surat";
            textBoxCariSuratMasuk.SendToBack();
            dateTimeInputTanggalSurat.BringToFront();
            suratMasuk surat_masuk = new suratMasuk();
            setDataTable(surat_masuk.getAllSuratMasuk());
        }

        private void dateTimeInput1_MonthCalendar_DateChanged(object sender, EventArgs e)
        {
            cari = dateTimeInputTanggalSurat.Value.Date.ToString("yyyy-MM-dd");
            suratMasuk surat_masuk = new suratMasuk();
            setDataTable(surat_masuk.cariSuratMasuk(kriteria, cari));
        }

        private void radioButtonTanggalTerima_CheckedChanged(object sender, EventArgs e)
        {
            kriteria = "tanggal_terima";
            textBoxCariSuratMasuk.SendToBack();
            dateTimeInputTanggalSurat.BringToFront();
            suratMasuk surat_masuk = new suratMasuk();
            setDataTable(surat_masuk.getAllSuratMasuk());
        }
    }
}