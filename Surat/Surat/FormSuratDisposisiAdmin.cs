using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using MySql.Data;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;

namespace Surat
{
    public partial class FormSuratDisposisiAdmin : DevComponents.DotNetBar.OfficeForm
    {
        private string kriteria, cari;
        public static string nomor_surat;
        

        public FormSuratDisposisiAdmin()
        {
            InitializeComponent();
        }

        public void setDataTable(MySqlDataReader reader)
        {
            DataTable disposisi = new DataTable();
            disposisi.Load(reader);
            disposisi.Columns[0].ColumnName = "Nomor Urut";
            disposisi.Columns[1].ColumnName = "Nomor Surat";
            disposisi.Columns[2].ColumnName = "Nomor Agenda";
            disposisi.Columns[3].ColumnName = "Tanggal Surat";
            disposisi.Columns[4].ColumnName = "Tanggal Diterima";
            disposisi.Columns[5].ColumnName = "Tanggal Diteruskan";
            disposisi.Columns[6].ColumnName = "Asal Surat";
            disposisi.Columns[7].ColumnName = "Perihal";
            disposisi.Columns[8].ColumnName = "Sifat Surat";
            //dataGridViewSuratDisposisi.ClearSelection();
            dataGridViewSuratDisposisi.DataSource = disposisi;
            labelJumlahSurat.Text = "Jumlah Surat Disposisi : " + dataGridViewSuratDisposisi.RowCount.ToString();
        }

        private void FormSuratDisposisi_FormClosed(object sender, FormClosedEventArgs e)
        {
                FormMainAdmin form_main = new FormMainAdmin();
                form_main.Show();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuratDisposisi_Load(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            kriteria = "nomor_surat";
            setDataTable(surat_disposisi.getAllSuratDisposisi());
        }

        private void radioButtonNomorSurat_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            kriteria = "nomor_surat";
            textBoxCari.BringToFront();
            setDataTable(surat_disposisi.getAllSuratDisposisi());
        }

        private void radioButtonNomorAgenda_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            kriteria = "nomor_agenda";
            textBoxCari.BringToFront();
            setDataTable(surat_disposisi.getAllSuratDisposisi());
        }

        private void radioButtonAsalSurat_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            kriteria = "asal";
            textBoxCari.BringToFront();
            setDataTable(surat_disposisi.getAllSuratDisposisi());
        }

        private void radioButtonPerihalSuratMasuk_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            kriteria = "perihal";
            textBoxCari.BringToFront();
            setDataTable(surat_disposisi.getAllSuratDisposisi());
        }

        private void radioButtonTanggalSurat_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            kriteria = "tanggal_surat";
            textBoxCari.SendToBack();
            dataGridViewSuratDisposisi.BringToFront();
            setDataTable(surat_disposisi.getAllSuratDisposisi());
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            cari = textBoxCari.Text;
            setDataTable(surat_disposisi.cariSuratDisposisi(kriteria, cari));
        }

        private void dateTimeInputTanggalSurat_MonthCalendar_DateChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            cari = dateTimeInputTanggalSurat.Value.Date.ToString("yyyy-MM-dd");
            //MessageBox.Show(cari);
            setDataTable(surat_disposisi.cariSuratDisposisi(kriteria, cari));
        }

        private void dataGridViewSuratDisposisi_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewSuratDisposisi.SelectedRows)
            {
                nomor_surat = row.Cells[1].Value.ToString();
            }
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            FormSuratDisposisiDetail form_detail = new FormSuratDisposisiDetail();
            form_detail.ShowDialog();
        }

        
        private void radioButtonTanggalTerima_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            kriteria = "tanggal_terima";
            textBoxCari.SendToBack();
            dataGridViewSuratDisposisi.BringToFront();
            setDataTable(surat_disposisi.getAllSuratDisposisi());
        }
    }
}