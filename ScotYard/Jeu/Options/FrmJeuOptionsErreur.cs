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
    /// Signaler au joueur que ce n'est pas tous les champs
    /// qui ont étés remplis.
    /// </summary>
    public partial class JeuOptionsErreur : Form
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public JeuOptionsErreur()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ferme le form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
