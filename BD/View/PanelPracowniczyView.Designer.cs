namespace BD.View
{
    partial class Panel_pracowniczy
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
            this.tb_nazwa_uzytkownika = new System.Windows.Forms.TextBox();
            this.tb_haslo = new System.Windows.Forms.TextBox();
            this.l_nazwa_uzytkownika = new System.Windows.Forms.Label();
            this.l_haslo = new System.Windows.Forms.Label();
            this.b_zaloguj = new System.Windows.Forms.Button();
            this.b_zakończ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_nazwa_uzytkownika
            // 
            this.tb_nazwa_uzytkownika.Location = new System.Drawing.Point(84, 25);
            this.tb_nazwa_uzytkownika.Name = "tb_nazwa_uzytkownika";
            this.tb_nazwa_uzytkownika.Size = new System.Drawing.Size(100, 20);
            this.tb_nazwa_uzytkownika.TabIndex = 1;
            // 
            // tb_haslo
            // 
            this.tb_haslo.Location = new System.Drawing.Point(84, 73);
            this.tb_haslo.Name = "tb_haslo";
            this.tb_haslo.Size = new System.Drawing.Size(100, 20);
            this.tb_haslo.TabIndex = 2;
            // 
            // l_nazwa_uzytkownika
            // 
            this.l_nazwa_uzytkownika.AutoSize = true;
            this.l_nazwa_uzytkownika.Location = new System.Drawing.Point(82, 9);
            this.l_nazwa_uzytkownika.Name = "l_nazwa_uzytkownika";
            this.l_nazwa_uzytkownika.Size = new System.Drawing.Size(102, 13);
            this.l_nazwa_uzytkownika.TabIndex = 3;
            this.l_nazwa_uzytkownika.Text = "Nazwa użytkownika";
            // 
            // l_haslo
            // 
            this.l_haslo.AutoSize = true;
            this.l_haslo.Location = new System.Drawing.Point(116, 57);
            this.l_haslo.Name = "l_haslo";
            this.l_haslo.Size = new System.Drawing.Size(36, 13);
            this.l_haslo.TabIndex = 5;
            this.l_haslo.Text = "Hasło";
            // 
            // b_zaloguj
            // 
            this.b_zaloguj.Location = new System.Drawing.Point(47, 108);
            this.b_zaloguj.Name = "b_zaloguj";
            this.b_zaloguj.Size = new System.Drawing.Size(75, 23);
            this.b_zaloguj.TabIndex = 7;
            this.b_zaloguj.Text = "Zaloguj";
            this.b_zaloguj.UseVisualStyleBackColor = true;
            this.b_zaloguj.Click += new System.EventHandler(this.b_zaloguj_Click);
            // 
            // b_zakończ
            // 
            this.b_zakończ.Location = new System.Drawing.Point(148, 108);
            this.b_zakończ.Name = "b_zakończ";
            this.b_zakończ.Size = new System.Drawing.Size(75, 23);
            this.b_zakończ.TabIndex = 8;
            this.b_zakończ.Text = "Zakończ";
            this.b_zakończ.UseVisualStyleBackColor = true;
            this.b_zakończ.Click += new System.EventHandler(this.b_zakoncz_Click);
            // 
            // Panel_pracowniczy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 146);
            this.Controls.Add(this.b_zakończ);
            this.Controls.Add(this.b_zaloguj);
            this.Controls.Add(this.l_haslo);
            this.Controls.Add(this.l_nazwa_uzytkownika);
            this.Controls.Add(this.tb_haslo);
            this.Controls.Add(this.tb_nazwa_uzytkownika);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Panel_pracowniczy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel pracowniczy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_nazwa_uzytkownika;
        private System.Windows.Forms.TextBox tb_haslo;
        private System.Windows.Forms.Label l_nazwa_uzytkownika;
        private System.Windows.Forms.Label l_haslo;
        private System.Windows.Forms.Button b_zaloguj;
        private System.Windows.Forms.Button b_zakończ;

    }
}