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
            this.label3 = new System.Windows.Forms.Label();
            this.tb_kwota = new System.Windows.Forms.TextBox();
            this.b_dodaj = new System.Windows.Forms.Button();
            this.b_edytuj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kwota promocyjna";
            // 
            // tb_kwota
            // 
            this.tb_kwota.Location = new System.Drawing.Point(110, 12);
            this.tb_kwota.Name = "tb_kwota";
            this.tb_kwota.Size = new System.Drawing.Size(102, 20);
            this.tb_kwota.TabIndex = 5;
            this.tb_kwota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_kwota_KeyPress);
            // 
            // b_dodaj
            // 
            this.b_dodaj.Location = new System.Drawing.Point(12, 43);
            this.b_dodaj.Name = "b_dodaj";
            this.b_dodaj.Size = new System.Drawing.Size(200, 23);
            this.b_dodaj.TabIndex = 7;
            this.b_dodaj.Text = "Dodaj promocję";
            this.b_dodaj.UseVisualStyleBackColor = true;
            this.b_dodaj.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_edytuj
            // 
            this.b_edytuj.Location = new System.Drawing.Point(12, 43);
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
            this.ClientSize = new System.Drawing.Size(226, 78);
            this.Controls.Add(this.b_edytuj);
            this.Controls.Add(this.b_dodaj);
            this.Controls.Add(this.tb_kwota);
            this.Controls.Add(this.label3);
            this.Name = "PromocjaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Promocja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tb_kwota;
        public System.Windows.Forms.Button b_dodaj;
        public System.Windows.Forms.Button b_edytuj;
    }
}