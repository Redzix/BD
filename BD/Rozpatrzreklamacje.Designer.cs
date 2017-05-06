namespace BD
{
    partial class Rozpatrzreklamacje
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
            this.lb_reklamacje = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.l_reklamacje = new System.Windows.Forms.Label();
            this.l_opis_reklamacji = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.l_nazwa_wycieczki = new System.Windows.Forms.Label();
            this.l_okres_wycieczki = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_reklamacje
            // 
            this.lb_reklamacje.FormattingEnabled = true;
            this.lb_reklamacje.Location = new System.Drawing.Point(12, 42);
            this.lb_reklamacje.Name = "lb_reklamacje";
            this.lb_reklamacje.Size = new System.Drawing.Size(120, 199);
            this.lb_reklamacje.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(239, 65);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(302, 134);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Rozpatrz negatywnie";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(425, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Rozpatrz pozytywnie";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // l_reklamacje
            // 
            this.l_reklamacje.AutoSize = true;
            this.l_reklamacje.Location = new System.Drawing.Point(34, 20);
            this.l_reklamacje.Name = "l_reklamacje";
            this.l_reklamacje.Size = new System.Drawing.Size(63, 13);
            this.l_reklamacje.TabIndex = 4;
            this.l_reklamacje.Text = "Reklamacje";
            // 
            // l_opis_reklamacji
            // 
            this.l_opis_reklamacji.AutoSize = true;
            this.l_opis_reklamacji.Location = new System.Drawing.Point(155, 68);
            this.l_opis_reklamacji.Name = "l_opis_reklamacji";
            this.l_opis_reklamacji.Size = new System.Drawing.Size(78, 13);
            this.l_opis_reklamacji.TabIndex = 5;
            this.l_opis_reklamacji.Text = "Opis reklamacji";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(239, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(239, 39);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 7;
            // 
            // l_nazwa_wycieczki
            // 
            this.l_nazwa_wycieczki.AutoSize = true;
            this.l_nazwa_wycieczki.Location = new System.Drawing.Point(144, 16);
            this.l_nazwa_wycieczki.Name = "l_nazwa_wycieczki";
            this.l_nazwa_wycieczki.Size = new System.Drawing.Size(89, 13);
            this.l_nazwa_wycieczki.TabIndex = 8;
            this.l_nazwa_wycieczki.Text = "Nazwa wycieczki";
            // 
            // l_okres_wycieczki
            // 
            this.l_okres_wycieczki.AutoSize = true;
            this.l_okres_wycieczki.Location = new System.Drawing.Point(149, 42);
            this.l_okres_wycieczki.Name = "l_okres_wycieczki";
            this.l_okres_wycieczki.Size = new System.Drawing.Size(84, 13);
            this.l_okres_wycieczki.TabIndex = 9;
            this.l_okres_wycieczki.Text = "Okres wycieczki";
            // 
            // Rozpatrzreklamacje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 261);
            this.Controls.Add(this.l_okres_wycieczki);
            this.Controls.Add(this.l_nazwa_wycieczki);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.l_opis_reklamacji);
            this.Controls.Add(this.l_reklamacje);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lb_reklamacje);
            this.Name = "Rozpatrzreklamacje";
            this.Text = "Rozpatrz reklamacje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_reklamacje;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label l_reklamacje;
        private System.Windows.Forms.Label l_opis_reklamacji;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label l_nazwa_wycieczki;
        private System.Windows.Forms.Label l_okres_wycieczki;
    }
}