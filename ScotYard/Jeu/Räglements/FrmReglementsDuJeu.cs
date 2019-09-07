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
    /// Cette classe permet au joueur de lire les règlements du jeu.
    /// </summary>
    public partial class JeuRegles : Form
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        public JeuRegles()
        {
            InitializeComponent();
            PibPlateauDuJeu.BringToFront();
            PibPlateauDuJeu.Visible = true;
        }

        /// <summary>
        /// Affiche le plateau du jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlateauDuJeu_Click(object sender, EventArgs e)
        {
            PnlCote.Height = BtnPlateauDuJeu.Height;
            PnlCote.Top = BtnPlateauDuJeu.Top;
            PibPlateauDuJeu.Visible = true;
        }

        /// <summary>
        /// Affiche les composants du jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnComposants_Click(object sender, EventArgs e)
        {
            PnlCote.Height = BtnComposants.Height;
            PnlCote.Top = BtnComposants.Top;

            PibPlateauDuJeu.Visible = false;
            PibComposants.Visible = true;
            PibConseilsTactiques.Visible = false;
            PibCoupsSpeciaux.Visible = false;
            PibFinDuJeu.Visible = false;
            PibPlateauDuJeu.Visible = false;
            PibPreparation.Visible = false;
            PibTourDeJeu1.Visible = false;
        }

        /// <summary>
        /// Affiche la préparation du jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPreparation_Click(object sender, EventArgs e)
        {
            PnlCote.Height = BtnPreparation.Height;
            PnlCote.Top = BtnPreparation.Top;

            PibPlateauDuJeu.Visible = false;
            PibComposants.Visible = false;
            PibConseilsTactiques.Visible = false;
            PibCoupsSpeciaux.Visible = false;
            PibFinDuJeu.Visible = false;
            PibPlateauDuJeu.Visible = false;
            PibPreparation.Visible = true;
            PibTourDeJeu1.Visible = false;
        }

        /// <summary>
        /// Explique le tour de jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTourDeJeu_Click(object sender, EventArgs e)
        {
            PnlCote.Height = BtnPlateauDuJeu.Height;
            PnlCote.Top = BtnTourDeJeu.Top;

            PibPlateauDuJeu.Visible = false;
            PibComposants.Visible = false;
            PibConseilsTactiques.Visible = false;
            PibCoupsSpeciaux.Visible = false;
            PibFinDuJeu.Visible = false;
            PibPlateauDuJeu.Visible = false;
            PibPreparation.Visible = false;
            PibTourDeJeu1.Visible = true;
        }

        /// <summary>
        /// Affiche les coups spéciaux de MisterX.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCoupsSpeciaux_Click(object sender, EventArgs e)
        {
            PnlCote.Height = BtnCoupsSpeciaux.Height;
            PnlCote.Top = BtnCoupsSpeciaux.Top;

            PibPlateauDuJeu.Visible = false;
            PibComposants.Visible = false;
            PibConseilsTactiques.Visible = false;
            PibCoupsSpeciaux.Visible = true;
            PibFinDuJeu.Visible = false;
            PibPlateauDuJeu.Visible = false;
            PibPreparation.Visible = false;
            PibTourDeJeu1.Visible = false;
        }

        /// <summary>
        /// Affiche les indications lors de la fin du jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFinDuJeu_Click(object sender, EventArgs e)
        {
            PnlCote.Height = BtnFinDuJeu.Height;
            PnlCote.Top = BtnFinDuJeu.Top;

            PibPlateauDuJeu.Visible = false;
            PibComposants.Visible = false;
            PibConseilsTactiques.Visible = false;
            PibCoupsSpeciaux.Visible = false;
            PibFinDuJeu.Visible = true;
            PibPlateauDuJeu.Visible = false;
            PibPreparation.Visible = false;
            PibTourDeJeu1.Visible = false;
        }

        /// <summary>
        /// Affiche les conceils et tactiques.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConseilsTactiques_Click(object sender, EventArgs e)
        {
            PnlCote.Height = BtnConseilsTactiques.Height;
            PnlCote.Top = BtnConseilsTactiques.Top;

            PibPlateauDuJeu.Visible = false;
            PibComposants.Visible = false;
            PibConseilsTactiques.Visible = true;
            PibCoupsSpeciaux.Visible = false;
            PibFinDuJeu.Visible = false;
            PibPlateauDuJeu.Visible = false;
            PibPreparation.Visible = false;
            PibTourDeJeu1.Visible = false;
        }

        /// <summary>
        /// Permet de retourner au form précédent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
