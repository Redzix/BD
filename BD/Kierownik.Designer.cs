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
            this.b_usun_wycieczke = new System.Windows.Forms.Button();
            this.b_edytuj = new System.Windows.Forms.Button();
            this.b_dodaj_wycieczke = new System.Windows.Forms.Button();
            this.l_wycieczki = new System.Windows.Forms.Label();
            this.lb_wycieczki = new System.Windows.Forms.ListBox();
            this.tp_rozpatrz_reklamacje = new System.Windows.Forms.TabPage();
            this.b_rozpatrz_negatywnie = new System.Windows.Forms.Button();
            this.l_opis_reklamacji = new System.Windows.Forms.Label();
            this.tb_opis_reklamacji = new System.Windows.Forms.TextBox();
            this.l_okres_wycieczki = new System.Windows.Forms.Label();
            this.tb_okres_wycieczki = new System.Windows.Forms.TextBox();
            this.l_nazwa_wycieczki = new System.Windows.Forms.Label();
            this.b_rozpatrz_pozytywnie = new System.Windows.Forms.Button();
            this.tb_nazwa_wycieczki = new System.Windows.Forms.TextBox();
            this.l_reklamacje = new System.Windows.Forms.Label();
            this.lb_reklamacje = new System.Windows.Forms.ListBox();
            this.tp_zarzadzaj_flota = new System.Windows.Forms.TabPage();
            this.lv_pojazdy = new System.Windows.Forms.ListView();
            this.b_dodaj_pojazd = new System.Windows.Forms.Button();
            this.l_pojazdy = new System.Windows.Forms.Label();
            this.b_usun_pojazd = new System.Windows.Forms.Button();
            this.Nr_rejestracyjny = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dostępność = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Marka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pojemność = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.b_edytuj_pojazd = new System.Windows.Forms.Button();
            this.tp_raporty = new System.Windows.Forms.TabPage();
            this.b_raport_wycieczki = new System.Windows.Forms.Button();
            this.b_raport_pojazdy = new System.Windows.Forms.Button();
            this.b_raport_reklamacje = new System.Windows.Forms.Button();
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
            this.tc_kierownik.Size = new System.Drawing.Size(443, 255);
            this.tc_kierownik.TabIndex = 2;
            // 
            // tp_zarzadzaj_wycieczkami
            // 
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.b_usun_wycieczke);
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.b_edytuj);
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.b_dodaj_wycieczke);
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.l_wycieczki);
            this.tp_zarzadzaj_wycieczkami.Controls.Add(this.lb_wycieczki);
            this.tp_zarzadzaj_wycieczkami.Location = new System.Drawing.Point(4, 22);
            this.tp_zarzadzaj_wycieczkami.Name = "tp_zarzadzaj_wycieczkami";
            this.tp_zarzadzaj_wycieczkami.Padding = new System.Windows.Forms.Padding(3);
            this.tp_zarzadzaj_wycieczkami.Size = new System.Drawing.Size(435, 229);
            this.tp_zarzadzaj_wycieczkami.TabIndex = 0;
            this.tp_zarzadzaj_wycieczkami.Text = "Zarządzaj wycieczkami";
            this.tp_zarzadzaj_wycieczkami.UseVisualStyleBackColor = true;
            // 
            // b_usun_wycieczke
            // 
            this.b_usun_wycieczke.Location = new System.Drawing.Point(322, 194);
            this.b_usun_wycieczke.Name = "b_usun_wycieczke";
            this.b_usun_wycieczke.Size = new System.Drawing.Size(103, 23);
            this.b_usun_wycieczke.TabIndex = 4;
            this.b_usun_wycieczke.Text = "Usuń wycieczkę";
            this.b_usun_wycieczke.UseVisualStyleBackColor = true;
            // 
            // b_edytuj
            // 
            this.b_edytuj.Location = new System.Drawing.Point(322, 108);
            this.b_edytuj.Name = "b_edytuj";
            this.b_edytuj.Size = new System.Drawing.Size(103, 23);
            this.b_edytuj.TabIndex = 3;
            this.b_edytuj.Text = "Edytuj";
            this.b_edytuj.UseVisualStyleBackColor = true;
            // 
            // b_dodaj_wycieczke
            // 
            this.b_dodaj_wycieczke.Location = new System.Drawing.Point(322, 31);
            this.b_dodaj_wycieczke.Name = "b_dodaj_wycieczke";
            this.b_dodaj_wycieczke.Size = new System.Drawing.Size(103, 23);
            this.b_dodaj_wycieczke.TabIndex = 2;
            this.b_dodaj_wycieczke.Text = "Dodaj wycieczkę";
            this.b_dodaj_wycieczke.UseVisualStyleBackColor = true;
            // 
            // l_wycieczki
            // 
            this.l_wycieczki.AutoSize = true;
            this.l_wycieczki.Location = new System.Drawing.Point(121, 15);
            this.l_wycieczki.Name = "l_wycieczki";
            this.l_wycieczki.Size = new System.Drawing.Size(56, 13);
            this.l_wycieczki.TabIndex = 1;
            this.l_wycieczki.Text = "Wycieczki";
            // 
            // lb_wycieczki
            // 
            this.lb_wycieczki.FormattingEnabled = true;
            this.lb_wycieczki.Location = new System.Drawing.Point(6, 31);
            this.lb_wycieczki.Name = "lb_wycieczki";
            this.lb_wycieczki.Size = new System.Drawing.Size(308, 186);
            this.lb_wycieczki.TabIndex = 0;
            // 
            // tp_rozpatrz_reklamacje
            // 
            this.tp_rozpatrz_reklamacje.Controls.Add(this.b_rozpatrz_negatywnie);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.l_opis_reklamacji);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.tb_opis_reklamacji);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.l_okres_wycieczki);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.tb_okres_wycieczki);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.l_nazwa_wycieczki);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.b_rozpatrz_pozytywnie);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.tb_nazwa_wycieczki);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.l_reklamacje);
            this.tp_rozpatrz_reklamacje.Controls.Add(this.lb_reklamacje);
            this.tp_rozpatrz_reklamacje.Location = new System.Drawing.Point(4, 22);
            this.tp_rozpatrz_reklamacje.Name = "tp_rozpatrz_reklamacje";
            this.tp_rozpatrz_reklamacje.Padding = new System.Windows.Forms.Padding(3);
            this.tp_rozpatrz_reklamacje.Size = new System.Drawing.Size(435, 229);
            this.tp_rozpatrz_reklamacje.TabIndex = 1;
            this.tp_rozpatrz_reklamacje.Text = "Rozpatrz reklamacje";
            this.tp_rozpatrz_reklamacje.UseVisualStyleBackColor = true;
            // 
            // b_rozpatrz_negatywnie
            // 
            this.b_rozpatrz_negatywnie.Location = new System.Drawing.Point(336, 174);
            this.b_rozpatrz_negatywnie.Name = "b_rozpatrz_negatywnie";
            this.b_rozpatrz_negatywnie.Size = new System.Drawing.Size(93, 49);
            this.b_rozpatrz_negatywnie.TabIndex = 9;
            this.b_rozpatrz_negatywnie.Text = "Rozpatrz negatywnie";
            this.b_rozpatrz_negatywnie.UseVisualStyleBackColor = true;
            // 
            // l_opis_reklamacji
            // 
            this.l_opis_reklamacji.AutoSize = true;
            this.l_opis_reklamacji.Location = new System.Drawing.Point(153, 97);
            this.l_opis_reklamacji.Name = "l_opis_reklamacji";
            this.l_opis_reklamacji.Size = new System.Drawing.Size(78, 13);
            this.l_opis_reklamacji.TabIndex = 8;
            this.l_opis_reklamacji.Text = "Opis reklamacji";
            // 
            // tb_opis_reklamacji
            // 
            this.tb_opis_reklamacji.Location = new System.Drawing.Point(237, 94);
            this.tb_opis_reklamacji.Multiline = true;
            this.tb_opis_reklamacji.Name = "tb_opis_reklamacji";
            this.tb_opis_reklamacji.Size = new System.Drawing.Size(192, 74);
            this.tb_opis_reklamacji.TabIndex = 7;
            // 
            // l_okres_wycieczki
            // 
            this.l_okres_wycieczki.AutoSize = true;
            this.l_okres_wycieczki.Location = new System.Drawing.Point(146, 66);
            this.l_okres_wycieczki.Name = "l_okres_wycieczki";
            this.l_okres_wycieczki.Size = new System.Drawing.Size(84, 13);
            this.l_okres_wycieczki.TabIndex = 6;
            this.l_okres_wycieczki.Text = "Okres wycieczki";
            // 
            // tb_okres_wycieczki
            // 
            this.tb_okres_wycieczki.Location = new System.Drawing.Point(236, 63);
            this.tb_okres_wycieczki.Name = "tb_okres_wycieczki";
            this.tb_okres_wycieczki.Size = new System.Drawing.Size(140, 20);
            this.tb_okres_wycieczki.TabIndex = 5;
            // 
            // l_nazwa_wycieczki
            // 
            this.l_nazwa_wycieczki.AutoSize = true;
            this.l_nazwa_wycieczki.Location = new System.Drawing.Point(141, 37);
            this.l_nazwa_wycieczki.Name = "l_nazwa_wycieczki";
            this.l_nazwa_wycieczki.Size = new System.Drawing.Size(89, 13);
            this.l_nazwa_wycieczki.TabIndex = 4;
            this.l_nazwa_wycieczki.Text = "Nazwa wycieczki";
            // 
            // b_rozpatrz_pozytywnie
            // 
            this.b_rozpatrz_pozytywnie.Location = new System.Drawing.Point(237, 174);
            this.b_rozpatrz_pozytywnie.Name = "b_rozpatrz_pozytywnie";
            this.b_rozpatrz_pozytywnie.Size = new System.Drawing.Size(93, 49);
            this.b_rozpatrz_pozytywnie.TabIndex = 3;
            this.b_rozpatrz_pozytywnie.Text = "Rozpatrz pozytywnie";
            this.b_rozpatrz_pozytywnie.UseVisualStyleBackColor = true;
            // 
            // tb_nazwa_wycieczki
            // 
            this.tb_nazwa_wycieczki.Location = new System.Drawing.Point(236, 34);
            this.tb_nazwa_wycieczki.Name = "tb_nazwa_wycieczki";
            this.tb_nazwa_wycieczki.Size = new System.Drawing.Size(140, 20);
            this.tb_nazwa_wycieczki.TabIndex = 2;
            // 
            // l_reklamacje
            // 
            this.l_reklamacje.AutoSize = true;
            this.l_reklamacje.Location = new System.Drawing.Point(30, 18);
            this.l_reklamacje.Name = "l_reklamacje";
            this.l_reklamacje.Size = new System.Drawing.Size(63, 13);
            this.l_reklamacje.TabIndex = 1;
            this.l_reklamacje.Text = "Reklamacje";
            // 
            // lb_reklamacje
            // 
            this.lb_reklamacje.FormattingEnabled = true;
            this.lb_reklamacje.Location = new System.Drawing.Point(6, 34);
            this.lb_reklamacje.Name = "lb_reklamacje";
            this.lb_reklamacje.Size = new System.Drawing.Size(120, 173);
            this.lb_reklamacje.TabIndex = 0;
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
            this.tp_zarzadzaj_flota.Size = new System.Drawing.Size(435, 229);
            this.tp_zarzadzaj_flota.TabIndex = 2;
            this.tp_zarzadzaj_flota.Text = "Zarządzaj flotą";
            this.tp_zarzadzaj_flota.UseVisualStyleBackColor = true;
            // 
            // lv_pojazdy
            // 
            this.lv_pojazdy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nr_rejestracyjny,
            this.Dostępność,
            this.Marka,
            this.Pojemność,
            this.Stan});
            this.lv_pojazdy.Location = new System.Drawing.Point(8, 33);
            this.lv_pojazdy.Name = "lv_pojazdy";
            this.lv_pojazdy.Size = new System.Drawing.Size(307, 186);
            this.lv_pojazdy.TabIndex = 0;
            this.lv_pojazdy.UseCompatibleStateImageBehavior = false;
            // 
            // b_dodaj_pojazd
            // 
            this.b_dodaj_pojazd.Location = new System.Drawing.Point(321, 33);
            this.b_dodaj_pojazd.Name = "b_dodaj_pojazd";
            this.b_dodaj_pojazd.Size = new System.Drawing.Size(104, 23);
            this.b_dodaj_pojazd.TabIndex = 1;
            this.b_dodaj_pojazd.Text = "Dodaj pojazd";
            this.b_dodaj_pojazd.UseVisualStyleBackColor = true;
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
            // b_usun_pojazd
            // 
            this.b_usun_pojazd.Location = new System.Drawing.Point(321, 196);
            this.b_usun_pojazd.Name = "b_usun_pojazd";
            this.b_usun_pojazd.Size = new System.Drawing.Size(104, 23);
            this.b_usun_pojazd.TabIndex = 3;
            this.b_usun_pojazd.Text = "Usuń pojazd";
            this.b_usun_pojazd.UseVisualStyleBackColor = true;
            // 
            // b_edytuj_pojazd
            // 
            this.b_edytuj_pojazd.Location = new System.Drawing.Point(321, 115);
            this.b_edytuj_pojazd.Name = "b_edytuj_pojazd";
            this.b_edytuj_pojazd.Size = new System.Drawing.Size(104, 23);
            this.b_edytuj_pojazd.TabIndex = 4;
            this.b_edytuj_pojazd.Text = "Edytuj pojazd";
            this.b_edytuj_pojazd.UseVisualStyleBackColor = true;
            // 
            // tp_raporty
            // 
            this.tp_raporty.Controls.Add(this.b_raport_reklamacje);
            this.tp_raporty.Controls.Add(this.b_raport_pojazdy);
            this.tp_raporty.Controls.Add(this.b_raport_wycieczki);
            this.tp_raporty.Location = new System.Drawing.Point(4, 22);
            this.tp_raporty.Name = "tp_raporty";
            this.tp_raporty.Padding = new System.Windows.Forms.Padding(3);
            this.tp_raporty.Size = new System.Drawing.Size(435, 229);
            this.tp_raporty.TabIndex = 3;
            this.tp_raporty.Text = "Raporty";
            this.tp_raporty.UseVisualStyleBackColor = true;
            // 
            // b_raport_wycieczki
            // 
            this.b_raport_wycieczki.Location = new System.Drawing.Point(62, 22);
            this.b_raport_wycieczki.Name = "b_raport_wycieczki";
            this.b_raport_wycieczki.Size = new System.Drawing.Size(302, 48);
            this.b_raport_wycieczki.TabIndex = 0;
            this.b_raport_wycieczki.Text = "Drukuj raport wycieczek";
            this.b_raport_wycieczki.UseVisualStyleBackColor = true;
            // 
            // b_raport_pojazdy
            // 
            this.b_raport_pojazdy.Location = new System.Drawing.Point(62, 92);
            this.b_raport_pojazdy.Name = "b_raport_pojazdy";
            this.b_raport_pojazdy.Size = new System.Drawing.Size(302, 48);
            this.b_raport_pojazdy.TabIndex = 1;
            this.b_raport_pojazdy.Text = "Drukuj raport pojazdów";
            this.b_raport_pojazdy.UseVisualStyleBackColor = true;
            // 
            // b_raport_reklamacje
            // 
            this.b_raport_reklamacje.Location = new System.Drawing.Point(62, 161);
            this.b_raport_reklamacje.Name = "b_raport_reklamacje";
            this.b_raport_reklamacje.Size = new System.Drawing.Size(302, 48);
            this.b_raport_reklamacje.TabIndex = 2;
            this.b_raport_reklamacje.Text = "Drukuj raport reklamacji";
            this.b_raport_reklamacje.UseVisualStyleBackColor = true;
            // 
            // Kierownik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 253);
            this.Controls.Add(this.tc_kierownik);
            this.Name = "Kierownik";
            this.Text = "Kierownik";
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

        }

        #endregion

        private System.Windows.Forms.TabControl tc_kierownik;
        private System.Windows.Forms.TabPage tp_zarzadzaj_wycieczkami;
        private System.Windows.Forms.TabPage tp_rozpatrz_reklamacje;
        private System.Windows.Forms.Button b_usun_wycieczke;
        private System.Windows.Forms.Button b_edytuj;
        private System.Windows.Forms.Button b_dodaj_wycieczke;
        private System.Windows.Forms.Label l_wycieczki;
        private System.Windows.Forms.ListBox lb_wycieczki;
        private System.Windows.Forms.Button b_rozpatrz_negatywnie;
        private System.Windows.Forms.Label l_opis_reklamacji;
        private System.Windows.Forms.TextBox tb_opis_reklamacji;
        private System.Windows.Forms.Label l_okres_wycieczki;
        private System.Windows.Forms.TextBox tb_okres_wycieczki;
        private System.Windows.Forms.Label l_nazwa_wycieczki;
        private System.Windows.Forms.Button b_rozpatrz_pozytywnie;
        private System.Windows.Forms.TextBox tb_nazwa_wycieczki;
        private System.Windows.Forms.Label l_reklamacje;
        private System.Windows.Forms.ListBox lb_reklamacje;
        private System.Windows.Forms.TabPage tp_zarzadzaj_flota;
        private System.Windows.Forms.Button b_dodaj_pojazd;
        private System.Windows.Forms.ListView lv_pojazdy;
        private System.Windows.Forms.Button b_usun_pojazd;
        private System.Windows.Forms.Label l_pojazdy;
        private System.Windows.Forms.ColumnHeader Nr_rejestracyjny;
        private System.Windows.Forms.ColumnHeader Dostępność;
        private System.Windows.Forms.ColumnHeader Marka;
        private System.Windows.Forms.ColumnHeader Pojemność;
        private System.Windows.Forms.ColumnHeader Stan;
        private System.Windows.Forms.Button b_edytuj_pojazd;
        private System.Windows.Forms.TabPage tp_raporty;
        private System.Windows.Forms.Button b_raport_reklamacje;
        private System.Windows.Forms.Button b_raport_pojazdy;
        private System.Windows.Forms.Button b_raport_wycieczki;
    }
}