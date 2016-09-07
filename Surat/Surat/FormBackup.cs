using System;
using System.Windows.Forms;

namespace Surat
{
    public partial class FormBackup : DevComponents.DotNetBar.OfficeForm
    {
        public FormBackup()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            backupRestore backup_restore = new backupRestore();
            backup_restore.backup();
        }

        private void FormBackup_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMainAdmin main = new FormMainAdmin();
            main.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            backupRestore backup_restore = new backupRestore();
            backup_restore.restore();
        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}