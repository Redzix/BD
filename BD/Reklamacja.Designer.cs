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
            this.l_data_odbytej_wycieczki = new System.Windows.Forms.Label();
            this.tb_data_odbytej_wycieczki = new System.Windows.Forms.TextBox();
            this.b_zapisz = new System.Windows.Forms.Button();
            this.b_anuluj = new System.Windows.Forms.Button();
            this.l_opis_reklamacji = new System.Windows.Forms.Label();
            this.l_nazwa_wycieczki = new System.Windows.Forms.Label();
            this.tb_opis_reklamacji = new System.Windows.Forms.TextBox();
            this.tp_stan_reklamacji = new System.Windows.Forms.TabPage();
            this.l_stan_reklamacji = new System.Windows.Forms.Label();
            this.lb_reklamacje = new System.Windows.Forms.ListBox();
            this.cb_nazwa_wycieczki = new System.Windows.Forms.ComboBox();
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
            this.tp_dodaj_reklamacje.Controls.Add(this.cb_nazwa_wycieczki);
            this.tp_dodaj_reklamacje.Controls.Add(this.l_data_odbytej_wycieczki);
            this.tp_dodaj_reklamacje.Controls.Add(this.tb_data_odbytej_wycieczki);
            this.tp_dodaj_reklamacje.Controls.Add(this.b_zapisz);
            this.tp_dodaj_reklamacje.Controls.Add(this.b_anuluj);
            this.tp_dodaj_reklamacje.Controls.Add(this.l_opis_reklamacji);
            this.tp_dodaj_reklamacje.Controls.Add(this.l_nazwa_wycieczki);
            this.tp_dodaj_reklamacje.Controls.Add(this.tb_opis_reklamacji);
            this.tp_dodaj_reklamacje.Location = new System.Drawing.Point(4, 22);
            this.tp_dodaj_reklamacje.Name = "tp_dodaj_reklamacje";
            this.tp_dodaj_reklamacje.Padding = new System.Windows.Forms.Padding(3);
            this.tp_dodaj_reklamacje.Size = new System.Drawing.Size(366, 216);
            this.tp_dodaj_reklamacje.TabIndex = 0;
            this.tp_dodaj_reklamacje.Text = "Dodaj reklamację";
            this.tp_dodaj_reklamacje.UseVisualStyleBackColor = true;
            // 
            // l_data_odbytej_wycieczki
            // 
            this.l_data_odbytej_wycieczki.AutoSize = true;
            this.l_data_odbytej_wycieczki.Location = new System.Drawing.Point(6, 38);
            this.l_data_odbytej_wycieczki.Name = "l_data_odbytej_wycieczki";
            this.l_data_odbytej_wycieczki.Size = new System.Drawing.Size(116, 13);
            this.l_data_odbytej_wycieczki.TabIndex = 19;
            this.l_data_odbytej_wycieczki.Text = "Data odbytej wycieczki";
            // 
            // tb_data_odbytej_wycieczki
            // 
            this.tb_data_odbytej_wycieczki.Location = new System.Drawing.Point(125, 35);
            this.tb_data_odbytej_wycieczki.Name = "tb_data_odbytej_wycieczki";
            this.tb_data_odbytej_wycieczki.Size = new System.Drawing.Size(121, 20);
            this.tb_data_odbytej_wycieczki.TabIndex = 18;
            // 
            // b_zapisz
            // 
            this.b_zapisz.Location = new System.Drawing.Point(125, 185);
            this.b_zapisz.Name = "b_zapisz";
            this.b_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_zapisz.TabIndex = 17;
            this.b_zapisz.Text = "Zapisz";
            this.b_zapisz.UseVisualStyleBackColor = true;
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
            // l_opis_reklamacji
            // 
            this.l_opis_reklamacji.AutoSize = true;
            this.l_opis_reklamacji.Location = new System.Drawing.Point(17, 64);
            this.l_opis_reklamacji.Name = "l_opis_reklamacji";
            this.l_opis_reklamacji.Size = new System.Drawing.Size(78, 13);
            this.l_opis_reklamacji.TabIndex = 15;
            this.l_opis_reklamacji.Text = "Opis reklamacji";
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
            // tb_opis_reklamacji
            // 
            this.tb_opis_reklamacji.Location = new System.Drawing.Point(125, 61);
            this.tb_opis_reklamacji.Multiline = true;
            this.tb_opis_reklamacji.Name = "tb_opis_reklamacji";
            this.tb_opis_reklamacji.Size = new System.Drawing.Size(232, 107);
            this.tb_opis_reklamacji.TabIndex = 12;
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
            // l_stan_reklamacji
            // 
            this.l_stan_reklamacji.AutoSize = true;
            this.l_stan_reklamacji.Location = new System.Drawing.Point(132, 19);
            this.l_stan_reklamacji.Name = "l_stan_reklamacji";
            this.l_stan_reklamacji.Size = new System.Drawing.Size(91, 13);
            this.l_stan_reklamacji.TabIndex = 1;
            this.l_stan_reklamacji.Text = "Stan reklamacji ...";
            // 
            // lb_reklamacje
            // 
            this.lb_reklamacje.FormattingEnabled = true;
            this.lb_reklamacje.Location = new System.Drawing.Point(6, 6);
            this.lb_reklamacje.Name = "lb_reklamacje";
            this.lb_reklamacje.Size = new System.Drawing.Size(120, 199);
            this.lb_reklamacje.TabIndex = 0;
            // 
            // cb_nazwa_wycieczki
            // 
            this.cb_nazwa_wycieczki.FormattingEnabled = true;
            this.cb_nazwa_wycieczki.Location = new System.Drawing.Point(125, 8);
            this.cb_nazwa_wycieczki.Name = "cb_nazwa_wycieczki";
            this.cb_nazwa_wycieczki.Size = new System.Drawing.Size(121, 21);
            this.cb_nazwa_wycieczki.TabIndex = 20;
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
        private System.Windows.Forms.Label l_data_odbytej_wycieczki;
        private System.Windows.Forms.TextBox tb_data_odbytej_wycieczki;
        private System.Windows.Forms.Button b_zapisz;
        private System.Windows.Forms.Button b_anuluj;
        private System.Windows.Forms.Label l_opis_reklamacji;
        private System.Windows.Forms.Label l_nazwa_wycieczki;
        private System.Windows.Forms.TextBox tb_opis_reklamacji;
        private System.Windows.Forms.TabPage tp_stan_reklamacji;
        private System.Windows.Forms.Label l_stan_reklamacji;
        private System.Windows.Forms.ListBox lb_reklamacje;
        private System.Windows.Forms.ComboBox cb_nazwa_wycieczki;

    }
}