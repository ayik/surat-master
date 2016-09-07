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
    public partial class FormKlasifikasiSuratTambah : DevComponents.DotNetBar.OfficeForm
    {
        private readonly FormKlasifikasiSurat frm1;
        public FormKlasifikasiSuratTambah(FormKlasifikasiSurat frm)
        {
            InitializeComponent();
            frm1 = frm;
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            JenisSurat j = new JenisSurat();
            j.nama_jenis = textBoxJenis.Text;
            j.tambahJenisSurat();
            frm1.setDataTable(j.getAllJenisSurat());

            frm1.loadComboBox();
        }


        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}