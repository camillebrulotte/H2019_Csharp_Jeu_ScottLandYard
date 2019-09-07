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
    /// Cette classe permet de valider que le joueur souhaite vraiment quitter le jeu.
    /// </summary>
    public partial class JeuValidationQuitter : Form
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public JeuValidationQuitter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ferme le jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnValidationOuiQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Ferme le form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnValidationNonNouvellePartie_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
