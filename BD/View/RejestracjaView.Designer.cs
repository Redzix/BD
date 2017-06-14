namespace BD.View
{
    partial class RejestracjaView
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
            this.b_anuluj = new System.Windows.Forms.Button();
            this.tb_pesel = new System.Windows.Forms.TextBox();
            this.tb_imie = new System.Windows.Forms.TextBox();
            this.tb_nazwisko = new System.Windows.Forms.TextBox();
            this.tb_adres = new System.Windows.Forms.TextBox();
            this.tb_miejscowosc = new System.Windows.Forms.TextBox();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.tb_haslo = new System.Windows.Forms.TextBox();
            this.tb_powtorzHaslo = new System.Windows.Forms.TextBox();
            this.l_pesel = new System.Windows.Forms.Label();
            this.l_imie = new System.Windows.Forms.Label();
            this.l_nazwisko = new System.Windows.Forms.Label();
            this.l_ulica = new System.Windows.Forms.Label();
            this.l_miejscowosc = new System.Windows.Forms.Label();
            this.l_login = new System.Windows.Forms.Label();
            this.l_haslo = new System.Windows.Forms.Label();
            this.l_powtorzHaslo = new System.Windows.Forms.Label();
            this.b_zarejestruj = new System.Windows.Forms.Button();
            this.tT_haslo = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // b_anuluj
            // 
            this.b_anuluj.Location = new System.Drawing.Point(158, 226);
            this.b_anuluj.Name = "b_anuluj";
            this.b_anuluj.Size = new System.Drawing.Size(75, 23);
            this.b_anuluj.TabIndex = 0;
            this.b_anuluj.Text = "Anuluj";
            this.b_anuluj.UseVisualStyleBackColor = true;
            this.b_anuluj.Click += new System.EventHandler(this.b_anuluj_Click);
            // 
            // tb_pesel
            // 
            this.tb_pesel.Location = new System.Drawing.Point(116, 12);
            this.tb_pesel.Name = "tb_pesel";
            this.tb_pesel.Size = new System.Drawing.Size(117, 20);
            this.tb_pesel.TabIndex = 1;
            // 
            // tb_imie
            // 
            this.tb_imie.Location = new System.Drawing.Point(116, 38);
            this.tb_imie.Name = "tb_imie";
            this.tb_imie.Size = new System.Drawing.Size(117, 20);
            this.tb_imie.TabIndex = 2;
            // 
            // tb_nazwisko
            // 
            this.tb_nazwisko.Location = new System.Drawing.Point(116, 64);
            this.tb_nazwisko.Name = "tb_nazwisko";
            this.tb_nazwisko.Size = new System.Drawing.Size(117, 20);
            this.tb_nazwisko.TabIndex = 3;
            // 
            // tb_adres
            // 
            this.tb_adres.Location = new System.Drawing.Point(116, 90);
            this.tb_adres.Name = "tb_adres";
            this.tb_adres.Size = new System.Drawing.Size(117, 20);
            this.tb_adres.TabIndex = 4;
            // 
            // tb_miejscowosc
            // 
            this.tb_miejscowosc.Location = new System.Drawing.Point(116, 116);
            this.tb_miejscowosc.Name = "tb_miejscowosc";
            this.tb_miejscowosc.Size = new System.Drawing.Size(117, 20);
            this.tb_miejscowosc.TabIndex = 5;
            // 
            // tb_login
            // 
            this.tb_login.Location = new System.Drawing.Point(116, 142);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(117, 20);
            this.tb_login.TabIndex = 6;
            // 
            // tb_haslo
            // 
            this.tb_haslo.Location = new System.Drawing.Point(116, 168);
            this.tb_haslo.Name = "tb_haslo";
            this.tb_haslo.Size = new System.Drawing.Size(117, 20);
            this.tb_haslo.TabIndex = 7;
            this.tT_haslo.SetToolTip(this.tb_haslo, "Pamiętaj, że hasło musi zawierać co najmniej 8 znaków.");
            this.tb_haslo.UseSystemPasswordChar = true;
            // 
            // tb_powtorzHaslo
            // 
            this.tb_powtorzHaslo.Location = new System.Drawing.Point(116, 194);
            this.tb_powtorzHaslo.Name = "tb_powtorzHaslo";
            this.tb_powtorzHaslo.Size = new System.Drawing.Size(117, 20);
            this.tb_powtorzHaslo.TabIndex = 8;
            this.tT_haslo.SetToolTip(this.tb_powtorzHaslo, "Hasła musza być takie same.");
            this.tb_powtorzHaslo.UseSystemPasswordChar = true;
            // 
            // l_pesel
            // 
            this.l_pesel.AutoSize = true;
            this.l_pesel.Location = new System.Drawing.Point(12, 15);
            this.l_pesel.Name = "l_pesel";
            this.l_pesel.Size = new System.Drawing.Size(33, 13);
            this.l_pesel.TabIndex = 9;
            this.l_pesel.Text = "Pesel";
            // 
            // l_imie
            // 
            this.l_imie.AutoSize = true;
            this.l_imie.Location = new System.Drawing.Point(12, 41);
            this.l_imie.Name = "l_imie";
            this.l_imie.Size = new System.Drawing.Size(26, 13);
            this.l_imie.TabIndex = 10;
            this.l_imie.Text = "Imie";
            // 
            // l_nazwisko
            // 
            this.l_nazwisko.AutoSize = true;
            this.l_nazwisko.Location = new System.Drawing.Point(12, 67);
            this.l_nazwisko.Name = "l_nazwisko";
            this.l_nazwisko.Size = new System.Drawing.Size(53, 13);
            this.l_nazwisko.TabIndex = 11;
            this.l_nazwisko.Text = "Nazwisko";
            // 
            // l_ulica
            // 
            this.l_ulica.AutoSize = true;
            this.l_ulica.Location = new System.Drawing.Point(12, 93);
            this.l_ulica.Name = "l_ulica";
            this.l_ulica.Size = new System.Drawing.Size(31, 13);
            this.l_ulica.TabIndex = 12;
            this.l_ulica.Text = "Ulica";
            // 
            // l_miejscowosc
            // 
            this.l_miejscowosc.AutoSize = true;
            this.l_miejscowosc.Location = new System.Drawing.Point(12, 119);
            this.l_miejscowosc.Name = "l_miejscowosc";
            this.l_miejscowosc.Size = new System.Drawing.Size(68, 13);
            this.l_miejscowosc.TabIndex = 13;
            this.l_miejscowosc.Text = "Miejscowosc";
            // 
            // l_login
            // 
            this.l_login.AutoSize = true;
            this.l_login.Location = new System.Drawing.Point(12, 145);
            this.l_login.Name = "l_login";
            this.l_login.Size = new System.Drawing.Size(102, 13);
            this.l_login.TabIndex = 14;
            this.l_login.Text = "Nazwa uzytkownika";
            // 
            // l_haslo
            // 
            this.l_haslo.AutoSize = true;
            this.l_haslo.Location = new System.Drawing.Point(12, 171);
            this.l_haslo.Name = "l_haslo";
            this.l_haslo.Size = new System.Drawing.Size(36, 13);
            this.l_haslo.TabIndex = 15;
            this.l_haslo.Text = "Hasło";
            // 
            // l_powtorzHaslo
            // 
            this.l_powtorzHaslo.AutoSize = true;
            this.l_powtorzHaslo.Location = new System.Drawing.Point(12, 197);
            this.l_powtorzHaslo.Name = "l_powtorzHaslo";
            this.l_powtorzHaslo.Size = new System.Drawing.Size(75, 13);
            this.l_powtorzHaslo.TabIndex = 16;
            this.l_powtorzHaslo.Text = "Powtórz hasło";
            // 
            // b_zarejestruj
            // 
            this.b_zarejestruj.Location = new System.Drawing.Point(15, 226);
            this.b_zarejestruj.Name = "b_zarejestruj";
            this.b_zarejestruj.Size = new System.Drawing.Size(75, 23);
            this.b_zarejestruj.TabIndex = 17;
            this.b_zarejestruj.Text = "Zarejestruj";
            this.b_zarejestruj.UseVisualStyleBackColor = true;
            this.b_zarejestruj.Click += new System.EventHandler(this.b_zarejestruj_Click);
            // 
            // RejestracjaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 261);
            this.Controls.Add(this.b_zarejestruj);
            this.Controls.Add(this.l_powtorzHaslo);
            this.Controls.Add(this.l_haslo);
            this.Controls.Add(this.l_login);
            this.Controls.Add(this.l_miejscowosc);
            this.Controls.Add(this.l_ulica);
            this.Controls.Add(this.l_nazwisko);
            this.Controls.Add(this.l_imie);
            this.Controls.Add(this.l_pesel);
            this.Controls.Add(this.tb_powtorzHaslo);
            this.Controls.Add(this.tb_haslo);
            this.Controls.Add(this.tb_login);
            this.Controls.Add(this.tb_miejscowosc);
            this.Controls.Add(this.tb_adres);
            this.Controls.Add(this.tb_nazwisko);
            this.Controls.Add(this.tb_imie);
            this.Controls.Add(this.tb_pesel);
            this.Controls.Add(this.b_anuluj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RejestracjaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rejestracja klienta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RejestracjaView_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_anuluj;
        public System.Windows.Forms.TextBox tb_pesel;
        public System.Windows.Forms.TextBox tb_imie;
        public System.Windows.Forms.TextBox tb_nazwisko;
        public System.Windows.Forms.TextBox tb_adres;
        public System.Windows.Forms.TextBox tb_miejscowosc;
        public System.Windows.Forms.TextBox tb_login;
        public System.Windows.Forms.TextBox tb_haslo;
        public System.Windows.Forms.TextBox tb_powtorzHaslo;
        private System.Windows.Forms.Label l_pesel;
        private System.Windows.Forms.Label l_imie;
        private System.Windows.Forms.Label l_nazwisko;
        private System.Windows.Forms.Label l_ulica;
        private System.Windows.Forms.Label l_miejscowosc;
        private System.Windows.Forms.Label l_login;
        private System.Windows.Forms.Label l_haslo;
        private System.Windows.Forms.Label l_powtorzHaslo;
        private System.Windows.Forms.Button b_zarejestruj;
        private System.Windows.Forms.ToolTip tT_haslo;
    }
}