namespace BD
{
    partial class Reklamacja
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
            this.tc_reklamacje = new System.Windows.Forms.TabControl();
            this.tp_dodaj_reklamacje = new System.Windows.Forms.TabPage();
            this.tp_stan_reklamacji = new System.Windows.Forms.TabPage();
            this.tb_opis_reklamacji = new System.Windows.Forms.TextBox();
            this.tb_nazwa_wycieczki = new System.Windows.Forms.TextBox();
            this.l_nazwa_wycieczki = new System.Windows.Forms.Label();
            this.l_opis_reklamacji = new System.Windows.Forms.Label();
            this.b_anuluj = new System.Windows.Forms.Button();
            this.b_zapisz = new System.Windows.Forms.Button();
            this.tb_okres_wycieczki = new System.Windows.Forms.TextBox();
            this.l_okres_wycieczki = new System.Windows.Forms.Label();
            this.lb_reklamacje = new System.Windows.Forms.ListBox();
            this.l_stan_reklamacji = new System.Windows.Forms.Label();
            this.tc_reklamacje.SuspendLayout();
            this.tp_dodaj_reklamacje.SuspendLayout();
            this.tp_stan_reklamacji.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_reklamacje
            // 
            this.tc_reklamacje.Controls.Add(this.tp_dodaj_reklamacje);
            this.tc_reklamacje.Controls.Add(this.tp_stan_reklamacji);
            this.tc_reklamacje.Location = new System.Drawing.Point(3, 12);
            this.tc_reklamacje.Name = "tc_reklamacje";
            this.tc_reklamacje.SelectedIndex = 0;
            this.tc_reklamacje.Size = new System.Drawing.Size(374, 242);
            this.tc_reklamacje.TabIndex = 12;
            // 
            // tp_dodaj_reklamacje
            // 
            this.tp_dodaj_reklamacje.Controls.Add(this.l_okres_wycieczki);
            this.tp_dodaj_reklamacje.Controls.Add(this.tb_okres_wycieczki);
            this.tp_dodaj_reklamacje.Controls.Add(this.b_zapisz);
            this.tp_dodaj_reklamacje.Controls.Add(this.b_anuluj);
            this.tp_dodaj_reklamacje.Controls.Add(this.l_opis_reklamacji);
            this.tp_dodaj_reklamacje.Controls.Add(this.l_nazwa_wycieczki);
            this.tp_dodaj_reklamacje.Controls.Add(this.tb_nazwa_wycieczki);
            this.tp_dodaj_reklamacje.Controls.Add(this.tb_opis_reklamacji);
            this.tp_dodaj_reklamacje.Location = new System.Drawing.Point(4, 22);
            this.tp_dodaj_reklamacje.Name = "tp_dodaj_reklamacje";
            this.tp_dodaj_reklamacje.Padding = new System.Windows.Forms.Padding(3);
            this.tp_dodaj_reklamacje.Size = new System.Drawing.Size(366, 216);
            this.tp_dodaj_reklamacje.TabIndex = 0;
            this.tp_dodaj_reklamacje.Text = "Dodaj reklamację";
            this.tp_dodaj_reklamacje.UseVisualStyleBackColor = true;
            // 
            // tp_stan_reklamacji
            // 
            this.tp_stan_reklamacji.Controls.Add(this.l_stan_reklamacji);
            this.tp_stan_reklamacji.Controls.Add(this.lb_reklamacje);
            this.tp_stan_reklamacji.Location = new System.Drawing.Point(4, 22);
            this.tp_stan_reklamacji.Name = "tp_stan_reklamacji";
            this.tp_stan_reklamacji.Padding = new System.Windows.Forms.Padding(3);
            this.tp_stan_reklamacji.Size = new System.Drawing.Size(366, 216);
            this.tp_stan_reklamacji.TabIndex = 1;
            this.tp_stan_reklamacji.Text = "Stan reklamacji";
            this.tp_stan_reklamacji.UseVisualStyleBackColor = true;
            // 
            // tb_opis_reklamacji
            // 
            this.tb_opis_reklamacji.Location = new System.Drawing.Point(97, 61);
            this.tb_opis_reklamacji.Multiline = true;
            this.tb_opis_reklamacji.Name = "tb_opis_reklamacji";
            this.tb_opis_reklamacji.Size = new System.Drawing.Size(260, 107);
            this.tb_opis_reklamacji.TabIndex = 12;
            // 
            // tb_nazwa_wycieczki
            // 
            this.tb_nazwa_wycieczki.Location = new System.Drawing.Point(97, 9);
            this.tb_nazwa_wycieczki.Name = "tb_nazwa_wycieczki";
            this.tb_nazwa_wycieczki.Size = new System.Drawing.Size(118, 20);
            this.tb_nazwa_wycieczki.TabIndex = 13;
            // 
            // l_nazwa_wycieczki
            // 
            this.l_nazwa_wycieczki.AutoSize = true;
            this.l_nazwa_wycieczki.Location = new System.Drawing.Point(6, 12);
            this.l_nazwa_wycieczki.Name = "l_nazwa_wycieczki";
            this.l_nazwa_wycieczki.Size = new System.Drawing.Size(89, 13);
            this.l_nazwa_wycieczki.TabIndex = 14;
            this.l_nazwa_wycieczki.Text = "Nazwa wycieczki";
            // 
            // l_opis_reklamacji
            // 
            this.l_opis_reklamacji.AutoSize = true;
            this.l_opis_reklamacji.Location = new System.Drawing.Point(6, 64);
            this.l_opis_reklamacji.Name = "l_opis_reklamacji";
            this.l_opis_reklamacji.Size = new System.Drawing.Size(78, 13);
            this.l_opis_reklamacji.TabIndex = 15;
            this.l_opis_reklamacji.Text = "Opis reklamacji";
            // 
            // b_anuluj
            // 
            this.b_anuluj.Location = new System.Drawing.Point(282, 185);
            this.b_anuluj.Name = "b_anuluj";
            this.b_anuluj.Size = new System.Drawing.Size(75, 23);
            this.b_anuluj.TabIndex = 16;
            this.b_anuluj.Text = "Anuluj";
            this.b_anuluj.UseVisualStyleBackColor = true;
            // 
            // b_zapisz
            // 
            this.b_zapisz.Location = new System.Drawing.Point(97, 185);
            this.b_zapisz.Name = "b_zapisz";
            this.b_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_zapisz.TabIndex = 17;
            this.b_zapisz.Text = "Zapisz";
            this.b_zapisz.UseVisualStyleBackColor = true;
            // 
            // tb_okres_wycieczki
            // 
            this.tb_okres_wycieczki.Location = new System.Drawing.Point(97, 35);
            this.tb_okres_wycieczki.Name = "tb_okres_wycieczki";
            this.tb_okres_wycieczki.Size = new System.Drawing.Size(118, 20);
            this.tb_okres_wycieczki.TabIndex = 18;
            // 
            // l_okres_wycieczki
            // 
            this.l_okres_wycieczki.AutoSize = true;
            this.l_okres_wycieczki.Location = new System.Drawing.Point(6, 38);
            this.l_okres_wycieczki.Name = "l_okres_wycieczki";
            this.l_okres_wycieczki.Size = new System.Drawing.Size(84, 13);
            this.l_okres_wycieczki.TabIndex = 19;
            this.l_okres_wycieczki.Text = "Okres wycieczki";
            // 
            // lb_reklamacje
            // 
            this.lb_reklamacje.FormattingEnabled = true;
            this.lb_reklamacje.Location = new System.Drawing.Point(6, 6);
            this.lb_reklamacje.Name = "lb_reklamacje";
            this.lb_reklamacje.Size = new System.Drawing.Size(120, 199);
            this.lb_reklamacje.TabIndex = 0;
            // 
            // l_stan_reklamacji
            // 
            this.l_stan_reklamacji.AutoSize = true;
            this.l_stan_reklamacji.Location = new System.Drawing.Point(132, 19);
            this.l_stan_reklamacji.Name = "l_stan_reklamacji";
            this.l_stan_reklamacji.Size = new System.Drawing.Size(91, 13);
            this.l_stan_reklamacji.TabIndex = 1;
            this.l_stan_reklamacji.Text = "Stan reklamacji ...";
            // 
            // Reklamacja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 262);
            this.Controls.Add(this.tc_reklamacje);
            this.Name = "Reklamacja";
            this.Text = "Reklamacja";
            this.tc_reklamacje.ResumeLayout(false);
            this.tp_dodaj_reklamacje.ResumeLayout(false);
            this.tp_dodaj_reklamacje.PerformLayout();
            this.tp_stan_reklamacji.ResumeLayout(false);
            this.tp_stan_reklamacji.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_reklamacje;
        private System.Windows.Forms.TabPage tp_dodaj_reklamacje;
        private System.Windows.Forms.Label l_okres_wycieczki;
        private System.Windows.Forms.TextBox tb_okres_wycieczki;
        private System.Windows.Forms.Button b_zapisz;
        private System.Windows.Forms.Button b_anuluj;
        private System.Windows.Forms.Label l_opis_reklamacji;
        private System.Windows.Forms.Label l_nazwa_wycieczki;
        private System.Windows.Forms.TextBox tb_nazwa_wycieczki;
        private System.Windows.Forms.TextBox tb_opis_reklamacji;
        private System.Windows.Forms.TabPage tp_stan_reklamacji;
        private System.Windows.Forms.Label l_stan_reklamacji;
        private System.Windows.Forms.ListBox lb_reklamacje;

    }
}