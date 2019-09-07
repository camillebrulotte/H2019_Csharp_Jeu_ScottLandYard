namespace ScotYard
{
    partial class JeuValidationNouvellePartie
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
            this.LblNouvellePartie = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnValidationNon
            // 
            this.BtnValidationNon.BackColor = System.Drawing.Color.DarkGray;
            this.BtnValidationNon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnValidationNon.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValidationNon.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnValidationNon.Location = new System.Drawing.Point(237, 83);
            this.BtnValidationNon.Name = "BtnValidationNon";
            this.BtnValidationNon.Size = new System.Drawing.Size(138, 35);
            this.BtnValidationNon.TabIndex = 236;
            this.BtnValidationNon.Text = "Non";
            this.BtnValidationNon.UseVisualStyleBackColor = false;
            this.BtnValidationNon.Click += new System.EventHandler(this.BtnValidationNon_Click);
            // 
            // BtnValidationOui
            // 
            this.BtnValidationOui.BackColor = System.Drawing.Color.DarkGray;
            this.BtnValidationOui.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnValidationOui.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValidationOui.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnValidationOui.Location = new System.Drawing.Point(65, 83);
            this.BtnValidationOui.Name = "BtnValidationOui";
            this.BtnValidationOui.Size = new System.Drawing.Size(138, 35);
            this.BtnValidationOui.TabIndex = 235;
            this.BtnValidationOui.Text = "Oui";
            this.BtnValidationOui.UseVisualStyleBackColor = false;
            this.BtnValidationOui.Click += new System.EventHandler(this.BtnValidationOui_Click);
            // 
            // LblNouvellePartie
            // 
            this.LblNouvellePartie.AutoSize = true;
            this.LblNouvellePartie.BackColor = System.Drawing.Color.Transparent;
            this.LblNouvellePartie.Font = new System.Drawing.Font("Elephant", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNouvellePartie.ForeColor = System.Drawing.Color.White;
            this.LblNouvellePartie.Location = new System.Drawing.Point(25, 16);
            this.LblNouvellePartie.Name = "LblNouvellePartie";
            this.LblNouvellePartie.Size = new System.Drawing.Size(388, 60);
            this.LblNouvellePartie.TabIndex = 234;
            this.LblNouvellePartie.Text = "Désirez-vous \r\ndémarrer une nouvelle partie?";
            this.LblNouvellePartie.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // JeuValidationNouvellePartie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(438, 135);
            this.Controls.Add(this.BtnValidationNon);
            this.Controls.Add(this.BtnValidationOui);
            this.Controls.Add(this.LblNouvellePartie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JeuValidationNouvellePartie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JeuValidationNouvellePartie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnValidationNon;
        private System.Windows.Forms.Button BtnValidationOui;
        private System.Windows.Forms.Label LblNouvellePartie;
    }
}