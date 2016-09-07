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

    public partial class FormLogin : DevComponents.DotNetBar.OfficeForm
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        public static string id_user;

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            user u = new user();
            if(u.cekLogin(textBoxUsername.Text, textBoxPassword.Text))
            {
                this.Hide();
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}