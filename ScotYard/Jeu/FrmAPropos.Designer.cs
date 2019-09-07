namespace ScotYard
{
    partial class JeuAPropos
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
            this.BtnOk = new System.Windows.Forms.Button();
            this.LblAPropos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.DarkGray;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Font = new System.Drawing.Font("Elephant", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnOk.Location = new System.Drawing.Point(148, 93);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(138, 35);
            this.BtnOk.TabIndex = 217;
            this.BtnOk.Text = "Ok";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // LblAPropos
            // 
            this.LblAPropos.AutoSize = true;
            this.LblAPropos.BackColor = System.Drawing.Color.MidnightBlue;
            this.LblAPropos.Font = new System.Drawing.Font("Elephant", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAPropos.ForeColor = System.Drawing.Color.DarkGray;
            this.LblAPropos.Location = new System.Drawing.Point(14, 9);
            this.LblAPropos.Name = "LblAPropos";
            this.LblAPropos.Size = new System.Drawing.Size(417, 81);
            this.LblAPropos.TabIndex = 229;
            this.LblAPropos.Text = "Cette   reproduction  du  jeu  ScotLand \r\nYard a été réalisé par Camille Brulotte" +
    ".\r\nLa   remise  de  ce projet est le 18 Mars.";
            this.LblAPropos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // JeuAPropos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(448, 135);
            this.Controls.Add(this.LblAPropos);
            this.Controls.Add(this.BtnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JeuAPropos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "JeuAPropos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Label LblAPropos;
    }
}