namespace BD
{
    partial class Pojazd
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
            this.l_nr_rejestracyjny = new System.Windows.Forms.Label();
            this.b_zapisz = new System.Windows.Forms.Button();
            this.tb_numer_rejestracyjny = new System.Windows.Forms.TextBox();
            this.tb_marka = new System.Windows.Forms.TextBox();
            this.l_marka = new System.Windows.Forms.Label();
            this.tb_pojemnosc = new System.Windows.Forms.TextBox();
            this.l_pojemnosc = new System.Windows.Forms.Label();
            this.b_anuluj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_nr_rejestracyjny
            // 
            this.l_nr_rejestracyjny.AutoSize = true;
            this.l_nr_rejestracyjny.Location = new System.Drawing.Point(12, 32);
            this.l_nr_rejestracyjny.Name = "l_nr_rejestracyjny";
            this.l_nr_rejestracyjny.Size = new System.Drawing.Size(79, 13);
            this.l_nr_rejestracyjny.TabIndex = 0;
            this.l_nr_rejestracyjny.Text = "Nr rejestracyjny";
            // 
            // b_zapisz
            // 
            this.b_zapisz.Location = new System.Drawing.Point(88, 139);
            this.b_zapisz.Name = "b_zapisz";
            this.b_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_zapisz.TabIndex = 1;
            this.b_zapisz.Text = "Zapisz";
            this.b_zapisz.UseVisualStyleBackColor = true;
            // 
            // tb_numer_rejestracyjny
            // 
            this.tb_numer_rejestracyjny.Location = new System.Drawing.Point(97, 29);
            this.tb_numer_rejestracyjny.Name = "tb_numer_rejestracyjny";
            this.tb_numer_rejestracyjny.Size = new System.Drawing.Size(157, 20);
            this.tb_numer_rejestracyjny.TabIndex = 3;
            // 
            // tb_marka
            // 
            this.tb_marka.Location = new System.Drawing.Point(97, 55);
            this.tb_marka.Name = "tb_marka";
            this.tb_marka.Size = new System.Drawing.Size(157, 20);
            this.tb_marka.TabIndex = 5;
            // 
            // l_marka
            // 
            this.l_marka.AutoSize = true;
            this.l_marka.Location = new System.Drawing.Point(12, 58);
            this.l_marka.Name = "l_marka";
            this.l_marka.Size = new System.Drawing.Size(37, 13);
            this.l_marka.TabIndex = 4;
            this.l_marka.Text = "Marka";
            // 
            // tb_pojemnosc
            // 
            this.tb_pojemnosc.Location = new System.Drawing.Point(97, 83);
            this.tb_pojemnosc.Name = "tb_pojemnosc";
            this.tb_pojemnosc.Size = new System.Drawing.Size(83, 20);
            this.tb_pojemnosc.TabIndex = 7;
            // 
            // l_pojemnosc
            // 
            this.l_pojemnosc.AutoSize = true;
            this.l_pojemnosc.Location = new System.Drawing.Point(12, 83);
            this.l_pojemnosc.Name = "l_pojemnosc";
            this.l_pojemnosc.Size = new System.Drawing.Size(59, 13);
            this.l_pojemnosc.TabIndex = 6;
            this.l_pojemnosc.Text = "Pojemność";
            // 
            // b_anuluj
            // 
            this.b_anuluj.Location = new System.Drawing.Point(179, 139);
            this.b_anuluj.Name = "b_anuluj";
            this.b_anuluj.Size = new System.Drawing.Size(75, 23);
            this.b_anuluj.TabIndex = 8;
            this.b_anuluj.Text = "Anuluj";
            this.b_anuluj.UseVisualStyleBackColor = true;
            // 
            // Pojazd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 174);
            this.Controls.Add(this.b_anuluj);
            this.Controls.Add(this.tb_pojemnosc);
            this.Controls.Add(this.l_pojemnosc);
            this.Controls.Add(this.tb_marka);
            this.Controls.Add(this.l_marka);
            this.Controls.Add(this.tb_numer_rejestracyjny);
            this.Controls.Add(this.b_zapisz);
            this.Controls.Add(this.l_nr_rejestracyjny);
            this.Name = "Pojazd";
            this.Text = "Pojazd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_nr_rejestracyjny;
        private System.Windows.Forms.Button b_zapisz;
        private System.Windows.Forms.TextBox tb_numer_rejestracyjny;
        private System.Windows.Forms.TextBox tb_marka;
        private System.Windows.Forms.Label l_marka;
        private System.Windows.Forms.TextBox tb_pojemnosc;
        private System.Windows.Forms.Label l_pojemnosc;
        private System.Windows.Forms.Button b_anuluj;
    }
}