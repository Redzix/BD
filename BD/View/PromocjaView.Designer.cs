namespace BD.View
{
    partial class PromocjaView
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
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_termin_start = new System.Windows.Forms.DateTimePicker();
            this.tb_kwota = new System.Windows.Forms.TextBox();
            this.dtp_termin_koniec = new System.Windows.Forms.DateTimePicker();
            this.b_dodaj = new System.Windows.Forms.Button();
            this.b_edytuj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Termin początku";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Termin końca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kwota promocyjna";
            // 
            // dtp_termin_start
            // 
            this.dtp_termin_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_termin_start.Location = new System.Drawing.Point(116, 15);
            this.dtp_termin_start.Name = "dtp_termin_start";
            this.dtp_termin_start.Size = new System.Drawing.Size(102, 20);
            this.dtp_termin_start.TabIndex = 3;
            // 
            // tb_kwota
            // 
            this.tb_kwota.Location = new System.Drawing.Point(116, 67);
            this.tb_kwota.Name = "tb_kwota";
            this.tb_kwota.Size = new System.Drawing.Size(102, 20);
            this.tb_kwota.TabIndex = 5;
            // 
            // dtp_termin_koniec
            // 
            this.dtp_termin_koniec.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_termin_koniec.Location = new System.Drawing.Point(116, 41);
            this.dtp_termin_koniec.Name = "dtp_termin_koniec";
            this.dtp_termin_koniec.Size = new System.Drawing.Size(102, 20);
            this.dtp_termin_koniec.TabIndex = 6;
            // 
            // b_dodaj
            // 
            this.b_dodaj.Location = new System.Drawing.Point(18, 98);
            this.b_dodaj.Name = "b_dodaj";
            this.b_dodaj.Size = new System.Drawing.Size(200, 23);
            this.b_dodaj.TabIndex = 7;
            this.b_dodaj.Text = "Dodaj promocję";
            this.b_dodaj.UseVisualStyleBackColor = true;
            this.b_dodaj.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_edytuj
            // 
            this.b_edytuj.Location = new System.Drawing.Point(18, 98);
            this.b_edytuj.Name = "b_edytuj";
            this.b_edytuj.Size = new System.Drawing.Size(200, 23);
            this.b_edytuj.TabIndex = 8;
            this.b_edytuj.Text = "Edytuj promocję";
            this.b_edytuj.UseVisualStyleBackColor = true;
            this.b_edytuj.Click += new System.EventHandler(this.b_edytuj_Click);
            // 
            // PromocjaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 133);
            this.Controls.Add(this.b_edytuj);
            this.Controls.Add(this.b_dodaj);
            this.Controls.Add(this.dtp_termin_koniec);
            this.Controls.Add(this.tb_kwota);
            this.Controls.Add(this.dtp_termin_start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PromocjaView";
            this.Text = "Promocja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtp_termin_start;
        public System.Windows.Forms.TextBox tb_kwota;
        public System.Windows.Forms.DateTimePicker dtp_termin_koniec;
        public System.Windows.Forms.Button b_dodaj;
        public System.Windows.Forms.Button b_edytuj;
    }
}