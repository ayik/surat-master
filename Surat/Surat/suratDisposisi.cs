using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Surat
{
    class suratDisposisi
    {
        public string nomor_surat { get; set; }
        public string nomor_agenda { get; set; }
        public string asal_surat { get; set; }
        public string perihal { get; set; }
        public string sifat_surat { get; set; }
        public string tanggal_surat { get; set; }
        public string tanggal_diterima { get; set; }
        public string tanggal_diteruskan { get; set; }
        public string isi_surat { get; set; }
        public string lain { get; set; }
        public string gambar { get; set; }
        public string diproses { get; set; }
        public string dilaksanakan { get; set; }
        public string ditanggapi { get; set; }
        public string diperhatikan { get; set; }
        public string dilaporkan { get; set; }
        public string diketahui { get; set; }
        public string diedarkan { get; set; }
        public string diperbanyak { get; set; }
        public string ditampung { get; set; }
        public string dihadiri { get; set; }
        public string dikonsepkan { get; set; }
        public string dievaluasi { get; set; }
        public string saran { get; set; }
        public string disimpan { get; set; }

        public MySqlDataReader getAllSuratDisposisi()
        {
            Database db = new Database();
            MySqlDataReader reader = null;
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "SELECT @s:=@s+1 AS nomor, nomor_surat, nomor_agenda, DATE_FORMAT(tanggal_surat, '%d-%m-%Y'), DATE_FORMAT(tanggal_terima, '%d-%m-%Y'), " +
                        "DATE_FORMAT(tanggal_diteruskan, '%d-%m-%Y'), asal, perihal, sifat " +
                        "FROM surat_disposisi, (SELECT @s:=0) AS s ORDER BY nomor ASC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return reader;
        }

        public MySqlDataReader cariSuratDisposisi(string kriteria, string cari)
        {
            Database db = new Database();
            MySqlDataReader reader = null;
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "SELECT @s:=@s+1 AS nomor, nomor_surat, nomor_agenda, DATE_FORMAT(tanggal_surat, '%d-%m-%Y'), DATE_FORMAT(tanggal_terima, '%d-%m-%Y'), " +
                        "DATE_FORMAT(tanggal_diteruskan, '%Y-%m-%d'), asal, perihal, sifat " +
                        "FROM surat_disposisi, (SELECT @s:=0) AS s WHERE " + kriteria + " LIKE '%" + cari + "%' ORDER BY nomor";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //MessageBox.Show(kriteria);
                reader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return reader;
        }

        public void tambahKabag(List<string> list_kabag)
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();

            try
            {
                foreach (var kabag in list_kabag)
                {
                    string query = "INSERT INTO disposisi_bagian VALUES(@nomor_surat, (SELECT id_bagian_bidang FROM bagian_bidang WHERE nama_bagian_bidang = @bagian))";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                    cmd.Parameters.AddWithValue("@bagian", kabag);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conn.Close();
        }

        public void tambahSuratDisposisi()
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "INSERT INTO surat_disposisi (nomor_surat, nomor_agenda, tanggal_surat, tanggal_terima, tanggal_diteruskan, "+
                                                            "asal, sifat, perihal, perintah, disposisi_lain, diproses_diselesaikan, dilaksanakan, "+
                                                            "ditanggapi, diperhatikan, dilaporkan, diketahui, diedarkan, diperbanyak_dicopy, "+
                                                            "ditampung, dihadiri_diwakilkan, dikonsepkan_jawaban, dievaluasi_diteliti, saran_pendapat, "+
                                                            "disimpan_file_arsip, gambar_surat, tanggal_update)" +
                        "VALUES(@nomor_surat, @nomor_agenda, STR_TO_DATE(@tanggal_surat, '%d-%m-%Y'), " +
                                "STR_TO_DATE(@tanggal_diterima, '%d-%m-%Y'), STR_TO_DATE(@tanggal_diteruskan, '%d-%m-%Y'), " +
                                "@asal, @sifat, @perihal, @perintah, @lain, @diproses, @dilaksanakan, @ditanggapi, @diperhatikan, " +
                                "@dilaporkan, @diketahui, @diedarkan, @diperbanyak, @ditampung, @dihadiri, @dikonsepkan, " +
                                "@dievaluasi, @saran_pendapat, @disimpan, @gambar_surat, NOW())";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                cmd.Parameters.AddWithValue("@nomor_agenda", nomor_agenda);
                cmd.Parameters.AddWithValue("@tanggal_surat", tanggal_surat);
                cmd.Parameters.AddWithValue("@tanggal_diterima", tanggal_diterima);
                cmd.Parameters.AddWithValue("@tanggal_diteruskan", tanggal_diteruskan);
                cmd.Parameters.AddWithValue("@asal", asal_surat);
                cmd.Parameters.AddWithValue("@sifat", sifat_surat);
                cmd.Parameters.AddWithValue("@perihal", perihal);
                cmd.Parameters.AddWithValue("@perintah", isi_surat);
                cmd.Parameters.AddWithValue("@lain", lain);
                cmd.Parameters.AddWithValue("@diproses", diproses);
                cmd.Parameters.AddWithValue("@dilaksanakan", dilaksanakan);
                cmd.Parameters.AddWithValue("@ditanggapi", ditanggapi);
                cmd.Parameters.AddWithValue("@diperhatikan", diperhatikan);
                cmd.Parameters.AddWithValue("@dilaporkan", dilaporkan);
                cmd.Parameters.AddWithValue("@diketahui", diketahui);
                cmd.Parameters.AddWithValue("@diedarkan", diedarkan);
                cmd.Parameters.AddWithValue("@diperbanyak", diperbanyak);
                cmd.Parameters.AddWithValue("@ditampung", ditampung);
                cmd.Parameters.AddWithValue("@dihadiri", dihadiri);
                cmd.Parameters.AddWithValue("@dikonsepkan", dikonsepkan);
                cmd.Parameters.AddWithValue("@dievaluasi", dievaluasi);
                cmd.Parameters.AddWithValue("@saran_pendapat", saran);
                cmd.Parameters.AddWithValue("@disimpan", disimpan);
                cmd.Parameters.AddWithValue("@gambar_surat", gambar);
                //cmd.Parameters.AddWithValue("@id_user", FormMain.id_user);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Nomor surat/agenda yang diisi telah ada. Proses penyimpanan dibatalkan", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show(ex.ToString());
            }

            conn.Close();
        }

        public void hapusDisposisiBidang(string nomor_surat)
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "DELETE FROM disposisi_bagian WHERE nomor_surat = @nomor_surat";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        public void hapusSuratDisposisi(string nomor_surat)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus data?", "Konfirmasi Penghapusan Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Database db = new Database();
                MySqlConnection conn = db.connect(db.getString());
                conn.Open();
                try
                {
                    hapusDisposisiBidang(nomor_surat);
                    string query = "DELETE FROM surat_disposisi WHERE nomor_surat = @nomor_surat";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
        }
    }
}
