using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScotYard
{
    /// <summary>
    /// Cette classe permet d'afficher le à propos.
    /// </summary>
    public partial class JeuAPropos : Form
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public JeuAPropos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fermer le form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
