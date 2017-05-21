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
            this.l_data_przyjazdu = new System.Windows.Forms.Label();
            this.l_data_odjazdu = new System.Windows.Forms.Label();
            this.l_opis = new System.Windows.Forms.Label();
            this.l_cena = new System.Windows.Forms.Label();
            this.tb_nazwa = new System.Windows.Forms.TextBox();
            this.tb_data_przyjazdu = new System.Windows.Forms.TextBox();
            this.tb_data_odjazdu = new System.Windows.Forms.TextBox();
            this.tb_opis = new System.Windows.Forms.TextBox();
            this.tb_cena = new System.Windows.Forms.TextBox();
            this.b_zapisz = new System.Windows.Forms.Button();
            this.b_anuluj = new System.Windows.Forms.Button();
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
            // l_data_przyjazdu
            // 
            this.l_data_przyjazdu.AutoSize = true;
            this.l_data_przyjazdu.Location = new System.Drawing.Point(11, 35);
            this.l_data_przyjazdu.Name = "l_data_przyjazdu";
            this.l_data_przyjazdu.Size = new System.Drawing.Size(77, 13);
            this.l_data_przyjazdu.TabIndex = 1;
            this.l_data_przyjazdu.Text = "Data przyjazdu";
            // 
            // l_data_odjazdu
            // 
            this.l_data_odjazdu.AutoSize = true;
            this.l_data_odjazdu.Location = new System.Drawing.Point(11, 61);
            this.l_data_odjazdu.Name = "l_data_odjazdu";
            this.l_data_odjazdu.Size = new System.Drawing.Size(70, 13);
            this.l_data_odjazdu.TabIndex = 2;
            this.l_data_odjazdu.Text = "Data odjazdu";
            // 
            // l_opis
            // 
            this.l_opis.AutoSize = true;
            this.l_opis.Location = new System.Drawing.Point(50, 87);
            this.l_opis.Name = "l_opis";
            this.l_opis.Size = new System.Drawing.Size(28, 13);
            this.l_opis.TabIndex = 3;
            this.l_opis.Text = "Opis";
            // 
            // l_cena
            // 
            this.l_cena.AutoSize = true;
            this.l_cena.Location = new System.Drawing.Point(58, 166);
            this.l_cena.Name = "l_cena";
            this.l_cena.Size = new System.Drawing.Size(32, 13);
            this.l_cena.TabIndex = 4;
            this.l_cena.Text = "Cena";
            // 
            // tb_nazwa
            // 
            this.tb_nazwa.Location = new System.Drawing.Point(96, 6);
            this.tb_nazwa.Name = "tb_nazwa";
            this.tb_nazwa.Size = new System.Drawing.Size(159, 20);
            this.tb_nazwa.TabIndex = 5;
            // 
            // tb_data_przyjazdu
            // 
            this.tb_data_przyjazdu.Location = new System.Drawing.Point(96, 32);
            this.tb_data_przyjazdu.Name = "tb_data_przyjazdu";
            this.tb_data_przyjazdu.Size = new System.Drawing.Size(159, 20);
            this.tb_data_przyjazdu.TabIndex = 6;
            // 
            // tb_data_odjazdu
            // 
            this.tb_data_odjazdu.Location = new System.Drawing.Point(96, 58);
            this.tb_data_odjazdu.Name = "tb_data_odjazdu";
            this.tb_data_odjazdu.Size = new System.Drawing.Size(159, 20);
            this.tb_data_odjazdu.TabIndex = 7;
            // 
            // tb_opis
            // 
            this.tb_opis.Location = new System.Drawing.Point(96, 84);
            this.tb_opis.Multiline = true;
            this.tb_opis.Name = "tb_opis";
            this.tb_opis.Size = new System.Drawing.Size(159, 73);
            this.tb_opis.TabIndex = 8;
            // 
            // tb_cena
            // 
            this.tb_cena.Location = new System.Drawing.Point(96, 163);
            this.tb_cena.Name = "tb_cena";
            this.tb_cena.Size = new System.Drawing.Size(100, 20);
            this.tb_cena.TabIndex = 9;
            // 
            // b_zapisz
            // 
            this.b_zapisz.Location = new System.Drawing.Point(15, 207);
            this.b_zapisz.Name = "b_zapisz";
            this.b_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_zapisz.TabIndex = 10;
            this.b_zapisz.Text = "Zapisz";
            this.b_zapisz.UseVisualStyleBackColor = true;
            // 
            // b_anuluj
            // 
            this.b_anuluj.Location = new System.Drawing.Point(179, 207);
            this.b_anuluj.Name = "b_anuluj";
            this.b_anuluj.Size = new System.Drawing.Size(75, 23);
            this.b_anuluj.TabIndex = 11;
            this.b_anuluj.Text = "Anuluj";
            this.b_anuluj.UseVisualStyleBackColor = true;
            this.b_anuluj.Click += new System.EventHandler(this.b_anuluj_Click);
            // 
            // Wycieczka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 239);
            this.Controls.Add(this.b_anuluj);
            this.Controls.Add(this.b_zapisz);
            this.Controls.Add(this.tb_cena);
            this.Controls.Add(this.tb_opis);
            this.Controls.Add(this.tb_data_odjazdu);
            this.Controls.Add(this.tb_data_przyjazdu);
            this.Controls.Add(this.tb_nazwa);
            this.Controls.Add(this.l_cena);
            this.Controls.Add(this.l_opis);
            this.Controls.Add(this.l_data_odjazdu);
            this.Controls.Add(this.l_data_przyjazdu);
            this.Controls.Add(this.l_nazwa);
            this.Name = "Wycieczka";
            this.Text = "Wycieczka";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Wycieczka_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_nazwa;
        private System.Windows.Forms.Label l_data_przyjazdu;
        private System.Windows.Forms.Label l_data_odjazdu;
        private System.Windows.Forms.Label l_opis;
        private System.Windows.Forms.Label l_cena;
        private System.Windows.Forms.TextBox tb_nazwa;
        private System.Windows.Forms.TextBox tb_data_przyjazdu;
        private System.Windows.Forms.TextBox tb_data_odjazdu;
        private System.Windows.Forms.TextBox tb_opis;
        private System.Windows.Forms.TextBox tb_cena;
        private System.Windows.Forms.Button b_zapisz;
        private System.Windows.Forms.Button b_anuluj;
    }
}