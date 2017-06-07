namespace BD.View
{
    partial class KlientView
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
            this.dgv_katalog = new System.Windows.Forms.DataGridView();
            this.id_wycieczki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nazwa_wycieczki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Okres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_wyjazdu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Promocja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Koszt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtb_wycieczka = new System.Windows.Forms.RichTextBox();
            this.b_katalog_rezerwuj = new System.Windows.Forms.Button();
            this.b_katalog_wyjdz = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.wystawOpinięToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reklamujWycieczkęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezygnacjaZWycieczkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.l_polaczenie = new System.Windows.Forms.Label();
            this.b_zaplac = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_katalog)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_katalog
            // 
            this.dgv_katalog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_katalog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_katalog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_wycieczki,
            this.Nazwa_wycieczki,
            this.Okres,
            this.Data_wyjazdu,
            this.Promocja,
            this.Koszt});
            this.dgv_katalog.Location = new System.Drawing.Point(12, 39);
            this.dgv_katalog.Name = "dgv_katalog";
            this.dgv_katalog.Size = new System.Drawing.Size(585, 304);
            this.dgv_katalog.TabIndex = 0;
            this.dgv_katalog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_katalog_CellClick);
            // 
            // id_wycieczki
            // 
            this.id_wycieczki.HeaderText = "Id wycieczki";
            this.id_wycieczki.Name = "id_wycieczki";
            this.id_wycieczki.Visible = false;
            // 
            // Nazwa_wycieczki
            // 
            this.Nazwa_wycieczki.HeaderText = "Nazwa wycieczki";
            this.Nazwa_wycieczki.Name = "Nazwa_wycieczki";
            // 
            // Okres
            // 
            this.Okres.HeaderText = "Okres";
            this.Okres.Name = "Okres";
            // 
            // Data_wyjazdu
            // 
            this.Data_wyjazdu.HeaderText = "Data wyjazdu";
            this.Data_wyjazdu.Name = "Data_wyjazdu";
            // 
            // Promocja
            // 
            this.Promocja.HeaderText = "Promocja";
            this.Promocja.Name = "Promocja";
            // 
            // Koszt
            // 
            this.Koszt.HeaderText = "Cena całkowita";
            this.Koszt.Name = "Koszt";
            // 
            // rtb_wycieczka
            // 
            this.rtb_wycieczka.Location = new System.Drawing.Point(613, 39);
            this.rtb_wycieczka.Name = "rtb_wycieczka";
            this.rtb_wycieczka.Size = new System.Drawing.Size(330, 232);
            this.rtb_wycieczka.TabIndex = 1;
            this.rtb_wycieczka.Text = "Nazwa\nData wyjazdu\nData powrotu\nOpis\n\nAdres miejsca\nMiejscowość";
            // 
            // b_katalog_rezerwuj
            // 
            this.b_katalog_rezerwuj.Location = new System.Drawing.Point(868, 277);
            this.b_katalog_rezerwuj.Name = "b_katalog_rezerwuj";
            this.b_katalog_rezerwuj.Size = new System.Drawing.Size(75, 23);
            this.b_katalog_rezerwuj.TabIndex = 2;
            this.b_katalog_rezerwuj.Text = "Rezerwuj";
            this.b_katalog_rezerwuj.UseVisualStyleBackColor = true;
            this.b_katalog_rezerwuj.Click += new System.EventHandler(this.b_katalog_rezerwuj_Click);
            // 
            // b_katalog_wyjdz
            // 
            this.b_katalog_wyjdz.Location = new System.Drawing.Point(868, 335);
            this.b_katalog_wyjdz.Name = "b_katalog_wyjdz";
            this.b_katalog_wyjdz.Size = new System.Drawing.Size(75, 23);
            this.b_katalog_wyjdz.TabIndex = 3;
            this.b_katalog_wyjdz.Text = "Wyjdź";
            this.b_katalog_wyjdz.UseVisualStyleBackColor = true;
            this.b_katalog_wyjdz.Click += new System.EventHandler(this.b_katalog_wyjdz_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wystawOpinięToolStripMenuItem,
            this.reklamujWycieczkęToolStripMenuItem,
            this.rezygnacjaZWycieczkiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(955, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // wystawOpinięToolStripMenuItem
            // 
            this.wystawOpinięToolStripMenuItem.Name = "wystawOpinięToolStripMenuItem";
            this.wystawOpinięToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.wystawOpinięToolStripMenuItem.Text = "Wystaw opinię";
            this.wystawOpinięToolStripMenuItem.Click += new System.EventHandler(this.wystawOpinięToolStripMenuItem_Click);
            // 
            // reklamujWycieczkęToolStripMenuItem
            // 
            this.reklamujWycieczkęToolStripMenuItem.Name = "reklamujWycieczkęToolStripMenuItem";
            this.reklamujWycieczkęToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.reklamujWycieczkęToolStripMenuItem.Text = "Reklamuj wycieczkę";
            this.reklamujWycieczkęToolStripMenuItem.Click += new System.EventHandler(this.reklamujWycieczkęToolStripMenuItem_Click);
            // 
            // rezygnacjaZWycieczkiToolStripMenuItem
            // 
            this.rezygnacjaZWycieczkiToolStripMenuItem.Name = "rezygnacjaZWycieczkiToolStripMenuItem";
            this.rezygnacjaZWycieczkiToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.rezygnacjaZWycieczkiToolStripMenuItem.Text = "Rezygnacja z wycieczki";
            this.rezygnacjaZWycieczkiToolStripMenuItem.Click += new System.EventHandler(this.rezygnacjaZWycieczkiToolStripMenuItem_Click);
            // 
            // l_polaczenie
            // 
            this.l_polaczenie.AutoSize = true;
            this.l_polaczenie.Location = new System.Drawing.Point(15, 348);
            this.l_polaczenie.Name = "l_polaczenie";
            this.l_polaczenie.Size = new System.Drawing.Size(10, 13);
            this.l_polaczenie.TabIndex = 10;
            this.l_polaczenie.Text = " ";
            // 
            // b_zaplac
            // 
            this.b_zaplac.Location = new System.Drawing.Point(613, 277);
            this.b_zaplac.Name = "b_zaplac";
            this.b_zaplac.Size = new System.Drawing.Size(75, 23);
            this.b_zaplac.TabIndex = 11;
            this.b_zaplac.Text = "Zapłać";
            this.b_zaplac.UseVisualStyleBackColor = true;
            this.b_zaplac.Click += new System.EventHandler(this.b_zaplac_Click);
            // 
            // KlientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 370);
            this.Controls.Add(this.b_zaplac);
            this.Controls.Add(this.l_polaczenie);
            this.Controls.Add(this.b_katalog_wyjdz);
            this.Controls.Add(this.b_katalog_rezerwuj);
            this.Controls.Add(this.rtb_wycieczka);
            this.Controls.Add(this.dgv_katalog);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "KlientView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Klient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Klient_FormClosing);
            this.Load += new System.EventHandler(this.Klient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_katalog)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_katalog;
        private System.Windows.Forms.RichTextBox rtb_wycieczka;
        private System.Windows.Forms.Button b_katalog_rezerwuj;
        private System.Windows.Forms.Button b_katalog_wyjdz;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wystawOpinięToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reklamujWycieczkęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezygnacjaZWycieczkiToolStripMenuItem;
        private System.Windows.Forms.Label l_polaczenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_wycieczki;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa_wycieczki;
        private System.Windows.Forms.DataGridViewTextBoxColumn Okres;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_wyjazdu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Promocja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Koszt;
        private System.Windows.Forms.Button b_zaplac;
    }
}

