namespace BD
{
    partial class Zarzadzajwycieczkami
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
            this.label1 = new System.Windows.Forms.Label();
            this.lb_wycieczki = new System.Windows.Forms.ListBox();
            this.b_dodaj_wycieczke = new System.Windows.Forms.Button();
            this.l_wycieczki = new System.Windows.Forms.Label();
            this.b_edytuj = new System.Windows.Forms.Button();
            this.b_usun_wycieczke = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Zalogowany jako ";
            // 
            // lb_wycieczki
            // 
            this.lb_wycieczki.FormattingEnabled = true;
            this.lb_wycieczki.Location = new System.Drawing.Point(12, 25);
            this.lb_wycieczki.Name = "lb_wycieczki";
            this.lb_wycieczki.Size = new System.Drawing.Size(120, 186);
            this.lb_wycieczki.TabIndex = 2;
            // 
            // b_dodaj_wycieczke
            // 
            this.b_dodaj_wycieczke.Location = new System.Drawing.Point(147, 42);
            this.b_dodaj_wycieczke.Name = "b_dodaj_wycieczke";
            this.b_dodaj_wycieczke.Size = new System.Drawing.Size(97, 23);
            this.b_dodaj_wycieczke.TabIndex = 3;
            this.b_dodaj_wycieczke.Text = "Dodaj wycieczkę";
            this.b_dodaj_wycieczke.UseVisualStyleBackColor = true;
            // 
            // l_wycieczki
            // 
            this.l_wycieczki.AutoSize = true;
            this.l_wycieczki.Location = new System.Drawing.Point(44, 9);
            this.l_wycieczki.Name = "l_wycieczki";
            this.l_wycieczki.Size = new System.Drawing.Size(56, 13);
            this.l_wycieczki.TabIndex = 4;
            this.l_wycieczki.Text = "Wycieczki";
            // 
            // b_edytuj
            // 
            this.b_edytuj.Location = new System.Drawing.Point(147, 87);
            this.b_edytuj.Name = "b_edytuj";
            this.b_edytuj.Size = new System.Drawing.Size(97, 23);
            this.b_edytuj.TabIndex = 5;
            this.b_edytuj.Text = "Edytuj";
            this.b_edytuj.UseVisualStyleBackColor = true;
            // 
            // b_usun_wycieczke
            // 
            this.b_usun_wycieczke.Location = new System.Drawing.Point(147, 136);
            this.b_usun_wycieczke.Name = "b_usun_wycieczke";
            this.b_usun_wycieczke.Size = new System.Drawing.Size(97, 23);
            this.b_usun_wycieczke.TabIndex = 6;
            this.b_usun_wycieczke.Text = "Usuń wycieczkę";
            this.b_usun_wycieczke.UseVisualStyleBackColor = true;
            // 
            // Zarzadzajwycieczkami
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 261);
            this.Controls.Add(this.b_usun_wycieczke);
            this.Controls.Add(this.b_edytuj);
            this.Controls.Add(this.l_wycieczki);
            this.Controls.Add(this.b_dodaj_wycieczke);
            this.Controls.Add(this.lb_wycieczki);
            this.Controls.Add(this.label1);
            this.Name = "Zarzadzajwycieczkami";
            this.Text = "Zarzadzaj wycieczkami";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_wycieczki;
        private System.Windows.Forms.Button b_dodaj_wycieczke;
        private System.Windows.Forms.Label l_wycieczki;
        private System.Windows.Forms.Button b_edytuj;
        private System.Windows.Forms.Button b_usun_wycieczke;
    }
}