namespace ScotYard
{
    partial class JeuOptionsErreur
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
            this.LblErreur = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblErreur
            // 
            this.LblErreur.AutoSize = true;
            this.LblErreur.BackColor = System.Drawing.Color.MidnightBlue;
            this.LblErreur.Font = new System.Drawing.Font("Elephant", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblErreur.ForeColor = System.Drawing.Color.DarkGray;
            this.LblErreur.Location = new System.Drawing.Point(7, 7);
            this.LblErreur.Name = "LblErreur";
            this.LblErreur.Size = new System.Drawing.Size(435, 27);
            this.LblErreur.TabIndex = 231;
            this.LblErreur.Text = "Assurez-vous de remplir tous les champs.";
            this.LblErreur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.DarkGray;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Font = new System.Drawing.Font("Elephant", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnOk.Location = new System.Drawing.Point(151, 39);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(138, 35);
            this.BtnOk.TabIndex = 230;
            this.BtnOk.Text = "Ok";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // JeuOptionsErreur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(448, 83);
            this.Controls.Add(this.LblErreur);
            this.Controls.Add(this.BtnOk);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JeuOptionsErreur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OptionOk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblErreur;
        private System.Windows.Forms.Button BtnOk;
    }
}