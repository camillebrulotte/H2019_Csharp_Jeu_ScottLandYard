namespace ScotYard
{
    partial class JeuValidationQuitter
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
            this.BtnValidationNon = new System.Windows.Forms.Button();
            this.BtnValidationOui = new System.Windows.Forms.Button();
            this.LblQuitter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnValidationNon
            // 
            this.BtnValidationNon.BackColor = System.Drawing.Color.DarkGray;
            this.BtnValidationNon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnValidationNon.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValidationNon.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnValidationNon.Location = new System.Drawing.Point(241, 84);
            this.BtnValidationNon.Name = "BtnValidationNon";
            this.BtnValidationNon.Size = new System.Drawing.Size(138, 35);
            this.BtnValidationNon.TabIndex = 233;
            this.BtnValidationNon.Text = "Non";
            this.BtnValidationNon.UseVisualStyleBackColor = false;
            this.BtnValidationNon.Click += new System.EventHandler(this.BtnValidationNonNouvellePartie_Click);
            // 
            // BtnValidationOui
            // 
            this.BtnValidationOui.BackColor = System.Drawing.Color.DarkGray;
            this.BtnValidationOui.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnValidationOui.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValidationOui.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnValidationOui.Location = new System.Drawing.Point(69, 84);
            this.BtnValidationOui.Name = "BtnValidationOui";
            this.BtnValidationOui.Size = new System.Drawing.Size(138, 35);
            this.BtnValidationOui.TabIndex = 232;
            this.BtnValidationOui.Text = "Oui";
            this.BtnValidationOui.UseVisualStyleBackColor = false;
            this.BtnValidationOui.Click += new System.EventHandler(this.BtnValidationOuiQuitter_Click);
            // 
            // LblQuitter
            // 
            this.LblQuitter.AutoSize = true;
            this.LblQuitter.BackColor = System.Drawing.Color.Transparent;
            this.LblQuitter.Font = new System.Drawing.Font("Elephant", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblQuitter.ForeColor = System.Drawing.Color.White;
            this.LblQuitter.Location = new System.Drawing.Point(47, 17);
            this.LblQuitter.Name = "LblQuitter";
            this.LblQuitter.Size = new System.Drawing.Size(363, 60);
            this.LblQuitter.TabIndex = 231;
            this.LblQuitter.Text = "Êtes-vous certain de vouloir \r\nquitter?";
            this.LblQuitter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // JeuValidationQuitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(448, 135);
            this.Controls.Add(this.BtnValidationNon);
            this.Controls.Add(this.BtnValidationOui);
            this.Controls.Add(this.LblQuitter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JeuValidationQuitter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JeuValidationQuitter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnValidationNon;
        private System.Windows.Forms.Button BtnValidationOui;
        private System.Windows.Forms.Label LblQuitter;
    }
}