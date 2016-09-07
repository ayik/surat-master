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

namespace Surat
{
    public partial class FormSuratKeluarTambah : DevComponents.DotNetBar.OfficeForm
    {
        private string lokasi_gambar, nama_gambar;
        private List<string> list_bagian = new List<string>();
        private readonly FormSuratKeluar frm1;

        public FormSuratKeluarTambah(FormSuratKeluar frm)
        {
            InitializeComponent();
            frm1 = frm;
        }

        private void setGambar(string gambar)
        {
            nama_gambar = gambar;
        }

        private string getGambar()
        {
            return nama_gambar;
        }

        private void clear()
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private bool cekValid()
        {
            bool error = false;
            if (textBoxNomorSuratKeluar.Text == "")
            {
                error = true;
                MessageBox.Show("Nomor surat belum diisi. Proses penyimpanan data dibatalkan");
            }
            return error;
        }

        public void getJenisSurat()
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            string query = "SELECT nama_jenis FROM jenis_surat";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxJenisSuratKeluar.Items.Add(reader[0]);
            }
            conn.Close();
        }

        private void FormSuratKeluarTambah_Load(object sender, EventArgs e)
        {
            getJenisSurat();
            comboBoxJenisSuratKeluar.SelectedIndex = 0;
            comboBoxSifatSurat.SelectedIndex = 0;
            textBoxNomorSuratKeluar.Focus();
        }

        private void FormSuratKeluarTambah_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormSuratKeluarLampiran.list_lampiran.Clear();
            FormSuratKeluarTembusan.list_tembusan.Clear();
        }

        private void buttonLampiranSuratKeluar_Click_1(object sender, EventArgs e)
        {
            FormSuratKeluarLampiran lampirankeluar = new FormSuratKeluarLampiran();
            lampirankeluar.Show();
        }

        private void buttonTembusanSuratKeluar_Click_1(object sender, EventArgs e)
        {
            FormSuratKeluarTembusan Tembusankeluar = new FormSuratKeluarTembusan();
            Tembusankeluar.Show();
        }

        private void buttonTambahSuratKeluar_Click_1(object sender, EventArgs e)
        {
            suratKeluar surat_keluar = new suratKeluar();
            string lokasi_tujuan;
            surat_keluar.nomor_surat = textBoxNomorSuratKeluar.Text;
            surat_keluar.tgl_surat = dateTimeInputTanggalSuratKeluar.Value.Date.ToString("dd-MM-yyyy");
            surat_keluar.jenis_surat = comboBoxJenisSuratKeluar.Text;
            surat_keluar.perihal_surat = textBoxPerihalSuratKeluar.Text;
            surat_keluar.keterangan_surat = textBoxKeteranganSuratKeluar.Text;
            surat_keluar.isi_surat = textBoxIsiSuratKeluar.Text;
            surat_keluar.penerima = textBoxPenerimaSuratKeluar.Text;
            //surat_keluar.jabatan_tertanda = textBoxJabatanTertandaSuratKeluar.Text;
            //tertanda_pengirim = textBoxTertandaPengirimSuratKeluar.Text;
            surat_keluar.distribusi_tanggal = dateTimeInputTanggalDistribusiSuratKeluar.Value.Date.ToString("dd-MM-yyyy");
            surat_keluar.sifat_surat = comboBoxSifatSurat.Text;
            surat_keluar.distribusi_tanggal = dateTimeInputTanggalDistribusiSuratKeluar.Value.Date.ToString("dd-MM-yyyy");
            lokasi_tujuan = Application.StartupPath + "\\image_surat_keluar";
            surat_keluar.gambar = getGambar();

            if (cekValid())
                return;
            else
            {
                if (!Directory.Exists(lokasi_tujuan))
                {
                    Directory.CreateDirectory(lokasi_tujuan);
                }
                if (pictureBoxGambarSuratKeluar.Image != null)
                {
                    File.Copy(lokasi_gambar, lokasi_tujuan + "\\" + getGambar(), true);
                }
                else
                {
                    surat_keluar.gambar = "no_image.png";
                    if (!File.Exists(lokasi_tujuan + "\\no_image.png"))
                        File.Copy(Application.StartupPath + "\\no_image.png", lokasi_tujuan + "\\no_image.png", true);
                }
                surat_keluar.tambahSuratKeluar();
                if (FormSuratKeluarLampiran.list_lampiran.Count != 0)
                {
                    surat_keluar.tambahLampiran();
                }
                if (FormSuratKeluarTembusan.list_tembusan.Count != 0)
                {
                    surat_keluar.tambahTembusan();
                }
                if (list_bagian.Count != 0)
                {
                    surat_keluar.tambahBagianBidang(list_bagian);
                }
            }
            clear();
            frm1.setDataTable(surat_keluar.getAllSuratKeluar());
        }

        private void buttonKembaliSuratMasuk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxTataUsaha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTataUsaha.Checked)
            {
                list_bagian.Add("Tata Usaha");
            }
            else
            {
                list_bagian.Remove("Tata Usaha");
            }
        }

        private void checkBoxProgramaSiaran_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxProgramaSiaran.Checked)
            {
                list_bagian.Add("Programa Siaran");
            }
            else
            {
                list_bagian.Remove("Programa Siaran");
            }
        }

        private void checkBoxPemberitaan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPemberitaan.Checked)
            {
                list_bagian.Add("Pemberitaan");
            }
            else
            {
                list_bagian.Remove("Pemberitaan");
            }
        }

        private void checkBoxTeknologi_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxTeknologi.Checked)
            {
                list_bagian.Add("Teknologi dan Media Baru");
            }
            else
            {
                list_bagian.Remove("Teknologi dan Media Baru");
            }
        }

        private void checkBoxLayanan_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxLayanan.Checked)
            {
                list_bagian.Add("Layanan dan Pengembangan");
            }
            else
            {
                list_bagian.Remove("Layanan dan Pengembangan");
            }
        }

        private void buttonGambarSuratKeluar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lokasi_gambar = dialog.FileName;
                setGambar(Path.GetFileName(dialog.FileName));
                pictureBoxGambarSuratKeluar.Image = new Bitmap(dialog.FileName);
            }
        }

    }
}