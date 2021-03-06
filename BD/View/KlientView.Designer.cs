﻿namespace BD.View
{
    partial class KlientView
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
            this.rtb_wycieczka = new System.Windows.Forms.RichTextBox();
            this.b_katalog_rezerwuj = new System.Windows.Forms.Button();
            this.b_katalog_wyjdz = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.wystawOpinięToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reklamujWycieczkęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezygnacjaZWycieczkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyświetlWszystkieWycieczkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyświetlMojeRezerwacjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.l_polaczenie = new System.Windows.Forms.Label();
            this.b_zaplac = new System.Windows.Forms.Button();
            this.l_uzytkownik = new System.Windows.Forms.Label();
            this.l_zalogowany_jako = new System.Windows.Forms.Label();
            this.lv_klient = new System.Windows.Forms.ListView();
            this.nazwaWycieczki = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.okresTrwania = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataWyjazdu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.promocja = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cenaCalkowita = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cenaDoZaplaty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tb_szukaj = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.l_szukaj = new System.Windows.Forms.Label();
            this.b_szukaj = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb_wycieczka
            // 
            this.rtb_wycieczka.Location = new System.Drawing.Point(613, 27);
            this.rtb_wycieczka.Name = "rtb_wycieczka";
            this.rtb_wycieczka.ReadOnly = true;
            this.rtb_wycieczka.Size = new System.Drawing.Size(330, 232);
            this.rtb_wycieczka.TabIndex = 1;
            this.rtb_wycieczka.Text = "Nazwa\nData wyjazdu\nData powrotu\nOpis\n\nAdres miejsca\nMiejscowość";
            // 
            // b_katalog_rezerwuj
            // 
            this.b_katalog_rezerwuj.Enabled = false;
            this.b_katalog_rezerwuj.Location = new System.Drawing.Point(868, 263);
            this.b_katalog_rezerwuj.Name = "b_katalog_rezerwuj";
            this.b_katalog_rezerwuj.Size = new System.Drawing.Size(75, 23);
            this.b_katalog_rezerwuj.TabIndex = 2;
            this.b_katalog_rezerwuj.Text = "Rezerwuj";
            this.b_katalog_rezerwuj.UseVisualStyleBackColor = true;
            this.b_katalog_rezerwuj.Click += new System.EventHandler(this.b_katalog_rezerwuj_Click);
            // 
            // b_katalog_wyjdz
            // 
            this.b_katalog_wyjdz.Location = new System.Drawing.Point(868, 343);
            this.b_katalog_wyjdz.Name = "b_katalog_wyjdz";
            this.b_katalog_wyjdz.Size = new System.Drawing.Size(75, 23);
            this.b_katalog_wyjdz.TabIndex = 3;
            this.b_katalog_wyjdz.Text = "Wyjdź";
            this.b_katalog_wyjdz.UseVisualStyleBackColor = true;
            this.b_katalog_wyjdz.Click += new System.EventHandler(this.b_katalog_wyjdz_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wystawOpinięToolStripMenuItem,
            this.reklamujWycieczkęToolStripMenuItem,
            this.rezygnacjaZWycieczkiToolStripMenuItem,
            this.wyświetlWszystkieWycieczkiToolStripMenuItem,
            this.wyświetlMojeRezerwacjeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(955, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // wystawOpinięToolStripMenuItem
            // 
            this.wystawOpinięToolStripMenuItem.Name = "wystawOpinięToolStripMenuItem";
            this.wystawOpinięToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.wystawOpinięToolStripMenuItem.Text = "Wystaw opinię";
            this.wystawOpinięToolStripMenuItem.Click += new System.EventHandler(this.wystawOpinięToolStripMenuItem_Click);
            // 
            // reklamujWycieczkęToolStripMenuItem
            // 
            this.reklamujWycieczkęToolStripMenuItem.Name = "reklamujWycieczkęToolStripMenuItem";
            this.reklamujWycieczkęToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.reklamujWycieczkęToolStripMenuItem.Text = "Reklamuj wycieczkę";
            this.reklamujWycieczkęToolStripMenuItem.Click += new System.EventHandler(this.reklamujWycieczkęToolStripMenuItem_Click);
            // 
            // rezygnacjaZWycieczkiToolStripMenuItem
            // 
            this.rezygnacjaZWycieczkiToolStripMenuItem.Name = "rezygnacjaZWycieczkiToolStripMenuItem";
            this.rezygnacjaZWycieczkiToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.rezygnacjaZWycieczkiToolStripMenuItem.Text = "Rezygnacja z wycieczki";
            this.rezygnacjaZWycieczkiToolStripMenuItem.Click += new System.EventHandler(this.rezygnacjaZWycieczkiToolStripMenuItem_Click);
            // 
            // wyświetlWszystkieWycieczkiToolStripMenuItem
            // 
            this.wyświetlWszystkieWycieczkiToolStripMenuItem.Name = "wyświetlWszystkieWycieczkiToolStripMenuItem";
            this.wyświetlWszystkieWycieczkiToolStripMenuItem.Size = new System.Drawing.Size(171, 20);
            this.wyświetlWszystkieWycieczkiToolStripMenuItem.Text = "Wyświetl wszystkie wycieczki";
            this.wyświetlWszystkieWycieczkiToolStripMenuItem.Click += new System.EventHandler(this.wyswietlWszystkieWycieczkiToolStripMenuItem_Click);
            // 
            // wyświetlMojeRezerwacjeToolStripMenuItem
            // 
            this.wyświetlMojeRezerwacjeToolStripMenuItem.Name = "wyświetlMojeRezerwacjeToolStripMenuItem";
            this.wyświetlMojeRezerwacjeToolStripMenuItem.Size = new System.Drawing.Size(154, 20);
            this.wyświetlMojeRezerwacjeToolStripMenuItem.Text = "Wyświetl moje rezerwacje";
            this.wyświetlMojeRezerwacjeToolStripMenuItem.Click += new System.EventHandler(this.wyswietlMojeRezerwacjeToolStripMenuItem_Click);
            // 
            // l_polaczenie
            // 
            this.l_polaczenie.AutoSize = true;
            this.l_polaczenie.Location = new System.Drawing.Point(15, 348);
            this.l_polaczenie.Name = "l_polaczenie";
            this.l_polaczenie.Size = new System.Drawing.Size(10, 13);
            this.l_polaczenie.TabIndex = 10;
            this.l_polaczenie.Text = " ";
            // 
            // b_zaplac
            // 
            this.b_zaplac.Enabled = false;
            this.b_zaplac.Location = new System.Drawing.Point(776, 263);
            this.b_zaplac.Name = "b_zaplac";
            this.b_zaplac.Size = new System.Drawing.Size(75, 23);
            this.b_zaplac.TabIndex = 11;
            this.b_zaplac.Text = "Zapłać";
            this.b_zaplac.UseVisualStyleBackColor = true;
            this.b_zaplac.Click += new System.EventHandler(this.b_zaplac_Click);
            // 
            // l_uzytkownik
            // 
            this.l_uzytkownik.AutoSize = true;
            this.l_uzytkownik.Location = new System.Drawing.Point(174, 348);
            this.l_uzytkownik.Name = "l_uzytkownik";
            this.l_uzytkownik.Size = new System.Drawing.Size(10, 13);
            this.l_uzytkownik.TabIndex = 13;
            this.l_uzytkownik.Text = " ";
            // 
            // l_zalogowany_jako
            // 
            this.l_zalogowany_jako.AutoSize = true;
            this.l_zalogowany_jako.Location = new System.Drawing.Point(87, 348);
            this.l_zalogowany_jako.Name = "l_zalogowany_jako";
            this.l_zalogowany_jako.Size = new System.Drawing.Size(88, 13);
            this.l_zalogowany_jako.TabIndex = 12;
            this.l_zalogowany_jako.Text = "Zalogowany jako";
            // 
            // lv_klient
            // 
            this.lv_klient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nazwaWycieczki,
            this.okresTrwania,
            this.dataWyjazdu,
            this.promocja,
            this.cenaCalkowita,
            this.cenaDoZaplaty});
            this.lv_klient.FullRowSelect = true;
            this.lv_klient.Location = new System.Drawing.Point(0, 27);
            this.lv_klient.Name = "lv_klient";
            this.lv_klient.Size = new System.Drawing.Size(595, 309);
            this.lv_klient.TabIndex = 14;
            this.lv_klient.UseCompatibleStateImageBehavior = false;
            this.lv_klient.View = System.Windows.Forms.View.Details;
            this.lv_klient.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_klient_ColumnClick);
            this.lv_klient.ItemActivate += new System.EventHandler(this.lv_klient_ItemActivate);
            // 
            // nazwaWycieczki
            // 
            this.nazwaWycieczki.Text = "Nazwa wycieczki";
            this.nazwaWycieczki.Width = 110;
            // 
            // okresTrwania
            // 
            this.okresTrwania.Text = "Długość wycieczki";
            this.okresTrwania.Width = 110;
            // 
            // dataWyjazdu
            // 
            this.dataWyjazdu.Text = "Data wyjazdu";
            this.dataWyjazdu.Width = 130;
            // 
            // promocja
            // 
            this.promocja.Text = "Promocja";
            this.promocja.Width = 110;
            // 
            // cenaCalkowita
            // 
            this.cenaCalkowita.Text = "Cena całkowita";
            this.cenaCalkowita.Width = 110;
            // 
            // cenaDoZaplaty
            // 
            this.cenaDoZaplaty.Text = "Do zapłaty";
            // 
            // tb_szukaj
            // 
            this.tb_szukaj.Location = new System.Drawing.Point(613, 283);
            this.tb_szukaj.Name = "tb_szukaj";
            this.tb_szukaj.Size = new System.Drawing.Size(110, 20);
            this.tb_szukaj.TabIndex = 15;
            this.tb_szukaj.TextChanged += new System.EventHandler(this.tb_szukaj_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // l_szukaj
            // 
            this.l_szukaj.AutoSize = true;
            this.l_szukaj.Location = new System.Drawing.Point(610, 267);
            this.l_szukaj.Name = "l_szukaj";
            this.l_szukaj.Size = new System.Drawing.Size(103, 13);
            this.l_szukaj.TabIndex = 17;
            this.l_szukaj.Text = "Podaj szukaną frazę";
            // 
            // b_szukaj
            // 
            this.b_szukaj.Enabled = false;
            this.b_szukaj.Location = new System.Drawing.Point(613, 309);
            this.b_szukaj.Name = "b_szukaj";
            this.b_szukaj.Size = new System.Drawing.Size(75, 23);
            this.b_szukaj.TabIndex = 18;
            this.b_szukaj.Text = "Szukaj";
            this.b_szukaj.UseVisualStyleBackColor = true;
            this.b_szukaj.Click += new System.EventHandler(this.b_szukaj_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "";
            // 
            // KlientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 370);
            this.Controls.Add(this.b_szukaj);
            this.Controls.Add(this.l_szukaj);
            this.Controls.Add(this.tb_szukaj);
            this.Controls.Add(this.lv_klient);
            this.Controls.Add(this.l_uzytkownik);
            this.Controls.Add(this.l_zalogowany_jako);
            this.Controls.Add(this.b_zaplac);
            this.Controls.Add(this.l_polaczenie);
            this.Controls.Add(this.b_katalog_wyjdz);
            this.Controls.Add(this.b_katalog_rezerwuj);
            this.Controls.Add(this.rtb_wycieczka);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Index);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "KlientView";
            this.helpProvider.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Klient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Klient_FormClosing);
            this.Load += new System.EventHandler(this.Klient_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.RichTextBox rtb_wycieczka;
        private System.Windows.Forms.Button b_katalog_rezerwuj;
        private System.Windows.Forms.Button b_katalog_wyjdz;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wystawOpinięToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reklamujWycieczkęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezygnacjaZWycieczkiToolStripMenuItem;
        private System.Windows.Forms.Label l_polaczenie;
        private System.Windows.Forms.Button b_zaplac;
        private System.Windows.Forms.Label l_uzytkownik;
        private System.Windows.Forms.Label l_zalogowany_jako;
        public System.Windows.Forms.ListView lv_klient;
        public System.Windows.Forms.ColumnHeader nazwaWycieczki;
        public System.Windows.Forms.ColumnHeader okresTrwania;
        public System.Windows.Forms.ColumnHeader dataWyjazdu;
        public System.Windows.Forms.ColumnHeader promocja;
        private System.Windows.Forms.ColumnHeader cenaCalkowita;
        private System.Windows.Forms.TextBox tb_szukaj;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label l_szukaj;
        private System.Windows.Forms.Button b_szukaj;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem wyświetlWszystkieWycieczkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyświetlMojeRezerwacjeToolStripMenuItem;
        public System.Windows.Forms.ColumnHeader cenaDoZaplaty;
        private System.Windows.Forms.HelpProvider helpProvider;
    }
}

