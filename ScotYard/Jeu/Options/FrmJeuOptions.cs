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
    /// Cette classe permet de setter le nom des pions et leur couleur.
    /// </summary>
    public partial class JeuOptions : Form
    {
        List<JoueurDetective> ListeTempDetective;

        /// <summary>
        /// Constructeur.
        /// </summary>
        public JeuOptions (List<JoueurDetective> ListeDetective)
        {
            InitializeComponent();
            ListeTempDetective = ListeDetective;

            ///Initialisation de l'affichage des informations des détectives
            TxtDetective1.Text = ListeTempDetective[0].Nom;
            string CouleurDetective1 = ListeTempDetective[0].Couleur.Name;
            CboDetective1.Text = CouleurDetective1;

            TxtDetective2.Text = ListeTempDetective[1].Nom;
            string CouleurDetective2 = ListeTempDetective[1].Couleur.Name;
            CboDetective2.Text = CouleurDetective2;

            TxtDetective3.Text = ListeTempDetective[2].Nom;
            string CouleurDetective3 = ListeTempDetective[2].Couleur.Name;
            CboDetective3.Text = CouleurDetective3;
        }

        /// <summary>
        /// Retourne à la fenêtre précédente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Permet d'enregistrer les changements.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnregistrer_Click_1(object sender, EventArgs e)
        {
            if (TxtDetective1.Text != "" && TxtDetective2.Text != "" && TxtDetective3.Text != "" && CboDetective1.SelectedIndex != -1 && CboDetective2.SelectedIndex != -1 && CboDetective3.SelectedIndex != -1)
            {
                ListeTempDetective[0].Nom = TxtDetective1.Text;
                ListeTempDetective[0].Couleur = Color.FromName(CboDetective1.Text);
                TxtDetective1.Text = ListeTempDetective[0].Nom;
                CboDetective1.Text = CboDetective1.Text;

                ListeTempDetective[1].Nom = TxtDetective2.Text;
                ListeTempDetective[1].Couleur = Color.FromName(CboDetective2.Text);
                TxtDetective2.Text = ListeTempDetective[1].Nom;
                CboDetective2.Text = CboDetective2.Text;

                ListeTempDetective[2].Nom = TxtDetective3.Text;
                ListeTempDetective[2].Couleur = Color.FromName(CboDetective3.Text);
                TxtDetective3.Text = ListeTempDetective[2].Nom;
                CboDetective3.Text = CboDetective3.Text;

                this.Close();
            }
            else
            {
                JeuOptionsErreur MessageErreur = new JeuOptionsErreur();
                MessageErreur.Show();
            }
        }

        /// <summary>
        /// Obliger la première lettre d'être une majuscule.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtDetective1_TextChanged_1(object sender, EventArgs e)
        {
            TxtDetective1.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.TxtDetective1.Text);
            TxtDetective1.Select(TxtDetective1.Text.Length, 0);
        }

        /// <summary>
        /// Obliger la première lettre d'être une majuscule.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtDetective2_TextChanged_1(object sender, EventArgs e)
        {
            TxtDetective2.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.TxtDetective2.Text);
            TxtDetective2.Select(TxtDetective2.Text.Length, 0);
        }

        /// <summary>
        /// Obliger la première lettre d'être une majuscule.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtDetective3_TextChanged_1(object sender, EventArgs e)
        {
            TxtDetective3.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.TxtDetective3.Text);
            TxtDetective3.Select(TxtDetective3.Text.Length, 0);
        }
    }
}
