namespace Surat
{
    partial class FormSuratMasukAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSuratMasukAdmin));
            this.dataGridViewSuratMasuk = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupBoxCariSuratMasuk = new System.Windows.Forms.GroupBox();
            this.radioButtonTanggalTerima = new System.Windows.Forms.RadioButton();
            this.radioButtonTanggalSurat = new System.Windows.Forms.RadioButton();
            this.textBoxCariSuratMasuk = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.radioButtonPerihalSuratMasuk = new System.Windows.Forms.RadioButton();
            this.radioButtonInstansiPengirim = new System.Windows.Forms.RadioButton();
            this.radioButtonNomorSuratMasuk = new System.Windows.Forms.RadioButton();
            this.dateTimeInputTanggalSurat = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.buttonKembali = new DevComponents.DotNetBar.ButtonX();
            this.buttonDetail = new DevComponents.DotNetBar.ButtonX();
            this.labelJumlahSurat = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuratMasuk)).BeginInit();
            this.groupBoxCariSuratMasuk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputTanggalSurat)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSuratMasuk
            // 
            this.dataGridViewSuratMasuk.AllowUserToAddRows = false;
            this.dataGridViewSuratMasuk.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSuratMasuk.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSuratMasuk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSuratMasuk.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSuratMasuk.EnableHeadersVisualStyles = false;
            this.dataGridViewSuratMasuk.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewSuratMasuk.Location = new System.Drawing.Point(12, 140);
            this.dataGridViewSuratMasuk.Name = "dataGridViewSuratMasuk";
            this.dataGridViewSuratMasuk.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSuratMasuk.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSuratMasuk.RowHeadersVisible = false;
            this.dataGridViewSuratMasuk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSuratMasuk.Size = new System.Drawing.Size(801, 394);
            this.dataGridViewSuratMasuk.TabIndex = 0;
            this.dataGridViewSuratMasuk.SelectionChanged += new System.EventHandler(this.dataGridViewSuratMasuk_SelectionChanged);
            // 
            // groupBoxCariSuratMasuk
            // 
            this.groupBoxCariSuratMasuk.Controls.Add(this.radioButtonTanggalTerima);
            this.groupBoxCariSuratMasuk.Controls.Add(this.radioButtonTanggalSurat);
            this.groupBoxCariSuratMasuk.Controls.Add(this.textBoxCariSuratMasuk);
            this.groupBoxCariSuratMasuk.Controls.Add(this.labelX1);
            this.groupBoxCariSuratMasuk.Controls.Add(this.radioButtonPerihalSuratMasuk);
            this.groupBoxCariSuratMasuk.Controls.Add(this.radioButtonInstansiPengirim);
            this.groupBoxCariSuratMasuk.Controls.Add(this.radioButtonNomorSuratMasuk);
            this.groupBoxCariSuratMasuk.Controls.Add(this.dateTimeInputTanggalSurat);
            this.groupBoxCariSuratMasuk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCariSuratMasuk.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCariSuratMasuk.Name = "groupBoxCariSuratMasuk";
            this.groupBoxCariSuratMasuk.Size = new System.Drawing.Size(801, 111);
            this.groupBoxCariSuratMasuk.TabIndex = 1;
            this.groupBoxCariSuratMasuk.TabStop = false;
            this.groupBoxCariSuratMasuk.Text = "Pencarian Data Surat Masuk";
            // 
            // radioButtonTanggalTerima
            // 
            this.radioButtonTanggalTerima.AutoSize = true;
            this.radioButtonTanggalTerima.Location = new System.Drawing.Point(516, 43);
            this.radioButtonTanggalTerima.Name = "radioButtonTanggalTerima";
            this.radioButtonTanggalTerima.Size = new System.Drawing.Size(123, 20);
            this.radioButtonTanggalTerima.TabIndex = 7;
            this.radioButtonTanggalTerima.Text = "Tanggal Terima";
            this.radioButtonTanggalTerima.UseVisualStyleBackColor = true;
            this.radioButtonTanggalTerima.CheckedChanged += new System.EventHandler(this.radioButtonTanggalTerima_CheckedChanged);
            // 
            // radioButtonTanggalSurat
            // 
            this.radioButtonTanggalSurat.AutoSize = true;
            this.radioButtonTanggalSurat.Location = new System.Drawing.Point(385, 43);
            this.radioButtonTanggalSurat.Name = "radioButtonTanggalSurat";
            this.radioButtonTanggalSurat.Size = new System.Drawing.Size(111, 20);
            this.radioButtonTanggalSurat.TabIndex = 5;
            this.radioButtonTanggalSurat.Text = "Tanggal Surat";
            this.radioButtonTanggalSurat.UseVisualStyleBackColor = true;
            this.radioButtonTanggalSurat.CheckedChanged += new System.EventHandler(this.radioButtonTanggalSurat_CheckedChanged);
            // 
            // textBoxCariSuratMasuk
            // 
            // 
            // 
            // 
            this.textBoxCariSuratMasuk.Border.Class = "TextBoxBorder";
            this.textBoxCariSuratMasuk.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxCariSuratMasuk.Location = new System.Drawing.Point(16, 73);
            this.textBoxCariSuratMasuk.Name = "textBoxCariSuratMasuk";
            this.textBoxCariSuratMasuk.Size = new System.Drawing.Size(762, 22);
            this.textBoxCariSuratMasuk.TabIndex = 4;
            this.textBoxCariSuratMasuk.TextChanged += new System.EventHandler(this.textBoxCariSuratMasuk_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(16, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(263, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "Pencarian Data Surat Masuk Berdasarkan:";
            // 
            // radioButtonPerihalSuratMasuk
            // 
            this.radioButtonPerihalSuratMasuk.AutoSize = true;
            this.radioButtonPerihalSuratMasuk.Location = new System.Drawing.Point(146, 43);
            this.radioButtonPerihalSuratMasuk.Name = "radioButtonPerihalSuratMasuk";
            this.radioButtonPerihalSuratMasuk.Size = new System.Drawing.Size(68, 20);
            this.radioButtonPerihalSuratMasuk.TabIndex = 2;
            this.radioButtonPerihalSuratMasuk.Text = "Perihal";
            this.radioButtonPerihalSuratMasuk.UseVisualStyleBackColor = true;
            this.radioButtonPerihalSuratMasuk.CheckedChanged += new System.EventHandler(this.radioButtonPerihalSuratMasuk_CheckedChanged);
            // 
            // radioButtonInstansiPengirim
            // 
            this.radioButtonInstansiPengirim.AutoSize = true;
            this.radioButtonInstansiPengirim.Location = new System.Drawing.Point(235, 43);
            this.radioButtonInstansiPengirim.Name = "radioButtonInstansiPengirim";
            this.radioButtonInstansiPengirim.Size = new System.Drawing.Size(127, 20);
            this.radioButtonInstansiPengirim.TabIndex = 1;
            this.radioButtonInstansiPengirim.Text = "Instansi Pengirim";
            this.radioButtonInstansiPengirim.UseVisualStyleBackColor = true;
            this.radioButtonInstansiPengirim.CheckedChanged += new System.EventHandler(this.radioButtonInstansiPengirim_CheckedChanged);
            // 
            // radioButtonNomorSuratMasuk
            // 
            this.radioButtonNomorSuratMasuk.AutoSize = true;
            this.radioButtonNomorSuratMasuk.Checked = true;
            this.radioButtonNomorSuratMasuk.Location = new System.Drawing.Point(16, 43);
            this.radioButtonNomorSuratMasuk.Name = "radioButtonNomorSuratMasuk";
            this.radioButtonNomorSuratMasuk.Size = new System.Drawing.Size(101, 20);
            this.radioButtonNomorSuratMasuk.TabIndex = 0;
            this.radioButtonNomorSuratMasuk.TabStop = true;
            this.radioButtonNomorSuratMasuk.Text = "Nomor Surat";
            this.radioButtonNomorSuratMasuk.UseVisualStyleBackColor = true;
            this.radioButtonNomorSuratMasuk.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // dateTimeInputTanggalSurat
            // 
            // 
            // 
            // 
            this.dateTimeInputTanggalSurat.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInputTanggalSurat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInputTanggalSurat.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInputTanggalSurat.ButtonDropDown.Visible = true;
            this.dateTimeInputTanggalSurat.CustomFormat = "dd-MM-yyyy";
            this.dateTimeInputTanggalSurat.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dateTimeInputTanggalSurat.IsPopupCalendarOpen = false;
            this.dateTimeInputTanggalSurat.Location = new System.Drawing.Point(16, 73);
            // 
            // 
            // 
            this.dateTimeInputTanggalSurat.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInputTanggalSurat.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInputTanggalSurat.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInputTanggalSurat.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInputTanggalSurat.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInputTanggalSurat.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInputTanggalSurat.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInputTanggalSurat.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInputTanggalSurat.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInputTanggalSurat.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInputTanggalSurat.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInputTanggalSurat.MonthCalendar.DisplayMonth = new System.DateTime(2015, 8, 1, 0, 0, 0, 0);
            this.dateTimeInputTanggalSurat.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInputTanggalSurat.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInputTanggalSurat.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInputTanggalSurat.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInputTanggalSurat.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInputTanggalSurat.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInputTanggalSurat.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInputTanggalSurat.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInputTanggalSurat.MonthCalendar.DateChanged += new System.EventHandler(this.dateTimeInput1_MonthCalendar_DateChanged);
            this.dateTimeInputTanggalSurat.Name = "dateTimeInputTanggalSurat";
            this.dateTimeInputTanggalSurat.Size = new System.Drawing.Size(762, 22);
            this.dateTimeInputTanggalSurat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInputTanggalSurat.TabIndex = 6;
            // 
            // buttonKembali
            // 
            this.buttonKembali.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonKembali.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonKembali.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKembali.Location = new System.Drawing.Point(833, 489);
            this.buttonKembali.Name = "buttonKembali";
            this.buttonKembali.Size = new System.Drawing.Size(106, 45);
            this.buttonKembali.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonKembali.TabIndex = 5;
            this.buttonKembali.Text = "Kembali";
            this.buttonKembali.Click += new System.EventHandler(this.buttonKembali_Click);
            // 
            // buttonDetail
            // 
            this.buttonDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonDetail.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDetail.Location = new System.Drawing.Point(833, 12);
            this.buttonDetail.Name = "buttonDetail";
            this.buttonDetail.Size = new System.Drawing.Size(106, 45);
            this.buttonDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonDetail.TabIndex = 6;
            this.buttonDetail.Text = "Detail";
            this.buttonDetail.Click += new System.EventHandler(this.buttonDetail_Click);
            // 
            // labelJumlahSurat
            // 
            // 
            // 
            // 
            this.labelJumlahSurat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelJumlahSurat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJumlahSurat.Location = new System.Drawing.Point(12, 542);
            this.labelJumlahSurat.Name = "labelJumlahSurat";
            this.labelJumlahSurat.Size = new System.Drawing.Size(235, 23);
            this.labelJumlahSurat.TabIndex = 8;
            // 
            // FormSuratMasukAdmin
            // 
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.labelJumlahSurat);
            this.Controls.Add(this.buttonDetail);
            this.Controls.Add(this.buttonKembali);
            this.Controls.Add(this.groupBoxCariSuratMasuk);
            this.Controls.Add(this.dataGridViewSuratMasuk);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSuratMasukAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Surat Masuk";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSuratMasuk_FormClosed);
            this.Load += new System.EventHandler(this.FormSuratMasuk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuratMasuk)).EndInit();
            this.groupBoxCariSuratMasuk.ResumeLayout(false);
            this.groupBoxCariSuratMasuk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInputTanggalSurat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewSuratMasuk;
        private System.Windows.Forms.GroupBox groupBoxCariSuratMasuk;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxCariSuratMasuk;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.RadioButton radioButtonPerihalSuratMasuk;
        private System.Windows.Forms.RadioButton radioButtonInstansiPengirim;
        private System.Windows.Forms.RadioButton radioButtonNomorSuratMasuk;
        private DevComponents.DotNetBar.ButtonX buttonKembali;
        private DevComponents.DotNetBar.ButtonX buttonDetail;
        private System.Windows.Forms.RadioButton radioButtonTanggalSurat;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInputTanggalSurat;
        private DevComponents.DotNetBar.LabelX labelJumlahSurat;
        private System.Windows.Forms.RadioButton radioButtonTanggalTerima;
    }
}