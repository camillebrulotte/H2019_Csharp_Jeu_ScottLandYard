using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ScotYard { 

    /// <summary>
    /// Pour savoir quel joueur joue.
    /// </summary>
    public enum TourDeQuelJoueur
    {
        MisterX = -1,
        Detective1 = 0,
        Detective2 = 1,
        Detective3 = 2
    }

    /// <summary>
    /// Cette classe abstraite permet de relier les informations qui sont semblables pour le voleur et les détectives.
    /// </summary>
    public abstract class Joueur
    {
        public string Nom { get; set; }
        public Color Couleur { get; set; }
        public int Position { get; set; }
        public int TicketBus { get; set; }
        public int TicketMetro { get; set; }
        public int TicketTaxis { get; set; }
        

        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public Joueur()
        {
        }

       /// <summary>
       /// Constructeur.
       /// </summary>
       /// <param name="nom"></param>
       /// <param name="couleur"></param>
       /// <param name="position"></param>
        public Joueur(string nom, Color couleur, int position)
        {
            this.Nom = nom;
            this.Couleur = couleur;
            this.Position = position;
        }

        /// <summary>
        /// Permet de rafraîchir le nombre de tours qu'il reste au jeu.
        /// </summary>
        /// <param name="compteurTourRestant"></param>
        /// <param name="pnlNombreDeToursRestant"></param>
        /// <param name="lblNombreTours"></param>
        public static void RafraichirLabelNombreTours(int compteurTourRestant, System.Windows.Forms.Panel pnlNombreDeToursRestant, System.Windows.Forms.Label lblNombreTours)
        {
            lblNombreTours.Location = new Point(((pnlNombreDeToursRestant.Size.Width - lblNombreTours.Size.Width) / 2), lblNombreTours.Location.Y);
            lblNombreTours.Text = compteurTourRestant.ToString();
        }
    }
}
