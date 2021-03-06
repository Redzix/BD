﻿namespace BD.View
{
    partial class KierowcaView
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
            this.components = new System.ComponentModel.Container();
            this.l_zalgowany_jako = new System.Windows.Forms.Label();
            this.rb_sprawny = new System.Windows.Forms.RadioButton();
            this.rb_awaria = new System.Windows.Forms.RadioButton();
            this.gb_stan_pojazdu = new System.Windows.Forms.GroupBox();
            this.b_kierowca_zapisz = new System.Windows.Forms.Button();
            this.b_kierowca_wyjdz = new System.Windows.Forms.Button();
            this.lv_pojazdy = new System.Windows.Forms.ListView();
            this.Nr_rejestracyjny = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dostępnosc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Marka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pojemnosc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.l_uzytkownik = new System.Windows.Forms.Label();
            this.l_polaczenie = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.gb_stan_pojazdu.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_zalgowany_jako
            // 
            this.l_zalgowany_jako.AutoSize = true;
            this.l_zalgowany_jako.Location = new System.Drawing.Point(92, 239);
            this.l_zalgowany_jako.Name = "l_zalgowany_jako";
            this.l_zalgowany_jako.Size = new System.Drawing.Size(88, 13);
            this.l_zalgowany_jako.TabIndex = 1;
            this.l_zalgowany_jako.Text = "Zalogowany jako";
            // 
            // rb_sprawny
            // 
            this.rb_sprawny.AutoSize = true;
            this.rb_sprawny.Enabled = false;
            this.rb_sprawny.Location = new System.Drawing.Point(16, 44);
            this.rb_sprawny.Name = "rb_sprawny";
            this.rb_sprawny.Size = new System.Drawing.Size(66, 17);
            this.rb_sprawny.TabIndex = 3;
            this.rb_sprawny.TabStop = true;
            this.rb_sprawny.Text = "Sprawny";
            this.rb_sprawny.UseVisualStyleBackColor = true;
            // 
            // rb_awaria
            // 
            this.rb_awaria.AutoSize = true;
            this.rb_awaria.Enabled = false;
            this.rb_awaria.Location = new System.Drawing.Point(127, 44);
            this.rb_awaria.Name = "rb_awaria";
            this.rb_awaria.Size = new System.Drawing.Size(57, 17);
            this.rb_awaria.TabIndex = 4;
            this.rb_awaria.TabStop = true;
            this.rb_awaria.Text = "Awaria";
            this.rb_awaria.UseVisualStyleBackColor = true;
            // 
            // gb_stan_pojazdu
            // 
            this.gb_stan_pojazdu.Controls.Add(this.rb_awaria);
            this.gb_stan_pojazdu.Controls.Add(this.rb_sprawny);
            this.gb_stan_pojazdu.Location = new System.Drawing.Point(432, 33);
            this.gb_stan_pojazdu.Name = "gb_stan_pojazdu";
            this.gb_stan_pojazdu.Size = new System.Drawing.Size(200, 100);
            this.gb_stan_pojazdu.TabIndex = 5;
            this.gb_stan_pojazdu.TabStop = false;
            this.gb_stan_pojazdu.Text = "Stan pojazdu";
            // 
            // b_kierowca_zapisz
            // 
            this.b_kierowca_zapisz.Enabled = false;
            this.b_kierowca_zapisz.Location = new System.Drawing.Point(432, 161);
            this.b_kierowca_zapisz.Name = "b_kierowca_zapisz";
            this.b_kierowca_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_kierowca_zapisz.TabIndex = 6;
            this.b_kierowca_zapisz.Text = "Zapisz";
            this.b_kierowca_zapisz.UseVisualStyleBackColor = true;
            this.b_kierowca_zapisz.Click += new System.EventHandler(this.b_kierowca_zapisz_Click);
            // 
            // b_kierowca_wyjdz
            // 
            this.b_kierowca_wyjdz.Location = new System.Drawing.Point(557, 161);
            this.b_kierowca_wyjdz.Name = "b_kierowca_wyjdz";
            this.b_kierowca_wyjdz.Size = new System.Drawing.Size(75, 23);
            this.b_kierowca_wyjdz.TabIndex = 7;
            this.b_kierowca_wyjdz.Text = "Wyjdź";
            this.b_kierowca_wyjdz.UseVisualStyleBackColor = true;
            this.b_kierowca_wyjdz.Click += new System.EventHandler(this.b_kierowca_wyjdz_Click);
            // 
            // lv_pojazdy
            // 
            this.lv_pojazdy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nr_rejestracyjny,
            this.Dostępnosc,
            this.Marka,
            this.Pojemnosc,
            this.Stan});
            this.lv_pojazdy.FullRowSelect = true;
            this.lv_pojazdy.GridLines = true;
            this.lv_pojazdy.Location = new System.Drawing.Point(8, 3);
            this.lv_pojazdy.MultiSelect = false;
            this.lv_pojazdy.Name = "lv_pojazdy";
            this.lv_pojazdy.Size = new System.Drawing.Size(398, 233);
            this.lv_pojazdy.TabIndex = 1;
            this.lv_pojazdy.UseCompatibleStateImageBehavior = false;
            this.lv_pojazdy.View = System.Windows.Forms.View.Details;
            this.lv_pojazdy.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_pojazdy_ColumnClick);
            this.lv_pojazdy.ItemActivate += new System.EventHandler(this.lv_pojazdy_ItemActivate);
            // 
            // Nr_rejestracyjny
            // 
            this.Nr_rejestracyjny.Text = "Numer rejestracyjny";
            this.Nr_rejestracyjny.Width = 110;
            // 
            // Dostępnosc
            // 
            this.Dostępnosc.Text = "Dostępność";
            this.Dostępnosc.Width = 70;
            // 
            // Marka
            // 
            this.Marka.Text = "Marka";
            this.Marka.Width = 72;
            // 
            // Pojemnosc
            // 
            this.Pojemnosc.Text = "Pojemnosc";
            this.Pojemnosc.Width = 70;
            // 
            // Stan
            // 
            this.Stan.Text = "Stan";
            this.Stan.Width = 55;
            // 
            // l_uzytkownik
            // 
            this.l_uzytkownik.AutoSize = true;
            this.l_uzytkownik.Location = new System.Drawing.Point(178, 239);
            this.l_uzytkownik.Name = "l_uzytkownik";
            this.l_uzytkownik.Size = new System.Drawing.Size(10, 13);
            this.l_uzytkownik.TabIndex = 11;
            this.l_uzytkownik.Text = " ";
            // 
            // l_polaczenie
            // 
            this.l_polaczenie.AutoSize = true;
            this.l_polaczenie.Location = new System.Drawing.Point(18, 239);
            this.l_polaczenie.Name = "l_polaczenie";
            this.l_polaczenie.Size = new System.Drawing.Size(10, 13);
            this.l_polaczenie.TabIndex = 12;
            this.l_polaczenie.Text = " ";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "C:\\Users\\karol\\Source\\Re\\BD\\BD\\Helper\\Kierowca.chm";
            // 
            // KierowcaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 261);
            this.Controls.Add(this.l_polaczenie);
            this.Controls.Add(this.l_uzytkownik);
            this.Controls.Add(this.lv_pojazdy);
            this.Controls.Add(this.b_kierowca_wyjdz);
            this.Controls.Add(this.b_kierowca_zapisz);
            this.Controls.Add(this.gb_stan_pojazdu);
            this.Controls.Add(this.l_zalgowany_jako);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Index);
            this.MinimizeBox = false;
            this.Name = "KierowcaView";
            this.helpProvider.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kierowca";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kierowca_FormClosing);
            this.Load += new System.EventHandler(this.Kierowca_Load);
            this.gb_stan_pojazdu.ResumeLayout(false);
            this.gb_stan_pojazdu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_zalgowany_jako;
        public System.Windows.Forms.RadioButton rb_sprawny;
        public System.Windows.Forms.RadioButton rb_awaria;
        private System.Windows.Forms.GroupBox gb_stan_pojazdu;
        private System.Windows.Forms.Button b_kierowca_zapisz;
        private System.Windows.Forms.Button b_kierowca_wyjdz;
        public System.Windows.Forms.ListView lv_pojazdy;
        public System.Windows.Forms.ColumnHeader Nr_rejestracyjny;
        public System.Windows.Forms.ColumnHeader Dostępnosc;
        public System.Windows.Forms.ColumnHeader Marka;
        public System.Windows.Forms.ColumnHeader Pojemnosc;
        public System.Windows.Forms.ColumnHeader Stan;
        private System.Windows.Forms.Label l_uzytkownik;
        private System.Windows.Forms.Label l_polaczenie;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.HelpProvider helpProvider;
    }
}