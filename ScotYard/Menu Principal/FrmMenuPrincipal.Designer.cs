namespace ScotYard
{
    partial class JeuMenuPrincipal
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
            this.LblJouer = new System.Windows.Forms.Label();
            this.LblRegles = new System.Windows.Forms.Label();
            this.LblQuitter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblJouer
            // 
            this.LblJouer.AutoSize = true;
            this.LblJouer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblJouer.Font = new System.Drawing.Font("Elephant", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJouer.Location = new System.Drawing.Point(298, 489);
            this.LblJouer.Name = "LblJouer";
            this.LblJouer.Size = new System.Drawing.Size(103, 93);
            this.LblJouer.TabIndex = 0;
            this.LblJouer.Text = "\r\n Jouer  \r\n\r\n";
            this.LblJouer.Click += new System.EventHandler(this.LblJouer_Click);
            // 
            // LblRegles
            // 
            this.LblRegles.AutoSize = true;
            this.LblRegles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblRegles.Font = new System.Drawing.Font("Elephant", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRegles.Location = new System.Drawing.Point(501, 619);
            this.LblRegles.Name = "LblRegles";
            this.LblRegles.Size = new System.Drawing.Size(119, 31);
            this.LblRegles.TabIndex = 1;
            this.LblRegles.Text = "  Règles  ";
            this.LblRegles.Click += new System.EventHandler(this.LblRegles_Click);
            // 
            // LblQuitter
            // 
            this.LblQuitter.AutoSize = true;
            this.LblQuitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblQuitter.Font = new System.Drawing.Font("Elephant", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblQuitter.Location = new System.Drawing.Point(719, 514);
            this.LblQuitter.Name = "LblQuitter";
            this.LblQuitter.Size = new System.Drawing.Size(123, 93);
            this.LblQuitter.TabIndex = 0;
            this.LblQuitter.Text = "\r\n Quitter  \r\n   \r\n";
            this.LblQuitter.Click += new System.EventHandler(this.LblOptions_Click);
            // 
            // JeuMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImage = global::ScotYard.Properties.Resources.ScotlandYardBoard1;
            this.ClientSize = new System.Drawing.Size(984, 717);
            this.Controls.Add(this.LblQuitter);
            this.Controls.Add(this.LblRegles);
            this.Controls.Add(this.LblJouer);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JeuMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblJouer;
        private System.Windows.Forms.Label LblRegles;
        private System.Windows.Forms.Label LblQuitter;
    }
}