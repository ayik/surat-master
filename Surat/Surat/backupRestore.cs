using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using System.IO;

namespace Surat
{
    class backupRestore
    {
        public void backup()
        {
            SaveFileDialog sfBackup = new SaveFileDialog();

            sfBackup.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
            sfBackup.RestoreDirectory = true;
            //sfBackup.ShowDialog();

            Database dbc = new Database();
            string strconnect = dbc.getString();
            MySqlConnection connect = new MySqlConnection(strconnect);
            connect.Open();
            if (sfBackup.ShowDialog() == DialogResult.OK)
            {
                string filename = "" + sfBackup.FileName + "";

                using (MySqlConnection cn = new MySqlConnection(strconnect))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {

                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = cn;
                            cn.Open();
                            mb.ExportToFile(filename);
                            cn.Close();

                        }

                    }
                }
                try
                {
                    bool backupResult = true;
                    if (backupResult == true)
                    {
                        MessageBox.Show("Sukses Backup Database!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Gagal Backup Database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void restore()
        {
            OpenFileDialog ofRestore = new OpenFileDialog();
            ofRestore.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
            ofRestore.RestoreDirectory = true;

            Database dbc = new Database();
            string strconnect = dbc.getString();
            MySqlConnection connect = new MySqlConnection(strconnect);
            connect.Open();

            if (ofRestore.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(strconnect))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                mb.ImportFromFile(ofRestore.FileName);
                                conn.Close();
                                MessageBox.Show("Restore berhasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
