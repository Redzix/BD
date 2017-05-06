namespace BD
{
    partial class Kierowca
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
            this.label2 = new System.Windows.Forms.Label();
            this.rb_sprawny = new System.Windows.Forms.RadioButton();
            this.rb_awaria = new System.Windows.Forms.RadioButton();
            this.gb_stan_pojazdu = new System.Windows.Forms.GroupBox();
            this.b_kierowca_zapisz = new System.Windows.Forms.Button();
            this.b_kierowca_wyjdz = new System.Windows.Forms.Button();
            this.lb_pojazdy = new System.Windows.Forms.ListBox();
            this.l_aktualny_stan = new System.Windows.Forms.Label();
            this.gb_stan_pojazdu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Zalogowany jako";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pojazdy";
            // 
            // rb_sprawny
            // 
            this.rb_sprawny.AutoSize = true;
            this.rb_sprawny.Location = new System.Drawing.Point(16, 44);
            this.rb_sprawny.Name = "rb_sprawny";
            this.rb_sprawny.Size = new System.Drawing.Size(66, 17);
            this.rb_sprawny.TabIndex = 3;
            this.rb_sprawny.TabStop = true;
            this.rb_sprawny.Text = "Sprawny";
            this.rb_sprawny.UseVisualStyleBackColor = true;
            // 
            // rb_awaria
            // 
            this.rb_awaria.AutoSize = true;
            this.rb_awaria.Location = new System.Drawing.Point(127, 44);
            this.rb_awaria.Name = "rb_awaria";
            this.rb_awaria.Size = new System.Drawing.Size(57, 17);
            this.rb_awaria.TabIndex = 4;
            this.rb_awaria.TabStop = true;
            this.rb_awaria.Text = "Awaria";
            this.rb_awaria.UseVisualStyleBackColor = true;
            // 
            // gb_stan_pojazdu
            // 
            this.gb_stan_pojazdu.Controls.Add(this.rb_awaria);
            this.gb_stan_pojazdu.Controls.Add(this.rb_sprawny);
            this.gb_stan_pojazdu.Location = new System.Drawing.Point(320, 25);
            this.gb_stan_pojazdu.Name = "gb_stan_pojazdu";
            this.gb_stan_pojazdu.Size = new System.Drawing.Size(200, 100);
            this.gb_stan_pojazdu.TabIndex = 5;
            this.gb_stan_pojazdu.TabStop = false;
            this.gb_stan_pojazdu.Text = "Stan pojazdu";
            // 
            // b_kierowca_zapisz
            // 
            this.b_kierowca_zapisz.Location = new System.Drawing.Point(320, 161);
            this.b_kierowca_zapisz.Name = "b_kierowca_zapisz";
            this.b_kierowca_zapisz.Size = new System.Drawing.Size(75, 23);
            this.b_kierowca_zapisz.TabIndex = 6;
            this.b_kierowca_zapisz.Text = "Zapisz";
            this.b_kierowca_zapisz.UseVisualStyleBackColor = true;
            // 
            // b_kierowca_wyjdz
            // 
            this.b_kierowca_wyjdz.Location = new System.Drawing.Point(445, 161);
            this.b_kierowca_wyjdz.Name = "b_kierowca_wyjdz";
            this.b_kierowca_wyjdz.Size = new System.Drawing.Size(75, 23);
            this.b_kierowca_wyjdz.TabIndex = 7;
            this.b_kierowca_wyjdz.Text = "Wyjdź";
            this.b_kierowca_wyjdz.UseVisualStyleBackColor = true;
            // 
            // lb_pojazdy
            // 
            this.lb_pojazdy.FormattingEnabled = true;
            this.lb_pojazdy.Location = new System.Drawing.Point(15, 25);
            this.lb_pojazdy.Name = "lb_pojazdy";
            this.lb_pojazdy.Size = new System.Drawing.Size(120, 199);
            this.lb_pojazdy.TabIndex = 8;
            // 
            // l_aktualny_stan
            // 
            this.l_aktualny_stan.AutoSize = true;
            this.l_aktualny_stan.Location = new System.Drawing.Point(141, 25);
            this.l_aktualny_stan.Name = "l_aktualny_stan";
            this.l_aktualny_stan.Size = new System.Drawing.Size(83, 13);
            this.l_aktualny_stan.TabIndex = 9;
            this.l_aktualny_stan.Text = "Aktualny stan ...";
            // 
            // Kierowca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 261);
            this.Controls.Add(this.l_aktualny_stan);
            this.Controls.Add(this.lb_pojazdy);
            this.Controls.Add(this.b_kierowca_wyjdz);
            this.Controls.Add(this.b_kierowca_zapisz);
            this.Controls.Add(this.gb_stan_pojazdu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Kierowca";
            this.Text = "Kierowca";
            this.gb_stan_pojazdu.ResumeLayout(false);
            this.gb_stan_pojazdu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb_sprawny;
        private System.Windows.Forms.RadioButton rb_awaria;
        private System.Windows.Forms.GroupBox gb_stan_pojazdu;
        private System.Windows.Forms.Button b_kierowca_zapisz;
        private System.Windows.Forms.Button b_kierowca_wyjdz;
        private System.Windows.Forms.ListBox lb_pojazdy;
        private System.Windows.Forms.Label l_aktualny_stan;
    }
}