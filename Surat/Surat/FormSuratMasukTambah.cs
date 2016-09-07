using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevComponents.DotNetBar;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Surat
{
    public partial class FormSuratMasukTambah : DevComponents.DotNetBar.OfficeForm
    {
        private string nama_gambar, lokasi_gambar;
        private readonly FormSuratMasuk frm1;
        private List<string> list_bagian = new List<string>();

        private void setGambar(string lokasi)
        {
            nama_gambar = lokasi;
        }

        private string getGambar()
        {
            return nama_gambar;
        }

        public FormSuratMasukTambah(FormSuratMasuk frm)
        {
            InitializeComponent();
            frm1 = frm;
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
            if (textBoxNomorSuratMasuk.Text == "")
            {
                error = true;
                MessageBox.Show("Nomor surat belum diisi. Penyimpanan data dibatalkan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNomorSuratMasuk.Focus();
            }
            return error;
        }

        public void getJenisSurat()
        {
            Database db = new Database();
            MySqlConnection conn = new MySqlConnection(db.getString());
            conn.Open();
            string query = "SELECT nama_jenis FROM jenis_surat";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxJenisSuratMasuk.Items.Add(reader[0]);
            }
            conn.Close();
        }

        public string getIdJenisSurat(string nama_jenis)
        {
            string id_jenis = "";
            Database db = new Database();
            MySqlConnection conn = new MySqlConnection(db.getString());
            conn.Open();
            string query = "SELECT id_jenis FROM jenis_surat WHERE nama_jenis = @nama_jenis";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nama_jenis", nama_jenis);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id_jenis = reader[0].ToString();
            }
            conn.Close();
            return id_jenis;
        }

        private void FormTambahSuratMasuk_Load(object sender, EventArgs e)
        {
            getJenisSurat();
            comboBoxJenisSuratMasuk.SelectedIndex = 0;
            comboBoxSifatSuratMasuk.SelectedIndex = 0;
            textBoxNomorSuratMasuk.Focus();
        }

        private void buttonGambarSuratMasuk_Click(object sender, EventArgs e)
        {
            suratMasuk surat_masuk = new suratMasuk();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lokasi_gambar = dialog.FileName;
                setGambar(Path.GetFileName(dialog.FileName));
                pictureBoxGambarSuratMasuk.Image = new Bitmap(dialog.FileName);
            }
        }

        private void buttonTembusanSuratMasuk_Click(object sender, EventArgs e)
        {
            FormSuratMasukTembusan form_tembusan = new FormSuratMasukTembusan();
            form_tembusan.ShowDialog();
        }

        private void buttonTambahSuratMasuk_Click(object sender, EventArgs e)
        {
            string lokasi_tujuan;
            suratMasuk surat_masuk = new suratMasuk();
            surat_masuk.nomor_surat = textBoxNomorSuratMasuk.Text;
            surat_masuk.tgl_surat = dateTimeInputTanggalSuratMasuk.Value.Date.ToString("dd-MM-yyyy");
            surat_masuk.tgl_terima = dateTimeInputTanggalTerimaSuratMasuk.Value.Date.ToString("dd-MM-yyyy");
            surat_masuk.jenis_surat = comboBoxJenisSuratMasuk.Text;
            surat_masuk.sifat_surat = comboBoxSifatSuratMasuk.Text;
            surat_masuk.perihal_surat = textBoxPerihalSuratMasuk.Text;
            surat_masuk.keterangan_surat = textBoxKeteranganSuratMasuk.Text;
            surat_masuk.isi_surat = textBoxIsiSuratMasuk.Text;
            surat_masuk.pengirim = textBoxInstansiPengirimSuratMasuk.Text;
            surat_masuk.alamat_pengirim = textBoxAlamatPengirimSuratMasuk.Text;
            surat_masuk.penerima = textBoxPenerimaSuratMasuk.Text;
            //jabatan_tertanda = textBoxJabatanTertandaSuratMasuk.Text;
            //tertanda = textBoxTertandaPengirimSuratMasuk.Text;
            surat_masuk.tanggal_distribusi = dateTimeInputTanggalDistribusiSuratMasuk.Value.Date.ToString("dd-MM-yyyy");
            surat_masuk.gambar = getGambar();
            lokasi_tujuan = Application.StartupPath + "\\image_surat_masuk";
            if (!Directory.Exists(lokasi_tujuan))
            {
                Directory.CreateDirectory(lokasi_tujuan);
            }
            if (pictureBoxGambarSuratMasuk.Image != null)
            {
                File.Copy(lokasi_gambar, lokasi_tujuan + "\\" + getGambar(), true);
            }
            else
            {
                surat_masuk.gambar = "no_image.png";
                if (!File.Exists(lokasi_tujuan + "\\no_image.png"))
                    File.Copy(Application.StartupPath + "\\no_image.png", lokasi_tujuan + "\\no_image.png", true);
            }
            
            if (cekValid())
            {
                return;
            }
            else
            {
                surat_masuk.tambahSuratMasuk();
                if (FormSuratMasukLampiran.list_lampiran.Count != 0)
                {
                    surat_masuk.tambahLampiran();
                }
                if (FormSuratMasukTembusan.list_tembusan.Count != 0)
                {
                    surat_masuk.tambahTembusan();
                }
                if (list_bagian.Count != 0)
                {
                    surat_masuk.tambahBagianBidang(list_bagian);
                }
            }
            clear();
            frm1.setDataTable(surat_masuk.getAllSuratMasuk());
            
        }

        private void buttonKembaliSuratMasuk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLampiranSuratMasuk_Click(object sender, EventArgs e)
        {
            FormSuratMasukLampiran form_lampiran = new FormSuratMasukLampiran();
            form_lampiran.ShowDialog();
        }

        private void FormTambahSuratMasuk_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormSuratMasukLampiran.list_lampiran.Clear();
            FormSuratMasukTembusan.list_tembusan.Clear();
            this.Dispose();
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
    }
}