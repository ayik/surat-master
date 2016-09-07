using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Surat
{
    class suratMasuk
    {
        public string nomor_surat { get; set; }
        public string tgl_surat { get; set; }
        public string tgl_terima { get; set; }
        public string jenis_surat { get; set; }
        public string sifat_surat { get; set; }
        public string perihal_surat { get; set; }
        public string keterangan_surat { get; set; }
        public string isi_surat { get; set; }
        public string pengirim { get; set; }
        public string alamat_pengirim { get; set; }
        public string penerima { get; set; }
        public string tanggal_distribusi { get; set; }
        public string gambar { get; set; }

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

        public void tambahTembusan()
        {
            Database db = new Database();
            MySqlConnection conn = new MySqlConnection(db.getString());
            conn.Open();
            try
            {
                foreach (string tembusan in FormSuratMasukTembusan.list_tembusan)
                {
                    string query = "INSERT INTO tembusan_surat_masuk VALUES(NULL, @tembusan, @nomor_surat_masuk)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tembusan", tembusan);
                    cmd.Parameters.AddWithValue("@nomor_surat_masuk", nomor_surat);
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
            MySqlConnection conn = new MySqlConnection(db.getString());
            conn.Open();
            try
            {
                foreach (string lampiran in FormSuratMasukLampiran.list_lampiran)
                {
                    string query = "INSERT INTO lampiran_surat_masuk VALUES(NULL, @lampiran, @nomor_surat_masuk)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@lampiran", lampiran);
                    cmd.Parameters.AddWithValue("@nomor_surat_masuk", nomor_surat);
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
            MySqlConnection conn = new MySqlConnection(db.getString());
            conn.Open();
            try
            {
                foreach (var kabag in list_bagian)
                {
                    string query = "INSERT INTO detail_bagian_bidang_surat_masuk VALUES(@nomor_surat, (SELECT id_bagian_bidang FROM bagian_bidang WHERE nama_bagian_bidang = @bagian))";
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

        public void tambahSuratMasuk()
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "INSERT INTO surat_masuk(nomor_surat_masuk, perihal, tanggal_surat, tanggal_terima, id_jenis, " +
                                                    "sifat_surat, pengirim, alamat_pengirim, penerima, " +
                                                    "distribusi_tanggal, isi_singkat, keterangan, gambar_surat, tanggal_update) " +
                                "VALUES(@nomor_surat, @perihal_surat, STR_TO_DATE(@tanggal_surat, '%d-%m-%Y'), " +
                                    "STR_TO_DATE(@tanggal_terima, '%d-%m-%Y'), @id_jenis, " +
                                    "@sifat_surat, @pengirim, @alamat_pengirim, @penerima, " +
                                    "STR_TO_DATE(@distribusi_tanggal, '%d-%m-%Y'), @isi_singkat, @keterangan, @gambar_surat, NOW())";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                cmd.Parameters.AddWithValue("@sifat_surat", sifat_surat);
                cmd.Parameters.AddWithValue("@id_jenis", getIdJenisSurat(jenis_surat));
                cmd.Parameters.AddWithValue("@gambar_surat", gambar);
                cmd.Parameters.AddWithValue("@perihal_surat", perihal_surat);
                cmd.Parameters.AddWithValue("@tanggal_surat", tgl_surat);
                cmd.Parameters.AddWithValue("@tanggal_terima", tgl_terima);
                cmd.Parameters.AddWithValue("@pengirim", pengirim);
                cmd.Parameters.AddWithValue("@alamat_pengirim", alamat_pengirim);
                cmd.Parameters.AddWithValue("@penerima", penerima);
                //cmd.Parameters.AddWithValue("@jabatan_tertanda", jabatan_tertanda);
                //cmd.Parameters.AddWithValue("@tertanda", tertanda);
                cmd.Parameters.AddWithValue("@distribusi_tanggal", tanggal_distribusi);
                cmd.Parameters.AddWithValue("@isi_singkat", isi_surat);
                cmd.Parameters.AddWithValue("@keterangan", keterangan_surat);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Nomor surat yang dimaksud telah ada dalam database. Silahkan ubah nomor surat yang ingin dimasukkan.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            conn.Close();
        }

        public MySqlDataReader getAllSuratMasuk()
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            MySqlDataReader reader = null;
            try
            {
                string query = "SELECT @s:=@s+1 AS nomor, nomor_surat_masuk, DATE_FORMAT(tanggal_surat, '%d-%m-%Y'), DATE_FORMAT(tanggal_terima, '%d-%m-%Y'), perihal, pengirim, sifat_surat, j.nama_jenis AS jenis_surat " +
                                "FROM surat_masuk JOIN jenis_surat AS j USING(id_jenis), (SELECT @s:= 0) AS s ORDER BY nomor ASC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("@col", "2");
                reader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return reader;
        }

        public MySqlDataReader cariSuratMasuk(string kriteria, string cari)
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            MySqlDataReader reader = null;
            conn.Open();
            try
            {
                string query = "SELECT @s:=@s+1 AS nomor, nomor_surat_masuk, DATE_FORMAT(tanggal_surat, '%d-%m-%Y'), DATE_FORMAT(tanggal_terima, '%d-%m-%Y'), perihal, pengirim, sifat_surat, j.nama_jenis AS jenis_surat " +
                                "FROM surat_masuk JOIN jenis_surat AS j USING(id_jenis) , (SELECT @s:= 0) AS s " +
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

        public void editSuratMasuk()
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "UPDATE surat_masuk SET nomor_surat_masuk = @nomor_surat, perihal = @perihal_surat, " +
                                                "tanggal_surat = STR_TO_DATE(@tanggal_surat, '%d-%m-%Y'), " +
                                                "tanggal_terima = STR_TO_DATE(@tanggal_terima, '%d-%m-%Y'), " +
                                                "id_jenis = @id_jenis, " +
                                                "sifat_surat = @sifat_surat, pengirim = @pengirim, " +
                                                "alamat_pengirim = @alamat_pengirim, penerima = @penerima, " +
                                                "distribusi_tanggal = STR_TO_DATE(@distribusi_tanggal, '%d-%m-%Y'), " +
                                                "isi_singkat = @isi_singkat, keterangan = @keterangan, " +
                                                "gambar_surat = @gambar_surat, tanggal_update = NOW() " +
                                "WHERE nomor_surat_masuk = @nomor_surat_sebelumnya";
                // MessageBox.Show(nama_gambar);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                cmd.Parameters.AddWithValue("@sifat_surat", sifat_surat);
                cmd.Parameters.AddWithValue("@id_jenis", getIdJenisSurat(jenis_surat));
                cmd.Parameters.AddWithValue("@gambar_surat", gambar);
                cmd.Parameters.AddWithValue("@perihal_surat", perihal_surat);
                cmd.Parameters.AddWithValue("@tanggal_surat", tgl_surat);
                cmd.Parameters.AddWithValue("@tanggal_terima", tgl_terima);
                cmd.Parameters.AddWithValue("@pengirim", pengirim);
                cmd.Parameters.AddWithValue("@alamat_pengirim", alamat_pengirim);
                cmd.Parameters.AddWithValue("@penerima", penerima);
                //cmd.Parameters.AddWithValue("@jabatan_tertanda", jabatan_tertanda);
                //cmd.Parameters.AddWithValue("@tertanda", tertanda);
                cmd.Parameters.AddWithValue("@distribusi_tanggal", tanggal_distribusi);
                cmd.Parameters.AddWithValue("@isi_singkat", isi_surat);
                cmd.Parameters.AddWithValue("@keterangan", keterangan_surat);
                cmd.Parameters.AddWithValue("@nomor_surat_sebelumnya", FormSuratMasuk.nomor_surat);
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

        public void deleteTembusanSuratMasuk(string nomor_surat)
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "DELETE FROM tembusan_surat_masuk WHERE nomor_surat_masuk = @nomor_surat";
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

        public void deleteLampiranSuratMasuk(string nomor_surat)
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "DELETE FROM lampiran_surat_masuk WHERE nomor_surat_masuk = @nomor_surat";
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

        public void deleteDistribusiSuratMasuk(string nomor_surat)
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "DELETE FROM detail_bagian_bidang_surat_masuk WHERE nomor_surat_masuk = @nomor_surat";
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

        public void deleteSuratMasuk(string nomor_surat)
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "DELETE FROM surat_masuk WHERE nomor_surat_masuk = @nomor_surat";
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

        public Dictionary<string, string> lihatSuratMasuk(string nomor_surat)
        {
            Dictionary<string, string> surat_masuk = new Dictionary<string, string>();
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "SELECT * FROM surat_masuk WHERE nomor_surat_masuk = @nomor_surat";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor_surat", nomor_surat);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    surat_masuk.Add("nomor_surat", nomor_surat);
                    surat_masuk.Add("perihal", reader["perihal"].ToString());
                    surat_masuk.Add("perihal", reader["perihal"].ToString());
                    if (reader["tanggal_terima"].ToString().Equals("1/1/0001"))
                        textBoxTanggalTerima.Text = "";
                    else
                        textBoxTanggalTerima.Text = reader["tanggal_terima"].ToString();
                    if (reader["tanggal_surat"].ToString().Equals("1/1/0001"))
                        textBoxTanggalSurat.Text = "";
                    else
                        textBoxTanggalSurat.Text = reader["tanggal_surat"].ToString();
                    textBoxInstansiPengirimSuratMasuk.Text = reader["pengirim"].ToString();
                    textBoxAlamatPengirimSuratMasuk.Text = reader["alamat_pengirim"].ToString();
                    textBoxPenerimaSuratMasuk.Text = reader["penerima"].ToString();
                    textBoxJabatanTertandaSuratMasuk.Text = reader["jabatan_tertanda"].ToString();
                    textBoxTertandaPengirimSuratMasuk.Text = reader["tertanda"].ToString();
                    if (reader["distribusi_tanggal"].ToString().Equals("1/1/0001"))
                        textBoxTanggalDistribusi.Text = "";
                    else
                        textBoxTanggalDistribusi.Text = reader["distribusi_tanggal"].ToString();
                    textBoxKeteranganSuratMasuk.Text = reader["keterangan"].ToString();
                    textBoxIsiSuratMasuk.Text = reader["isi_singkat"].ToString();
                    pictureBoxGambarSuratMasuk.Image = new Bitmap(Application.StartupPath + "\\image_surat_masuk\\" + reader["gambar_surat"].ToString());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
            return surat_masuk;
        }
    }
}
