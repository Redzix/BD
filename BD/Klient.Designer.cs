namespace BD
{
    partial class Klient
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
            this.Nazwa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Okres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Promocja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Koszt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtb_wycieczka = new System.Windows.Forms.RichTextBox();
            this.b_katalog_rezerwuj = new System.Windows.Forms.Button();
            this.b_katalog_wyjdz = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.wystawOpinięToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reklamujWycieczkęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezygnacjaZWycieczkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_katalog)).BeginInit();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_katalog
            // 
            this.dgv_katalog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_katalog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nazwa,
            this.Okres,
            this.Promocja,
            this.Koszt});
            this.dgv_katalog.Location = new System.Drawing.Point(12, 39);
            this.dgv_katalog.Name = "dgv_katalog";
            this.dgv_katalog.Size = new System.Drawing.Size(443, 219);
            this.dgv_katalog.TabIndex = 0;
            // 
            // Nazwa
            // 
            this.Nazwa.HeaderText = "Nazwa";
            this.Nazwa.Name = "Nazwa";
            // 
            // Okres
            // 
            this.Okres.HeaderText = "Okres";
            this.Okres.Name = "Okres";
            // 
            // Promocja
            // 
            this.Promocja.HeaderText = "Promocja";
            this.Promocja.Name = "Promocja";
            // 
            // Koszt
            // 
            this.Koszt.HeaderText = "Koszt";
            this.Koszt.Name = "Koszt";
            // 
            // rtb_wycieczka
            // 
            this.rtb_wycieczka.Location = new System.Drawing.Point(461, 39);
            this.rtb_wycieczka.Name = "rtb_wycieczka";
            this.rtb_wycieczka.Size = new System.Drawing.Size(330, 150);
            this.rtb_wycieczka.TabIndex = 1;
            this.rtb_wycieczka.Text = "Nazwa\nData odjazdu\nData przyjazdu\nOpis\n\nAdres miejsca\nMiejscowość";
            // 
            // b_katalog_rezerwuj
            // 
            this.b_katalog_rezerwuj.Location = new System.Drawing.Point(598, 195);
            this.b_katalog_rezerwuj.Name = "b_katalog_rezerwuj";
            this.b_katalog_rezerwuj.Size = new System.Drawing.Size(75, 23);
            this.b_katalog_rezerwuj.TabIndex = 2;
            this.b_katalog_rezerwuj.Text = "Rezerwuj";
            this.b_katalog_rezerwuj.UseVisualStyleBackColor = true;
            this.b_katalog_rezerwuj.Click += new System.EventHandler(this.b_katalog_rezerwuj_Click);
            // 
            // b_katalog_wyjdz
            // 
            this.b_katalog_wyjdz.Location = new System.Drawing.Point(716, 240);
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
            this.menuStrip1.Size = new System.Drawing.Size(796, 24);
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
            // Klient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 270);
            this.Controls.Add(this.b_katalog_wyjdz);
            this.Controls.Add(this.b_katalog_rezerwuj);
            this.Controls.Add(this.rtb_wycieczka);
            this.Controls.Add(this.dgv_katalog);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Klient";
            this.Text = "Klient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Klient_FormClosing);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Okres;
        private System.Windows.Forms.DataGridViewTextBoxColumn Promocja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Koszt;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wystawOpinięToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reklamujWycieczkęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezygnacjaZWycieczkiToolStripMenuItem;
    }
}

