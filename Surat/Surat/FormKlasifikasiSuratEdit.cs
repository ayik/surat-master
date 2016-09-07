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
    public partial class FormKlasifikasiSuratEdit : DevComponents.DotNetBar.OfficeForm
    {
        public string id_jenis, nama_jenis;
        private readonly FormKlasifikasiSurat frm1;

        public FormKlasifikasiSuratEdit(string id, string nama, FormKlasifikasiSurat frm)
        {
            InitializeComponent();
            id_jenis = id;
            nama_jenis = nama;
            textBoxEditJenisSurat.Text = nama;
            frm1 = frm;
        }

        private void buttonEditJenisSuratKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEditJenisSurat_Click(object sender, EventArgs e)
        {
            JenisSurat jenis_surat = new JenisSurat();
            jenis_surat.id_jenis = id_jenis;
            jenis_surat.nama_jenis = textBoxEditJenisSurat.Text;
            jenis_surat.editJenisSurat();
            frm1.setDataTable(jenis_surat.getAllJenisSurat());
            frm1.loadComboBox();
        }
    }
}