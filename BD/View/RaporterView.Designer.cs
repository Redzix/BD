namespace BD.View
{
    partial class RaporterView
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
            this.lb_kolumny = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.b_GenerujRaport = new System.Windows.Forms.Button();
            this.b_DodajKolumny = new System.Windows.Forms.Button();
            this.lv_Sortowanie = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lb_kolumny
            // 
            this.lb_kolumny.FormattingEnabled = true;
            this.lb_kolumny.Location = new System.Drawing.Point(11, 65);
            this.lb_kolumny.Name = "lb_kolumny";
            this.lb_kolumny.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lb_kolumny.Size = new System.Drawing.Size(120, 212);
            this.lb_kolumny.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wybierz kolumny";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ustaw sortowanie";
            // 
            // b_GenerujRaport
            // 
            this.b_GenerujRaport.Location = new System.Drawing.Point(418, 283);
            this.b_GenerujRaport.Name = "b_GenerujRaport";
            this.b_GenerujRaport.Size = new System.Drawing.Size(132, 23);
            this.b_GenerujRaport.TabIndex = 4;
            this.b_GenerujRaport.Text = "Generuj raport";
            this.b_GenerujRaport.UseVisualStyleBackColor = true;
            this.b_GenerujRaport.Click += new System.EventHandler(this.b_GenerujRaport_Click);
            // 
            // b_DodajKolumny
            // 
            this.b_DodajKolumny.Location = new System.Drawing.Point(141, 152);
            this.b_DodajKolumny.Name = "b_DodajKolumny";
            this.b_DodajKolumny.Size = new System.Drawing.Size(21, 23);
            this.b_DodajKolumny.TabIndex = 5;
            this.b_DodajKolumny.Text = ">";
            this.b_DodajKolumny.UseVisualStyleBackColor = true;
            this.b_DodajKolumny.Click += new System.EventHandler(this.b_DodajKolumny_Click);
            // 
            // lv_Sortowanie
            // 
            this.lv_Sortowanie.GridLines = true;
            this.lv_Sortowanie.Location = new System.Drawing.Point(168, 65);
            this.lv_Sortowanie.Name = "lv_Sortowanie";
            this.lv_Sortowanie.Size = new System.Drawing.Size(382, 212);
            this.lv_Sortowanie.TabIndex = 0;
            this.lv_Sortowanie.UseCompatibleStateImageBehavior = false;
            this.lv_Sortowanie.View = System.Windows.Forms.View.Details;
            this.lv_Sortowanie.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_Sortowanie_ColumnClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nazwa raportu";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(166, 20);
            this.textBox1.TabIndex = 7;
            // 
            // RaporterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 317);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.b_DodajKolumny);
            this.Controls.Add(this.b_GenerujRaport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_kolumny);
            this.Controls.Add(this.lv_Sortowanie);
            this.Name = "RaporterView";
            this.Text = "RaporterView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_GenerujRaport;
        private System.Windows.Forms.Button b_DodajKolumny;
        public System.Windows.Forms.ListBox lb_kolumny;
        public System.Windows.Forms.ListView lv_Sortowanie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}