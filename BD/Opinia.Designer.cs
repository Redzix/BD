namespace BD
{
    partial class Opinia
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
            this.b_zapisz = new System.Windows.Forms.Button();
            this.b_anuluj = new System.Windows.Forms.Button();
            this.l_opinia = new System.Windows.Forms.Label();
            this.l_nazwa_wycieczki = new System.Windows.Forms.Label();
            this.l_nazwisko = new System.Windows.Forms.Label();
            this.l_imie = new System.Windows.Forms.Label();
            this.tb_nazwa_wycieczki = new System.Windows.Forms.TextBox();
            this.tb_nazwisko = new System.Windows.Forms.TextBox();
            this.tb_imie = new System.Windows.Forms.TextBox();
            this.tb_opinia = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b_zapisz
            // 
            this.b_zapisz.Location = new System.Drawing.Point(188, 209);
            this.b_zapisz.Name = "b_zapisz";
            this.b_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_zapisz.TabIndex = 21;
            this.b_zapisz.Text = "Zapisz";
            this.b_zapisz.UseVisualStyleBackColor = true;
            // 
            // b_anuluj
            // 
            this.b_anuluj.Location = new System.Drawing.Point(361, 209);
            this.b_anuluj.Name = "b_anuluj";
            this.b_anuluj.Size = new System.Drawing.Size(75, 23);
            this.b_anuluj.TabIndex = 20;
            this.b_anuluj.Text = "Anuluj";
            this.b_anuluj.UseVisualStyleBackColor = true;
            // 
            // l_opinia
            // 
            this.l_opinia.AutoSize = true;
            this.l_opinia.Location = new System.Drawing.Point(12, 87);
            this.l_opinia.Name = "l_opinia";
            this.l_opinia.Size = new System.Drawing.Size(37, 13);
            this.l_opinia.TabIndex = 19;
            this.l_opinia.Text = "Opinia";
            // 
            // l_nazwa_wycieczki
            // 
            this.l_nazwa_wycieczki.AutoSize = true;
            this.l_nazwa_wycieczki.Location = new System.Drawing.Point(12, 61);
            this.l_nazwa_wycieczki.Name = "l_nazwa_wycieczki";
            this.l_nazwa_wycieczki.Size = new System.Drawing.Size(89, 13);
            this.l_nazwa_wycieczki.TabIndex = 18;
            this.l_nazwa_wycieczki.Text = "Nazwa wycieczki";
            // 
            // l_nazwisko
            // 
            this.l_nazwisko.AutoSize = true;
            this.l_nazwisko.Location = new System.Drawing.Point(12, 35);
            this.l_nazwisko.Name = "l_nazwisko";
            this.l_nazwisko.Size = new System.Drawing.Size(53, 13);
            this.l_nazwisko.TabIndex = 17;
            this.l_nazwisko.Text = "Nazwisko";
            // 
            // l_imie
            // 
            this.l_imie.AutoSize = true;
            this.l_imie.Location = new System.Drawing.Point(12, 9);
            this.l_imie.Name = "l_imie";
            this.l_imie.Size = new System.Drawing.Size(26, 13);
            this.l_imie.TabIndex = 16;
            this.l_imie.Text = "Imię";
            // 
            // tb_nazwa_wycieczki
            // 
            this.tb_nazwa_wycieczki.Location = new System.Drawing.Point(103, 58);
            this.tb_nazwa_wycieczki.Name = "tb_nazwa_wycieczki";
            this.tb_nazwa_wycieczki.Size = new System.Drawing.Size(118, 20);
            this.tb_nazwa_wycieczki.TabIndex = 15;
            // 
            // tb_nazwisko
            // 
            this.tb_nazwisko.Location = new System.Drawing.Point(103, 32);
            this.tb_nazwisko.Name = "tb_nazwisko";
            this.tb_nazwisko.Size = new System.Drawing.Size(118, 20);
            this.tb_nazwisko.TabIndex = 14;
            // 
            // tb_imie
            // 
            this.tb_imie.Location = new System.Drawing.Point(103, 6);
            this.tb_imie.Name = "tb_imie";
            this.tb_imie.Size = new System.Drawing.Size(118, 20);
            this.tb_imie.TabIndex = 13;
            // 
            // tb_opinia
            // 
            this.tb_opinia.Location = new System.Drawing.Point(103, 84);
            this.tb_opinia.Multiline = true;
            this.tb_opinia.Name = "tb_opinia";
            this.tb_opinia.Size = new System.Drawing.Size(260, 107);
            this.tb_opinia.TabIndex = 12;
            // 
            // Opinia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 239);
            this.Controls.Add(this.b_zapisz);
            this.Controls.Add(this.b_anuluj);
            this.Controls.Add(this.l_opinia);
            this.Controls.Add(this.l_nazwa_wycieczki);
            this.Controls.Add(this.l_nazwisko);
            this.Controls.Add(this.l_imie);
            this.Controls.Add(this.tb_nazwa_wycieczki);
            this.Controls.Add(this.tb_nazwisko);
            this.Controls.Add(this.tb_imie);
            this.Controls.Add(this.tb_opinia);
            this.Name = "Opinia";
            this.Text = "Opinia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_zapisz;
        private System.Windows.Forms.Button b_anuluj;
        private System.Windows.Forms.Label l_opinia;
        private System.Windows.Forms.Label l_nazwa_wycieczki;
        private System.Windows.Forms.Label l_nazwisko;
        private System.Windows.Forms.Label l_imie;
        private System.Windows.Forms.TextBox tb_nazwa_wycieczki;
        private System.Windows.Forms.TextBox tb_nazwisko;
        private System.Windows.Forms.TextBox tb_imie;
        private System.Windows.Forms.TextBox tb_opinia;

    }
}