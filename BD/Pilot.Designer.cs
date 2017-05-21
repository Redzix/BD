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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nazwa_wycieczki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_odjazdu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_przyjazdu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pojazd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kierowca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drugi_pilot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.l_zalogowany_jako = new System.Windows.Forms.Label();
            this.b_wyjdz = new System.Windows.Forms.Button();
            this.l_uzytkownik = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nazwa_wycieczki,
            this.Data_odjazdu,
            this.Data_przyjazdu,
            this.Pojazd,
            this.Kierowca,
            this.Drugi_pilot});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(651, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // Nazwa_wycieczki
            // 
            this.Nazwa_wycieczki.HeaderText = "Nazwa wycieczki";
            this.Nazwa_wycieczki.Name = "Nazwa_wycieczki";
            // 
            // Data_odjazdu
            // 
            this.Data_odjazdu.HeaderText = "Data odjazdu";
            this.Data_odjazdu.Name = "Data_odjazdu";
            // 
            // Data_przyjazdu
            // 
            this.Data_przyjazdu.HeaderText = "Data przyjazdu";
            this.Data_przyjazdu.Name = "Data_przyjazdu";
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
            // Drugi_pilot
            // 
            this.Drugi_pilot.HeaderText = "Drugi pilot";
            this.Drugi_pilot.Name = "Drugi_pilot";
            // 
            // l_zalogowany_jako
            // 
            this.l_zalogowany_jako.AutoSize = true;
            this.l_zalogowany_jako.Location = new System.Drawing.Point(9, 197);
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
            this.l_uzytkownik.Location = new System.Drawing.Point(103, 197);
            this.l_uzytkownik.Name = "l_uzytkownik";
            this.l_uzytkownik.Size = new System.Drawing.Size(10, 13);
            this.l_uzytkownik.TabIndex = 3;
            this.l_uzytkownik.Text = " ";
            // 
            // Pilot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 219);
            this.Controls.Add(this.l_uzytkownik);
            this.Controls.Add(this.b_wyjdz);
            this.Controls.Add(this.l_zalogowany_jako);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Pilot";
            this.Text = "Pilot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pilot_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label l_zalogowany_jako;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa_wycieczki;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_odjazdu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_przyjazdu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pojazd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kierowca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drugi_pilot;
        private System.Windows.Forms.Button b_wyjdz;
        private System.Windows.Forms.Label l_uzytkownik;
    }
}