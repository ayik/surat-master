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
    public partial class FormSuratDisposisiTambah : DevComponents.DotNetBar.OfficeForm
    {
        private string diproses, dilaksanakan, ditanggapi, diperhatikan, dilaporkan, diketahui, diedarkan, diperbanyak, ditampung, dihadiri, dikonsepkan, dievaluasi, saran, disimpan;
        private string nama_gambar, lokasi_gambar, lokasi_tujuan;
        private List<string> list_kabag = new List<string>();
        private readonly FormSuratDisposisi frm;

        public FormSuratDisposisiTambah(FormSuratDisposisi frm1)
        {
            InitializeComponent();
            frm = frm1;
        }

        private void setGambar(string gambar)
        {
            nama_gambar = gambar;
        }

        private string getGambar()
        {
            return nama_gambar;
        }


        private bool validasi()
        {
            bool error = false;
            if (textBoxNomorSurat.Text == "")
            {
                error = true;
                MessageBox.Show("Nomor surat belum diisi. Penyimpanan data dibatalkan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNomorSurat.Focus();
            }
            return error;
        }
 
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuratDisposisiTambah_Load(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            comboBoxSifatSurat.SelectedIndex = 0;
            diproses = "T";
            dilaksanakan = "T";
            ditanggapi = "T";
            diperhatikan = "T";
            dilaporkan = "T";
            diketahui = "T";
            diedarkan = "T";
            diperbanyak = "T";
            ditampung = "T";
            dihadiri = "T";
            dikonsepkan = "T";
            dievaluasi = "T";
            saran = "T";
            disimpan = "T";
        }

        private void checkBoxDiproses_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxDiproses.Checked)
            {
                diproses = "Y";
            }
            else
            {
                diproses = "T";
            }
           // MessageBox.Show(diproses);
        }

        private void checkBoxDilaksanakan_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxDilaksanakan.Checked)
            {
                dilaksanakan = "Y";
            }
            else
            {
                dilaksanakan = "T";
            }
        }

        private void checkBoxDitanggapi_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxDitanggapi.Checked)
            {
                ditanggapi = "Y";
            }
            else
            {
                ditanggapi = "T";
            }
        }

        private void checkBoxDiperhatikan_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxDiperhatikan.Checked)
            {
                diperhatikan = "Y";
            }
            else
            {
                diperhatikan = "T";
            }
        }

        private void checkBoxDilaporkan_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxDilaporkan.Checked)
            {
                dilaporkan = "Y";
            }
            else
            {
                dilaporkan = "T";
            }
        }

        private void checkBoxDiketahui_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxDiketahui.Checked)
            {
                diketahui = "Y";
            }
            else
            {
                diketahui = "T";
            }
        }

        private void checkBoxDiedarkan_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxDiedarkan.Checked)
            {
                diedarkan = "Y";
            }
            else
            {
                diedarkan = "T";
            }
        }

        private void checkBoxDiperbanyak_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxDiperbanyak.Checked)
            {
                diperbanyak = "Y";
            }
            else
            {
                diperbanyak = "T";
            }
        }

        private void checkBoxDitampung_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxDitampung.Checked)
            {
                ditampung = "Y";
            }
            else
            {
                ditampung = "T";
            }
        }

        private void checkBoxDihadiri_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxDihadiri.Checked)
            {
                dihadiri = "Y";
            }
            else
            {
                dihadiri = "T";
            }
        }

        private void checkBoxDikonsepkan_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxDikonsepkan.Checked)
            {
                dikonsepkan = "Y";
            }
            else
            {
                dikonsepkan = "T";
            }
        }

        private void checkBoxDievaluasi_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxDievaluasi.Checked)
            {
                dievaluasi = "Y";
            }
            else
            {
                dievaluasi = "T";
            }
        }

        private void checkBoxSaran_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxSaran.Checked)
            {
                saran = "Y";
            }
            else
            {
                saran = "T";
            }
        }

        private void checkBoxDisimpan_CheckedChanged(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            if (checkBoxDisimpan.Checked)
            {
                disimpan = "Y";
            }
            else
            {
                disimpan = "T";
            }
        }

        private void buttonGambarSurat_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                lokasi_gambar = dialog.FileName;
                setGambar(Path.GetFileName(lokasi_gambar));
                pictureBoxGambarSurat.Image = new Bitmap(lokasi_gambar);
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            suratDisposisi surat_disposisi = new suratDisposisi();
            surat_disposisi.nomor_surat = textBoxNomorSurat.Text;
            surat_disposisi.nomor_agenda = textBoxNomorAgenda.Text;
            surat_disposisi.asal_surat = textBoxAsalSurat.Text;
            surat_disposisi.perihal = textBoxPerihal.Text;
            surat_disposisi.sifat_surat = comboBoxSifatSurat.Text;
            surat_disposisi.isi_surat = textBoxIsiSurat.Text;
            surat_disposisi.lain = textBoxKeterangan.Text;
            surat_disposisi.tanggal_surat = dateTimeInputTanggalSurat.Value.Date.ToString("dd-MM-yyyy");
            surat_disposisi.tanggal_diterima = dateTimeInputTanggalDiterima.Value.Date.ToString("dd-MM-yyyy");
            surat_disposisi.tanggal_diteruskan = dateTimeInputDiteruskan.Value.Date.ToString("dd-MM-yyyy");
            surat_disposisi.diproses = diproses;
            surat_disposisi.dilaksanakan = dilaksanakan;
            surat_disposisi.ditanggapi = ditanggapi;
            surat_disposisi.diperhatikan = diperhatikan;
            surat_disposisi.dilaporkan = dilaporkan;
            surat_disposisi.diketahui = diketahui;
            surat_disposisi.diedarkan = diedarkan;
            surat_disposisi.diperbanyak = diperbanyak;
            surat_disposisi.ditampung = ditampung;
            surat_disposisi.dihadiri = dihadiri;
            surat_disposisi.dikonsepkan = dikonsepkan;
            surat_disposisi.dievaluasi = dievaluasi;
            surat_disposisi.saran = saran;
            surat_disposisi.disimpan = disimpan;
            lokasi_tujuan = Application.StartupPath + "\\image_surat_disposisi";
            surat_disposisi.gambar = getGambar();
            //id_user = FormMain.id_user;

            if (validasi())
            {
                return;
            }
            else
            {
                if (!Directory.Exists(lokasi_tujuan))
                {
                    Directory.CreateDirectory(lokasi_tujuan);
                }
                if (pictureBoxGambarSurat.Image != null)
                {
                    File.Copy(lokasi_gambar, lokasi_tujuan + "\\" + getGambar(), true);
                }
                else
                {
                    surat_disposisi.gambar = "no_image.png";
                    if (!File.Exists(lokasi_tujuan + "\\no_image.png"))
                        File.Copy(Application.StartupPath + "\\no_image.png", lokasi_tujuan + "\\no_image.png", true);
                }
                surat_disposisi.tambahSuratDisposisi();
                surat_disposisi.tambahKabag(list_kabag);
                frm.setDataTable(surat_disposisi.getAllSuratDisposisi());
            }
        }

        private void checkBoxKabagTataUsaha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKabagTataUsaha.Checked)
            {
                list_kabag.Add("Tata Usaha");
            }
            else
            {
                list_kabag.Remove("Tata Usaha");
            }
        }

        private void checkBoxKabidProgramaSiaran_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKabidProgramaSiaran.Checked)
            {
                list_kabag.Add("Programa Siaran");
            }
            else
            {
                list_kabag.Remove("Programa Siaran");
            }
        }

        private void checkBoxKabidPemberitaan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKabidPemberitaan.Checked)
            {
                list_kabag.Add("Pemberitaan");
            }
            else
            {
                list_kabag.Remove("Pemberitaan");
            }
        }

        private void checkBoxKabidTeknologi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKabidTeknologi.Checked)
            {
                list_kabag.Add("Teknologi dan Media Baru");
            }
            else
            {
                list_kabag.Remove("Teknologi dan Media Baru");
            }
        }

        private void checkBoxKabidLPU_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKabidLPU.Checked)
            {
                list_kabag.Add("Layanan dan Pengembangan");
            }
            else
            {
                list_kabag.Remove("Layanan dan Pengembangan");
            }
        }
    }
}