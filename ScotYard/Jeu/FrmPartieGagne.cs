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
    /// Cette classe permet de signaler au joueur qu'il a gagné.
    /// </summary>
    public partial class PartieGagne : Form
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        public PartieGagne()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fermer le form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOkGagne_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
