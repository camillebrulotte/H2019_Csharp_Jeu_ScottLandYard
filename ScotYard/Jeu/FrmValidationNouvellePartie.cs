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
    /// Cette classe permet de valider que le joueur souhaite vraiment démarrer une nouvelle partie.
    /// </summary>
    public partial class JeuValidationNouvellePartie : Form
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public JeuValidationNouvellePartie()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Si le joueur souhaite démarrer une nouvelle partie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnValidationOui_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        /// <summary>
        /// Si le joueur ne souhaite plus démarrer une nouvelle partie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnValidationNon_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
