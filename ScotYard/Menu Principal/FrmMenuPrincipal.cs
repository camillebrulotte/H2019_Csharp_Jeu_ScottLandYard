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
    /// Cette classe permet de gérer le menu principal.
    /// </summary>
    public partial class JeuMenuPrincipal : Form
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        public JeuMenuPrincipal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Permet de démarrer une partie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblJouer_Click(object sender, EventArgs e)
        {
            JeuFenetre jeuPanel = new JeuFenetre();
            jeuPanel.ShowDialog();
        }

        /// <summary>
        /// Permet de voir les réglements du jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblRegles_Click(object sender, EventArgs e)
        {
            JeuRegles jeuRegles = new JeuRegles();
            jeuRegles.ShowDialog();
        }

        /// <summary>
        /// Permet de quitter le jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblOptions_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
