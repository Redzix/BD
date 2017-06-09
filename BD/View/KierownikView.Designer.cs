namespace BD.View
{
    partial class KierownikView
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
            this.tc_kierownik = new System.Windows.Forms.TabControl();
            this.tp_zarzadzaj_wycieczkami = new System.Windows.Forms.TabPage();
            this.lv_wycieczki = new System.Windows.Forms.ListView();
            this.Nazwa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.b_usun_wycieczke = new System.Windows.Forms.Button();
            this.b_edytuj = new System.Windows.Forms.Button();
            this.b_dodaj_wycieczke = new System.Windows.Forms.Button();
            this.tp_rozpatrz_reklamacje = new System.Windows.Forms.TabPage();
            this.tb_nazwa_wycieczki = new System.Windows.Forms.TextBox();
            this.tb_okresTrwaniaWycieczki = new System.Windows.Forms.TextBox();
            this.rtb_opisReklamacji = new System.Windows.Forms.RichTextBox();
            this.lv_reklamacje = new System.Windows.Forms.ListView();
            this.numer_reklamacji = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.skrot_skargi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stan_reklamacji = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.b_rozpatrz_negatywnie = new System.Windows.Forms.Button();
            this.l_opis_reklamacji = new System.Windows.Forms.Label();
            this.l_okres_wycieczki = new System.Windows.Forms.Label();
            this.l_nazwa_wycieczki = new System.Windows.Forms.Label();
            this.b_rozpatrz_pozytywnie = new System.Windows.Forms.Button();
            this.tp_zarzadzaj_flota = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.b_edytuj_pojazd = new System.Windows.Forms.Button();
            this.b_usun_pojazd = new System.Windows.Forms.Button();
            this.b_dodaj_pojazd = new System.Windows.Forms.Button();
            this.lv_pojazdy = new System.Windows.Forms.ListView();
            this.Nr_rejestracyjny = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dostepnosc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Marka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pojemnosc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tp_raporty = new System.Windows.Forms.TabPage();
            this.b_raport_reklamacje = new System.Windows.Forms.Button();
            this.b_raport_pojazdy = new System.Windows.Forms.Button();
            this.b_raport_wycieczki = new System.Windows.Forms.Button();
            this.b_wyjdz = new System.Windows.Forms.Button();
            this.l_zalogowany_jako = new System.Windows.Forms.Label();
            this.l_uzytkownik = new System.Windows.Forms.Label();
            this.l_polaczenie = new System.Windows.Forms.Label();
            this.b_promocja = new System.Windows.Forms.Button();
            this.tc_kierownik.SuspendLayout();
            this.tp_zarzadzaj_wycieczkami.SuspendLayout();
            this.tp_rozpatrz_reklamacje.SuspendLayout();
            this.tp_zarzadzaj_flota.SuspendLayout();
            this.tp_raporty.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_kierownik
            // 
            this.tc_kierownik.Controls.Add(this.tp_zarzadzaj_wycieczkami);
            this.tc_kierownik.Controls.Add(this.tp_rozpatrz_reklamacje);
            this.tc_kierownik.Controls.Add(this.tp_zarzadzaj_flota);
            this.tc_kierownik.Controls.Add(this.tp_raporty);
            this.tc_kierownik.Location = new System.Drawing.Point(0, 0);
            this.tc_kierownik.Name = "tc_kierownik";
            this.tc_kierownik.SelectedIndex = 0;
            this.tc_kierownik.Size = new System.Drawing.Size(743, 388);
            this.tc_kierownik.TabIndex = 2;
            this.tc_kierownik.SelectedIndexChanged += new System.EventHandler(this.tc_kierownik_SelectedIndexChanged);
            // 
            // tp_zarzadzaj_wycieczkami
            // 
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.b_promocja);
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.lv_wycieczki);
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.b_usun_wycieczke);
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.b_edytuj);
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.b_dodaj_wycieczke);
            this.tp_zarzadzaj_wycieczkami.Location = new System.Drawing.Point(4, 22);
            this.tp_zarzadzaj_wycieczkami.Name = "tp_zarzadzaj_wycieczkami";
            this.tp_zarzadzaj_wycieczkami.Padding = new System.Windows.Forms.Padding(3);
            this.tp_zarzadzaj_wycieczkami.Size = new System.Drawing.Size(735, 362);
            this.tp_zarzadzaj_wycieczkami.TabIndex = 0;
            this.tp_zarzadzaj_wycieczkami.Text = "Zarządzaj wycieczkami";
            this.tp_zarzadzaj_wycieczkami.UseVisualStyleBackColor = true;
            // 
            // lv_wycieczki
            // 
            this.lv_wycieczki.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nazwa,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lv_wycieczki.Dock = System.Windows.Forms.DockStyle.Left;
            this.lv_wycieczki.FullRowSelect = true;
            this.lv_wycieczki.GridLines = true;
            this.lv_wycieczki.Location = new System.Drawing.Point(3, 3);
            this.lv_wycieczki.MultiSelect = false;
            this.lv_wycieczki.Name = "lv_wycieczki";
            this.lv_wycieczki.Size = new System.Drawing.Size(617, 356);
            this.lv_wycieczki.TabIndex = 1;
            this.lv_wycieczki.UseCompatibleStateImageBehavior = false;
            this.lv_wycieczki.View = System.Windows.Forms.View.Details;
            this.lv_wycieczki.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_wycieczki_ColumnClick);
            // 
            // Nazwa
            // 
            this.Nazwa.Text = "Nazwa wycieczki";
            this.Nazwa.Width = 138;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Data odjazdu";
            this.columnHeader1.Width = 82;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data przyjazdu";
            this.columnHeader2.Width = 88;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Miejsce odjazdu";
            this.columnHeader3.Width = 98;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Miejsce przyjazdu";
            this.columnHeader4.Width = 103;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Cena";
            this.columnHeader5.Width = 100;
            // 
            // b_usun_wycieczke
            // 
            this.b_usun_wycieczke.Location = new System.Drawing.Point(626, 192);
            this.b_usun_wycieczke.Name = "b_usun_wycieczke";
            this.b_usun_wycieczke.Size = new System.Drawing.Size(103, 23);
            this.b_usun_wycieczke.TabIndex = 4;
            this.b_usun_wycieczke.Text = "Usuń wycieczkę";
            this.b_usun_wycieczke.UseVisualStyleBackColor = true;
            this.b_usun_wycieczke.Click += new System.EventHandler(this.b_usun_wycieczke_Click);
            // 
            // b_edytuj
            // 
            this.b_edytuj.Location = new System.Drawing.Point(626, 58);
            this.b_edytuj.Name = "b_edytuj";
            this.b_edytuj.Size = new System.Drawing.Size(103, 23);
            this.b_edytuj.TabIndex = 3;
            this.b_edytuj.Text = "Edytuj";
            this.b_edytuj.UseVisualStyleBackColor = true;
            this.b_edytuj.Click += new System.EventHandler(this.b_edytuj_Click);
            // 
            // b_dodaj_wycieczke
            // 
            this.b_dodaj_wycieczke.Location = new System.Drawing.Point(626, 29);
            this.b_dodaj_wycieczke.Name = "b_dodaj_wycieczke";
            this.b_dodaj_wycieczke.Size = new System.Drawing.Size(103, 23);
            this.b_dodaj_wycieczke.TabIndex = 2;
            this.b_dodaj_wycieczke.Text = "Dodaj wycieczkę";
            this.b_dodaj_wycieczke.UseVisualStyleBackColor = true;
            this.b_dodaj_wycieczke.Click += new System.EventHandler(this.b_dodaj_wycieczke_Click);
            // 
            // tp_rozpatrz_reklamacje
            // 
            this.tp_rozpatrz_reklamacje.Controls.Add(this.tb_nazwa_wycieczki);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.tb_okresTrwaniaWycieczki);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.rtb_opisReklamacji);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.lv_reklamacje);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.b_rozpatrz_negatywnie);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.l_opis_reklamacji);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.l_okres_wycieczki);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.l_nazwa_wycieczki);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.b_rozpatrz_pozytywnie);
            this.tp_rozpatrz_reklamacje.Location = new System.Drawing.Point(4, 22);
            this.tp_rozpatrz_reklamacje.Name = "tp_rozpatrz_reklamacje";
            this.tp_rozpatrz_reklamacje.Padding = new System.Windows.Forms.Padding(3);
            this.tp_rozpatrz_reklamacje.Size = new System.Drawing.Size(735, 362);
            this.tp_rozpatrz_reklamacje.TabIndex = 1;
            this.tp_rozpatrz_reklamacje.Text = "Rozpatrz reklamacje";
            this.tp_rozpatrz_reklamacje.UseVisualStyleBackColor = true;
            // 
            // tb_nazwa_wycieczki
            // 
            this.tb_nazwa_wycieczki.Enabled = false;
            this.tb_nazwa_wycieczki.Location = new System.Drawing.Point(390, 44);
            this.tb_nazwa_wycieczki.Name = "tb_nazwa_wycieczki";
            this.tb_nazwa_wycieczki.Size = new System.Drawing.Size(162, 20);
            this.tb_nazwa_wycieczki.TabIndex = 15;
            // 
            // tb_okresTrwaniaWycieczki
            // 
            this.tb_okresTrwaniaWycieczki.Enabled = false;
            this.tb_okresTrwaniaWycieczki.Location = new System.Drawing.Point(390, 76);
            this.tb_okresTrwaniaWycieczki.Name = "tb_okresTrwaniaWycieczki";
            this.tb_okresTrwaniaWycieczki.Size = new System.Drawing.Size(162, 20);
            this.tb_okresTrwaniaWycieczki.TabIndex = 14;
            // 
            // rtb_opisReklamacji
            // 
            this.rtb_opisReklamacji.Location = new System.Drawing.Point(390, 104);
            this.rtb_opisReklamacji.Name = "rtb_opisReklamacji";
            this.rtb_opisReklamacji.Size = new System.Drawing.Size(337, 130);
            this.rtb_opisReklamacji.TabIndex = 13;
            this.rtb_opisReklamacji.Text = "";
            // 
            // lv_reklamacje
            // 
            this.lv_reklamacje.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numer_reklamacji,
            this.skrot_skargi,
            this.stan_reklamacji});
            this.lv_reklamacje.FullRowSelect = true;
            this.lv_reklamacje.GridLines = true;
            this.lv_reklamacje.Location = new System.Drawing.Point(9, 6);
            this.lv_reklamacje.MultiSelect = false;
            this.lv_reklamacje.Name = "lv_reklamacje";
            this.lv_reklamacje.Size = new System.Drawing.Size(280, 350);
            this.lv_reklamacje.TabIndex = 1;
            this.lv_reklamacje.UseCompatibleStateImageBehavior = false;
            this.lv_reklamacje.View = System.Windows.Forms.View.Details;
            this.lv_reklamacje.ItemActivate += new System.EventHandler(this.lv_reklamacje_ItemActivate);
            // 
            // numer_reklamacji
            // 
            this.numer_reklamacji.Text = "Numer";
            this.numer_reklamacji.Width = 45;
            // 
            // skrot_skargi
            // 
            this.skrot_skargi.Text = "Skrócony opis";
            this.skrot_skargi.Width = 124;
            // 
            // stan_reklamacji
            // 
            this.stan_reklamacji.Text = "Stan";
            this.stan_reklamacji.Width = 101;
            // 
            // b_rozpatrz_negatywnie
            // 
            this.b_rozpatrz_negatywnie.Location = new System.Drawing.Point(558, 240);
            this.b_rozpatrz_negatywnie.Name = "b_rozpatrz_negatywnie";
            this.b_rozpatrz_negatywnie.Size = new System.Drawing.Size(93, 49);
            this.b_rozpatrz_negatywnie.TabIndex = 9;
            this.b_rozpatrz_negatywnie.Text = "Rozpatrz negatywnie";
            this.b_rozpatrz_negatywnie.UseVisualStyleBackColor = true;
            this.b_rozpatrz_negatywnie.Click += new System.EventHandler(this.b_rozpatrz_negatywnie_Click);
            // 
            // l_opis_reklamacji
            // 
            this.l_opis_reklamacji.AutoSize = true;
            this.l_opis_reklamacji.Location = new System.Drawing.Point(307, 104);
            this.l_opis_reklamacji.Name = "l_opis_reklamacji";
            this.l_opis_reklamacji.Size = new System.Drawing.Size(78, 13);
            this.l_opis_reklamacji.TabIndex = 8;
            this.l_opis_reklamacji.Text = "Opis reklamacji";
            // 
            // l_okres_wycieczki
            // 
            this.l_okres_wycieczki.AutoSize = true;
            this.l_okres_wycieczki.Location = new System.Drawing.Point(300, 76);
            this.l_okres_wycieczki.Name = "l_okres_wycieczki";
            this.l_okres_wycieczki.Size = new System.Drawing.Size(84, 13);
            this.l_okres_wycieczki.TabIndex = 6;
            this.l_okres_wycieczki.Text = "Okres wycieczki";
            // 
            // l_nazwa_wycieczki
            // 
            this.l_nazwa_wycieczki.AutoSize = true;
            this.l_nazwa_wycieczki.Location = new System.Drawing.Point(295, 47);
            this.l_nazwa_wycieczki.Name = "l_nazwa_wycieczki";
            this.l_nazwa_wycieczki.Size = new System.Drawing.Size(89, 13);
            this.l_nazwa_wycieczki.TabIndex = 4;
            this.l_nazwa_wycieczki.Text = "Nazwa wycieczki";
            // 
            // b_rozpatrz_pozytywnie
            // 
            this.b_rozpatrz_pozytywnie.Location = new System.Drawing.Point(459, 240);
            this.b_rozpatrz_pozytywnie.Name = "b_rozpatrz_pozytywnie";
            this.b_rozpatrz_pozytywnie.Size = new System.Drawing.Size(93, 49);
            this.b_rozpatrz_pozytywnie.TabIndex = 3;
            this.b_rozpatrz_pozytywnie.Text = "Rozpatrz pozytywnie";
            this.b_rozpatrz_pozytywnie.UseVisualStyleBackColor = true;
            this.b_rozpatrz_pozytywnie.Click += new System.EventHandler(this.b_rozpatrz_pozytywnie_Click);
            // 
            // tp_zarzadzaj_flota
            // 
            this.tp_zarzadzaj_flota.Controls.Add(this.button1);
            this.tp_zarzadzaj_flota.Controls.Add(this.b_edytuj_pojazd);
            this.tp_zarzadzaj_flota.Controls.Add(this.b_usun_pojazd);
            this.tp_zarzadzaj_flota.Controls.Add(this.b_dodaj_pojazd);
            this.tp_zarzadzaj_flota.Controls.Add(this.lv_pojazdy);
            this.tp_zarzadzaj_flota.Location = new System.Drawing.Point(4, 22);
            this.tp_zarzadzaj_flota.Name = "tp_zarzadzaj_flota";
            this.tp_zarzadzaj_flota.Padding = new System.Windows.Forms.Padding(3);
            this.tp_zarzadzaj_flota.Size = new System.Drawing.Size(735, 362);
            this.tp_zarzadzaj_flota.TabIndex = 2;
            this.tp_zarzadzaj_flota.Text = "Zarządzaj flotą";
            this.tp_zarzadzaj_flota.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(476, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_edytuj_pojazd
            // 
            this.b_edytuj_pojazd.Location = new System.Drawing.Point(476, 104);
            this.b_edytuj_pojazd.Name = "b_edytuj_pojazd";
            this.b_edytuj_pojazd.Size = new System.Drawing.Size(104, 23);
            this.b_edytuj_pojazd.TabIndex = 4;
            this.b_edytuj_pojazd.Text = "Edytuj pojazd";
            this.b_edytuj_pojazd.UseVisualStyleBackColor = true;
            this.b_edytuj_pojazd.Click += new System.EventHandler(this.b_edytuj_pojazd_Click);
            // 
            // b_usun_pojazd
            // 
            this.b_usun_pojazd.Location = new System.Drawing.Point(476, 189);
            this.b_usun_pojazd.Name = "b_usun_pojazd";
            this.b_usun_pojazd.Size = new System.Drawing.Size(104, 23);
            this.b_usun_pojazd.TabIndex = 3;
            this.b_usun_pojazd.Text = "Usuń pojazd";
            this.b_usun_pojazd.UseVisualStyleBackColor = true;
            this.b_usun_pojazd.Click += new System.EventHandler(this.b_usun_pojazd_Click);
            // 
            // b_dodaj_pojazd
            // 
            this.b_dodaj_pojazd.Location = new System.Drawing.Point(476, 31);
            this.b_dodaj_pojazd.Name = "b_dodaj_pojazd";
            this.b_dodaj_pojazd.Size = new System.Drawing.Size(104, 23);
            this.b_dodaj_pojazd.TabIndex = 1;
            this.b_dodaj_pojazd.Text = "Dodaj pojazd";
            this.b_dodaj_pojazd.UseVisualStyleBackColor = true;
            this.b_dodaj_pojazd.Click += new System.EventHandler(this.b_dodaj_pojazd_Click);
            // 
            // lv_pojazdy
            // 
            this.lv_pojazdy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nr_rejestracyjny,
            this.Dostepnosc,
            this.Marka,
            this.Pojemnosc,
            this.Stan});
            this.lv_pojazdy.GridLines = true;
            this.lv_pojazdy.Location = new System.Drawing.Point(82, 3);
            this.lv_pojazdy.MultiSelect = false;
            this.lv_pojazdy.Name = "lv_pojazdy";
            this.lv_pojazdy.Size = new System.Drawing.Size(388, 356);
            this.lv_pojazdy.TabIndex = 1;
            this.lv_pojazdy.UseCompatibleStateImageBehavior = false;
            this.lv_pojazdy.View = System.Windows.Forms.View.Details;
            this.lv_pojazdy.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_pojazdy_ColumnClick);
            // 
            // Nr_rejestracyjny
            // 
            this.Nr_rejestracyjny.Text = "Numer rejestracyjny";
            this.Nr_rejestracyjny.Width = 110;
            // 
            // Dostepnosc
            // 
            this.Dostepnosc.Text = "Dostępność";
            this.Dostepnosc.Width = 70;
            // 
            // Marka
            // 
            this.Marka.Text = "Marka";
            this.Marka.Width = 50;
            // 
            // Pojemnosc
            // 
            this.Pojemnosc.Text = "Pojemność";
            this.Pojemnosc.Width = 70;
            // 
            // Stan
            // 
            this.Stan.Text = "Stan";
            this.Stan.Width = 57;
            // 
            // tp_raporty
            // 
            this.tp_raporty.Controls.Add(this.b_raport_reklamacje);
            this.tp_raporty.Controls.Add(this.b_raport_pojazdy);
            this.tp_raporty.Controls.Add(this.b_raport_wycieczki);
            this.tp_raporty.Location = new System.Drawing.Point(4, 22);
            this.tp_raporty.Name = "tp_raporty";
            this.tp_raporty.Padding = new System.Windows.Forms.Padding(3);
            this.tp_raporty.Size = new System.Drawing.Size(735, 362);
            this.tp_raporty.TabIndex = 3;
            this.tp_raporty.Text = "Raporty";
            this.tp_raporty.UseVisualStyleBackColor = true;
            // 
            // b_raport_reklamacje
            // 
            this.b_raport_reklamacje.Location = new System.Drawing.Point(219, 200);
            this.b_raport_reklamacje.Name = "b_raport_reklamacje";
            this.b_raport_reklamacje.Size = new System.Drawing.Size(302, 48);
            this.b_raport_reklamacje.TabIndex = 2;
            this.b_raport_reklamacje.Text = "Drukuj raport reklamacji";
            this.b_raport_reklamacje.UseVisualStyleBackColor = true;
            // 
            // b_raport_pojazdy
            // 
            this.b_raport_pojazdy.Location = new System.Drawing.Point(219, 131);
            this.b_raport_pojazdy.Name = "b_raport_pojazdy";
            this.b_raport_pojazdy.Size = new System.Drawing.Size(302, 48);
            this.b_raport_pojazdy.TabIndex = 1;
            this.b_raport_pojazdy.Text = "Drukuj raport pojazdów";
            this.b_raport_pojazdy.UseVisualStyleBackColor = true;
            // 
            // b_raport_wycieczki
            // 
            this.b_raport_wycieczki.Location = new System.Drawing.Point(219, 61);
            this.b_raport_wycieczki.Name = "b_raport_wycieczki";
            this.b_raport_wycieczki.Size = new System.Drawing.Size(302, 48);
            this.b_raport_wycieczki.TabIndex = 0;
            this.b_raport_wycieczki.Text = "Drukuj raport wycieczek";
            this.b_raport_wycieczki.UseVisualStyleBackColor = true;
            // 
            // b_wyjdz
            // 
            this.b_wyjdz.Location = new System.Drawing.Point(658, 394);
            this.b_wyjdz.Name = "b_wyjdz";
            this.b_wyjdz.Size = new System.Drawing.Size(75, 23);
            this.b_wyjdz.TabIndex = 3;
            this.b_wyjdz.Text = "Wyjdź";
            this.b_wyjdz.UseVisualStyleBackColor = true;
            this.b_wyjdz.Click += new System.EventHandler(this.b_wyjdz_Click);
            // 
            // l_zalogowany_jako
            // 
            this.l_zalogowany_jako.AutoSize = true;
            this.l_zalogowany_jako.Location = new System.Drawing.Point(83, 399);
            this.l_zalogowany_jako.Name = "l_zalogowany_jako";
            this.l_zalogowany_jako.Size = new System.Drawing.Size(88, 13);
            this.l_zalogowany_jako.TabIndex = 4;
            this.l_zalogowany_jako.Text = "Zalogowany jako";
            // 
            // l_uzytkownik
            // 
            this.l_uzytkownik.AutoSize = true;
            this.l_uzytkownik.Location = new System.Drawing.Point(170, 399);
            this.l_uzytkownik.Name = "l_uzytkownik";
            this.l_uzytkownik.Size = new System.Drawing.Size(10, 13);
            this.l_uzytkownik.TabIndex = 5;
            this.l_uzytkownik.Text = " ";
            // 
            // l_polaczenie
            // 
            this.l_polaczenie.AutoSize = true;
            this.l_polaczenie.Location = new System.Drawing.Point(10, 399);
            this.l_polaczenie.Name = "l_polaczenie";
            this.l_polaczenie.Size = new System.Drawing.Size(10, 13);
            this.l_polaczenie.TabIndex = 6;
            this.l_polaczenie.Text = " ";
            // 
            // b_promocja
            // 
            this.b_promocja.Location = new System.Drawing.Point(627, 87);
            this.b_promocja.Name = "b_promocja";
            this.b_promocja.Size = new System.Drawing.Size(102, 23);
            this.b_promocja.TabIndex = 5;
            this.b_promocja.Text = "Promocja";
            this.b_promocja.UseVisualStyleBackColor = true;
            this.b_promocja.Click += new System.EventHandler(this.b_promocja_Click);
            // 
            // KierownikView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 422);
            this.Controls.Add(this.l_polaczenie);
            this.Controls.Add(this.l_uzytkownik);
            this.Controls.Add(this.l_zalogowany_jako);
            this.Controls.Add(this.b_wyjdz);
            this.Controls.Add(this.tc_kierownik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "KierownikView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kierownik";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kierownik_FormClosing);
            this.Load += new System.EventHandler(this.Kierownik_Load);
            this.tc_kierownik.ResumeLayout(false);
            this.tp_zarzadzaj_wycieczkami.ResumeLayout(false);
            this.tp_rozpatrz_reklamacje.ResumeLayout(false);
            this.tp_rozpatrz_reklamacje.PerformLayout();
            this.tp_zarzadzaj_flota.ResumeLayout(false);
            this.tp_raporty.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tc_kierownik;
        private System.Windows.Forms.TabPage tp_zarzadzaj_wycieczkami;
        private System.Windows.Forms.TabPage tp_rozpatrz_reklamacje;
        private System.Windows.Forms.Button b_usun_wycieczke;
        private System.Windows.Forms.Button b_edytuj;
        private System.Windows.Forms.Button b_dodaj_wycieczke;
        private System.Windows.Forms.TabPage tp_zarzadzaj_flota;
        private System.Windows.Forms.Button b_dodaj_pojazd;
        private System.Windows.Forms.ListView lv_pojazdy;
        private System.Windows.Forms.Button b_usun_pojazd;
        private System.Windows.Forms.ColumnHeader Nr_rejestracyjny;
        private System.Windows.Forms.ColumnHeader Dostepnosc;
        private System.Windows.Forms.ColumnHeader Marka;
        private System.Windows.Forms.ColumnHeader Pojemnosc;
        private System.Windows.Forms.ColumnHeader Stan;
        private System.Windows.Forms.Button b_edytuj_pojazd;
        private System.Windows.Forms.TabPage tp_raporty;
        private System.Windows.Forms.Button b_raport_reklamacje;
        private System.Windows.Forms.Button b_raport_pojazdy;
        private System.Windows.Forms.Button b_raport_wycieczki;
        private System.Windows.Forms.Button b_wyjdz;
        private System.Windows.Forms.Label l_zalogowany_jako;
        private System.Windows.Forms.Label l_uzytkownik;
        private System.Windows.Forms.Label l_polaczenie;
        private System.Windows.Forms.ListView lv_wycieczki;
        private System.Windows.Forms.ColumnHeader Nazwa;
        private System.Windows.Forms.ListView lv_reklamacje;
        private System.Windows.Forms.ColumnHeader numer_reklamacji;
        private System.Windows.Forms.Button b_rozpatrz_negatywnie;
        private System.Windows.Forms.Label l_opis_reklamacji;
        private System.Windows.Forms.Label l_okres_wycieczki;
        private System.Windows.Forms.Label l_nazwa_wycieczki;
        private System.Windows.Forms.Button b_rozpatrz_pozytywnie;
        private System.Windows.Forms.RichTextBox rtb_opisReklamacji;
        private System.Windows.Forms.TextBox tb_okresTrwaniaWycieczki;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_nazwa_wycieczki;
        private System.Windows.Forms.ColumnHeader skrot_skargi;
        private System.Windows.Forms.ColumnHeader stan_reklamacji;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button b_promocja;
    }
}