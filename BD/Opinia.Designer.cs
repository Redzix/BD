﻿namespace BD
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
            this.l_uwagi = new System.Windows.Forms.Label();
            this.l_nazwa_wycieczki = new System.Windows.Forms.Label();
            this.tb_opinia = new System.Windows.Forms.TextBox();
            this.cb_nazwa_wycieczki = new System.Windows.Forms.ComboBox();
            this.l_ocena = new System.Windows.Forms.Label();
            this.cb_ocena = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // b_zapisz
            // 
            this.b_zapisz.Location = new System.Drawing.Point(103, 243);
            this.b_zapisz.Name = "b_zapisz";
            this.b_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_zapisz.TabIndex = 21;
            this.b_zapisz.Text = "Zapisz";
            this.b_zapisz.UseVisualStyleBackColor = true;
            // 
            // b_anuluj
            // 
            this.b_anuluj.Location = new System.Drawing.Point(288, 243);
            this.b_anuluj.Name = "b_anuluj";
            this.b_anuluj.Size = new System.Drawing.Size(75, 23);
            this.b_anuluj.TabIndex = 20;
            this.b_anuluj.Text = "Anuluj";
            this.b_anuluj.UseVisualStyleBackColor = true;
            // 
            // l_uwagi
            // 
            this.l_uwagi.AutoSize = true;
            this.l_uwagi.Location = new System.Drawing.Point(12, 85);
            this.l_uwagi.Name = "l_uwagi";
            this.l_uwagi.Size = new System.Drawing.Size(37, 13);
            this.l_uwagi.TabIndex = 19;
            this.l_uwagi.Text = "Uwagi";
            // 
            // l_nazwa_wycieczki
            // 
            this.l_nazwa_wycieczki.AutoSize = true;
            this.l_nazwa_wycieczki.Location = new System.Drawing.Point(12, 9);
            this.l_nazwa_wycieczki.Name = "l_nazwa_wycieczki";
            this.l_nazwa_wycieczki.Size = new System.Drawing.Size(89, 13);
            this.l_nazwa_wycieczki.TabIndex = 18;
            this.l_nazwa_wycieczki.Text = "Nazwa wycieczki";
            // 
            // tb_opinia
            // 
            this.tb_opinia.Location = new System.Drawing.Point(107, 85);
            this.tb_opinia.Multiline = true;
            this.tb_opinia.Name = "tb_opinia";
            this.tb_opinia.Size = new System.Drawing.Size(260, 107);
            this.tb_opinia.TabIndex = 12;
            // 
            // cb_nazwa_wycieczki
            // 
            this.cb_nazwa_wycieczki.FormattingEnabled = true;
            this.cb_nazwa_wycieczki.Location = new System.Drawing.Point(107, 6);
            this.cb_nazwa_wycieczki.Name = "cb_nazwa_wycieczki";
            this.cb_nazwa_wycieczki.Size = new System.Drawing.Size(173, 21);
            this.cb_nazwa_wycieczki.TabIndex = 22;
            // 
            // l_ocena
            // 
            this.l_ocena.AutoSize = true;
            this.l_ocena.Location = new System.Drawing.Point(12, 48);
            this.l_ocena.Name = "l_ocena";
            this.l_ocena.Size = new System.Drawing.Size(39, 13);
            this.l_ocena.TabIndex = 23;
            this.l_ocena.Text = "Ocena";
            // 
            // cb_ocena
            // 
            this.cb_ocena.FormattingEnabled = true;
            this.cb_ocena.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cb_ocena.Location = new System.Drawing.Point(107, 45);
            this.cb_ocena.Name = "cb_ocena";
            this.cb_ocena.Size = new System.Drawing.Size(37, 21);
            this.cb_ocena.TabIndex = 24;
            // 
            // Opinia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 272);
            this.Controls.Add(this.cb_ocena);
            this.Controls.Add(this.l_ocena);
            this.Controls.Add(this.cb_nazwa_wycieczki);
            this.Controls.Add(this.b_zapisz);
            this.Controls.Add(this.b_anuluj);
            this.Controls.Add(this.l_uwagi);
            this.Controls.Add(this.l_nazwa_wycieczki);
            this.Controls.Add(this.tb_opinia);
            this.Name = "Opinia";
            this.Text = "Opinia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_zapisz;
        private System.Windows.Forms.Button b_anuluj;
        private System.Windows.Forms.Label l_uwagi;
        private System.Windows.Forms.Label l_nazwa_wycieczki;
        private System.Windows.Forms.TextBox tb_opinia;
        private System.Windows.Forms.ComboBox cb_nazwa_wycieczki;
        private System.Windows.Forms.Label l_ocena;
        private System.Windows.Forms.ComboBox cb_ocena;

    }
}