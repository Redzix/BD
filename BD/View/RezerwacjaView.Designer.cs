namespace BD.View
{
    partial class RezerwacjaView
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
            this.tb_imie = new System.Windows.Forms.TextBox();
            this.tb_nazwisko = new System.Windows.Forms.TextBox();
            this.tb_liczba_osob = new System.Windows.Forms.TextBox();
            this.tb_zaliczka = new System.Windows.Forms.TextBox();
            this.tb_adres = new System.Windows.Forms.TextBox();
            this.l_imie = new System.Windows.Forms.Label();
            this.l_nazwisko = new System.Windows.Forms.Label();
            this.l_adres = new System.Windows.Forms.Label();
            this.l_liczba_osob = new System.Windows.Forms.Label();
            this.l_zaliczka = new System.Windows.Forms.Label();
            this.b_rezerwacja_zapisz = new System.Windows.Forms.Button();
            this.b_rezerwacja_anuluj = new System.Windows.Forms.Button();
            this.l_miejscowosc = new System.Windows.Forms.Label();
            this.tb_miejscowosc = new System.Windows.Forms.TextBox();
            this.tb_pesel = new System.Windows.Forms.TextBox();
            this.l_pesel = new System.Windows.Forms.Label();
            this.p_rezerwuj = new System.Windows.Forms.Panel();
            this.p_zaplac = new System.Windows.Forms.Panel();
            this.l_wotaCalkowita = new System.Windows.Forms.Label();
            this.tb_kwotaCalkowita = new System.Windows.Forms.TextBox();
            this.b_anulujZaplate = new System.Windows.Forms.Button();
            this.b_zapłaćRezerwacje = new System.Windows.Forms.Button();
            this.l_kwotaZaplacona = new System.Windows.Forms.Label();
            this.l_kwotaDoZaplaty = new System.Windows.Forms.Label();
            this.l_nazwaWycieczkiZaplac = new System.Windows.Forms.Label();
            this.l_numerRezerwacji = new System.Windows.Forms.Label();
            this.tb_nazwaWycieczkiZaplac = new System.Windows.Forms.TextBox();
            this.tb_kwotaZaplacona = new System.Windows.Forms.TextBox();
            this.tb_kwotaDoZaplaty = new System.Windows.Forms.TextBox();
            this.tb_numerRezerwacji = new System.Windows.Forms.TextBox();
            this.p_rezerwuj.SuspendLayout();
            this.p_zaplac.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_imie
            // 
            this.tb_imie.Enabled = false;
            this.tb_imie.Location = new System.Drawing.Point(107, 52);
            this.tb_imie.Name = "tb_imie";
            this.tb_imie.Size = new System.Drawing.Size(100, 20);
            this.tb_imie.TabIndex = 1;
            // 
            // tb_nazwisko
            // 
            this.tb_nazwisko.Enabled = false;
            this.tb_nazwisko.Location = new System.Drawing.Point(107, 78);
            this.tb_nazwisko.Name = "tb_nazwisko";
            this.tb_nazwisko.Size = new System.Drawing.Size(100, 20);
            this.tb_nazwisko.TabIndex = 2;
            // 
            // tb_liczba_osob
            // 
            this.tb_liczba_osob.Location = new System.Drawing.Point(107, 156);
            this.tb_liczba_osob.Name = "tb_liczba_osob";
            this.tb_liczba_osob.Size = new System.Drawing.Size(100, 20);
            this.tb_liczba_osob.TabIndex = 5;
            this.tb_liczba_osob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_liczba_osob_KeyPress);
            // 
            // tb_zaliczka
            // 
            this.tb_zaliczka.Location = new System.Drawing.Point(107, 182);
            this.tb_zaliczka.Name = "tb_zaliczka";
            this.tb_zaliczka.Size = new System.Drawing.Size(100, 20);
            this.tb_zaliczka.TabIndex = 6;
            this.tb_zaliczka.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_zaliczka_KeyPress);
            // 
            // tb_adres
            // 
            this.tb_adres.Location = new System.Drawing.Point(107, 104);
            this.tb_adres.Multiline = true;
            this.tb_adres.Name = "tb_adres";
            this.tb_adres.Size = new System.Drawing.Size(100, 20);
            this.tb_adres.TabIndex = 3;
            // 
            // l_imie
            // 
            this.l_imie.AutoSize = true;
            this.l_imie.Location = new System.Drawing.Point(37, 55);
            this.l_imie.Name = "l_imie";
            this.l_imie.Size = new System.Drawing.Size(26, 13);
            this.l_imie.TabIndex = 6;
            this.l_imie.Text = "Imię";
            // 
            // l_nazwisko
            // 
            this.l_nazwisko.AutoSize = true;
            this.l_nazwisko.Location = new System.Drawing.Point(37, 81);
            this.l_nazwisko.Name = "l_nazwisko";
            this.l_nazwisko.Size = new System.Drawing.Size(53, 13);
            this.l_nazwisko.TabIndex = 7;
            this.l_nazwisko.Text = "Nazwisko";
            // 
            // l_adres
            // 
            this.l_adres.AutoSize = true;
            this.l_adres.Location = new System.Drawing.Point(37, 107);
            this.l_adres.Name = "l_adres";
            this.l_adres.Size = new System.Drawing.Size(34, 13);
            this.l_adres.TabIndex = 8;
            this.l_adres.Text = "Adres";
            // 
            // l_liczba_osob
            // 
            this.l_liczba_osob.AutoSize = true;
            this.l_liczba_osob.Location = new System.Drawing.Point(37, 159);
            this.l_liczba_osob.Name = "l_liczba_osob";
            this.l_liczba_osob.Size = new System.Drawing.Size(64, 13);
            this.l_liczba_osob.TabIndex = 5;
            this.l_liczba_osob.Text = "Liczba osób";
            // 
            // l_zaliczka
            // 
            this.l_zaliczka.AutoSize = true;
            this.l_zaliczka.Location = new System.Drawing.Point(37, 185);
            this.l_zaliczka.Name = "l_zaliczka";
            this.l_zaliczka.Size = new System.Drawing.Size(47, 13);
            this.l_zaliczka.TabIndex = 6;
            this.l_zaliczka.Text = "Zaliczka";
            // 
            // b_rezerwacja_zapisz
            // 
            this.b_rezerwacja_zapisz.Location = new System.Drawing.Point(15, 226);
            this.b_rezerwacja_zapisz.Name = "b_rezerwacja_zapisz";
            this.b_rezerwacja_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_rezerwacja_zapisz.TabIndex = 7;
            this.b_rezerwacja_zapisz.Text = "Zapisz";
            this.b_rezerwacja_zapisz.UseVisualStyleBackColor = true;
            this.b_rezerwacja_zapisz.Click += new System.EventHandler(this.b_rezerwacja_zapisz_Click);
            // 
            // b_rezerwacja_anuluj
            // 
            this.b_rezerwacja_anuluj.Location = new System.Drawing.Point(161, 226);
            this.b_rezerwacja_anuluj.Name = "b_rezerwacja_anuluj";
            this.b_rezerwacja_anuluj.Size = new System.Drawing.Size(75, 23);
            this.b_rezerwacja_anuluj.TabIndex = 12;
            this.b_rezerwacja_anuluj.Text = "Anuluj";
            this.b_rezerwacja_anuluj.UseVisualStyleBackColor = true;
            this.b_rezerwacja_anuluj.Click += new System.EventHandler(this.b_rezerwacja_anuluj_Click);
            // 
            // l_miejscowosc
            // 
            this.l_miejscowosc.AutoSize = true;
            this.l_miejscowosc.Location = new System.Drawing.Point(37, 133);
            this.l_miejscowosc.Name = "l_miejscowosc";
            this.l_miejscowosc.Size = new System.Drawing.Size(68, 13);
            this.l_miejscowosc.TabIndex = 14;
            this.l_miejscowosc.Text = "Miejscowość";
            // 
            // tb_miejscowosc
            // 
            this.tb_miejscowosc.Location = new System.Drawing.Point(107, 130);
            this.tb_miejscowosc.Multiline = true;
            this.tb_miejscowosc.Name = "tb_miejscowosc";
            this.tb_miejscowosc.Size = new System.Drawing.Size(100, 20);
            this.tb_miejscowosc.TabIndex = 4;
            // 
            // tb_pesel
            // 
            this.tb_pesel.Enabled = false;
            this.tb_pesel.Location = new System.Drawing.Point(107, 26);
            this.tb_pesel.Name = "tb_pesel";
            this.tb_pesel.Size = new System.Drawing.Size(100, 20);
            this.tb_pesel.TabIndex = 0;
            // 
            // l_pesel
            // 
            this.l_pesel.AutoSize = true;
            this.l_pesel.Location = new System.Drawing.Point(37, 29);
            this.l_pesel.Name = "l_pesel";
            this.l_pesel.Size = new System.Drawing.Size(33, 13);
            this.l_pesel.TabIndex = 16;
            this.l_pesel.Text = "Pesel";
            // 
            // p_rezerwuj
            // 
            this.p_rezerwuj.Controls.Add(this.l_pesel);
            this.p_rezerwuj.Controls.Add(this.tb_pesel);
            this.p_rezerwuj.Controls.Add(this.l_miejscowosc);
            this.p_rezerwuj.Controls.Add(this.tb_miejscowosc);
            this.p_rezerwuj.Controls.Add(this.b_rezerwacja_anuluj);
            this.p_rezerwuj.Controls.Add(this.b_rezerwacja_zapisz);
            this.p_rezerwuj.Controls.Add(this.l_zaliczka);
            this.p_rezerwuj.Controls.Add(this.l_liczba_osob);
            this.p_rezerwuj.Controls.Add(this.l_adres);
            this.p_rezerwuj.Controls.Add(this.l_nazwisko);
            this.p_rezerwuj.Controls.Add(this.l_imie);
            this.p_rezerwuj.Controls.Add(this.tb_adres);
            this.p_rezerwuj.Controls.Add(this.tb_zaliczka);
            this.p_rezerwuj.Controls.Add(this.tb_liczba_osob);
            this.p_rezerwuj.Controls.Add(this.tb_nazwisko);
            this.p_rezerwuj.Controls.Add(this.tb_imie);
            this.p_rezerwuj.Location = new System.Drawing.Point(0, 0);
            this.p_rezerwuj.Name = "p_rezerwuj";
            this.p_rezerwuj.Size = new System.Drawing.Size(252, 297);
            this.p_rezerwuj.TabIndex = 17;
            // 
            // p_zaplac
            // 
            this.p_zaplac.Controls.Add(this.l_wotaCalkowita);
            this.p_zaplac.Controls.Add(this.tb_kwotaCalkowita);
            this.p_zaplac.Controls.Add(this.b_anulujZaplate);
            this.p_zaplac.Controls.Add(this.b_zapłaćRezerwacje);
            this.p_zaplac.Controls.Add(this.l_kwotaZaplacona);
            this.p_zaplac.Controls.Add(this.l_kwotaDoZaplaty);
            this.p_zaplac.Controls.Add(this.l_nazwaWycieczkiZaplac);
            this.p_zaplac.Controls.Add(this.l_numerRezerwacji);
            this.p_zaplac.Controls.Add(this.tb_nazwaWycieczkiZaplac);
            this.p_zaplac.Controls.Add(this.tb_kwotaZaplacona);
            this.p_zaplac.Controls.Add(this.tb_kwotaDoZaplaty);
            this.p_zaplac.Controls.Add(this.tb_numerRezerwacji);
            this.p_zaplac.Location = new System.Drawing.Point(0, 0);
            this.p_zaplac.Name = "p_zaplac";
            this.p_zaplac.Size = new System.Drawing.Size(249, 296);
            this.p_zaplac.TabIndex = 18;
            this.p_zaplac.Visible = false;
            // 
            // l_wotaCalkowita
            // 
            this.l_wotaCalkowita.AutoSize = true;
            this.l_wotaCalkowita.Location = new System.Drawing.Point(11, 73);
            this.l_wotaCalkowita.Name = "l_wotaCalkowita";
            this.l_wotaCalkowita.Size = new System.Drawing.Size(87, 13);
            this.l_wotaCalkowita.TabIndex = 11;
            this.l_wotaCalkowita.Text = "Kwota całkowita";
            // 
            // tb_kwotaCalkowita
            // 
            this.tb_kwotaCalkowita.Enabled = false;
            this.tb_kwotaCalkowita.Location = new System.Drawing.Point(132, 70);
            this.tb_kwotaCalkowita.Name = "tb_kwotaCalkowita";
            this.tb_kwotaCalkowita.Size = new System.Drawing.Size(101, 20);
            this.tb_kwotaCalkowita.TabIndex = 10;
            // 
            // b_anulujZaplate
            // 
            this.b_anulujZaplate.Location = new System.Drawing.Point(160, 159);
            this.b_anulujZaplate.Name = "b_anulujZaplate";
            this.b_anulujZaplate.Size = new System.Drawing.Size(75, 23);
            this.b_anulujZaplate.TabIndex = 8;
            this.b_anulujZaplate.Text = "Anuluj";
            this.b_anulujZaplate.UseVisualStyleBackColor = true;
            this.b_anulujZaplate.Click += new System.EventHandler(this.b_anlujZaplate_Click);
            // 
            // b_zapłaćRezerwacje
            // 
            this.b_zapłaćRezerwacje.Location = new System.Drawing.Point(14, 159);
            this.b_zapłaćRezerwacje.Name = "b_zapłaćRezerwacje";
            this.b_zapłaćRezerwacje.Size = new System.Drawing.Size(75, 23);
            this.b_zapłaćRezerwacje.TabIndex = 7;
            this.b_zapłaćRezerwacje.Text = "Zapłać";
            this.b_zapłaćRezerwacje.UseVisualStyleBackColor = true;
            this.b_zapłaćRezerwacje.Click += new System.EventHandler(this.b_zapłaćRezerwacje_Click);
            // 
            // l_kwotaZaplacona
            // 
            this.l_kwotaZaplacona.AutoSize = true;
            this.l_kwotaZaplacona.Location = new System.Drawing.Point(11, 125);
            this.l_kwotaZaplacona.Name = "l_kwotaZaplacona";
            this.l_kwotaZaplacona.Size = new System.Drawing.Size(88, 13);
            this.l_kwotaZaplacona.TabIndex = 7;
            this.l_kwotaZaplacona.Text = "Kwota wpłacana";
            // 
            // l_kwotaDoZaplaty
            // 
            this.l_kwotaDoZaplaty.AutoSize = true;
            this.l_kwotaDoZaplaty.Location = new System.Drawing.Point(11, 99);
            this.l_kwotaDoZaplaty.Name = "l_kwotaDoZaplaty";
            this.l_kwotaDoZaplaty.Size = new System.Drawing.Size(90, 13);
            this.l_kwotaDoZaplaty.TabIndex = 6;
            this.l_kwotaDoZaplaty.Text = "Kwota do zapłaty";
            // 
            // l_nazwaWycieczkiZaplac
            // 
            this.l_nazwaWycieczkiZaplac.AutoSize = true;
            this.l_nazwaWycieczkiZaplac.Location = new System.Drawing.Point(11, 47);
            this.l_nazwaWycieczkiZaplac.Name = "l_nazwaWycieczkiZaplac";
            this.l_nazwaWycieczkiZaplac.Size = new System.Drawing.Size(89, 13);
            this.l_nazwaWycieczkiZaplac.TabIndex = 5;
            this.l_nazwaWycieczkiZaplac.Text = "Nazwa wycieczki";
            // 
            // l_numerRezerwacji
            // 
            this.l_numerRezerwacji.AutoSize = true;
            this.l_numerRezerwacji.Location = new System.Drawing.Point(12, 21);
            this.l_numerRezerwacji.Name = "l_numerRezerwacji";
            this.l_numerRezerwacji.Size = new System.Drawing.Size(88, 13);
            this.l_numerRezerwacji.TabIndex = 4;
            this.l_numerRezerwacji.Text = "Numer rezerwacji";
            // 
            // tb_nazwaWycieczkiZaplac
            // 
            this.tb_nazwaWycieczkiZaplac.Enabled = false;
            this.tb_nazwaWycieczkiZaplac.Location = new System.Drawing.Point(132, 44);
            this.tb_nazwaWycieczkiZaplac.Name = "tb_nazwaWycieczkiZaplac";
            this.tb_nazwaWycieczkiZaplac.Size = new System.Drawing.Size(101, 20);
            this.tb_nazwaWycieczkiZaplac.TabIndex = 3;
            // 
            // tb_kwotaZaplacona
            // 
            this.tb_kwotaZaplacona.Location = new System.Drawing.Point(132, 122);
            this.tb_kwotaZaplacona.Name = "tb_kwotaZaplacona";
            this.tb_kwotaZaplacona.Size = new System.Drawing.Size(101, 20);
            this.tb_kwotaZaplacona.TabIndex = 2;
            // 
            // tb_kwotaDoZaplaty
            // 
            this.tb_kwotaDoZaplaty.Enabled = false;
            this.tb_kwotaDoZaplaty.Location = new System.Drawing.Point(132, 96);
            this.tb_kwotaDoZaplaty.Name = "tb_kwotaDoZaplaty";
            this.tb_kwotaDoZaplaty.Size = new System.Drawing.Size(102, 20);
            this.tb_kwotaDoZaplaty.TabIndex = 1;
            // 
            // tb_numerRezerwacji
            // 
            this.tb_numerRezerwacji.Location = new System.Drawing.Point(132, 18);
            this.tb_numerRezerwacji.Name = "tb_numerRezerwacji";
            this.tb_numerRezerwacji.Size = new System.Drawing.Size(103, 20);
            this.tb_numerRezerwacji.TabIndex = 0;
            this.tb_numerRezerwacji.Leave += new System.EventHandler(this.tb_numerRezerwacji_Leave);
            // 
            // RezerwacjaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 295);
            this.Controls.Add(this.p_rezerwuj);
            this.Controls.Add(this.p_zaplac);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RezerwacjaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rezerwacja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Rezerwacja_FormClosing);
            this.p_rezerwuj.ResumeLayout(false);
            this.p_rezerwuj.PerformLayout();
            this.p_zaplac.ResumeLayout(false);
            this.p_zaplac.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox tb_imie;
        public System.Windows.Forms.TextBox tb_nazwisko;
        public System.Windows.Forms.TextBox tb_liczba_osob;
        public System.Windows.Forms.TextBox tb_zaliczka;
        public System.Windows.Forms.TextBox tb_adres;
        private System.Windows.Forms.Label l_imie;
        private System.Windows.Forms.Label l_nazwisko;
        private System.Windows.Forms.Label l_adres;
        private System.Windows.Forms.Label l_liczba_osob;
        private System.Windows.Forms.Label l_zaliczka;
        private System.Windows.Forms.Button b_rezerwacja_zapisz;
        private System.Windows.Forms.Button b_rezerwacja_anuluj;
        private System.Windows.Forms.Label l_miejscowosc;
        public System.Windows.Forms.TextBox tb_miejscowosc;
        public System.Windows.Forms.TextBox tb_pesel;
        private System.Windows.Forms.Label l_pesel;
        private System.Windows.Forms.Panel p_rezerwuj;
        private System.Windows.Forms.Panel p_zaplac;
        private System.Windows.Forms.Button b_anulujZaplate;
        private System.Windows.Forms.Button b_zapłaćRezerwacje;
        private System.Windows.Forms.Label l_kwotaZaplacona;
        private System.Windows.Forms.Label l_kwotaDoZaplaty;
        private System.Windows.Forms.Label l_nazwaWycieczkiZaplac;
        private System.Windows.Forms.Label l_numerRezerwacji;
        public System.Windows.Forms.TextBox tb_nazwaWycieczkiZaplac;
        public System.Windows.Forms.TextBox tb_kwotaZaplacona;
        public System.Windows.Forms.TextBox tb_kwotaDoZaplaty;
        public System.Windows.Forms.TextBox tb_numerRezerwacji;
        private System.Windows.Forms.Label l_wotaCalkowita;
        public System.Windows.Forms.TextBox tb_kwotaCalkowita;
    }
}