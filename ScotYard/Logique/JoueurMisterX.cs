using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScotYard
{
    /// <summary>
    /// Cette classe permet d'obtenir les informations nécessaires du voleur.
    /// </summary>
    public class JoueurMisterX : Joueur
    {
        public int TicketNoir { get; set; }
        public List<JoueurDetective> listeDetective;
        public static int CompteurTicketsMisterX { get; set; } = 1;
        public static ScotAI.Transports TicketUtiliseMisterX { get; set; }
        public static int CompteurPictureBox { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="NomJoueur"></param>
        /// <param name="CouleurJoueur"></param>
        /// <param name="PositionJoueur"></param>
        public JoueurMisterX(string NomJoueur, Color CouleurJoueur, int PositionJoueur) : base("Mister X", Color.DarkGray, PositionJoueur)
        {
            Nom = NomJoueur;
            Couleur = CouleurJoueur;
            Position = PositionJoueur;
        }

        /// <summary>
        /// Setter la position de départ de misterX.
        /// </summary>
        /// <param name="listeDetective"></param>
        /// <returns></returns>
        public static JoueurMisterX RemplirDonneesMisterX(List<JoueurDetective> listeDetective)
        {
            JoueurMisterX TempMisterX;
            Random NombreAleatoire = new Random();
            int PositionMisterX = 0;

            do
            {
                PositionMisterX = NombreAleatoire.Next(1, 199);
            } while (listeDetective[0].Position == PositionMisterX ||
                        listeDetective[1].Position == PositionMisterX ||
                        listeDetective[2].Position == PositionMisterX);

            TempMisterX = new JoueurMisterX("Mister X", Color.DarkGray, PositionMisterX);

            return TempMisterX;
        }

        /// <summary>
        /// Initialiser les tickets de MisterX.
        /// </summary>
        public static void InitialisationMisterX(JoueurMisterX misterX, System.Windows.Forms.PictureBox pibMisterX)
        {
            misterX.TicketTaxis = 4;
            misterX.TicketMetro = 3;
            misterX.TicketBus = 3;
            misterX.TicketNoir = 3;

            ///Cacher son pion
            pibMisterX.Hide();
        }

        /// <summary>
        /// MisterX joue sa partie.
        /// </summary>
        /// <param name="misterX"></param>
        /// <param name="listeDetective"></param>
        /// <param name="lblNombreTaxisMisterX"></param>
        /// <param name="lblNombreBusMisterX"></param>
        /// <param name="lblNombreMetroMisterX"></param>
        /// <param name="lblNombreNoirMisterX"></param>
        /// <param name="listeTicketsMisterX"></param>
        /// <param name="compteurTourRestant"></param>
        /// <param name="listeBoutons"></param>
        /// <param name="pibMisterX"></param>
        public static void TourDeMisterX(JoueurMisterX misterX, List<JoueurDetective> listeDetective,
            Label lblNombreTaxisMisterX, Label lblNombreBusMisterX, Label lblNombreMetroMisterX, Label
            lblNombreNoirMisterX, List<PictureBox> listeTicketsMisterX, int compteurTourRestant,
            List<Button> listeBoutons, PictureBox pibMisterX, PictureBox pibTourDetective2, PictureBox pibTourDetective3)
        {
            ///Position des joueurs
            int PositionMisterX = misterX.Position;
            int PositionDetective1 = listeDetective[0].Position;
            int PositionDetective2 = listeDetective[1].Position;
            int PositionDetective3 = listeDetective[2].Position;

            ScotAI.Transports? transportChoisi = null;
            bool? utiliseFrime = null;

            ///Savoir la position du voleur
            int NumeroCase = ScotAI.Case.ProchaineCaseVoleur(true, PositionMisterX, Int32.Parse(lblNombreTaxisMisterX.Text),
                Int32.Parse(lblNombreBusMisterX.Text), Int32.Parse(lblNombreMetroMisterX.Text),
                Int32.Parse(lblNombreNoirMisterX.Text), out transportChoisi, out utiliseFrime,
                PositionDetective1, PositionDetective2, PositionDetective3);

            //Nouvelle position MisterX
            misterX.Position = NumeroCase;

            ///Setter le ticket qu'il a utilisé
            JoueurMisterX.TicketUtiliseMisterX = (ScotAI.Transports)transportChoisi;

            ///Met à jour les tickets de Mister X
            if (JoueurMisterX.TicketUtiliseMisterX == ScotAI.Transports.Taxi)
            {
                misterX.TicketTaxis--;
                lblNombreTaxisMisterX.Text = misterX.TicketTaxis.ToString();
                listeTicketsMisterX[CompteurPictureBox].Image = Properties.Resources.TicketTaxi;
            }
            else if (JoueurMisterX.TicketUtiliseMisterX == ScotAI.Transports.Bus)
            {
                misterX.TicketBus--;
                lblNombreBusMisterX.Text = misterX.TicketBus.ToString();
                listeTicketsMisterX[CompteurPictureBox].Image = Properties.Resources.TicketBus;
            }
            else if (JoueurMisterX.TicketUtiliseMisterX == ScotAI.Transports.Metro)
            {
                misterX.TicketMetro--;
                lblNombreMetroMisterX.Text = misterX.TicketMetro.ToString();
                listeTicketsMisterX[CompteurPictureBox].Image = Properties.Resources.TicketMetro;
            }
            else if (JoueurMisterX.TicketUtiliseMisterX == ScotAI.Transports.Bateau)
            {
                misterX.TicketNoir--;
                lblNombreNoirMisterX.Text = misterX.TicketNoir.ToString();
                listeTicketsMisterX[CompteurPictureBox].Image = Properties.Resources.TicketNoir;
            }
            
            CompteurPictureBox = JoueurMisterX.CompteurTicketsMisterX++;

            ///Affiche, s'il le faut, la position de MisterX sur la planche
            if (compteurTourRestant == 3 || compteurTourRestant == 8 || compteurTourRestant == 13 || compteurTourRestant == 18)
            {
                PositionMisterX = misterX.Position;
                pibMisterX.Location = new Point((listeBoutons[PositionMisterX].Location.X) + 24, (listeBoutons[PositionMisterX].Location.Y) + 8);
                pibMisterX.Show();
            }
            else
            {
                pibMisterX.Hide();
            }

            pibTourDetective2.Hide();
            pibTourDetective3.Hide();
        }

        /// <summary>
        /// Lorsque le détective joue, il doit ensuite donner son ticket de taxis à MisterX.
        /// </summary>
        /// <param name="misterX"></param>
        /// <param name="lblNombreTaxisMisterX"></param>
        public static void DonnerTicketTaxisMisterX(JoueurMisterX misterX, Label lblNombreTaxisMisterX)
        {
            misterX.TicketTaxis++;
            lblNombreTaxisMisterX.Text = misterX.TicketTaxis.ToString();

            misterX.TicketTaxis = Int32.Parse(lblNombreTaxisMisterX.Text);
        }

        /// <summary>
        /// Lorsque le détective joue, il doit ensuite donner son ticket de bus à MisterX.
        /// </summary>
        /// <param name="misterX"></param>
        /// <param name="lblNombreBusMisterX"></param>
        internal static void DonnerTicketBusMisterX(JoueurMisterX misterX, Label lblNombreBusMisterX)
        {
            misterX.TicketBus++;
            lblNombreBusMisterX.Text = misterX.TicketBus.ToString();

            misterX.TicketBus = Int32.Parse(lblNombreBusMisterX.Text);
        }

        /// <summary>
        /// Lorsque le détective joue, il doit ensuite donner son ticket de metro à MisterX.
        /// </summary>
        /// <param name="misterX"></param>
        /// <param name="lblNombreMetroMisterX"></param>
        internal static void DonnerTicketMetroMisterX(JoueurMisterX misterX, Label lblNombreMetroMisterX)
        {
            misterX.TicketMetro++;
            lblNombreMetroMisterX.Text = misterX.TicketMetro.ToString();

            misterX.TicketMetro = Int32.Parse(lblNombreMetroMisterX.Text);
        }
    }
}
