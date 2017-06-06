namespace BD.View
{
    partial class RezygnacjaView
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
            this.tb_numerRezerwacji = new System.Windows.Forms.TextBox();
            this.tb_nazwaWycieczki = new System.Windows.Forms.TextBox();
            this.tb_liczbaOsob = new System.Windows.Forms.TextBox();
            this.tb_liczbaRezygnujacychOsob = new System.Windows.Forms.TextBox();
            this.tb_cenaPoRezygnacji = new System.Windows.Forms.TextBox();
            this.l_numerRezerwacji = new System.Windows.Forms.Label();
            this.l_nazwaWycieczki = new System.Windows.Forms.Label();
            this.l_liczbaOsob = new System.Windows.Forms.Label();
            this.l_liczbaRezygnującychOsob = new System.Windows.Forms.Label();
            this.l_cenaPoRezygnacji = new System.Windows.Forms.Label();
            this.b_oblicz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_zapisz
            // 
            this.b_zapisz.Location = new System.Drawing.Point(122, 156);
            this.b_zapisz.Name = "b_zapisz";
            this.b_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_zapisz.TabIndex = 21;
            this.b_zapisz.Text = "Zapisz";
            this.b_zapisz.UseVisualStyleBackColor = true;
            this.b_zapisz.Click += new System.EventHandler(this.b_zapisz_Click);
            // 
            // b_anuluj
            // 
            this.b_anuluj.Location = new System.Drawing.Point(203, 156);
            this.b_anuluj.Name = "b_anuluj";
            this.b_anuluj.Size = new System.Drawing.Size(75, 23);
            this.b_anuluj.TabIndex = 20;
            this.b_anuluj.Text = "Anuluj";
            this.b_anuluj.UseVisualStyleBackColor = true;
            this.b_anuluj.Click += new System.EventHandler(this.b_anuluj_Click);
            // 
            // tb_numerRezerwacji
            // 
            this.tb_numerRezerwacji.Location = new System.Drawing.Point(158, 12);
            this.tb_numerRezerwacji.Name = "tb_numerRezerwacji";
            this.tb_numerRezerwacji.Size = new System.Drawing.Size(120, 20);
            this.tb_numerRezerwacji.TabIndex = 22;
            // 
            // tb_nazwaWycieczki
            // 
            this.tb_nazwaWycieczki.Enabled = false;
            this.tb_nazwaWycieczki.Location = new System.Drawing.Point(158, 38);
            this.tb_nazwaWycieczki.Name = "tb_nazwaWycieczki";
            this.tb_nazwaWycieczki.Size = new System.Drawing.Size(120, 20);
            this.tb_nazwaWycieczki.TabIndex = 23;
            // 
            // tb_liczbaOsob
            // 
            this.tb_liczbaOsob.Enabled = false;
            this.tb_liczbaOsob.Location = new System.Drawing.Point(158, 64);
            this.tb_liczbaOsob.Name = "tb_liczbaOsob";
            this.tb_liczbaOsob.Size = new System.Drawing.Size(120, 20);
            this.tb_liczbaOsob.TabIndex = 24;
            // 
            // tb_liczbaRezygnujacychOsob
            // 
            this.tb_liczbaRezygnujacychOsob.Location = new System.Drawing.Point(158, 90);
            this.tb_liczbaRezygnujacychOsob.Name = "tb_liczbaRezygnujacychOsob";
            this.tb_liczbaRezygnujacychOsob.Size = new System.Drawing.Size(120, 20);
            this.tb_liczbaRezygnujacychOsob.TabIndex = 25;
            // 
            // tb_cenaPoRezygnacji
            // 
            this.tb_cenaPoRezygnacji.Enabled = false;
            this.tb_cenaPoRezygnacji.Location = new System.Drawing.Point(158, 116);
            this.tb_cenaPoRezygnacji.Name = "tb_cenaPoRezygnacji";
            this.tb_cenaPoRezygnacji.Size = new System.Drawing.Size(120, 20);
            this.tb_cenaPoRezygnacji.TabIndex = 26;
            // 
            // l_numerRezerwacji
            // 
            this.l_numerRezerwacji.AutoSize = true;
            this.l_numerRezerwacji.Location = new System.Drawing.Point(12, 15);
            this.l_numerRezerwacji.Name = "l_numerRezerwacji";
            this.l_numerRezerwacji.Size = new System.Drawing.Size(88, 13);
            this.l_numerRezerwacji.TabIndex = 27;
            this.l_numerRezerwacji.Text = "Numer rezerwacji";
            // 
            // l_nazwaWycieczki
            // 
            this.l_nazwaWycieczki.AutoSize = true;
            this.l_nazwaWycieczki.Location = new System.Drawing.Point(12, 41);
            this.l_nazwaWycieczki.Name = "l_nazwaWycieczki";
            this.l_nazwaWycieczki.Size = new System.Drawing.Size(89, 13);
            this.l_nazwaWycieczki.TabIndex = 28;
            this.l_nazwaWycieczki.Text = "Nazwa wycieczki";
            // 
            // l_liczbaOsob
            // 
            this.l_liczbaOsob.AutoSize = true;
            this.l_liczbaOsob.Location = new System.Drawing.Point(12, 67);
            this.l_liczbaOsob.Name = "l_liczbaOsob";
            this.l_liczbaOsob.Size = new System.Drawing.Size(64, 13);
            this.l_liczbaOsob.TabIndex = 29;
            this.l_liczbaOsob.Text = "Liczba osób";
            // 
            // l_liczbaRezygnującychOsob
            // 
            this.l_liczbaRezygnującychOsob.AutoSize = true;
            this.l_liczbaRezygnującychOsob.Location = new System.Drawing.Point(12, 93);
            this.l_liczbaRezygnującychOsob.Name = "l_liczbaRezygnującychOsob";
            this.l_liczbaRezygnującychOsob.Size = new System.Drawing.Size(135, 13);
            this.l_liczbaRezygnującychOsob.TabIndex = 30;
            this.l_liczbaRezygnującychOsob.Text = "Liczba rezygnujących osób";
            // 
            // l_cenaPoRezygnacji
            // 
            this.l_cenaPoRezygnacji.AutoSize = true;
            this.l_cenaPoRezygnacji.Location = new System.Drawing.Point(12, 119);
            this.l_cenaPoRezygnacji.Name = "l_cenaPoRezygnacji";
            this.l_cenaPoRezygnacji.Size = new System.Drawing.Size(97, 13);
            this.l_cenaPoRezygnacji.TabIndex = 31;
            this.l_cenaPoRezygnacji.Text = "Cena po rezygnacji";
            // 
            // b_oblicz
            // 
            this.b_oblicz.Location = new System.Drawing.Point(31, 156);
            this.b_oblicz.Name = "b_oblicz";
            this.b_oblicz.Size = new System.Drawing.Size(85, 23);
            this.b_oblicz.TabIndex = 32;
            this.b_oblicz.Text = "Oblicz";
            this.b_oblicz.UseVisualStyleBackColor = true;
            this.b_oblicz.Click += new System.EventHandler(this.b_pobierz_Click);
            // 
            // RezygnacjaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 243);
            this.Controls.Add(this.b_oblicz);
            this.Controls.Add(this.l_cenaPoRezygnacji);
            this.Controls.Add(this.l_liczbaRezygnującychOsob);
            this.Controls.Add(this.l_liczbaOsob);
            this.Controls.Add(this.l_nazwaWycieczki);
            this.Controls.Add(this.l_numerRezerwacji);
            this.Controls.Add(this.tb_cenaPoRezygnacji);
            this.Controls.Add(this.tb_liczbaRezygnujacychOsob);
            this.Controls.Add(this.tb_liczbaOsob);
            this.Controls.Add(this.tb_nazwaWycieczki);
            this.Controls.Add(this.tb_numerRezerwacji);
            this.Controls.Add(this.b_anuluj);
            this.Controls.Add(this.b_zapisz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RezygnacjaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rezygnacja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Rezygnacja_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_zapisz;
        private System.Windows.Forms.Button b_anuluj;
        private System.Windows.Forms.TextBox tb_numerRezerwacji;
        private System.Windows.Forms.TextBox tb_nazwaWycieczki;
        private System.Windows.Forms.TextBox tb_liczbaOsob;
        private System.Windows.Forms.TextBox tb_liczbaRezygnujacychOsob;
        private System.Windows.Forms.TextBox tb_cenaPoRezygnacji;
        private System.Windows.Forms.Label l_numerRezerwacji;
        private System.Windows.Forms.Label l_nazwaWycieczki;
        private System.Windows.Forms.Label l_liczbaOsob;
        private System.Windows.Forms.Label l_liczbaRezygnującychOsob;
        private System.Windows.Forms.Label l_cenaPoRezygnacji;
        private System.Windows.Forms.Button b_oblicz;
    }
}