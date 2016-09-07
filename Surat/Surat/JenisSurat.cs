using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Surat
{
    class JenisSurat
    {
        public string id_jenis, nama_jenis;

        public MySqlDataReader getAllJenisSurat()
        {
            Database db = new Database();
            MySqlDataReader reader = null;
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();

            string query = "SELECT * FROM jenis_surat";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();

            return reader;
        }

        public MySqlDataReader cariJenisSurat(string cari)
        {
            JenisSurat jenis_surat = new JenisSurat();

            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            MySqlDataReader reader = null;
            conn.Open();

            string query = "SELECT * FROM jenis_surat WHERE nama_jenis LIKE '%" + cari + "%'";
            //MessageBox.Show(query);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@cari", cari);
            reader = cmd.ExecuteReader();

            return reader;
        }

        public void hapusJenisSurat(string idJenis)
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();

            string query = "DELETE FROM jenis_surat WHERE id_jenis = @id_jenis";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_jenis", idJenis);
            //MessageBox.Show(query);
            int sukses = cmd.ExecuteNonQuery();
            if (sukses > 0)
            {
                JenisSurat jenis_surat = new JenisSurat();
                MessageBox.Show("Data berhasil dihapus.", "Sukses");
            }
            else
            {
                MessageBox.Show("Data gagal dihapus", "Gagal");
            }
            conn.Close();
        }

        public void tambahJenisSurat()
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            string query = "INSERT INTO jenis_surat VALUES(NULL, @jenis)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@jenis", nama_jenis);
            int hasil = cmd.ExecuteNonQuery();
            if (hasil > 0)
            {
                MessageBox.Show("Data berhasil ditambah", "Sukses");
            }
            else
            {
                MessageBox.Show("Data gagal ditambah", "Gagal");
            }
            conn.Close();
        }

        public void editJenisSurat()
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            string query = "UPDATE jenis_surat SET nama_jenis = @nama_jenis WHERE id_jenis = @id_jenis";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_jenis", id_jenis);
            cmd.Parameters.AddWithValue("@nama_jenis", nama_jenis);
            //MessageBox.Show(query);
            int sukses = cmd.ExecuteNonQuery();
            if (sukses > 0)
            {
                MessageBox.Show("Data berhasil diubah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data gagal diubah.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            conn.Close();
        }
    }
}
