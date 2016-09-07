using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Surat
{
    public class user
    {
        public string id_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nama { get; set; }
        public static string hak_akses { get; set; }

        public bool cekLogin(string username, string password)
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            bool benar = false;
            try
            {
                conn.Open();
                string query = "SELECT * FROM user WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Username atau Password salah. Silahkan ulangi kembali.", "Kesalahan");
                }
                else
                {
                    benar = true;
                    id_user = reader[0].ToString();
                    hak_akses = reader[4].ToString();
                    if(hak_akses == "Admin")
                    {
                        FormLogin form_login = new FormLogin();
                        FormMainAdmin main = new FormMainAdmin();
                        main.Show();
                    }
                    else if(hak_akses == "User")
                    {
                        FormLogin form_login = new FormLogin();
                        FormMain main = new FormMain();
                        main.Show();
                    }
                }
                conn.Close();
            }
            catch (MySqlException)
            {
                db.createDatabase();
                this.cekLogin(username, password);
            }
            return benar;
        }

        public MySqlDataReader getAllUser()
        {
            Database db = new Database();
            MySqlDataReader reader = null;
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();

            string query = "SELECT id_user, username, nama, hak_akses FROM user";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();

            return reader;
        }

        public MySqlDataReader cariuser(string cari)
        {
            user usernames = new user();
            Database db = new Database();
            MySqlDataReader reader = null;
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();

            string query = "SELECT id_user, username, nama, hak_akses FROM user WHERE username LIKE '%" + cari + "%'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@cari", cari);
            reader = cmd.ExecuteReader();

            return reader;
        }

        public void hapusUser(string id_user)
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();

            string query = "DELETE FROM user WHERE id_user = @id_user";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_user", id_user);
            int sukses = cmd.ExecuteNonQuery();
            if (sukses > 0)
            {
                MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data gagal dihapus.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            conn.Close();
        }

        public void tambahUser()
        {

            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            string query = "INSERT INTO user VALUES(NULL, @username, @password, @nama, @hak_akses)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@nama", nama);
            cmd.Parameters.AddWithValue("@hak_akses", hak_akses);

            int hasil = cmd.ExecuteNonQuery();
            if (hasil > 0)
            {
                MessageBox.Show("Data berhasil ditambah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Data gagal ditambah.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            conn.Close();
        }

        public void editUser()
        {
            Database db = new Database();
            MySqlConnection conn = db.connect(db.getString());
            conn.Open();
            try
            {
                //MessageBox.Show(hak_akses);
                string query = "UPDATE user SET username = @username, password = @password, nama = @nama, hak_akses = @hak_akses  WHERE id_user = @id_user";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_user", id_user);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@hak_akses", hak_akses);
                //MessageBox.Show(query);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diupdate", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }
    }
}
