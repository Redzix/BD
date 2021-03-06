﻿namespace BD.View
{
    partial class ReklamacjaView
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
            this.tc_reklamacje = new System.Windows.Forms.TabControl();
            this.tp_dodaj_reklamacje = new System.Windows.Forms.TabPage();
            this.b_zapisz = new System.Windows.Forms.Button();
            this.b_anuluj = new System.Windows.Forms.Button();
            this.l_opis_reklamacji = new System.Windows.Forms.Label();
            this.l_nazwa_wycieczki = new System.Windows.Forms.Label();
            this.tb_opis_reklamacji = new System.Windows.Forms.TextBox();
            this.tp_stan_reklamacji = new System.Windows.Forms.TabPage();
            this.rtb_reklamacja = new System.Windows.Forms.RichTextBox();
            this.lv_reklamacje = new System.Windows.Forms.ListView();
            this.NumerReklamacji = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cb_rezerwacje = new System.Windows.Forms.ComboBox();
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
            this.tc_reklamacje.Size = new System.Drawing.Size(374, 241);
            this.tc_reklamacje.TabIndex = 12;
            this.tc_reklamacje.SelectedIndexChanged += new System.EventHandler(this.tc_reklamacje_SelectedIndexChanged);
            // 
            // tp_dodaj_reklamacje
            // 
            this.tp_dodaj_reklamacje.Controls.Add(this.cb_rezerwacje);
            this.tp_dodaj_reklamacje.Controls.Add(this.b_zapisz);
            this.tp_dodaj_reklamacje.Controls.Add(this.b_anuluj);
            this.tp_dodaj_reklamacje.Controls.Add(this.l_opis_reklamacji);
            this.tp_dodaj_reklamacje.Controls.Add(this.l_nazwa_wycieczki);
            this.tp_dodaj_reklamacje.Controls.Add(this.tb_opis_reklamacji);
            this.tp_dodaj_reklamacje.Location = new System.Drawing.Point(4, 22);
            this.tp_dodaj_reklamacje.Name = "tp_dodaj_reklamacje";
            this.tp_dodaj_reklamacje.Padding = new System.Windows.Forms.Padding(3);
            this.tp_dodaj_reklamacje.Size = new System.Drawing.Size(366, 215);
            this.tp_dodaj_reklamacje.TabIndex = 0;
            this.tp_dodaj_reklamacje.Text = "Dodaj reklamację";
            this.tp_dodaj_reklamacje.UseVisualStyleBackColor = true;
            // 
            // b_zapisz
            // 
            this.b_zapisz.Enabled = false;
            this.b_zapisz.Location = new System.Drawing.Point(124, 154);
            this.b_zapisz.Name = "b_zapisz";
            this.b_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_zapisz.TabIndex = 17;
            this.b_zapisz.Text = "Zapisz";
            this.b_zapisz.UseVisualStyleBackColor = true;
            this.b_zapisz.Click += new System.EventHandler(this.b_zapisz_Click);
            // 
            // b_anuluj
            // 
            this.b_anuluj.Location = new System.Drawing.Point(281, 154);
            this.b_anuluj.Name = "b_anuluj";
            this.b_anuluj.Size = new System.Drawing.Size(75, 23);
            this.b_anuluj.TabIndex = 16;
            this.b_anuluj.Text = "Anuluj";
            this.b_anuluj.UseVisualStyleBackColor = true;
            this.b_anuluj.Click += new System.EventHandler(this.b_anuluj_Click);
            // 
            // l_opis_reklamacji
            // 
            this.l_opis_reklamacji.AutoSize = true;
            this.l_opis_reklamacji.Location = new System.Drawing.Point(16, 44);
            this.l_opis_reklamacji.Name = "l_opis_reklamacji";
            this.l_opis_reklamacji.Size = new System.Drawing.Size(78, 13);
            this.l_opis_reklamacji.TabIndex = 15;
            this.l_opis_reklamacji.Text = "Opis reklamacji";
            // 
            // l_nazwa_wycieczki
            // 
            this.l_nazwa_wycieczki.AutoSize = true;
            this.l_nazwa_wycieczki.Location = new System.Drawing.Point(5, 17);
            this.l_nazwa_wycieczki.Name = "l_nazwa_wycieczki";
            this.l_nazwa_wycieczki.Size = new System.Drawing.Size(89, 13);
            this.l_nazwa_wycieczki.TabIndex = 14;
            this.l_nazwa_wycieczki.Text = "Nazwa wycieczki";
            // 
            // tb_opis_reklamacji
            // 
            this.tb_opis_reklamacji.Location = new System.Drawing.Point(124, 41);
            this.tb_opis_reklamacji.Multiline = true;
            this.tb_opis_reklamacji.Name = "tb_opis_reklamacji";
            this.tb_opis_reklamacji.Size = new System.Drawing.Size(232, 107);
            this.tb_opis_reklamacji.TabIndex = 12;
            // 
            // tp_stan_reklamacji
            // 
            this.tp_stan_reklamacji.Controls.Add(this.rtb_reklamacja);
            this.tp_stan_reklamacji.Controls.Add(this.lv_reklamacje);
            this.tp_stan_reklamacji.Location = new System.Drawing.Point(4, 22);
            this.tp_stan_reklamacji.Name = "tp_stan_reklamacji";
            this.tp_stan_reklamacji.Padding = new System.Windows.Forms.Padding(3);
            this.tp_stan_reklamacji.Size = new System.Drawing.Size(366, 215);
            this.tp_stan_reklamacji.TabIndex = 1;
            this.tp_stan_reklamacji.Text = "Stan reklamacji";
            this.tp_stan_reklamacji.UseVisualStyleBackColor = true;
            // 
            // rtb_reklamacja
            // 
            this.rtb_reklamacja.Location = new System.Drawing.Point(133, 6);
            this.rtb_reklamacja.Name = "rtb_reklamacja";
            this.rtb_reklamacja.ReadOnly = true;
            this.rtb_reklamacja.Size = new System.Drawing.Size(223, 203);
            this.rtb_reklamacja.TabIndex = 1;
            this.rtb_reklamacja.Text = "Numer reklamacji:\nNazwa wycieczki:\nData wycieczki:\nOpis:\n\n\n\n";
            // 
            // lv_reklamacje
            // 
            this.lv_reklamacje.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NumerReklamacji});
            this.lv_reklamacje.Location = new System.Drawing.Point(6, 6);
            this.lv_reklamacje.Name = "lv_reklamacje";
            this.lv_reklamacje.Size = new System.Drawing.Size(121, 204);
            this.lv_reklamacje.TabIndex = 0;
            this.lv_reklamacje.UseCompatibleStateImageBehavior = false;
            this.lv_reklamacje.View = System.Windows.Forms.View.Details;
            this.lv_reklamacje.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_reklamacje_ColumnClick);
            this.lv_reklamacje.ItemActivate += new System.EventHandler(this.lv_reklamacje_ItemActivate);
            // 
            // NumerReklamacji
            // 
            this.NumerReklamacji.Text = "Numer reklamacji";
            this.NumerReklamacji.Width = 110;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cb_rezerwacje
            // 
            this.cb_rezerwacje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_rezerwacje.FormattingEnabled = true;
            this.cb_rezerwacje.Location = new System.Drawing.Point(124, 14);
            this.cb_rezerwacje.Name = "cb_rezerwacje";
            this.cb_rezerwacje.Size = new System.Drawing.Size(232, 21);
            this.cb_rezerwacje.TabIndex = 18;
            this.cb_rezerwacje.SelectedIndexChanged += new System.EventHandler(this.b_sprawdzPoprawnosc_Click);
            // 
            // ReklamacjaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 256);
            this.Controls.Add(this.tc_reklamacje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReklamacjaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reklamacja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Reklamacja_FormClosing);
            this.tc_reklamacje.ResumeLayout(false);
            this.tp_dodaj_reklamacje.ResumeLayout(false);
            this.tp_dodaj_reklamacje.PerformLayout();
            this.tp_stan_reklamacji.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tc_reklamacje;
        public System.Windows.Forms.TabPage tp_dodaj_reklamacje;
        private System.Windows.Forms.Button b_zapisz;
        private System.Windows.Forms.Button b_anuluj;
        private System.Windows.Forms.Label l_opis_reklamacji;
        private System.Windows.Forms.Label l_nazwa_wycieczki;
        public System.Windows.Forms.TextBox tb_opis_reklamacji;
        public System.Windows.Forms.TabPage tp_stan_reklamacji;
        public System.Windows.Forms.ListView lv_reklamacje;
        public System.Windows.Forms.ColumnHeader NumerReklamacji;
        public System.Windows.Forms.RichTextBox rtb_reklamacja;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ComboBox cb_rezerwacje;
    }
}