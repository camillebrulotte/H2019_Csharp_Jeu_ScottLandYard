namespace ScotYard
{
    partial class PartiePerdue
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
            this.LblPerdu = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblPerdu
            // 
            this.LblPerdu.AutoSize = true;
            this.LblPerdu.BackColor = System.Drawing.Color.DarkGray;
            this.LblPerdu.Font = new System.Drawing.Font("Elephant", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPerdu.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LblPerdu.Location = new System.Drawing.Point(47, 8);
            this.LblPerdu.Name = "LblPerdu";
            this.LblPerdu.Size = new System.Drawing.Size(338, 82);
            this.LblPerdu.TabIndex = 234;
            this.LblPerdu.Text = "Meilleure chance la \r\nprochaine fois ...";
            this.LblPerdu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.MidnightBlue;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Font = new System.Drawing.Font("Elephant", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.ForeColor = System.Drawing.Color.DarkGray;
            this.BtnOk.Location = new System.Drawing.Point(133, 108);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(138, 35);
            this.BtnOk.TabIndex = 233;
            this.BtnOk.Text = "Ok";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOkPerdu_Click);
            // 
            // PartiePerdue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(437, 148);
            this.Controls.Add(this.LblPerdu);
            this.Controls.Add(this.BtnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PartiePerdue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PartiPerdue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblPerdu;
        private System.Windows.Forms.Button BtnOk;
    }
}