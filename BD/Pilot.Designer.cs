namespace BD
{
    partial class Pilot
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
            this.dgv_tabelaPilot = new System.Windows.Forms.DataGridView();
            this.Nazwa_wycieczki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_wyjazdu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_powrotu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pojazd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kierowca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.l_zalogowany_jako = new System.Windows.Forms.Label();
            this.b_wyjdz = new System.Windows.Forms.Button();
            this.l_uzytkownik = new System.Windows.Forms.Label();
            this.l_polaczenie = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tabelaPilot)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_tabelaPilot
            // 
            this.dgv_tabelaPilot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_tabelaPilot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tabelaPilot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nazwa_wycieczki,
            this.Data_wyjazdu,
            this.Data_powrotu,
            this.Pojazd,
            this.Kierowca});
            this.dgv_tabelaPilot.Location = new System.Drawing.Point(12, 12);
            this.dgv_tabelaPilot.Name = "dgv_tabelaPilot";
            this.dgv_tabelaPilot.Size = new System.Drawing.Size(651, 150);
            this.dgv_tabelaPilot.TabIndex = 0;
            // 
            // Nazwa_wycieczki
            // 
            this.Nazwa_wycieczki.HeaderText = "Nazwa wycieczki";
            this.Nazwa_wycieczki.Name = "Nazwa_wycieczki";
            // 
            // Data_wyjazdu
            // 
            this.Data_wyjazdu.HeaderText = "Data wyjazdu";
            this.Data_wyjazdu.Name = "Data_wyjazdu";
            // 
            // Data_powrotu
            // 
            this.Data_powrotu.HeaderText = "Data powrotu";
            this.Data_powrotu.Name = "Data_powrotu";
            // 
            // Pojazd
            // 
            this.Pojazd.HeaderText = "Pojazd";
            this.Pojazd.Name = "Pojazd";
            // 
            // Kierowca
            // 
            this.Kierowca.HeaderText = "Kierowca";
            this.Kierowca.Name = "Kierowca";
            // 
            // l_zalogowany_jako
            // 
            this.l_zalogowany_jako.AutoSize = true;
            this.l_zalogowany_jako.Location = new System.Drawing.Point(154, 197);
            this.l_zalogowany_jako.Name = "l_zalogowany_jako";
            this.l_zalogowany_jako.Size = new System.Drawing.Size(88, 13);
            this.l_zalogowany_jako.TabIndex = 1;
            this.l_zalogowany_jako.Text = "Zalogowany jako";
            // 
            // b_wyjdz
            // 
            this.b_wyjdz.Location = new System.Drawing.Point(588, 184);
            this.b_wyjdz.Name = "b_wyjdz";
            this.b_wyjdz.Size = new System.Drawing.Size(75, 23);
            this.b_wyjdz.TabIndex = 2;
            this.b_wyjdz.Text = "Wyjdź";
            this.b_wyjdz.UseVisualStyleBackColor = true;
            this.b_wyjdz.Click += new System.EventHandler(this.b_wyjdz_Click);
            // 
            // l_uzytkownik
            // 
            this.l_uzytkownik.AutoSize = true;
            this.l_uzytkownik.Location = new System.Drawing.Point(240, 197);
            this.l_uzytkownik.Name = "l_uzytkownik";
            this.l_uzytkownik.Size = new System.Drawing.Size(10, 13);
            this.l_uzytkownik.TabIndex = 3;
            this.l_uzytkownik.Text = " ";
            // 
            // l_polaczenie
            // 
            this.l_polaczenie.AutoSize = true;
            this.l_polaczenie.Location = new System.Drawing.Point(16, 197);
            this.l_polaczenie.Name = "l_polaczenie";
            this.l_polaczenie.Size = new System.Drawing.Size(10, 13);
            this.l_polaczenie.TabIndex = 7;
            this.l_polaczenie.Text = " ";
            // 
            // Pilot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 219);
            this.Controls.Add(this.l_polaczenie);
            this.Controls.Add(this.l_uzytkownik);
            this.Controls.Add(this.b_wyjdz);
            this.Controls.Add(this.l_zalogowany_jako);
            this.Controls.Add(this.dgv_tabelaPilot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Pilot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pilot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pilot_FormClosing);
            this.Load += new System.EventHandler(this.Pilot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tabelaPilot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_tabelaPilot;
        private System.Windows.Forms.Label l_zalogowany_jako;
        private System.Windows.Forms.Button b_wyjdz;
        private System.Windows.Forms.Label l_uzytkownik;
        private System.Windows.Forms.Label l_polaczenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa_wycieczki;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_wyjazdu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_powrotu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pojazd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kierowca;
    }
}