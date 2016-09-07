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
    public partial class FormSuratMasuk : DevComponents.DotNetBar.OfficeForm
    {
        private string query, strconn, kriteria;
        public static string nomor_surat, cari;
        public static string status;

        public FormSuratMasuk()
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

        private void buttonTambahSuratMasuk_Click(object sender, EventArgs e)
        {
            FormSuratMasukLampiran form_lampiran = new FormSuratMasukLampiran();
            status = "Tambah";
            FormSuratMasukTambah form_tambah = new FormSuratMasukTambah(this);
            form_tambah.ShowDialog();
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
            if(user.hak_akses == "admin")
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

        private void buttonHapusSuratMasuk_Click(object sender, EventArgs e)
        {
            suratMasuk surat_masuk = new suratMasuk();
            string title = "Konfirmasi Penghapusan Data";
            string konten = "Apakah Anda yakin ingin menghapus data?";

            DialogResult result = MessageBox.Show(konten, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                surat_masuk.deleteTembusanSuratMasuk(nomor_surat);
                surat_masuk.deleteLampiranSuratMasuk(nomor_surat);
                surat_masuk.deleteDistribusiSuratMasuk(nomor_surat);
                surat_masuk.deleteSuratMasuk(nomor_surat);
                setDataTable(surat_masuk.getAllSuratMasuk());
            }
        }

        private void dataGridViewSuratMasuk_SelectionChanged(object sender, EventArgs e)
        {
            suratMasuk surat_masuk = new suratMasuk();
            foreach (DataGridViewRow row in dataGridViewSuratMasuk.SelectedRows)
            {
                 nomor_surat = row.Cells[1].Value.ToString();
            }
        }

        private void buttonEditSuratMasuk_Click(object sender, EventArgs e)
        {
            FormSuratMasukLampiran form_lampiran = new FormSuratMasukLampiran();
            status = "Edit";
            FormSuratMasukEdit form_edit = new FormSuratMasukEdit(this);
            form_edit.ShowDialog();
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

        public void GenerateExcel2007(string p_strPath, DataSet p_dsSrc)    
        {
            try
            {
                using (ExcelPackage objExcelPackage = new ExcelPackage())
                {
                    foreach (DataTable dtSrc in p_dsSrc.Tables)
                    {
                        //Create the worksheet    
                        ExcelWorksheet objWorksheet = objExcelPackage.Workbook.Worksheets.Add(dtSrc.TableName);

                        //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1    
                        objWorksheet.Cells["A1"].LoadFromDataTable(dtSrc, true, OfficeOpenXml.Table.TableStyles.Medium1);
                        objWorksheet.Cells.Style.Font.SetFromFont(new Font("Calibri", 11));
                        objWorksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        objWorksheet.Cells.AutoFitColumns();

                        //Format the header    
                        using (ExcelRange objRange = objWorksheet.Cells["A1:N1"])
                        {
                            objRange.Style.Font.Bold = true;
                            objRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            objRange.Style.Fill.BackgroundColor.SetColor(Color.Gray);

                            objWorksheet.Column(1).Width = 25;
                            objWorksheet.Column(2).Width = 13;
                            objWorksheet.Column(3).Width = 15;
                            objWorksheet.Column(4).Width = 12;
                            objWorksheet.Column(5).Width = 19;
                            objWorksheet.Column(6).Width = 26;
                            objWorksheet.Column(7).Width = 19;
                            objWorksheet.Column(8).Width = 19;
                            objWorksheet.Column(9).Width = 25;
                            objWorksheet.Column(10).Width = 19;
                            objWorksheet.Column(11).Width = 19;
                            objWorksheet.Column(12).Width = 41;
                            objWorksheet.Column(13).Width = 19;
                            objWorksheet.Column(14).Width = 19;

                            objWorksheet.Column(1).Style.WrapText = true;
                            objWorksheet.Column(2).Style.WrapText = true;
                            objWorksheet.Column(3).Style.WrapText = true;
                            objWorksheet.Column(4).Style.WrapText = true;
                            objWorksheet.Column(5).Style.WrapText = true;
                            objWorksheet.Column(6).Style.WrapText = true;
                            objWorksheet.Column(7).Style.WrapText = true;
                            objWorksheet.Column(8).Style.WrapText = true;
                            objWorksheet.Column(9).Style.WrapText = true;
                            objWorksheet.Column(10).Style.WrapText = true;
                            objWorksheet.Column(11).Style.WrapText = true;
                            objWorksheet.Column(12).Style.WrapText = true;
                            objWorksheet.Column(13).Style.WrapText = true;
                            objWorksheet.Column(14).Style.WrapText = true;

                            objWorksheet.Column(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            objWorksheet.Column(2).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            objWorksheet.Column(3).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            objWorksheet.Column(4).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            objWorksheet.Column(5).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            objWorksheet.Column(6).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            objWorksheet.Column(7).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            objWorksheet.Column(8).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            objWorksheet.Column(9).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            objWorksheet.Column(10).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            objWorksheet.Column(11).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            objWorksheet.Column(12).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            objWorksheet.Column(13).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            objWorksheet.Column(14).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            objWorksheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            objWorksheet.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            objWorksheet.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            objWorksheet.Column(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            objWorksheet.Column(5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            objWorksheet.Column(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            objWorksheet.Column(7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            objWorksheet.Column(8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            objWorksheet.Column(9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            objWorksheet.Column(10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            objWorksheet.Column(11).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            objWorksheet.Column(12).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            objWorksheet.Column(13).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            objWorksheet.Column(14).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                            objWorksheet.Cells["A1:N1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }
                    }

                    //Write it back to the client    
                    if (File.Exists(p_strPath))
                        File.Delete(p_strPath);

                    //Create excel file on physical disk    
                    FileStream objFileStrm = File.Create(p_strPath);
                    objFileStrm.Close();

                    //Write content to excel file    
                    File.WriteAllBytes(p_strPath, objExcelPackage.GetAsByteArray());
                }
            }
            catch (IOException)
            {
                MessageBox.Show("File telah dibuka oleh aplikasi lain. Tutup terlebih dahulu sebelum menyimpan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBoxSuratMasuk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel 2007/2010 File|*.xlsx";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                string file = dialog.FileName;
                //MessageBox.Show(dialog.FileName);
                Database db = new Database();
                strconn = db.getString();
                MySqlConnection conn = new MySqlConnection(strconn);
                try
                {
                    query = "SELECT nomor_surat_masuk AS 'Nomor Surat', DATE_FORMAT(tanggal_surat, '%d-%m-%Y') AS 'Tanggal Surat', " +
                                    "DATE_FORMAT(tanggal_terima, '%d-%m-%Y') AS 'Tanggal Terima', sifat_surat AS 'Sifat Surat', j.nama_jenis AS 'Jenis Surat', " +
                                    "perihal AS 'Perihal', pengirim AS 'Pengirim', " +
                                    "alamat_pengirim AS 'Alamat Pengirim', penerima AS 'Penerima Surat', tertanda AS 'Tertanda', " +
                                    "jabatan_tertanda AS 'Jabatan Tertanda', isi_singkat AS 'Isi Surat', " +
                                    "distribusi_tanggal AS 'Tanggal Distribusi', " +
                                    "DATE_FORMAT(tanggal_update, '%d-%m-%Y %H:%i:%s') AS 'Waktu Update Terakhir' " +
                            "FROM surat_masuk JOIN jenis_surat AS j USING(id_jenis) ORDER BY tanggal_terima ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //cmd.ExecuteReader();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    adapter.Fill(data);

                    GenerateExcel2007(file, data);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
           
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            FormRekapSuratMasuk rekap = new FormRekapSuratMasuk();
            rekap.ShowDialog();
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