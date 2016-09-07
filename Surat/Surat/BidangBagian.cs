using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Surat
{
    class BidangBagian
    {
        private string nama_bidang { get; set; }

        //public void setBidang(string bidang)
        //{
        //    this.nama_bidang = bidang;
        //}

        //public string getBidang()
        //{
        //    return this.nama_bidang;
        //}

        public void tambahBidang(string nama_bidang)
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "INSERT INTO bagian_bidang VALUES(NULL, @nama_bagian_bidang)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama_bagian_bidang", nama_bidang);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bagian/Bidang berhasil ditambah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            conn.Close();
        }

        public MySqlDataReader getAllBidang()
        {
            MySqlDataReader reader = null;
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                string query = "SELECT id_bagian_bidang, nama_bagian_bidang FROM bagian_bidang";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            return reader;
        }
    }
}
