namespace BD
{
    partial class Pilot
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Nazwa_wycieczki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_odjazdu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_przyjazdu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pojazd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kierowca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drugi_pilot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nazwa_wycieczki,
            this.Data_odjazdu,
            this.Data_przyjazdu,
            this.Pojazd,
            this.Kierowca,
            this.Drugi_pilot});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(651, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Zalogowany jako";
            // 
            // Nazwa_wycieczki
            // 
            this.Nazwa_wycieczki.HeaderText = "Nazwa wycieczki";
            this.Nazwa_wycieczki.Name = "Nazwa_wycieczki";
            // 
            // Data_odjazdu
            // 
            this.Data_odjazdu.HeaderText = "Data odjazdu";
            this.Data_odjazdu.Name = "Data_odjazdu";
            // 
            // Data_przyjazdu
            // 
            this.Data_przyjazdu.HeaderText = "Data przyjazdu";
            this.Data_przyjazdu.Name = "Data_przyjazdu";
            // 
            // Pojazd
            // 
            this.Pojazd.HeaderText = "Pojazd";
            this.Pojazd.Name = "Pojazd";
            // 
            // Kierowca
            // 
            this.Kierowca.HeaderText = "Kierowca";
            this.Kierowca.Name = "Kierowca";
            // 
            // Drugi_pilot
            // 
            this.Drugi_pilot.HeaderText = "Drugi pilot";
            this.Drugi_pilot.Name = "Drugi_pilot";
            // 
            // Pilot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 219);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Pilot";
            this.Text = "Pilot";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa_wycieczki;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_odjazdu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_przyjazdu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pojazd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kierowca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drugi_pilot;
    }
}