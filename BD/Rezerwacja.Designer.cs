namespace BD
{
    partial class Rezerwacja
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
            this.l_nr_rezerwacji = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // tb_imie
            // 
            this.tb_imie.Location = new System.Drawing.Point(76, 31);
            this.tb_imie.Name = "tb_imie";
            this.tb_imie.Size = new System.Drawing.Size(100, 20);
            this.tb_imie.TabIndex = 0;
            // 
            // l_nr_rezerwacji
            // 
            this.l_nr_rezerwacji.AutoSize = true;
            this.l_nr_rezerwacji.Location = new System.Drawing.Point(4, 277);
            this.l_nr_rezerwacji.Name = "l_nr_rezerwacji";
            this.l_nr_rezerwacji.Size = new System.Drawing.Size(91, 13);
            this.l_nr_rezerwacji.TabIndex = 1;
            this.l_nr_rezerwacji.Text = "Numer rezerwacji:";
            // 
            // tb_nazwisko
            // 
            this.tb_nazwisko.Location = new System.Drawing.Point(76, 57);
            this.tb_nazwisko.Name = "tb_nazwisko";
            this.tb_nazwisko.Size = new System.Drawing.Size(100, 20);
            this.tb_nazwisko.TabIndex = 2;
            // 
            // tb_liczba_osob
            // 
            this.tb_liczba_osob.Location = new System.Drawing.Point(76, 147);
            this.tb_liczba_osob.Name = "tb_liczba_osob";
            this.tb_liczba_osob.Size = new System.Drawing.Size(100, 20);
            this.tb_liczba_osob.TabIndex = 3;
            // 
            // tb_zaliczka
            // 
            this.tb_zaliczka.Location = new System.Drawing.Point(76, 173);
            this.tb_zaliczka.Name = "tb_zaliczka";
            this.tb_zaliczka.ReadOnly = true;
            this.tb_zaliczka.Size = new System.Drawing.Size(100, 20);
            this.tb_zaliczka.TabIndex = 4;
            // 
            // tb_adres
            // 
            this.tb_adres.Location = new System.Drawing.Point(76, 83);
            this.tb_adres.Multiline = true;
            this.tb_adres.Name = "tb_adres";
            this.tb_adres.Size = new System.Drawing.Size(100, 58);
            this.tb_adres.TabIndex = 5;
            // 
            // l_imie
            // 
            this.l_imie.AutoSize = true;
            this.l_imie.Location = new System.Drawing.Point(12, 34);
            this.l_imie.Name = "l_imie";
            this.l_imie.Size = new System.Drawing.Size(26, 13);
            this.l_imie.TabIndex = 6;
            this.l_imie.Text = "Imię";
            // 
            // l_nazwisko
            // 
            this.l_nazwisko.AutoSize = true;
            this.l_nazwisko.Location = new System.Drawing.Point(12, 60);
            this.l_nazwisko.Name = "l_nazwisko";
            this.l_nazwisko.Size = new System.Drawing.Size(53, 13);
            this.l_nazwisko.TabIndex = 7;
            this.l_nazwisko.Text = "Nazwisko";
            // 
            // l_adres
            // 
            this.l_adres.AutoSize = true;
            this.l_adres.Location = new System.Drawing.Point(12, 86);
            this.l_adres.Name = "l_adres";
            this.l_adres.Size = new System.Drawing.Size(34, 13);
            this.l_adres.TabIndex = 8;
            this.l_adres.Text = "Adres";
            // 
            // l_liczba_osob
            // 
            this.l_liczba_osob.AutoSize = true;
            this.l_liczba_osob.Location = new System.Drawing.Point(12, 150);
            this.l_liczba_osob.Name = "l_liczba_osob";
            this.l_liczba_osob.Size = new System.Drawing.Size(64, 13);
            this.l_liczba_osob.TabIndex = 9;
            this.l_liczba_osob.Text = "Liczba osób";
            // 
            // l_zaliczka
            // 
            this.l_zaliczka.AutoSize = true;
            this.l_zaliczka.Location = new System.Drawing.Point(12, 176);
            this.l_zaliczka.Name = "l_zaliczka";
            this.l_zaliczka.Size = new System.Drawing.Size(47, 13);
            this.l_zaliczka.TabIndex = 10;
            this.l_zaliczka.Text = "Zaliczka";
            // 
            // b_rezerwacja_zapisz
            // 
            this.b_rezerwacja_zapisz.Location = new System.Drawing.Point(161, 229);
            this.b_rezerwacja_zapisz.Name = "b_rezerwacja_zapisz";
            this.b_rezerwacja_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_rezerwacja_zapisz.TabIndex = 11;
            this.b_rezerwacja_zapisz.Text = "Zapisz";
            this.b_rezerwacja_zapisz.UseVisualStyleBackColor = true;
            // 
            // b_rezerwacja_anuluj
            // 
            this.b_rezerwacja_anuluj.Location = new System.Drawing.Point(12, 229);
            this.b_rezerwacja_anuluj.Name = "b_rezerwacja_anuluj";
            this.b_rezerwacja_anuluj.Size = new System.Drawing.Size(75, 23);
            this.b_rezerwacja_anuluj.TabIndex = 12;
            this.b_rezerwacja_anuluj.Text = "Anuluj";
            this.b_rezerwacja_anuluj.UseVisualStyleBackColor = true;
            // 
            // Rezerwacja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 295);
            this.Controls.Add(this.b_rezerwacja_anuluj);
            this.Controls.Add(this.b_rezerwacja_zapisz);
            this.Controls.Add(this.l_zaliczka);
            this.Controls.Add(this.l_liczba_osob);
            this.Controls.Add(this.l_adres);
            this.Controls.Add(this.l_nazwisko);
            this.Controls.Add(this.l_imie);
            this.Controls.Add(this.tb_adres);
            this.Controls.Add(this.tb_zaliczka);
            this.Controls.Add(this.tb_liczba_osob);
            this.Controls.Add(this.tb_nazwisko);
            this.Controls.Add(this.l_nr_rezerwacji);
            this.Controls.Add(this.tb_imie);
            this.Name = "Rezerwacja";
            this.Text = "Rezerwacja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_imie;
        private System.Windows.Forms.Label l_nr_rezerwacji;
        private System.Windows.Forms.TextBox tb_nazwisko;
        private System.Windows.Forms.TextBox tb_liczba_osob;
        private System.Windows.Forms.TextBox tb_zaliczka;
        private System.Windows.Forms.TextBox tb_adres;
        private System.Windows.Forms.Label l_imie;
        private System.Windows.Forms.Label l_nazwisko;
        private System.Windows.Forms.Label l_adres;
        private System.Windows.Forms.Label l_liczba_osob;
        private System.Windows.Forms.Label l_zaliczka;
        private System.Windows.Forms.Button b_rezerwacja_zapisz;
        private System.Windows.Forms.Button b_rezerwacja_anuluj;
    }
}