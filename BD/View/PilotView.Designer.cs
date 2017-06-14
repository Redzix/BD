namespace BD.View
{
    partial class PilotView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="dispsosing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();
            this.l_zalogowany_jako = new System.Windows.Forms.Label();
            this.b_wyjdz = new System.Windows.Forms.Button();
            this.l_uzytkownik = new System.Windows.Forms.Label();
            this.l_polaczenie = new System.Windows.Forms.Label();
            this.lv_pilot = new System.Windows.Forms.ListView();
            this.nazwaWycieczki = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataWyjazdu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataPowrotu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pojazd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.kierowca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // l_zalogowany_jako
            // 
            this.l_zalogowany_jako.AutoSize = true;
            this.l_zalogowany_jako.Location = new System.Drawing.Point(154, 197);
            this.l_zalogowany_jako.Name = "l_zalogowany_jako";
            this.l_zalogowany_jako.Size = new System.Drawing.Size(88, 13);
            this.l_zalogowany_jako.TabIndex = 1;
            this.l_zalogowany_jako.Text = "Zalogowany jako";
            // 
            // b_wyjdz
            // 
            this.b_wyjdz.Location = new System.Drawing.Point(529, 192);
            this.b_wyjdz.Name = "b_wyjdz";
            this.b_wyjdz.Size = new System.Drawing.Size(75, 23);
            this.b_wyjdz.TabIndex = 2;
            this.b_wyjdz.Text = "Wyjdź";
            this.b_wyjdz.UseVisualStyleBackColor = true;
            this.b_wyjdz.Click += new System.EventHandler(this.b_wyjdz_Click);
            // 
            // l_uzytkownik
            // 
            this.l_uzytkownik.AutoSize = true;
            this.l_uzytkownik.Location = new System.Drawing.Point(240, 197);
            this.l_uzytkownik.Name = "l_uzytkownik";
            this.l_uzytkownik.Size = new System.Drawing.Size(10, 13);
            this.l_uzytkownik.TabIndex = 3;
            this.l_uzytkownik.Text = " ";
            // 
            // l_polaczenie
            // 
            this.l_polaczenie.AutoSize = true;
            this.l_polaczenie.Location = new System.Drawing.Point(16, 197);
            this.l_polaczenie.Name = "l_polaczenie";
            this.l_polaczenie.Size = new System.Drawing.Size(10, 13);
            this.l_polaczenie.TabIndex = 7;
            this.l_polaczenie.Text = " ";
            // 
            // lv_pilot
            // 
            this.lv_pilot.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nazwaWycieczki,
            this.dataWyjazdu,
            this.dataPowrotu,
            this.pojazd,
            this.kierowca});
            this.lv_pilot.Dock = System.Windows.Forms.DockStyle.Top;
            this.lv_pilot.FullRowSelect = true;
            this.lv_pilot.Location = new System.Drawing.Point(0, 0);
            this.lv_pilot.Name = "lv_pilot";
            this.lv_pilot.Size = new System.Drawing.Size(616, 175);
            this.lv_pilot.TabIndex = 8;
            this.lv_pilot.UseCompatibleStateImageBehavior = false;
            this.lv_pilot.View = System.Windows.Forms.View.Details;
            this.lv_pilot.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_pilot_ColumnClick);
            // 
            // nazwaWycieczki
            // 
            this.nazwaWycieczki.Text = "Nazwa wycieczki";
            this.nazwaWycieczki.Width = 110;
            // 
            // dataWyjazdu
            // 
            this.dataWyjazdu.Text = "Data wyjazdu";
            this.dataWyjazdu.Width = 130;
            // 
            // dataPowrotu
            // 
            this.dataPowrotu.Text = "Data powrotu";
            this.dataPowrotu.Width = 130;
            // 
            // pojazd
            // 
            this.pojazd.Text = "Pojazd";
            this.pojazd.Width = 110;
            // 
            // kierowca
            // 
            this.kierowca.Text = "Kierowca";
            this.kierowca.Width = 110;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "C:\\Users\\karol\\Source\\Re\\BD\\BD\\Helper\\Klient.chm";
            // 
            // PilotView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 219);
            this.Controls.Add(this.lv_pilot);
            this.Controls.Add(this.l_polaczenie);
            this.Controls.Add(this.l_uzytkownik);
            this.Controls.Add(this.b_wyjdz);
            this.Controls.Add(this.l_zalogowany_jako);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Index);
            this.MaximizeBox = false;
            this.Name = "PilotView";
            this.helpProvider.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pilot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pilot_FormClosing);
            this.Load += new System.EventHandler(this.Pilot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label l_zalogowany_jako;
        private System.Windows.Forms.Button b_wyjdz;
        private System.Windows.Forms.Label l_uzytkownik;
        private System.Windows.Forms.Label l_polaczenie;
        public System.Windows.Forms.ListView lv_pilot;
        public System.Windows.Forms.ColumnHeader nazwaWycieczki;
        public System.Windows.Forms.ColumnHeader dataWyjazdu;
        public System.Windows.Forms.ColumnHeader dataPowrotu;
        public System.Windows.Forms.ColumnHeader pojazd;
        public System.Windows.Forms.ColumnHeader kierowca;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.HelpProvider helpProvider;
    }
}