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
            this.components = new System.ComponentModel.Container();
            this.tc_kierownik = new System.Windows.Forms.TabControl();
            this.tp_zarzadzaj_wycieczkami = new System.Windows.Forms.TabPage();
            this.cBox_wycieczki = new System.Windows.Forms.CheckBox();
            this.b_promocja = new System.Windows.Forms.Button();
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
            this.cBox_reklamacja = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Rozstrzygajacy = new System.Windows.Forms.TextBox();
            this.tb_Reklamujacy = new System.Windows.Forms.TextBox();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
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
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.cBox_wycieczki);
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
            // cBox_wycieczki
            // 
            this.cBox_wycieczki.AutoSize = true;
            this.cBox_wycieczki.Location = new System.Drawing.Point(627, 7);
            this.cBox_wycieczki.Name = "cBox_wycieczki";
            this.cBox_wycieczki.Size = new System.Drawing.Size(101, 17);
            this.cBox_wycieczki.TabIndex = 6;
            this.cBox_wycieczki.Text = "Ładuj wszystkie";
            this.cBox_wycieczki.UseVisualStyleBackColor = true;
            this.cBox_wycieczki.CheckedChanged += new System.EventHandler(this.cBox_wycieczki_CheckedChanged);
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
            this.tp_rozpatrz_reklamacje.Controls.Add(this.cBox_reklamacja);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.label2);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.label1);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.tb_Rozstrzygajacy);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.tb_Reklamujacy);
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
            // cBox_reklamacja
            // 
            this.cBox_reklamacja.AutoSize = true;
            this.cBox_reklamacja.Location = new System.Drawing.Point(9, 329);
            this.cBox_reklamacja.Name = "cBox_reklamacja";
            this.cBox_reklamacja.Size = new System.Drawing.Size(116, 17);
            this.cBox_reklamacja.TabIndex = 20;
            this.cBox_reklamacja.Text = "Wyświetl wszystkie";
            this.cBox_reklamacja.UseVisualStyleBackColor = true;
            this.cBox_reklamacja.CheckedChanged += new System.EventHandler(this.cBox_reklamacja_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Rozpratrujący";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Osoba reklamująca";
            // 
            // tb_Rozstrzygajacy
            // 
            this.tb_Rozstrzygajacy.Location = new System.Drawing.Point(409, 84);
            this.tb_Rozstrzygajacy.Name = "tb_Rozstrzygajacy";
            this.tb_Rozstrzygajacy.ReadOnly = true;
            this.tb_Rozstrzygajacy.Size = new System.Drawing.Size(162, 20);
            this.tb_Rozstrzygajacy.TabIndex = 17;
            // 
            // tb_Reklamujacy
            // 
            this.tb_Reklamujacy.Location = new System.Drawing.Point(409, 58);
            this.tb_Reklamujacy.Name = "tb_Reklamujacy";
            this.tb_Reklamujacy.ReadOnly = true;
            this.tb_Reklamujacy.Size = new System.Drawing.Size(162, 20);
            this.tb_Reklamujacy.TabIndex = 16;
            // 
            // tb_nazwa_wycieczki
            // 
            this.tb_nazwa_wycieczki.Location = new System.Drawing.Point(409, 6);
            this.tb_nazwa_wycieczki.Name = "tb_nazwa_wycieczki";
            this.tb_nazwa_wycieczki.ReadOnly = true;
            this.tb_nazwa_wycieczki.Size = new System.Drawing.Size(162, 20);
            this.tb_nazwa_wycieczki.TabIndex = 15;
            // 
            // tb_okresTrwaniaWycieczki
            // 
            this.tb_okresTrwaniaWycieczki.Location = new System.Drawing.Point(409, 32);
            this.tb_okresTrwaniaWycieczki.Name = "tb_okresTrwaniaWycieczki";
            this.tb_okresTrwaniaWycieczki.ReadOnly = true;
            this.tb_okresTrwaniaWycieczki.Size = new System.Drawing.Size(162, 20);
            this.tb_okresTrwaniaWycieczki.TabIndex = 14;
            // 
            // rtb_opisReklamacji
            // 
            this.rtb_opisReklamacji.Location = new System.Drawing.Point(409, 110);
            this.rtb_opisReklamacji.Name = "rtb_opisReklamacji";
            this.rtb_opisReklamacji.ReadOnly = true;
            this.rtb_opisReklamacji.Size = new System.Drawing.Size(312, 181);
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
            this.lv_reklamacje.Size = new System.Drawing.Size(280, 317);
            this.lv_reklamacje.TabIndex = 1;
            this.lv_reklamacje.UseCompatibleStateImageBehavior = false;
            this.lv_reklamacje.View = System.Windows.Forms.View.Details;
            this.lv_reklamacje.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_reklamacje_ColumnClick);
            this.lv_reklamacje.Click += new System.EventHandler(this.lv_reklamacje_ItemActivate);
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
            this.b_rozpatrz_negatywnie.Location = new System.Drawing.Point(508, 297);
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
            this.l_opis_reklamacji.Location = new System.Drawing.Point(300, 113);
            this.l_opis_reklamacji.Name = "l_opis_reklamacji";
            this.l_opis_reklamacji.Size = new System.Drawing.Size(78, 13);
            this.l_opis_reklamacji.TabIndex = 8;
            this.l_opis_reklamacji.Text = "Opis reklamacji";
            // 
            // l_okres_wycieczki
            // 
            this.l_okres_wycieczki.AutoSize = true;
            this.l_okres_wycieczki.Location = new System.Drawing.Point(300, 35);
            this.l_okres_wycieczki.Name = "l_okres_wycieczki";
            this.l_okres_wycieczki.Size = new System.Drawing.Size(84, 13);
            this.l_okres_wycieczki.TabIndex = 6;
            this.l_okres_wycieczki.Text = "Okres wycieczki";
            // 
            // l_nazwa_wycieczki
            // 
            this.l_nazwa_wycieczki.AutoSize = true;
            this.l_nazwa_wycieczki.Location = new System.Drawing.Point(300, 6);
            this.l_nazwa_wycieczki.Name = "l_nazwa_wycieczki";
            this.l_nazwa_wycieczki.Size = new System.Drawing.Size(89, 13);
            this.l_nazwa_wycieczki.TabIndex = 4;
            this.l_nazwa_wycieczki.Text = "Nazwa wycieczki";
            // 
            // b_rozpatrz_pozytywnie
            // 
            this.b_rozpatrz_pozytywnie.Location = new System.Drawing.Point(409, 297);
            this.b_rozpatrz_pozytywnie.Name = "b_rozpatrz_pozytywnie";
            this.b_rozpatrz_pozytywnie.Size = new System.Drawing.Size(93, 49);
            this.b_rozpatrz_pozytywnie.TabIndex = 3;
            this.b_rozpatrz_pozytywnie.Text = "Rozpatrz pozytywnie";
            this.b_rozpatrz_pozytywnie.UseVisualStyleBackColor = true;
            this.b_rozpatrz_pozytywnie.Click += new System.EventHandler(this.b_rozpatrz_pozytywnie_Click);
            // 
            // tp_zarzadzaj_flota
            // 
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
            this.lv_pojazdy.FullRowSelect = true;
            this.lv_pojazdy.GridLines = true;
            this.lv_pojazdy.Location = new System.Drawing.Point(82, 3);
            this.lv_pojazdy.MultiSelect = false;
            this.lv_pojazdy.Name = "lv_pojazdy";
            this.lv_pojazdy.Size = new System.Drawing.Size(361, 356);
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
            this.b_raport_reklamacje.Click += new System.EventHandler(this.b_raport_reklamacje_Click);
            // 
            // b_raport_pojazdy
            // 
            this.b_raport_pojazdy.Location = new System.Drawing.Point(219, 131);
            this.b_raport_pojazdy.Name = "b_raport_pojazdy";
            this.b_raport_pojazdy.Size = new System.Drawing.Size(302, 48);
            this.b_raport_pojazdy.TabIndex = 1;
            this.b_raport_pojazdy.Text = "Drukuj raport pojazdów";
            this.b_raport_pojazdy.UseVisualStyleBackColor = true;
            this.b_raport_pojazdy.Click += new System.EventHandler(this.b_raport_pojazdy_Click);
            // 
            // b_raport_wycieczki
            // 
            this.b_raport_wycieczki.Location = new System.Drawing.Point(219, 61);
            this.b_raport_wycieczki.Name = "b_raport_wycieczki";
            this.b_raport_wycieczki.Size = new System.Drawing.Size(302, 48);
            this.b_raport_wycieczki.TabIndex = 0;
            this.b_raport_wycieczki.Text = "Drukuj raport wycieczek";
            this.b_raport_wycieczki.UseVisualStyleBackColor = true;
            this.b_raport_wycieczki.Click += new System.EventHandler(this.b_raport_wycieczki_Click);
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
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "";
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
            this.HelpButton = true;
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Index);
            this.MaximizeBox = false;
            this.Name = "KierownikView";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kierownik";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kierownik_FormClosing);
            this.tc_kierownik.ResumeLayout(false);
            this.tp_zarzadzaj_wycieczkami.ResumeLayout(false);
            this.tp_zarzadzaj_wycieczkami.PerformLayout();
            this.tp_rozpatrz_reklamacje.ResumeLayout(false);
            this.tp_rozpatrz_reklamacje.PerformLayout();
            this.tp_zarzadzaj_flota.ResumeLayout(false);
            this.tp_raporty.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TabControl tc_kierownik;
        public System.Windows.Forms.TabPage tp_zarzadzaj_wycieczkami;
        public System.Windows.Forms.TabPage tp_rozpatrz_reklamacje;
        public System.Windows.Forms.Button b_usun_wycieczke;
        public System.Windows.Forms.Button b_edytuj;
        public System.Windows.Forms.Button b_dodaj_wycieczke;
        public System.Windows.Forms.TabPage tp_zarzadzaj_flota;
        public System.Windows.Forms.Button b_dodaj_pojazd;
        public System.Windows.Forms.ListView lv_pojazdy;
        public System.Windows.Forms.Button b_usun_pojazd;
        public System.Windows.Forms.ColumnHeader Nr_rejestracyjny;
        public System.Windows.Forms.ColumnHeader Dostepnosc;
        public System.Windows.Forms.ColumnHeader Marka;
        public System.Windows.Forms.ColumnHeader Pojemnosc;
        public System.Windows.Forms.ColumnHeader Stan;
        public System.Windows.Forms.Button b_edytuj_pojazd;
        public System.Windows.Forms.TabPage tp_raporty;
        public System.Windows.Forms.Button b_raport_reklamacje;
        public System.Windows.Forms.Button b_raport_pojazdy;
        public System.Windows.Forms.Button b_raport_wycieczki;
        public System.Windows.Forms.Button b_wyjdz;
        public System.Windows.Forms.Label l_zalogowany_jako;
        public System.Windows.Forms.Label l_uzytkownik;
        public System.Windows.Forms.Label l_polaczenie;
        public System.Windows.Forms.ListView lv_wycieczki;
        public System.Windows.Forms.ColumnHeader Nazwa;
        public System.Windows.Forms.ListView lv_reklamacje;
        public System.Windows.Forms.ColumnHeader numer_reklamacji;
        public System.Windows.Forms.Button b_rozpatrz_negatywnie;
        public System.Windows.Forms.Label l_opis_reklamacji;
        public System.Windows.Forms.Label l_okres_wycieczki;
        public System.Windows.Forms.Label l_nazwa_wycieczki;
        public System.Windows.Forms.Button b_rozpatrz_pozytywnie;
        public System.Windows.Forms.RichTextBox rtb_opisReklamacji;
        public System.Windows.Forms.TextBox tb_okresTrwaniaWycieczki;
        public System.Windows.Forms.TextBox tb_nazwa_wycieczki;
        public System.Windows.Forms.ColumnHeader skrot_skargi;
        public System.Windows.Forms.ColumnHeader stan_reklamacji;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.ColumnHeader columnHeader5;
        public System.Windows.Forms.Button b_promocja;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tb_Rozstrzygajacy;
        public System.Windows.Forms.TextBox tb_Reklamujacy;
        public System.Windows.Forms.CheckBox cBox_wycieczki;
        public System.Windows.Forms.CheckBox cBox_reklamacja;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}