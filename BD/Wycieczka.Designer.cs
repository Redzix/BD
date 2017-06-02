namespace BD
{
    partial class Wycieczka
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
            this.l_nazwa = new System.Windows.Forms.Label();
            this.l_data_wyjazdu = new System.Windows.Forms.Label();
            this.l_data_powrotu = new System.Windows.Forms.Label();
            this.l_opis = new System.Windows.Forms.Label();
            this.l_cena = new System.Windows.Forms.Label();
            this.tb_nazwa = new System.Windows.Forms.TextBox();
            this.tb_data_przyjazdu = new System.Windows.Forms.TextBox();
            this.tb_data_odjazdu = new System.Windows.Forms.TextBox();
            this.tb_opis = new System.Windows.Forms.TextBox();
            this.tb_cena = new System.Windows.Forms.TextBox();
            this.b_zapisz = new System.Windows.Forms.Button();
            this.b_anuluj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_odjazd = new System.Windows.Forms.ComboBox();
            this.cb_docelowa = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // l_nazwa
            // 
            this.l_nazwa.AutoSize = true;
            this.l_nazwa.Location = new System.Drawing.Point(12, 9);
            this.l_nazwa.Name = "l_nazwa";
            this.l_nazwa.Size = new System.Drawing.Size(40, 13);
            this.l_nazwa.TabIndex = 0;
            this.l_nazwa.Text = "Nazwa";
            // 
            // l_data_wyjazdu
            // 
            this.l_data_wyjazdu.AutoSize = true;
            this.l_data_wyjazdu.Location = new System.Drawing.Point(11, 35);
            this.l_data_wyjazdu.Name = "l_data_wyjazdu";
            this.l_data_wyjazdu.Size = new System.Drawing.Size(71, 13);
            this.l_data_wyjazdu.TabIndex = 1;
            this.l_data_wyjazdu.Text = "Data wyjazdu";
            // 
            // l_data_powrotu
            // 
            this.l_data_powrotu.AutoSize = true;
            this.l_data_powrotu.Location = new System.Drawing.Point(11, 61);
            this.l_data_powrotu.Name = "l_data_powrotu";
            this.l_data_powrotu.Size = new System.Drawing.Size(71, 13);
            this.l_data_powrotu.TabIndex = 2;
            this.l_data_powrotu.Text = "Data powrotu";
            // 
            // l_opis
            // 
            this.l_opis.AutoSize = true;
            this.l_opis.Location = new System.Drawing.Point(92, 142);
            this.l_opis.Name = "l_opis";
            this.l_opis.Size = new System.Drawing.Size(28, 13);
            this.l_opis.TabIndex = 3;
            this.l_opis.Text = "Opis";
            // 
            // l_cena
            // 
            this.l_cena.AutoSize = true;
            this.l_cena.Location = new System.Drawing.Point(92, 221);
            this.l_cena.Name = "l_cena";
            this.l_cena.Size = new System.Drawing.Size(32, 13);
            this.l_cena.TabIndex = 4;
            this.l_cena.Text = "Cena";
            // 
            // tb_nazwa
            // 
            this.tb_nazwa.Location = new System.Drawing.Point(136, 9);
            this.tb_nazwa.Name = "tb_nazwa";
            this.tb_nazwa.Size = new System.Drawing.Size(159, 20);
            this.tb_nazwa.TabIndex = 5;
            // 
            // tb_data_przyjazdu
            // 
            this.tb_data_przyjazdu.Location = new System.Drawing.Point(136, 35);
            this.tb_data_przyjazdu.Name = "tb_data_przyjazdu";
            this.tb_data_przyjazdu.Size = new System.Drawing.Size(159, 20);
            this.tb_data_przyjazdu.TabIndex = 6;
            // 
            // tb_data_odjazdu
            // 
            this.tb_data_odjazdu.Location = new System.Drawing.Point(136, 61);
            this.tb_data_odjazdu.Name = "tb_data_odjazdu";
            this.tb_data_odjazdu.Size = new System.Drawing.Size(159, 20);
            this.tb_data_odjazdu.TabIndex = 7;
            // 
            // tb_opis
            // 
            this.tb_opis.Location = new System.Drawing.Point(136, 139);
            this.tb_opis.Multiline = true;
            this.tb_opis.Name = "tb_opis";
            this.tb_opis.Size = new System.Drawing.Size(159, 73);
            this.tb_opis.TabIndex = 8;
            // 
            // tb_cena
            // 
            this.tb_cena.Location = new System.Drawing.Point(136, 218);
            this.tb_cena.Name = "tb_cena";
            this.tb_cena.Size = new System.Drawing.Size(100, 20);
            this.tb_cena.TabIndex = 9;
            // 
            // b_zapisz
            // 
            this.b_zapisz.Location = new System.Drawing.Point(136, 262);
            this.b_zapisz.Name = "b_zapisz";
            this.b_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_zapisz.TabIndex = 10;
            this.b_zapisz.Text = "Zapisz";
            this.b_zapisz.UseVisualStyleBackColor = true;
            // 
            // b_anuluj
            // 
            this.b_anuluj.Location = new System.Drawing.Point(219, 262);
            this.b_anuluj.Name = "b_anuluj";
            this.b_anuluj.Size = new System.Drawing.Size(75, 23);
            this.b_anuluj.TabIndex = 11;
            this.b_anuluj.Text = "Anuluj";
            this.b_anuluj.UseVisualStyleBackColor = true;
            this.b_anuluj.Click += new System.EventHandler(this.b_anuluj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Miejscowość wyjazdu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Miejscowość docelowa";
            // 
            // cb_odjazd
            // 
            this.cb_odjazd.FormattingEnabled = true;
            this.cb_odjazd.Location = new System.Drawing.Point(136, 87);
            this.cb_odjazd.Name = "cb_odjazd";
            this.cb_odjazd.Size = new System.Drawing.Size(158, 21);
            this.cb_odjazd.TabIndex = 15;
            // 
            // cb_docelowa
            // 
            this.cb_docelowa.FormattingEnabled = true;
            this.cb_docelowa.Location = new System.Drawing.Point(137, 114);
            this.cb_docelowa.Name = "cb_docelowa";
            this.cb_docelowa.Size = new System.Drawing.Size(158, 21);
            this.cb_docelowa.TabIndex = 16;
            // 
            // Wycieczka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 302);
            this.Controls.Add(this.cb_docelowa);
            this.Controls.Add(this.cb_odjazd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_anuluj);
            this.Controls.Add(this.b_zapisz);
            this.Controls.Add(this.tb_cena);
            this.Controls.Add(this.tb_opis);
            this.Controls.Add(this.tb_data_odjazdu);
            this.Controls.Add(this.tb_data_przyjazdu);
            this.Controls.Add(this.tb_nazwa);
            this.Controls.Add(this.l_cena);
            this.Controls.Add(this.l_opis);
            this.Controls.Add(this.l_data_powrotu);
            this.Controls.Add(this.l_data_wyjazdu);
            this.Controls.Add(this.l_nazwa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Wycieczka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wycieczka";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Wycieczka_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_nazwa;
        private System.Windows.Forms.Label l_data_wyjazdu;
        private System.Windows.Forms.Label l_data_powrotu;
        private System.Windows.Forms.Label l_opis;
        private System.Windows.Forms.Label l_cena;
        private System.Windows.Forms.TextBox tb_nazwa;
        private System.Windows.Forms.TextBox tb_data_przyjazdu;
        private System.Windows.Forms.TextBox tb_data_odjazdu;
        private System.Windows.Forms.TextBox tb_opis;
        private System.Windows.Forms.TextBox tb_cena;
        private System.Windows.Forms.Button b_zapisz;
        private System.Windows.Forms.Button b_anuluj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_odjazd;
        private System.Windows.Forms.ComboBox cb_docelowa;
    }
}