namespace BD.View
{
    partial class OpiniaView
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
            this.tb_opinia = new System.Windows.Forms.TextBox();
            this.l_ocena = new System.Windows.Forms.Label();
            this.cb_ocena = new System.Windows.Forms.ComboBox();
            this.l_numerRezerwacji = new System.Windows.Forms.Label();
            this.cb_rezerwacje = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // b_zapisz
            // 
            this.b_zapisz.Enabled = false;
            this.b_zapisz.Location = new System.Drawing.Point(102, 173);
            this.b_zapisz.Name = "b_zapisz";
            this.b_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_zapisz.TabIndex = 21;
            this.b_zapisz.Text = "Zapisz";
            this.b_zapisz.UseVisualStyleBackColor = true;
            this.b_zapisz.Click += new System.EventHandler(this.b_zapisz_Click);
            // 
            // b_anuluj
            // 
            this.b_anuluj.Location = new System.Drawing.Point(287, 173);
            this.b_anuluj.Name = "b_anuluj";
            this.b_anuluj.Size = new System.Drawing.Size(75, 23);
            this.b_anuluj.TabIndex = 20;
            this.b_anuluj.Text = "Anuluj";
            this.b_anuluj.UseVisualStyleBackColor = true;
            this.b_anuluj.Click += new System.EventHandler(this.b_anuluj_Click);
            // 
            // l_uwagi
            // 
            this.l_uwagi.AutoSize = true;
            this.l_uwagi.Location = new System.Drawing.Point(10, 63);
            this.l_uwagi.Name = "l_uwagi";
            this.l_uwagi.Size = new System.Drawing.Size(37, 13);
            this.l_uwagi.TabIndex = 19;
            this.l_uwagi.Text = "Uwagi";
            // 
            // tb_opinia
            // 
            this.tb_opinia.Location = new System.Drawing.Point(102, 60);
            this.tb_opinia.Multiline = true;
            this.tb_opinia.Name = "tb_opinia";
            this.tb_opinia.Size = new System.Drawing.Size(260, 107);
            this.tb_opinia.TabIndex = 12;
            // 
            // l_ocena
            // 
            this.l_ocena.AutoSize = true;
            this.l_ocena.Location = new System.Drawing.Point(8, 36);
            this.l_ocena.Name = "l_ocena";
            this.l_ocena.Size = new System.Drawing.Size(39, 13);
            this.l_ocena.TabIndex = 23;
            this.l_ocena.Text = "Ocena";
            // 
            // cb_ocena
            // 
            this.cb_ocena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ocena.FormattingEnabled = true;
            this.cb_ocena.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cb_ocena.Location = new System.Drawing.Point(102, 33);
            this.cb_ocena.Name = "cb_ocena";
            this.cb_ocena.Size = new System.Drawing.Size(37, 21);
            this.cb_ocena.TabIndex = 24;
            // 
            // l_numerRezerwacji
            // 
            this.l_numerRezerwacji.AutoSize = true;
            this.l_numerRezerwacji.Location = new System.Drawing.Point(8, 9);
            this.l_numerRezerwacji.Name = "l_numerRezerwacji";
            this.l_numerRezerwacji.Size = new System.Drawing.Size(60, 13);
            this.l_numerRezerwacji.TabIndex = 25;
            this.l_numerRezerwacji.Text = "Wycieczka";
            // 
            // cb_rezerwacje
            // 
            this.cb_rezerwacje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_rezerwacje.FormattingEnabled = true;
            this.cb_rezerwacje.Location = new System.Drawing.Point(102, 6);
            this.cb_rezerwacje.Name = "cb_rezerwacje";
            this.cb_rezerwacje.Size = new System.Drawing.Size(131, 21);
            this.cb_rezerwacje.TabIndex = 28;
            this.cb_rezerwacje.SelectedIndexChanged += new System.EventHandler(this.tb_numerRezerwacji_Leave);
            // 
            // OpiniaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 208);
            this.Controls.Add(this.cb_rezerwacje);
            this.Controls.Add(this.l_numerRezerwacji);
            this.Controls.Add(this.cb_ocena);
            this.Controls.Add(this.l_ocena);
            this.Controls.Add(this.b_zapisz);
            this.Controls.Add(this.b_anuluj);
            this.Controls.Add(this.l_uwagi);
            this.Controls.Add(this.tb_opinia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OpiniaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opinia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Opinia_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_zapisz;
        private System.Windows.Forms.Button b_anuluj;
        private System.Windows.Forms.Label l_uwagi;
        public System.Windows.Forms.TextBox tb_opinia;
        private System.Windows.Forms.Label l_ocena;
        public System.Windows.Forms.ComboBox cb_ocena;
        private System.Windows.Forms.Label l_numerRezerwacji;
        public System.Windows.Forms.ComboBox cb_rezerwacje;
    }
}