﻿namespace BD
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
            this.lv_pojazdy = new System.Windows.Forms.ListView();
            this.Nr_rejestracyjny = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dostępność = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Marka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pojemność = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.label2.Location = new System.Drawing.Point(136, 9);
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
            this.b_kierowca_wyjdz.Click += new System.EventHandler(this.b_kierowca_wyjdz_Click);
            // 
            // lv_pojazdy
            // 
            this.lv_pojazdy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nr_rejestracyjny,
            this.Dostępność,
            this.Marka,
            this.Pojemność,
            this.Stan});
            this.lv_pojazdy.Location = new System.Drawing.Point(15, 25);
            this.lv_pojazdy.Name = "lv_pojazdy";
            this.lv_pojazdy.Size = new System.Drawing.Size(299, 211);
            this.lv_pojazdy.TabIndex = 10;
            this.lv_pojazdy.UseCompatibleStateImageBehavior = false;
            // 
            // Kierowca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 261);
            this.Controls.Add(this.lv_pojazdy);
            this.Controls.Add(this.b_kierowca_wyjdz);
            this.Controls.Add(this.b_kierowca_zapisz);
            this.Controls.Add(this.gb_stan_pojazdu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Kierowca";
            this.Text = "Kierowca";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kierowca_FormClosing);
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
        private System.Windows.Forms.ListView lv_pojazdy;
        private System.Windows.Forms.ColumnHeader Nr_rejestracyjny;
        private System.Windows.Forms.ColumnHeader Dostępność;
        private System.Windows.Forms.ColumnHeader Marka;
        private System.Windows.Forms.ColumnHeader Pojemność;
        private System.Windows.Forms.ColumnHeader Stan;
    }
}