using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Surat
{
    class suratKeluar
    {
        public string nomor_surat { get; set; }
        public string tgl_surat { get; set; }
        public string jenis_surat { get; set; }
        public string perihal_surat { get; set; }
        public string keterangan_surat { get; set; }
        public string isi_surat { get; set; }
        public string penerima { get; set; }
        public string distribusi_tanggal { get; set; }
        public string gambar { get; set; }
        public string sifat_surat { get; set; }

        public string getIdJenisSurat(string nama_jenis)
        {
            string id_jenis = "";
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
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

        public MySqlDataReader getAllSuratKeluar()
        {
            MySqlDataReader reader = null;
            Database db = new Database();
            MySqlConnection conn = new MySqlConnection(db.getString());
            conn.Open();

            try
            {
                string query = "SELECT @s:=@s+1 AS nomor, nomor_surat_Keluar, tanggal_surat,perihal, j.nama_jenis AS jenis_surat, sifat_surat " +
                                "FROM surat_Keluar JOIN jenis_surat AS j USING(id_jenis),(SELECT @s:= 0) AS s ORDER BY tanggal_surat ASC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return reader;
        }

        public MySqlDataReader cariSuratKeluar(string kriteria, string cari)
        {
            MySqlDataReader reader = null;
            Database db = new Database();
            MySqlConnection conn = new MySqlConnection(db.getString());
            conn.Open();
            try
            {
                string query = "SELECT @s:=@s+1 AS nomor,nomor_surat_keluar, tanggal_surat,perihal,nama_jenis AS jenis_surat, sifat_surat " +
                                "FROM surat_Keluar JOIN jenis_surat AS j USING(id_jenis) , (SELECT @s:= 0) AS s " +
                                "WHERE " + kriteria + " LIKE '%" + cari + "%' ORDER BY nomor ASC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return reader;
        }

        public void tambahTembusan()
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                foreach (string tembusan in FormSuratKeluarTembusan.list_tembusan)
                {
                    string query = "INSERT INTO tembusan_surat_keluar (nama_tembusan, nomor_surat_keluar) VALUES(@tembusan, @nomor_surat_keluar)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tembusan", tembusan);
                    cmd.Parameters.AddWithValue("@nomor_surat_keluar", nomor_surat);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        public void tambahLampiran()
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                foreach (string lampiran in FormSuratKeluarLampiran.list_lampiran)
                {
                    string query = "INSERT INTO lampiran_surat_keluar VALUES(NULL, @lampiran, @nomor_surat_keluar)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@lampiran", lampiran);
                    cmd.Parameters.AddWithValue("@nomor_surat_keluar", nomor_surat);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        public void tambahBagianBidang(List<string> list_bagian)
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();

            try
            {
                foreach (var kabag in list_bagian)
                {
                    string query = "INSERT INTO detail_bagian_bidang_surat_keluar VALUES(@nomor_surat, (SELECT id_bagian_bidang FROM bagian_bidang WHERE nama_bagian_bidang = @bagian))";
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

        public void tambahSuratKeluar()
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "INSERT INTO surat_keluar(nomor_surat_keluar, perihal, tanggal_surat, id_jenis, sifat_surat, " +
                                                        "penerima, " +
                                                        "distribusi_tanggal, isi_singkat, keterangan, gambar_surat, tanggal_update) " +
                                "VALUES(@nomor_surat, @perihal_surat, STR_TO_DATE(@tanggal_surat, '%d-%m-%Y'), " +
                                        "@id_jenis, @sifat_surat, " +
                                        "@penerima, " +
                                        "STR_TO_DATE(@distribusi_tanggal, '%d-%m-%Y'), @isi_singkat, @keterangan, @gambar_surat, NOW())";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                cmd.Parameters.AddWithValue("@id_jenis", getIdJenisSurat(jenis_surat));
                cmd.Parameters.AddWithValue("@sifat_surat", sifat_surat);
                cmd.Parameters.AddWithValue("@perihal_surat", perihal_surat);
                cmd.Parameters.AddWithValue("@tanggal_surat", tgl_surat);
                cmd.Parameters.AddWithValue("@penerima", penerima);
                //cmd.Parameters.AddWithValue("@jabatan_tertanda", jabatan_tertanda);
                //cmd.Parameters.AddWithValue("@tertanda_pengirim", tertanda_pengirim);
                cmd.Parameters.AddWithValue("@distribusi_tanggal", distribusi_tanggal);
                cmd.Parameters.AddWithValue("@isi_singkat", isi_surat);
                cmd.Parameters.AddWithValue("@keterangan", keterangan_surat);
                cmd.Parameters.AddWithValue("@gambar_surat", gambar);
                //cmd.Parameters.AddWithValue("@id_user", FormMain.id_user);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conn.Close();
        }

        public void editSuratKeluar()
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "UPDATE surat_keluar SET nomor_surat_keluar = @nomor_surat, perihal = @perihal_surat, " +
                                                "tanggal_surat = STR_TO_DATE(@tanggal_surat, '%d-%m-%Y'), " +
                                                "id_jenis = @id_jenis, " +
                                                "sifat_surat = @sifat_surat, " +
                                                "penerima = @penerima, " +
                                                //"jabatan_tertanda = @jabatan_tertanda, tertanda = @tertanda, " +
                                                "distribusi_tanggal = STR_TO_DATE(@distribusi_tanggal, '%d-%m-%Y'), " +
                                                "isi_singkat = @isi_singkat, keterangan = @keterangan, " +
                                                "gambar_surat = @gambar_surat, tanggal_update = NOW() " +
                                 "WHERE nomor_surat_keluar = @nomor_surat_sebelumnya";
                // MessageBox.Show(nama_gambar);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                cmd.Parameters.AddWithValue("@sifat_surat", sifat_surat);
                cmd.Parameters.AddWithValue("@id_jenis", getIdJenisSurat(jenis_surat));
                cmd.Parameters.AddWithValue("@gambar_surat", gambar);
                cmd.Parameters.AddWithValue("@perihal_surat", perihal_surat);
                cmd.Parameters.AddWithValue("@tanggal_surat", tgl_surat);
                cmd.Parameters.AddWithValue("@penerima", penerima);
                //cmd.Parameters.AddWithValue("@jabatan_tertanda", jabatan_tertanda);
                //cmd.Parameters.AddWithValue("@tertanda", tertanda);
                cmd.Parameters.AddWithValue("@distribusi_tanggal", distribusi_tanggal);
                cmd.Parameters.AddWithValue("@isi_singkat", isi_surat);
                cmd.Parameters.AddWithValue("@keterangan", keterangan_surat);
                cmd.Parameters.AddWithValue("@nomor_surat_sebelumnya", FormSuratKeluar.nomor_surat);
                //cmd.Parameters.AddWithValue("@id_user", FormMain.id_user);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Edit data berhasil.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conn.Close();
        }

        public void deleteSuratKeluar(string nomor_surat)
        {
            Database db = new Database();
            MySqlConnection conn = new MySqlConnection(db.getString());
            conn.Open();

            try
            {
                string query = "DELETE FROM surat_keluar WHERE nomor_surat_keluar = @nomor_surat";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                //MessageBox.Show(query);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        public void deleteTembusanSuratKeluar(string nomor_surat)
        {
            Database db = new Database();
            MySqlConnection conn = new MySqlConnection(db.getString());
            conn.Open();

            try
            {
                string query = "DELETE FROM tembusan_surat_keluar WHERE nomor_surat_keluar = @nomor_surat";
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

        public void deleteLampiranSuratKeluar(string nomor_surat)
        {
            Database db = new Database();
            MySqlConnection conn = new MySqlConnection(db.getString());
            conn.Open();

            try
            {
                string query = "DELETE FROM lampiran_surat_keluar WHERE nomor_surat_keluar = @nomor_surat";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                //MessageBox.Show(query);
                cmd.ExecuteNonQuery(); 
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        public void deleteDistribusiSuratKeluar(string nomor_surat)
        {
            Database db = new Database();
            MySqlConnection conn = new MySqlConnection(db.getString());
            conn.Open();

            try
            {
                string query = "DELETE FROM detail_bagian_bidang_surat_keluar WHERE nomor_surat_keluar = @nomor_surat";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                //MessageBox.Show(query);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }
    }
}
