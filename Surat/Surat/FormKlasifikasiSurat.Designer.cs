namespace Surat
{
    partial class FormKlasifikasiSurat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKlasifikasiSurat));
            this.dataGridViewJenisSurat = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.textBoxCari = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonHapusJenisSurat = new DevComponents.DotNetBar.ButtonX();
            this.buttonJenisSuratKembali = new DevComponents.DotNetBar.ButtonX();
            this.buttonTambahJenisSurat = new DevComponents.DotNetBar.ButtonX();
            this.buttonEditJenisSurat = new DevComponents.DotNetBar.ButtonX();
            this.comboBoxJenisSurat = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJenisSurat)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewJenisSurat
            // 
            this.dataGridViewJenisSurat.AllowUserToAddRows = false;
            this.dataGridViewJenisSurat.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewJenisSurat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewJenisSurat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewJenisSurat.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewJenisSurat.EnableHeadersVisualStyles = false;
            this.dataGridViewJenisSurat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewJenisSurat.Location = new System.Drawing.Point(12, 84);
            this.dataGridViewJenisSurat.Name = "dataGridViewJenisSurat";
            this.dataGridViewJenisSurat.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewJenisSurat.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewJenisSurat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewJenisSurat.Size = new System.Drawing.Size(301, 255);
            this.dataGridViewJenisSurat.TabIndex = 0;
            this.dataGridViewJenisSurat.SelectionChanged += new System.EventHandler(this.dataGridViewJenisSurat_SelectionChanged);
            // 
            // textBoxCari
            // 
            // 
            // 
            // 
            this.textBoxCari.Border.Class = "TextBoxBorder";
            this.textBoxCari.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCari.Location = new System.Drawing.Point(12, 41);
            this.textBoxCari.Name = "textBoxCari";
            this.textBoxCari.Size = new System.Drawing.Size(301, 26);
            this.textBoxCari.TabIndex = 1;
            this.textBoxCari.TextChanged += new System.EventHandler(this.textBoxCari_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(97, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Cari Jenis Surat";
            // 
            // buttonHapusJenisSurat
            // 
            this.buttonHapusJenisSurat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHapusJenisSurat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonHapusJenisSurat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHapusJenisSurat.Location = new System.Drawing.Point(351, 172);
            this.buttonHapusJenisSurat.Name = "buttonHapusJenisSurat";
            this.buttonHapusJenisSurat.Size = new System.Drawing.Size(186, 54);
            this.buttonHapusJenisSurat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonHapusJenisSurat.TabIndex = 5;
            this.buttonHapusJenisSurat.Text = "Hapus Data";
            this.buttonHapusJenisSurat.Click += new System.EventHandler(this.buttonHapusJenisSurat_Click);
            // 
            // buttonJenisSuratKembali
            // 
            this.buttonJenisSuratKembali.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonJenisSuratKembali.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonJenisSuratKembali.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonJenisSuratKembali.Location = new System.Drawing.Point(351, 285);
            this.buttonJenisSuratKembali.Name = "buttonJenisSuratKembali";
            this.buttonJenisSuratKembali.Size = new System.Drawing.Size(186, 54);
            this.buttonJenisSuratKembali.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonJenisSuratKembali.TabIndex = 6;
            this.buttonJenisSuratKembali.Text = "Kembali";
            this.buttonJenisSuratKembali.Click += new System.EventHandler(this.buttonKembali_Click);
            // 
            // buttonTambahJenisSurat
            // 
            this.buttonTambahJenisSurat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonTambahJenisSurat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonTambahJenisSurat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambahJenisSurat.Location = new System.Drawing.Point(351, 29);
            this.buttonTambahJenisSurat.Name = "buttonTambahJenisSurat";
            this.buttonTambahJenisSurat.Size = new System.Drawing.Size(186, 54);
            this.buttonTambahJenisSurat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonTambahJenisSurat.TabIndex = 3;
            this.buttonTambahJenisSurat.Text = "Tambah Data";
            this.buttonTambahJenisSurat.Click += new System.EventHandler(this.buttonTambah_Click);
            // 
            // buttonEditJenisSurat
            // 
            this.buttonEditJenisSurat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonEditJenisSurat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonEditJenisSurat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditJenisSurat.Location = new System.Drawing.Point(351, 100);
            this.buttonEditJenisSurat.Name = "buttonEditJenisSurat";
            this.buttonEditJenisSurat.Size = new System.Drawing.Size(186, 54);
            this.buttonEditJenisSurat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonEditJenisSurat.TabIndex = 4;
            this.buttonEditJenisSurat.Text = "Edit Data";
            this.buttonEditJenisSurat.Click += new System.EventHandler(this.buttonEditJenisSurat_Click);
            // 
            // comboBoxJenisSurat
            // 
            this.comboBoxJenisSurat.DisplayMember = "Text";
            this.comboBoxJenisSurat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxJenisSurat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxJenisSurat.FormattingEnabled = true;
            this.comboBoxJenisSurat.ItemHeight = 20;
            this.comboBoxJenisSurat.Location = new System.Drawing.Point(12, 41);
            this.comboBoxJenisSurat.Name = "comboBoxJenisSurat";
            this.comboBoxJenisSurat.Size = new System.Drawing.Size(301, 26);
            this.comboBoxJenisSurat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxJenisSurat.TabIndex = 7;
            this.comboBoxJenisSurat.SelectedIndexChanged += new System.EventHandler(this.comboBoxJenisSurat_SelectedIndexChanged);
            this.comboBoxJenisSurat.TextChanged += new System.EventHandler(this.comboBoxJenisSurat_TextChanged);
            // 
            // FormKlasifikasiSurat
            // 
            this.ClientSize = new System.Drawing.Size(549, 357);
            this.Controls.Add(this.comboBoxJenisSurat);
            this.Controls.Add(this.buttonJenisSuratKembali);
            this.Controls.Add(this.buttonHapusJenisSurat);
            this.Controls.Add(this.buttonEditJenisSurat);
            this.Controls.Add(this.buttonTambahJenisSurat);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.textBoxCari);
            this.Controls.Add(this.dataGridViewJenisSurat);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormKlasifikasiSurat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Klasifikasi Surat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormKlasifikasiSurat_FormClosed);
            this.Load += new System.EventHandler(this.FormKlasifikasiSurat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJenisSurat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewJenisSurat;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxCari;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonTambahJenisSurat;
        private DevComponents.DotNetBar.ButtonX buttonEditJenisSurat;
        private DevComponents.DotNetBar.ButtonX buttonHapusJenisSurat;
        private DevComponents.DotNetBar.ButtonX buttonJenisSuratKembali;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxJenisSurat;
    }
}