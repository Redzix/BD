namespace BD
{
    partial class Kierownik
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
            this.DataWyjazdu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataPrzyjazdu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Opis = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Promocja = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cena = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Kierowca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pilot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MiejsceOdjazdu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MiejsceDocelowe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.b_usun_wycieczke = new System.Windows.Forms.Button();
            this.b_edytuj = new System.Windows.Forms.Button();
            this.b_dodaj_wycieczke = new System.Windows.Forms.Button();
            this.l_wycieczki = new System.Windows.Forms.Label();
            this.tp_rozpatrz_reklamacje = new System.Windows.Forms.TabPage();
            this.cb_okres_wycieczki = new System.Windows.Forms.ComboBox();
            this.cb_nazwa_wycieczki = new System.Windows.Forms.ComboBox();
            this.lv_reklamacje = new System.Windows.Forms.ListView();
            this.numer_reklamacji = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.b_rozpatrz_negatywnie = new System.Windows.Forms.Button();
            this.l_opis_reklamacji = new System.Windows.Forms.Label();
            this.tb_opis_reklamacji = new System.Windows.Forms.TextBox();
            this.l_okres_wycieczki = new System.Windows.Forms.Label();
            this.l_nazwa_wycieczki = new System.Windows.Forms.Label();
            this.b_rozpatrz_pozytywnie = new System.Windows.Forms.Button();
            this.l_reklamacje = new System.Windows.Forms.Label();
            this.tp_zarzadzaj_flota = new System.Windows.Forms.TabPage();
            this.b_edytuj_pojazd = new System.Windows.Forms.Button();
            this.b_usun_pojazd = new System.Windows.Forms.Button();
            this.l_pojazdy = new System.Windows.Forms.Label();
            this.b_dodaj_pojazd = new System.Windows.Forms.Button();
            this.lv_pojazdy = new System.Windows.Forms.ListView();
            this.Nr_rejestracyjny = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dostępnosc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.tc_kierownik.Size = new System.Drawing.Size(494, 255);
            this.tc_kierownik.TabIndex = 2;
            this.tc_kierownik.SelectedIndexChanged += new System.EventHandler(this.tc_kierownik_SelectedIndexChanged);
            // 
            // tp_zarzadzaj_wycieczkami
            // 
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.lv_wycieczki);
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.b_usun_wycieczke);
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.b_edytuj);
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.b_dodaj_wycieczke);
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.l_wycieczki);
            this.tp_zarzadzaj_wycieczkami.Location = new System.Drawing.Point(4, 22);
            this.tp_zarzadzaj_wycieczkami.Name = "tp_zarzadzaj_wycieczkami";
            this.tp_zarzadzaj_wycieczkami.Padding = new System.Windows.Forms.Padding(3);
            this.tp_zarzadzaj_wycieczkami.Size = new System.Drawing.Size(486, 229);
            this.tp_zarzadzaj_wycieczkami.TabIndex = 0;
            this.tp_zarzadzaj_wycieczkami.Text = "Zarządzaj wycieczkami";
            this.tp_zarzadzaj_wycieczkami.UseVisualStyleBackColor = true;
            // 
            // lv_wycieczki
            // 
            this.lv_wycieczki.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nazwa,
            this.DataWyjazdu,
            this.DataPrzyjazdu,
            this.Opis,
            this.Promocja,
            this.Cena,
            this.Kierowca,
            this.Pilot,
            this.MiejsceOdjazdu,
            this.MiejsceDocelowe});
            this.lv_wycieczki.GridLines = true;
            this.lv_wycieczki.Location = new System.Drawing.Point(3, 32);
            this.lv_wycieczki.MultiSelect = false;
            this.lv_wycieczki.Name = "lv_wycieczki";
            this.lv_wycieczki.Size = new System.Drawing.Size(360, 191);
            this.lv_wycieczki.TabIndex = 1;
            this.lv_wycieczki.UseCompatibleStateImageBehavior = false;
            this.lv_wycieczki.View = System.Windows.Forms.View.Details;
            // 
            // Nazwa
            // 
            this.Nazwa.Text = "Nazwa wycieczki";
            this.Nazwa.Width = 110;
            // 
            // DataWyjazdu
            // 
            this.DataWyjazdu.Text = "Data wyjazdu";
            this.DataWyjazdu.Width = 110;
            // 
            // DataPrzyjazdu
            // 
            this.DataPrzyjazdu.Text = "Data powrotu";
            this.DataPrzyjazdu.Width = 110;
            // 
            // Opis
            // 
            this.Opis.Text = "Opis";
            this.Opis.Width = 110;
            // 
            // Promocja
            // 
            this.Promocja.Text = "Promocja";
            this.Promocja.Width = 80;
            // 
            // Cena
            // 
            this.Cena.Text = "Cena bez promocji";
            this.Cena.Width = 80;
            // 
            // Kierowca
            // 
            this.Kierowca.Text = "Kierowca";
            this.Kierowca.Width = 110;
            // 
            // Pilot
            // 
            this.Pilot.Text = "Pilot";
            this.Pilot.Width = 110;
            // 
            // MiejsceOdjazdu
            // 
            this.MiejsceOdjazdu.Text = "Miejsce odjazdu";
            this.MiejsceOdjazdu.Width = 110;
            // 
            // MiejsceDocelowe
            // 
            this.MiejsceDocelowe.Text = "Miejsce docelowe";
            this.MiejsceDocelowe.Width = 110;
            // 
            // b_usun_wycieczke
            // 
            this.b_usun_wycieczke.Location = new System.Drawing.Point(369, 192);
            this.b_usun_wycieczke.Name = "b_usun_wycieczke";
            this.b_usun_wycieczke.Size = new System.Drawing.Size(103, 23);
            this.b_usun_wycieczke.TabIndex = 4;
            this.b_usun_wycieczke.Text = "Usuń wycieczkę";
            this.b_usun_wycieczke.UseVisualStyleBackColor = true;
            // 
            // b_edytuj
            // 
            this.b_edytuj.Location = new System.Drawing.Point(369, 106);
            this.b_edytuj.Name = "b_edytuj";
            this.b_edytuj.Size = new System.Drawing.Size(103, 23);
            this.b_edytuj.TabIndex = 3;
            this.b_edytuj.Text = "Edytuj";
            this.b_edytuj.UseVisualStyleBackColor = true;
            // 
            // b_dodaj_wycieczke
            // 
            this.b_dodaj_wycieczke.Location = new System.Drawing.Point(369, 29);
            this.b_dodaj_wycieczke.Name = "b_dodaj_wycieczke";
            this.b_dodaj_wycieczke.Size = new System.Drawing.Size(103, 23);
            this.b_dodaj_wycieczke.TabIndex = 2;
            this.b_dodaj_wycieczke.Text = "Dodaj wycieczkę";
            this.b_dodaj_wycieczke.UseVisualStyleBackColor = true;
            this.b_dodaj_wycieczke.Click += new System.EventHandler(this.b_dodaj_wycieczke_Click);
            // 
            // l_wycieczki
            // 
            this.l_wycieczki.AutoSize = true;
            this.l_wycieczki.Location = new System.Drawing.Point(140, 16);
            this.l_wycieczki.Name = "l_wycieczki";
            this.l_wycieczki.Size = new System.Drawing.Size(56, 13);
            this.l_wycieczki.TabIndex = 1;
            this.l_wycieczki.Text = "Wycieczki";
            // 
            // tp_rozpatrz_reklamacje
            // 
            this.tp_rozpatrz_reklamacje.Controls.Add(this.cb_okres_wycieczki);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.cb_nazwa_wycieczki);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.lv_reklamacje);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.b_rozpatrz_negatywnie);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.l_opis_reklamacji);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.tb_opis_reklamacji);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.l_okres_wycieczki);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.l_nazwa_wycieczki);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.b_rozpatrz_pozytywnie);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.l_reklamacje);
            this.tp_rozpatrz_reklamacje.Location = new System.Drawing.Point(4, 22);
            this.tp_rozpatrz_reklamacje.Name = "tp_rozpatrz_reklamacje";
            this.tp_rozpatrz_reklamacje.Padding = new System.Windows.Forms.Padding(3);
            this.tp_rozpatrz_reklamacje.Size = new System.Drawing.Size(486, 229);
            this.tp_rozpatrz_reklamacje.TabIndex = 1;
            this.tp_rozpatrz_reklamacje.Text = "Rozpatrz reklamacje";
            this.tp_rozpatrz_reklamacje.UseVisualStyleBackColor = true;
            // 
            // cb_okres_wycieczki
            // 
            this.cb_okres_wycieczki.FormattingEnabled = true;
            this.cb_okres_wycieczki.Location = new System.Drawing.Point(269, 62);
            this.cb_okres_wycieczki.Name = "cb_okres_wycieczki";
            this.cb_okres_wycieczki.Size = new System.Drawing.Size(162, 21);
            this.cb_okres_wycieczki.TabIndex = 12;
            // 
            // cb_nazwa_wycieczki
            // 
            this.cb_nazwa_wycieczki.FormattingEnabled = true;
            this.cb_nazwa_wycieczki.Location = new System.Drawing.Point(269, 33);
            this.cb_nazwa_wycieczki.Name = "cb_nazwa_wycieczki";
            this.cb_nazwa_wycieczki.Size = new System.Drawing.Size(162, 21);
            this.cb_nazwa_wycieczki.TabIndex = 11;
            // 
            // lv_reklamacje
            // 
            this.lv_reklamacje.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numer_reklamacji});
            this.lv_reklamacje.GridLines = true;
            this.lv_reklamacje.Location = new System.Drawing.Point(6, 37);
            this.lv_reklamacje.MultiSelect = false;
            this.lv_reklamacje.Name = "lv_reklamacje";
            this.lv_reklamacje.Size = new System.Drawing.Size(134, 182);
            this.lv_reklamacje.TabIndex = 1;
            this.lv_reklamacje.UseCompatibleStateImageBehavior = false;
            this.lv_reklamacje.View = System.Windows.Forms.View.Details;
            // 
            // numer_reklamacji
            // 
            this.numer_reklamacji.Text = "Numer reklamacji";
            this.numer_reklamacji.Width = 110;
            // 
            // b_rozpatrz_negatywnie
            // 
            this.b_rozpatrz_negatywnie.Location = new System.Drawing.Point(369, 173);
            this.b_rozpatrz_negatywnie.Name = "b_rozpatrz_negatywnie";
            this.b_rozpatrz_negatywnie.Size = new System.Drawing.Size(93, 49);
            this.b_rozpatrz_negatywnie.TabIndex = 9;
            this.b_rozpatrz_negatywnie.Text = "Rozpatrz negatywnie";
            this.b_rozpatrz_negatywnie.UseVisualStyleBackColor = true;
            // 
            // l_opis_reklamacji
            // 
            this.l_opis_reklamacji.AutoSize = true;
            this.l_opis_reklamacji.Location = new System.Drawing.Point(186, 93);
            this.l_opis_reklamacji.Name = "l_opis_reklamacji";
            this.l_opis_reklamacji.Size = new System.Drawing.Size(78, 13);
            this.l_opis_reklamacji.TabIndex = 8;
            this.l_opis_reklamacji.Text = "Opis reklamacji";
            // 
            // tb_opis_reklamacji
            // 
            this.tb_opis_reklamacji.Location = new System.Drawing.Point(270, 93);
            this.tb_opis_reklamacji.Multiline = true;
            this.tb_opis_reklamacji.Name = "tb_opis_reklamacji";
            this.tb_opis_reklamacji.Size = new System.Drawing.Size(192, 74);
            this.tb_opis_reklamacji.TabIndex = 7;
            // 
            // l_okres_wycieczki
            // 
            this.l_okres_wycieczki.AutoSize = true;
            this.l_okres_wycieczki.Location = new System.Drawing.Point(179, 65);
            this.l_okres_wycieczki.Name = "l_okres_wycieczki";
            this.l_okres_wycieczki.Size = new System.Drawing.Size(84, 13);
            this.l_okres_wycieczki.TabIndex = 6;
            this.l_okres_wycieczki.Text = "Okres wycieczki";
            // 
            // l_nazwa_wycieczki
            // 
            this.l_nazwa_wycieczki.AutoSize = true;
            this.l_nazwa_wycieczki.Location = new System.Drawing.Point(174, 36);
            this.l_nazwa_wycieczki.Name = "l_nazwa_wycieczki";
            this.l_nazwa_wycieczki.Size = new System.Drawing.Size(89, 13);
            this.l_nazwa_wycieczki.TabIndex = 4;
            this.l_nazwa_wycieczki.Text = "Nazwa wycieczki";
            // 
            // b_rozpatrz_pozytywnie
            // 
            this.b_rozpatrz_pozytywnie.Location = new System.Drawing.Point(270, 173);
            this.b_rozpatrz_pozytywnie.Name = "b_rozpatrz_pozytywnie";
            this.b_rozpatrz_pozytywnie.Size = new System.Drawing.Size(93, 49);
            this.b_rozpatrz_pozytywnie.TabIndex = 3;
            this.b_rozpatrz_pozytywnie.Text = "Rozpatrz pozytywnie";
            this.b_rozpatrz_pozytywnie.UseVisualStyleBackColor = true;
            // 
            // l_reklamacje
            // 
            this.l_reklamacje.AutoSize = true;
            this.l_reklamacje.Location = new System.Drawing.Point(39, 21);
            this.l_reklamacje.Name = "l_reklamacje";
            this.l_reklamacje.Size = new System.Drawing.Size(63, 13);
            this.l_reklamacje.TabIndex = 1;
            this.l_reklamacje.Text = "Reklamacje";
            // 
            // tp_zarzadzaj_flota
            // 
            this.tp_zarzadzaj_flota.Controls.Add(this.b_edytuj_pojazd);
            this.tp_zarzadzaj_flota.Controls.Add(this.b_usun_pojazd);
            this.tp_zarzadzaj_flota.Controls.Add(this.l_pojazdy);
            this.tp_zarzadzaj_flota.Controls.Add(this.b_dodaj_pojazd);
            this.tp_zarzadzaj_flota.Controls.Add(this.lv_pojazdy);
            this.tp_zarzadzaj_flota.Location = new System.Drawing.Point(4, 22);
            this.tp_zarzadzaj_flota.Name = "tp_zarzadzaj_flota";
            this.tp_zarzadzaj_flota.Padding = new System.Windows.Forms.Padding(3);
            this.tp_zarzadzaj_flota.Size = new System.Drawing.Size(486, 229);
            this.tp_zarzadzaj_flota.TabIndex = 2;
            this.tp_zarzadzaj_flota.Text = "Zarządzaj flotą";
            this.tp_zarzadzaj_flota.UseVisualStyleBackColor = true;
            // 
            // b_edytuj_pojazd
            // 
            this.b_edytuj_pojazd.Location = new System.Drawing.Point(377, 115);
            this.b_edytuj_pojazd.Name = "b_edytuj_pojazd";
            this.b_edytuj_pojazd.Size = new System.Drawing.Size(104, 23);
            this.b_edytuj_pojazd.TabIndex = 4;
            this.b_edytuj_pojazd.Text = "Edytuj pojazd";
            this.b_edytuj_pojazd.UseVisualStyleBackColor = true;
            // 
            // b_usun_pojazd
            // 
            this.b_usun_pojazd.Location = new System.Drawing.Point(375, 196);
            this.b_usun_pojazd.Name = "b_usun_pojazd";
            this.b_usun_pojazd.Size = new System.Drawing.Size(104, 23);
            this.b_usun_pojazd.TabIndex = 3;
            this.b_usun_pojazd.Text = "Usuń pojazd";
            this.b_usun_pojazd.UseVisualStyleBackColor = true;
            // 
            // l_pojazdy
            // 
            this.l_pojazdy.AutoSize = true;
            this.l_pojazdy.Location = new System.Drawing.Point(127, 17);
            this.l_pojazdy.Name = "l_pojazdy";
            this.l_pojazdy.Size = new System.Drawing.Size(44, 13);
            this.l_pojazdy.TabIndex = 2;
            this.l_pojazdy.Text = "Pojazdy";
            // 
            // b_dodaj_pojazd
            // 
            this.b_dodaj_pojazd.Location = new System.Drawing.Point(376, 33);
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
            this.Dostępnosc,
            this.Marka,
            this.Pojemnosc,
            this.Stan});
            this.lv_pojazdy.GridLines = true;
            this.lv_pojazdy.Location = new System.Drawing.Point(8, 33);
            this.lv_pojazdy.MultiSelect = false;
            this.lv_pojazdy.Name = "lv_pojazdy";
            this.lv_pojazdy.Size = new System.Drawing.Size(363, 186);
            this.lv_pojazdy.TabIndex = 1;
            this.lv_pojazdy.UseCompatibleStateImageBehavior = false;
            this.lv_pojazdy.View = System.Windows.Forms.View.Details;
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
            this.Marka.Width = 50;
            // 
            // Pojemnosc
            // 
            this.Pojemnosc.Text = "Pojemnosc";
            this.Pojemnosc.Width = 70;
            // 
            // Stan
            // 
            this.Stan.Text = "Stan";
            this.Stan.Width = 40;
            // 
            // tp_raporty
            // 
            this.tp_raporty.Controls.Add(this.b_raport_reklamacje);
            this.tp_raporty.Controls.Add(this.b_raport_pojazdy);
            this.tp_raporty.Controls.Add(this.b_raport_wycieczki);
            this.tp_raporty.Location = new System.Drawing.Point(4, 22);
            this.tp_raporty.Name = "tp_raporty";
            this.tp_raporty.Padding = new System.Windows.Forms.Padding(3);
            this.tp_raporty.Size = new System.Drawing.Size(486, 229);
            this.tp_raporty.TabIndex = 3;
            this.tp_raporty.Text = "Raporty";
            this.tp_raporty.UseVisualStyleBackColor = true;
            // 
            // b_raport_reklamacje
            // 
            this.b_raport_reklamacje.Location = new System.Drawing.Point(89, 162);
            this.b_raport_reklamacje.Name = "b_raport_reklamacje";
            this.b_raport_reklamacje.Size = new System.Drawing.Size(302, 48);
            this.b_raport_reklamacje.TabIndex = 2;
            this.b_raport_reklamacje.Text = "Drukuj raport reklamacji";
            this.b_raport_reklamacje.UseVisualStyleBackColor = true;
            // 
            // b_raport_pojazdy
            // 
            this.b_raport_pojazdy.Location = new System.Drawing.Point(89, 93);
            this.b_raport_pojazdy.Name = "b_raport_pojazdy";
            this.b_raport_pojazdy.Size = new System.Drawing.Size(302, 48);
            this.b_raport_pojazdy.TabIndex = 1;
            this.b_raport_pojazdy.Text = "Drukuj raport pojazdów";
            this.b_raport_pojazdy.UseVisualStyleBackColor = true;
            // 
            // b_raport_wycieczki
            // 
            this.b_raport_wycieczki.Location = new System.Drawing.Point(89, 23);
            this.b_raport_wycieczki.Name = "b_raport_wycieczki";
            this.b_raport_wycieczki.Size = new System.Drawing.Size(302, 48);
            this.b_raport_wycieczki.TabIndex = 0;
            this.b_raport_wycieczki.Text = "Drukuj raport wycieczek";
            this.b_raport_wycieczki.UseVisualStyleBackColor = true;
            // 
            // b_wyjdz
            // 
            this.b_wyjdz.Location = new System.Drawing.Point(401, 257);
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
            this.l_zalogowany_jako.Location = new System.Drawing.Point(76, 267);
            this.l_zalogowany_jako.Name = "l_zalogowany_jako";
            this.l_zalogowany_jako.Size = new System.Drawing.Size(88, 13);
            this.l_zalogowany_jako.TabIndex = 4;
            this.l_zalogowany_jako.Text = "Zalogowany jako";
            // 
            // l_uzytkownik
            // 
            this.l_uzytkownik.AutoSize = true;
            this.l_uzytkownik.Location = new System.Drawing.Point(163, 267);
            this.l_uzytkownik.Name = "l_uzytkownik";
            this.l_uzytkownik.Size = new System.Drawing.Size(10, 13);
            this.l_uzytkownik.TabIndex = 5;
            this.l_uzytkownik.Text = " ";
            // 
            // l_polaczenie
            // 
            this.l_polaczenie.AutoSize = true;
            this.l_polaczenie.Location = new System.Drawing.Point(3, 267);
            this.l_polaczenie.Name = "l_polaczenie";
            this.l_polaczenie.Size = new System.Drawing.Size(10, 13);
            this.l_polaczenie.TabIndex = 6;
            this.l_polaczenie.Text = " ";
            // 
            // Kierownik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 287);
            this.Controls.Add(this.l_polaczenie);
            this.Controls.Add(this.l_uzytkownik);
            this.Controls.Add(this.l_zalogowany_jako);
            this.Controls.Add(this.b_wyjdz);
            this.Controls.Add(this.tc_kierownik);
            this.Name = "Kierownik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kierownik";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kierownik_FormClosing);
            this.Load += new System.EventHandler(this.Kierownik_Load);
            this.tc_kierownik.ResumeLayout(false);
            this.tp_zarzadzaj_wycieczkami.ResumeLayout(false);
            this.tp_zarzadzaj_wycieczkami.PerformLayout();
            this.tp_rozpatrz_reklamacje.ResumeLayout(false);
            this.tp_rozpatrz_reklamacje.PerformLayout();
            this.tp_zarzadzaj_flota.ResumeLayout(false);
            this.tp_zarzadzaj_flota.PerformLayout();
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
        private System.Windows.Forms.Label l_wycieczki;
        private System.Windows.Forms.Button b_rozpatrz_negatywnie;
        private System.Windows.Forms.Label l_opis_reklamacji;
        private System.Windows.Forms.TextBox tb_opis_reklamacji;
        private System.Windows.Forms.Label l_okres_wycieczki;
        private System.Windows.Forms.Label l_nazwa_wycieczki;
        private System.Windows.Forms.Button b_rozpatrz_pozytywnie;
        private System.Windows.Forms.Label l_reklamacje;
        private System.Windows.Forms.TabPage tp_zarzadzaj_flota;
        private System.Windows.Forms.Button b_dodaj_pojazd;
        private System.Windows.Forms.ListView lv_pojazdy;
        private System.Windows.Forms.Button b_usun_pojazd;
        private System.Windows.Forms.Label l_pojazdy;
        private System.Windows.Forms.ColumnHeader Nr_rejestracyjny;
        private System.Windows.Forms.ColumnHeader Dostępnosc;
        private System.Windows.Forms.ColumnHeader Marka;
        private System.Windows.Forms.ColumnHeader Pojemnosc;
        private System.Windows.Forms.ColumnHeader Stan;
        private System.Windows.Forms.Button b_edytuj_pojazd;
        private System.Windows.Forms.TabPage tp_raporty;
        private System.Windows.Forms.Button b_raport_reklamacje;
        private System.Windows.Forms.Button b_raport_pojazdy;
        private System.Windows.Forms.Button b_raport_wycieczki;
        private System.Windows.Forms.ComboBox cb_okres_wycieczki;
        private System.Windows.Forms.ComboBox cb_nazwa_wycieczki;
        private System.Windows.Forms.ListView lv_reklamacje;
        private System.Windows.Forms.ColumnHeader numer_reklamacji;
        private System.Windows.Forms.Button b_wyjdz;
        private System.Windows.Forms.Label l_zalogowany_jako;
        private System.Windows.Forms.Label l_uzytkownik;
        private System.Windows.Forms.Label l_polaczenie;
        private System.Windows.Forms.ListView lv_wycieczki;
        private System.Windows.Forms.ColumnHeader Nazwa;
        private System.Windows.Forms.ColumnHeader DataWyjazdu;
        private System.Windows.Forms.ColumnHeader DataPrzyjazdu;
        private System.Windows.Forms.ColumnHeader Opis;
        private System.Windows.Forms.ColumnHeader Promocja;
        private System.Windows.Forms.ColumnHeader Cena;
        private System.Windows.Forms.ColumnHeader Kierowca;
        private System.Windows.Forms.ColumnHeader Pilot;
        private System.Windows.Forms.ColumnHeader MiejsceOdjazdu;
        private System.Windows.Forms.ColumnHeader MiejsceDocelowe;
    }
}