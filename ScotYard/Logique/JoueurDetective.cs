using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScotYard
{
    /// <summary>
    /// Cette classe permet d'obtenir les informations sur les détectives.
    /// </summary>
    public class JoueurDetective : Joueur
    {
        public static int StationClique { get; set; }
        public static Random NombreAleatoire = new Random();

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="NomDetective"></param>
        /// <param name="CouleurDetective"></param>
        /// <param name="PositionDetective"></param>
        public JoueurDetective(string NomDetective, Color CouleurDetective, int PositionDetective) : base(NomDetective, CouleurDetective, PositionDetective)
        {
            Nom = NomDetective;
            Couleur = CouleurDetective;
            Position = PositionDetective;

            this.TicketTaxis = 10;
            this.TicketMetro = 4;
            this.TicketBus = 8;
        }

        /// <summary>
        /// Création des trois détectives.
        /// </summary>
        /// <returns></returns>
        public static List<JoueurDetective> RemplirListeDetective()
        {
            List<JoueurDetective> ListeTempDetective = new List<JoueurDetective>();
            
            int PositionDetective1 = 0, PositionDetective2 = 0, PositionDetective3 = 0;

            PositionDetective1 = NombreAleatoire.Next(1, 199);
            ListeTempDetective.Add(new JoueurDetective("Turquoise", Color.Turquoise, PositionDetective1));

            do
            {
                PositionDetective2 = NombreAleatoire.Next(1, 199);
            } while (PositionDetective2 == PositionDetective1);
            ListeTempDetective.Add(new JoueurDetective("Lime", Color.Lime, PositionDetective2));

            do
            {
                PositionDetective3 = NombreAleatoire.Next(1, 199);
            } while (PositionDetective3 == PositionDetective1 || PositionDetective3 == PositionDetective2);
            PositionDetective3 = NombreAleatoire.Next(1, 199);
            ListeTempDetective.Add(new JoueurDetective("Magenta", Color.Magenta, PositionDetective3));

            return ListeTempDetective;
        }

        /// <summary>
        /// Permet de vider la liste.
        /// </summary>
        /// <param name="listeDetective"></param>
        public static void ViderListeDetective(List<JoueurDetective> listeDetective)
        {
            listeDetective.Clear();
        }
    
        /// <summary>
        /// Lorsque le détective change de station.
        /// </summary>
        /// <param name="tourActuel"></param>
        /// <param name="listeDetective"></param>
        /// <param name="listeBoutons"></param>
        /// <param name="lblNombreTaxisDetective"></param>
        /// <param name="pibDetective"></param>
        /// <param name="nouvellePosition"></param>
        /// <param name="lblPositionDetective"></param>
        /// <param name="ticket"></param>
        internal static void ActionChangementStationDetective(TourDeQuelJoueur tourActuel, List<JoueurDetective> listeDetective, List<Button> listeBoutons, Label lblNombreTaxisDetective, PictureBox pibDetective, int nouvellePosition, Label lblPositionDetective, int ticket)
        {
            lblNombreTaxisDetective.Text = ticket.ToString();

            ///Position 
            pibDetective.Location = new Point((listeBoutons[nouvellePosition].Location.X) + 24, (listeBoutons[nouvellePosition].Location.Y) + 8);
            lblPositionDetective.Text = nouvellePosition.ToString();

            listeDetective[(int)tourActuel].Position = nouvellePosition;
        }  
    }
}
