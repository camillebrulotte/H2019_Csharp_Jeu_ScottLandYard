using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ScotYard.Graphe;

namespace ScotYard
{
    /// <summary>
    /// Cette classe permet de gérer le Jeu.
    /// </summary>
    public partial class JeuFenetre : Form 
    {
        List<Button> _listeBoutons = new List<Button>();
        List<PictureBox> _listeTicketsMisterX = new List<PictureBox>();

        public int CompteurTourMisterX { get; set; }
        public static List<JoueurDetective> ListeDetective { get; set; } = JoueurDetective.RemplirListeDetective();
        public JoueurMisterX MisterX { get; set; } = JoueurMisterX.RemplirDonneesMisterX(ListeDetective);

        public int CompteurTourRestant { get; set; }

        /// <summary>
        /// Savoir si le détective doit passer son tour.
        /// </summary>
        public bool PasserTourDetective1 { get; set; }
        public bool PasserTourDetective2 { get; set; }
        public bool PasserTourDetective3 { get; set; }

        public bool PartieTermine { get; set; }

        /// <summary>
        /// Savoir c'est à quel détective de jouer.
        /// </summary>
        TourDeQuelJoueur TourActuel = TourDeQuelJoueur.Detective1;

        /// <summary>
        /// Constructeur.
        /// </summary>
        public JeuFenetre()
        {   
            InitializeComponent();
            InitialiserBoutons();
            InitialiserTicketsTableauMisterX();
            Case.CreerCases();

            ///Initialisation des tickets valides selon la station
            for (int but = 0; but < _listeBoutons.Count; but++)
            {
                _listeBoutons[but].Click += new System.EventHandler(this.BtnGame_Click);
            }

            InitialisationPartie();
        }

        /// <summary>
        /// Initialise les joueurs.
        /// </summary>
        private void InitialisationPartie()
        {
            LblNombreTours.Text = 22.ToString();
            CompteurTourRestant = 22;
            JoueurMisterX.CompteurPictureBox = 0;
            CompteurTourMisterX = 0;
            LblPositionMisterX.Text = "?";
            LblPositionMisterX.Location = new Point(((PnlPositionMisterX.Size.Width - LblPositionMisterX.Size.Width) / 2), LblPositionMisterX.Location.Y);
            PartieTermine = false;

            PnlNombreTicketsRestantMisterX.Hide();
            PnlTicketsDetective.Hide();
            BtnPasserTour.Hide();
            
            InitialisationPictureBoxTicket(_listeTicketsMisterX);

            ///Initialisation des joueurs
            InitialisationDetective(0, LblDetective1, PibPionDetective1, PibDetective1, PnlDetective1, LblPositionDetective1, _listeBoutons);
            LblNombreTaxisDetective1.Text = ListeDetective[0].TicketTaxis.ToString();
            LblNombreBusDetective1.Text = ListeDetective[0].TicketBus.ToString();
            LblNombreMetroDetective1.Text = ListeDetective[0].TicketMetro.ToString();

            InitialisationDetective(1, LblDetective2, PibPionDetective2, PibDetective2, PnlDetective2, LblPositionDetective2, _listeBoutons);
            LblNombreTaxisDetective2.Text = ListeDetective[1].TicketTaxis.ToString();
            LblNombreBusDetective2.Text = ListeDetective[1].TicketBus.ToString();
            LblNombreMetroDetective2.Text = ListeDetective[1].TicketMetro.ToString();

            InitialisationDetective(2, LblDetective3, PibPionDetective3, PibDetective3, PnlDetective3, LblPositionDetective3, _listeBoutons);
            LblNombreTaxisDetective3.Text = ListeDetective[2].TicketTaxis.ToString();
            LblNombreBusDetective3.Text = ListeDetective[2].TicketBus.ToString();
            LblNombreMetroDetective3.Text = ListeDetective[2].TicketMetro.ToString();

            JoueurMisterX.InitialisationMisterX(MisterX, PibMisterX);

            ///MisterX commence la partie
            TourMisterX();
        }

        /// <summary>
        /// Tour de MisterX.
        /// </summary>
        public void TourMisterX()
        {
            TourActuel = TourDeQuelJoueur.MisterX;

            JoueurMisterX.TourDeMisterX(MisterX, ListeDetective, LblNombreTaxisMisterX, LblNombreBusMisterX,
                LblNombreMetroMisterX, LblNombreNoirMisterX, _listeTicketsMisterX, CompteurTourRestant,
                _listeBoutons, PibMisterX, PibTourDetective2, PibTourDetective3);

            ///C'est ensuite le tour du premier détective.
            TourActuel = TourDeQuelJoueur.Detective1;
            TourDeDetective1(PibTourDetective1, PibTourDetective2, PibTourDetective3);
        }

        /// <summary>
        /// Les tickets qui sont disponibles pour les détectives selon la station.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGame_Click(object sender, EventArgs e)
        {
            Button Clique = ((Button)sender);
            
            bool JoueurPeutJouer = false;

            bool VerificationPresentTaxis = false;
            bool VerificationPresentBus = false;
            bool VerificationPresentMetro = false;
            
            JoueurPeutJouer = Case.VerificationAucunMouvementPossible(ListeDetective[(int)TourActuel].Position, ListeDetective, (int)TourActuel);
            if (JoueurPeutJouer)
            {
                switch(TourActuel)
                {
                    case TourDeQuelJoueur.Detective1:
                        TourDeDetective1(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                        break;
                    case TourDeQuelJoueur.Detective2:
                        TourDeDetective2(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                        break;
                    case TourDeQuelJoueur.Detective3:
                        TourDeDetective3(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                        break;
                }
            }
            else
            {
                BtnPasserTour.Show();
            }

            ///Verifie si le bouton adjacent est présent
            VerificationPresentTaxis = Case.BoutonAdjacentTaxis(ListeDetective[(int)TourActuel].Position, ListeDetective, Int32.Parse(Clique.Text), (int)TourActuel);            
            if (!VerificationPresentTaxis)
            {
                BtnTicketTaxis.Hide();
            }
            else
            {
                BtnTicketTaxis.Show();
            }

            VerificationPresentBus = Case.BoutonAdjacentBus(ListeDetective[(int)TourActuel].Position, ListeDetective, Int32.Parse(Clique.Text), (int)TourActuel);
            if (!VerificationPresentBus)
            {
                BtnTicketBus.Hide();
            }
            else
            {
                BtnTicketBus.Show();
            }

            VerificationPresentMetro = Case.BoutonAdjacentMetro(ListeDetective[(int)TourActuel].Position, ListeDetective, Int32.Parse(Clique.Text), (int)TourActuel);
            if (!VerificationPresentMetro)
            {
                BtnTicketMetro.Hide();
            }
            else
            {
                BtnTicketMetro.Show();
            }

            JoueurDetective.StationClique = Int32.Parse(Clique.Text); 

            PnlTicketsDetective.Show();
        }

        /// <summary>
        /// Quand le joueur clique sur le ticket de Taxis.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTicketTaxis_Click(object sender, EventArgs e)
        {
            bool JoueurPeutJouer = false;
            int NumeroJoueur = (int)TourActuel;
            ListeDetective[NumeroJoueur].TicketTaxis--;

            int NouvellePosition = JoueurDetective.StationClique;

            switch (TourActuel)
            {
                case TourDeQuelJoueur.Detective1:
                    JoueurDetective.ActionChangementStationDetective(TourActuel, ListeDetective, _listeBoutons, LblNombreTaxisDetective1, PibDetective1, NouvellePosition, LblPositionDetective1, ListeDetective[0].TicketTaxis);
                    
                    JoueurMisterX.DonnerTicketTaxisMisterX(MisterX, LblNombreTaxisMisterX);

                    PartieTermine = VerificationSiGagne();
                    if (!PartieTermine)
                    {
                        JoueurPeutJouer = Case.VerificationAucunMouvementPossible(ListeDetective[1].Position, ListeDetective, 1);
                        TourActuel = TourDeQuelJoueur.Detective2;
                        if (JoueurPeutJouer)
                        {
                            TourDeDetective2(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                        }
                        else
                        {
                            BtnPasserTour.Show();
                        }
                        TourDeDetective2(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                    }
                    break;
                case TourDeQuelJoueur.Detective2:
                    JoueurDetective.ActionChangementStationDetective(TourActuel, ListeDetective, _listeBoutons, LblNombreTaxisDetective2, PibDetective2, NouvellePosition, LblPositionDetective2, ListeDetective[1].TicketTaxis);
                    
                    JoueurMisterX.DonnerTicketTaxisMisterX(MisterX, LblNombreTaxisMisterX);

                    PartieTermine = VerificationSiGagne();
                    if (!PartieTermine)
                    {
                        JoueurPeutJouer = Case.VerificationAucunMouvementPossible(ListeDetective[2].Position, ListeDetective, 2);
                        TourActuel = TourDeQuelJoueur.Detective3;
                        if (JoueurPeutJouer)
                        {
                            TourDeDetective3(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                        }
                        else
                        {
                            BtnPasserTour.Show();
                        }
                        TourDeDetective3(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                    }
                    break;
                case TourDeQuelJoueur.Detective3:
                    JoueurDetective.ActionChangementStationDetective(TourActuel, ListeDetective, _listeBoutons, LblNombreTaxisDetective3, PibDetective3, NouvellePosition, LblPositionDetective3, ListeDetective[2].TicketTaxis);
                    
                    JoueurMisterX.DonnerTicketTaxisMisterX(MisterX, LblNombreTaxisMisterX);

                    PartieTermine = VerificationSiGagne();
                    if (!PartieTermine)
                    {
                        CompteurTourRestant--;
                        Joueur.RafraichirLabelNombreTours(CompteurTourRestant, PnlNombreDeToursRestant, LblNombreTours);

                        JoueurMisterX.TourDeMisterX(MisterX, ListeDetective, LblNombreTaxisMisterX, LblNombreBusMisterX,
                            LblNombreMetroMisterX, LblNombreNoirMisterX, _listeTicketsMisterX, CompteurTourRestant,
                            _listeBoutons, PibMisterX, PibTourDetective2, PibTourDetective3);

                        VerificationAfficherPositionMisterX();

                        JoueurPeutJouer = Case.VerificationAucunMouvementPossible(ListeDetective[0].Position, ListeDetective, 0);
                        TourActuel = TourDeQuelJoueur.Detective1;
                        if (JoueurPeutJouer)
                        {
                            TourDeDetective1(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                        }
                        else
                        {
                            BtnPasserTour.Show();
                        }
                        TourDeDetective1(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                    }
                    break;
            }

            PnlTicketsDetective.Hide();

            if (CompteurTourRestant == 0)
            {
                FinDeLaPartie(false);
            }
        }

        /// <summary>
        /// Quand le joueur clique sur le ticket de Bus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTicketBus_Click(object sender, EventArgs e)
        {
            int NumeroJoueur = (int)TourActuel;
            ListeDetective[NumeroJoueur].TicketBus--;
            int NouvellePosition = JoueurDetective.StationClique;
            bool PeutJouer = false;

            switch (TourActuel)
            {
                case TourDeQuelJoueur.Detective1:
                    JoueurDetective.ActionChangementStationDetective(TourActuel, ListeDetective, _listeBoutons, LblNombreBusDetective1, PibDetective1, NouvellePosition, LblPositionDetective1, ListeDetective[0].TicketBus);
                    
                    JoueurMisterX.DonnerTicketTaxisMisterX(MisterX, LblNombreBusMisterX);

                    PartieTermine = VerificationSiGagne();
                    if (!PartieTermine)
                    {
                        PeutJouer = Case.VerificationAucunMouvementPossible(ListeDetective[1].Position, ListeDetective, 1);
                        TourActuel = TourDeQuelJoueur.Detective2;
                        if (PeutJouer)
                        {
                            TourDeDetective2(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                        }
                        else
                        {
                            BtnPasserTour.Show();
                        }
                        TourDeDetective2(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                    }
                    break;
                case TourDeQuelJoueur.Detective2:
                    JoueurDetective.ActionChangementStationDetective(TourActuel, ListeDetective, _listeBoutons, LblNombreBusDetective2, PibDetective2, NouvellePosition, LblPositionDetective2, ListeDetective[1].TicketBus);
                    
                    JoueurMisterX.DonnerTicketBusMisterX(MisterX, LblNombreBusMisterX);

                    PartieTermine = VerificationSiGagne();
                    if (!PartieTermine)
                    {
                        PeutJouer = Case.VerificationAucunMouvementPossible(ListeDetective[2].Position, ListeDetective, 2);
                        TourActuel = TourDeQuelJoueur.Detective3;
                        if (PeutJouer)
                        {
                            TourDeDetective3(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                        }
                        else
                        {
                            BtnPasserTour.Show();
                        }
                        TourDeDetective3(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                    }
                    break;
                case TourDeQuelJoueur.Detective3:
                    JoueurDetective.ActionChangementStationDetective(TourActuel, ListeDetective, _listeBoutons, LblNombreBusDetective3, PibDetective3, NouvellePosition, LblPositionDetective3, ListeDetective[2].TicketBus);
                    
                    JoueurMisterX.DonnerTicketBusMisterX(MisterX, LblNombreBusMisterX);

                    PartieTermine = VerificationSiGagne();
                    if (!PartieTermine)
                    {
                        CompteurTourRestant--;
                        Joueur.RafraichirLabelNombreTours(CompteurTourRestant, PnlNombreDeToursRestant, LblNombreTours);

                        JoueurMisterX.TourDeMisterX(MisterX, ListeDetective, LblNombreTaxisMisterX, LblNombreBusMisterX,
                            LblNombreMetroMisterX, LblNombreNoirMisterX, _listeTicketsMisterX, CompteurTourRestant,
                            _listeBoutons, PibMisterX, PibTourDetective2, PibTourDetective3);

                        VerificationAfficherPositionMisterX();

                        PeutJouer = Case.VerificationAucunMouvementPossible(ListeDetective[0].Position, ListeDetective, 0);
                        TourActuel = TourDeQuelJoueur.Detective1;
                        if (PeutJouer)
                        {

                            TourDeDetective1(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                        }
                        else
                        {
                            BtnPasserTour.Show();
                        }
                        TourDeDetective1(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                    }
                    break;
            }

            PnlTicketsDetective.Hide();

            if (CompteurTourRestant == 0)
            {
                FinDeLaPartie(false);
            }
        }

        /// <summary>
        /// Quand le joueur clique sur le ticket de Métro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTicketMetro_Click(object sender, EventArgs e)
        {
            ListeDetective[(int)TourActuel].TicketMetro--;
            bool PeutJouer = false;
            int NouvellePosition = JoueurDetective.StationClique;

            switch (TourActuel)
            {
                case TourDeQuelJoueur.Detective1:
                    JoueurDetective.ActionChangementStationDetective(TourActuel, ListeDetective, _listeBoutons, LblNombreMetroDetective1, PibDetective1, NouvellePosition, LblPositionDetective1, ListeDetective[0].TicketMetro);

                    JoueurMisterX.DonnerTicketMetroMisterX(MisterX, LblNombreMetroMisterX);

                    PartieTermine = VerificationSiGagne();
                    if (!PartieTermine)
                    {
                        PeutJouer = Case.VerificationAucunMouvementPossible(ListeDetective[1].Position, ListeDetective, 1);
                        TourActuel = TourDeQuelJoueur.Detective2;
                        if (PeutJouer)
                        {
                            TourDeDetective2(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                        }
                        else
                        {
                            BtnPasserTour.Show();
                        }
                        TourDeDetective2(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                    }
                    break;
                case TourDeQuelJoueur.Detective2:
                    JoueurDetective.ActionChangementStationDetective(TourActuel, ListeDetective, _listeBoutons, LblNombreMetroDetective2, PibDetective2, NouvellePosition, LblPositionDetective2, ListeDetective[1].TicketMetro);
                    
                    JoueurMisterX.DonnerTicketMetroMisterX(MisterX, LblNombreMetroMisterX);

                    PartieTermine = VerificationSiGagne();
                    if (!PartieTermine)
                    {
                        PeutJouer = Case.VerificationAucunMouvementPossible(ListeDetective[2].Position, ListeDetective, 2);
                        TourActuel = TourDeQuelJoueur.Detective3;
                        if (PeutJouer)
                        {
                            TourDeDetective3(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                        }
                        else
                        {
                            BtnPasserTour.Show();
                        }
                        TourDeDetective3(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                    }
                    break;
                case TourDeQuelJoueur.Detective3:
                    JoueurDetective.ActionChangementStationDetective(TourActuel, ListeDetective, _listeBoutons, LblNombreMetroDetective3, PibDetective3, NouvellePosition, LblPositionDetective3, ListeDetective[2].TicketMetro);
                    
                    JoueurMisterX.DonnerTicketMetroMisterX(MisterX, LblNombreMetroMisterX);

                    PartieTermine = VerificationSiGagne();
                    if (!PartieTermine)
                    {
                        CompteurTourRestant--;
                        Joueur.RafraichirLabelNombreTours(CompteurTourRestant, PnlNombreDeToursRestant, LblNombreTours);

                        JoueurMisterX.TourDeMisterX(MisterX, ListeDetective, LblNombreTaxisMisterX, LblNombreBusMisterX,
                            LblNombreMetroMisterX, LblNombreNoirMisterX, _listeTicketsMisterX, CompteurTourRestant,
                            _listeBoutons, PibMisterX, PibTourDetective2, PibTourDetective3);

                        VerificationAfficherPositionMisterX();

                        PeutJouer = Case.VerificationAucunMouvementPossible(ListeDetective[0].Position, ListeDetective, 0);
                        TourActuel = TourDeQuelJoueur.Detective1;
                        if (PeutJouer)
                        {
                            TourDeDetective1(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                        }
                        else
                        {
                            BtnPasserTour.Show();
                        }
                        TourDeDetective1(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                    }
                    break;
            }
            
            PnlTicketsDetective.Hide();

            if (CompteurTourRestant == 0)
            {
                FinDeLaPartie(false);
            }
        }

        public void VerificationAfficherPositionMisterX()
        {
            CompteurTourMisterX++;

            ///Affiche, s'il le faut, la position de MisterX sur la planche
            if (CompteurTourMisterX == 2 || CompteurTourMisterX == 7 || CompteurTourMisterX == 12 || CompteurTourMisterX == 17)
            {
                PibMisterX.Location = new Point((_listeBoutons[MisterX.Position].Location.X) + 24, (_listeBoutons[MisterX.Position].Location.Y) + 8);
                PibMisterX.Show();
                LblPositionMisterX.Text = MisterX.Position.ToString();
            }
            else
            {
                LblPositionMisterX.Text = "?";
                PibMisterX.Hide();
            }
            LblPositionMisterX.Location = new Point(((PnlPositionMisterX.Size.Width - LblPositionMisterX.Size.Width) / 2), LblPositionMisterX.Location.Y);
        }
        

        /// <summary>
        /// Lorsqu'aucun mouvement du joueur n'est possible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPasserTour_Click(object sender, EventArgs e)
        {
            switch (TourActuel)
            {
                case TourDeQuelJoueur.Detective1:
                    TourActuel = TourDeQuelJoueur.Detective2;
                    TourDeDetective2(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                    PasserTourDetective1 = true;
                    break;
                case TourDeQuelJoueur.Detective2:
                    TourActuel = TourDeQuelJoueur.Detective3;
                    TourDeDetective3(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                    PasserTourDetective2 = true;
                    break;
                case TourDeQuelJoueur.Detective3:
                    TourActuel = TourDeQuelJoueur.Detective1;
                    TourDeDetective1(PibTourDetective1, PibTourDetective2, PibTourDetective3);
                    PasserTourDetective3 = true;
                    break;
            }

            BtnPasserTour.Hide();

            if (PasserTourDetective1 && PasserTourDetective2 && PasserTourDetective3)
            {
                FinDeLaPartie(false);
            }
        }

        /// <summary>
        /// Si le détective a trouvé le voleur.
        /// </summary>
        private bool VerificationSiGagne()
        {
            int NumeroJoueur = (int)TourActuel;

            if (ListeDetective[NumeroJoueur].Position == MisterX.Position)
            {
                FinDeLaPartie(true);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Quand c'est la fin de la partie.
        /// </summary>
        /// <param name="VerificationGagne"></param>
        private void FinDeLaPartie(bool VerificationGagne)
        {
            if (VerificationGagne)
            {
                PartieGagne Gagne = new PartieGagne();
                      
                if(Gagne.ShowDialog(this) == DialogResult.OK)
                {
                    MontrerNouvellePartie();
                }   
            }
            else
            {
                PartiePerdue Perdu = new PartiePerdue();

                if (Perdu.ShowDialog(this) == DialogResult.OK)
                {
                    MontrerNouvellePartie();
                }
            }
        }

        private void MontrerNouvellePartie()
        {
            JeuValidationNouvellePartie NouvellePartie = new JeuValidationNouvellePartie();

            if (NouvellePartie.ShowDialog(this) == DialogResult.Yes)
            {
                JoueurDetective.ViderListeDetective(ListeDetective);
                ListeDetective = JoueurDetective.RemplirListeDetective();

                JoueurMisterX.RemplirDonneesMisterX(ListeDetective);
                JoueurMisterX.InitialisationMisterX(MisterX, PibMisterX);
                JoueurMisterX.CompteurTicketsMisterX = 0;

                InitialisationPartie();
                return;
            }
            else
            {
                NouvellePartie.Close();
            }
        }

        /// <summary>
        /// Demande au joueur s'il veut vraiment quitter le jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            JeuValidationQuitter ValidationQuitter = new JeuValidationQuitter();
            ValidationQuitter.Show();
        }

        /// <summary>
        /// Affiche les options du jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            JeuOptions options = new JeuOptions(ListeDetective);
            options.ShowDialog();

            InitialisationDetective(0, LblDetective1, PibPionDetective1, PibDetective1, PnlDetective1, LblPositionDetective1, _listeBoutons);
            InitialisationDetective(1, LblDetective2, PibPionDetective2, PibDetective2, PnlDetective2, LblPositionDetective2, _listeBoutons);
            InitialisationDetective(2, LblDetective3, PibPionDetective3, PibDetective3, PnlDetective3, LblPositionDetective3, _listeBoutons);
        }

        /// <summary>
        /// Affiche le à propos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ÀProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JeuAPropos APropos = new JeuAPropos();
            APropos.ShowDialog();
        }

        /// <summary>
        /// Affiche une description des tickets et des stations..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExplicationTicketsStations TicketsRestantDetectives = new ExplicationTicketsStations();
            TicketsRestantDetectives.ShowDialog();
        }

        /// <summary>
        /// Affiche les réglements du jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RèglementsDuJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JeuRegles regles = new JeuRegles();
            regles.ShowDialog();
        }

        /// <summary>
        /// Affiche les tickets restants de Mister X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTicketsRestant_MouseHover(object sender, EventArgs e)
        {
            PnlNombreTicketsRestantMisterX.Show();
        }

        /// <summary>
        /// Retire l'affichage des tickets restants de Mister X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTicketsRestant_MouseLeave(object sender, EventArgs e)
        {
            PnlNombreTicketsRestantMisterX.Hide();
        }

        /// <summary>
        /// Si le joueur souhaite démarrer une nouvelle partie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmNouvellePartie_Click(object sender, EventArgs e)
        {
            MontrerNouvellePartie();
        }

        /// <summary>
        /// Savoir que c'est au tour du détective 1.
        /// </summary>
        /// <param name="pibTourDetective1"></param>
        /// <param name="pibTourDetective2"></param>
        /// <param name="pibTourDetective3"></param>
        public static void TourDeDetective1(PictureBox pibTourDetective1, PictureBox pibTourDetective2, PictureBox pibTourDetective3)
        {
            pibTourDetective1.Show();
            pibTourDetective2.Hide();
            pibTourDetective3.Hide();
        }

        /// <summary>
        /// Savoir que c'est au tour du détective 2.
        /// </summary>
        /// <param name="pibTourDetective1"></param>
        /// <param name="pibTourDetective2"></param>
        /// <param name="pibTourDetective3"></param>
        public static void TourDeDetective2(PictureBox pibTourDetective1, PictureBox pibTourDetective2, PictureBox pibTourDetective3)
        {
            pibTourDetective1.Hide();
            pibTourDetective2.Show();
            pibTourDetective3.Hide();
        }

        /// <summary>
        /// Savoir que c'est au tour du détective 3.
        /// </summary>
        /// <param name="pibTourDetective1"></param>
        /// <param name="pibTourDetective2"></param>
        /// <param name="pibTourDetective3"></param>
        public static void TourDeDetective3(PictureBox pibTourDetective1, PictureBox pibTourDetective2, PictureBox pibTourDetective3)
        {
            pibTourDetective1.Hide();
            pibTourDetective2.Hide();
            pibTourDetective3.Show();
        }

        /// <summary>
        /// Initialiser chaque élément des détectives.
        /// </summary>
        /// <param name="compteur"></param>
        /// <param name="listeDetective"></param>
        /// <param name="lblDetective"></param>
        /// <param name="pibPionDetective"></param>
        /// <param name="pibDetective"></param>
        /// <param name="pnlDetective"></param>
        /// <param name="lblPositionDetective"></param>
        /// <param name="listeBoutons"></param>
        public static void InitialisationDetective(int compteur, Label lblDetective, PictureBox pibPionDetective, PictureBox pibDetective, Panel pnlDetective, Label lblPositionDetective, List<Button> listeBoutons)
        {
            ///Setter le nom du détective
            lblDetective.Text = ListeDetective[compteur].Nom;

            ///Centrer le nom du détective
            lblDetective.Location = new Point(((pnlDetective.Size.Width - lblDetective.Size.Width) / 2), lblDetective.Location.Y);

            ///Setter la bonne couleur
            pibPionDetective.BackColor = ListeDetective[compteur].Couleur;
            pibDetective.BackColor = ListeDetective[compteur].Couleur;

            ///Position de départ sur la planche
            int PositionDetective = ListeDetective[compteur].Position;

            pibDetective.Location = new Point((listeBoutons[PositionDetective].Location.X) + 24, (listeBoutons[PositionDetective].Location.Y) + 8);
            lblPositionDetective.Text = PositionDetective.ToString();
        }

        /// <summary>
        /// Initialise avec la bonne image les pictures box du tableau de MisterX
        /// </summary>
        /// <param name="_listeTicketsMisterX"></param>
        public void InitialisationPictureBoxTicket(List<PictureBox> _listeTicketsMisterX)
        {
            for (int i = 0; i < _listeTicketsMisterX.Count(); i++)
            {
                if (i == 2 || i == 7 || i == 12 || i == 17)
                {
                    _listeTicketsMisterX[i].Image = Properties.Resources.TableauCercleApparition1;
                }
                else
                {
                    _listeTicketsMisterX[i].Image = Properties.Resources.TableauCerclePasApparition;
                }
            }
        }

        /// <summary>
        /// Insertion des boutons dans une liste
        /// </summary>
        private void InitialiserBoutons()
        {
            _listeBoutons.Add(new Button());
            _listeBoutons.Add(btn1);
            _listeBoutons.Add(btn2);
            _listeBoutons.Add(btn3);
            _listeBoutons.Add(btn4);
            _listeBoutons.Add(btn5);
            _listeBoutons.Add(btn6);
            _listeBoutons.Add(btn7);
            _listeBoutons.Add(btn8);
            _listeBoutons.Add(btn9);
            _listeBoutons.Add(btn10);
            _listeBoutons.Add(btn11);
            _listeBoutons.Add(btn12);
            _listeBoutons.Add(btn13);
            _listeBoutons.Add(btn14);
            _listeBoutons.Add(btn15);
            _listeBoutons.Add(btn16);
            _listeBoutons.Add(btn17);
            _listeBoutons.Add(btn18);
            _listeBoutons.Add(btn19);
            _listeBoutons.Add(btn20);
            _listeBoutons.Add(btn21);
            _listeBoutons.Add(btn22);
            _listeBoutons.Add(btn23);
            _listeBoutons.Add(btn24);
            _listeBoutons.Add(btn25);
            _listeBoutons.Add(btn26);
            _listeBoutons.Add(btn27);
            _listeBoutons.Add(btn28);
            _listeBoutons.Add(btn29);
            _listeBoutons.Add(btn30);
            _listeBoutons.Add(btn31);
            _listeBoutons.Add(btn32);
            _listeBoutons.Add(btn33);
            _listeBoutons.Add(btn34);
            _listeBoutons.Add(btn35);
            _listeBoutons.Add(btn36);
            _listeBoutons.Add(btn37);
            _listeBoutons.Add(btn38);
            _listeBoutons.Add(btn39);
            _listeBoutons.Add(btn40);
            _listeBoutons.Add(btn41);
            _listeBoutons.Add(btn42);
            _listeBoutons.Add(btn43);
            _listeBoutons.Add(btn44);
            _listeBoutons.Add(btn45);
            _listeBoutons.Add(btn46);
            _listeBoutons.Add(btn47);
            _listeBoutons.Add(btn48);
            _listeBoutons.Add(btn49);
            _listeBoutons.Add(btn50);
            _listeBoutons.Add(btn51);
            _listeBoutons.Add(btn52);
            _listeBoutons.Add(btn53);
            _listeBoutons.Add(btn54);
            _listeBoutons.Add(btn55);
            _listeBoutons.Add(btn56);
            _listeBoutons.Add(btn57);
            _listeBoutons.Add(btn58);
            _listeBoutons.Add(btn59);
            _listeBoutons.Add(btn60);
            _listeBoutons.Add(btn61);
            _listeBoutons.Add(btn62);
            _listeBoutons.Add(btn63);
            _listeBoutons.Add(btn64);
            _listeBoutons.Add(btn65);
            _listeBoutons.Add(btn66);
            _listeBoutons.Add(btn67);
            _listeBoutons.Add(btn68);
            _listeBoutons.Add(btn69);
            _listeBoutons.Add(btn70);
            _listeBoutons.Add(btn71);
            _listeBoutons.Add(btn72);
            _listeBoutons.Add(btn73);
            _listeBoutons.Add(btn74);
            _listeBoutons.Add(btn75);
            _listeBoutons.Add(btn76);
            _listeBoutons.Add(btn77);
            _listeBoutons.Add(btn78);
            _listeBoutons.Add(btn79);
            _listeBoutons.Add(btn80);
            _listeBoutons.Add(btn81);
            _listeBoutons.Add(btn82);
            _listeBoutons.Add(btn83);
            _listeBoutons.Add(btn84);
            _listeBoutons.Add(btn85);
            _listeBoutons.Add(btn86);
            _listeBoutons.Add(btn87);
            _listeBoutons.Add(btn88);
            _listeBoutons.Add(btn89);
            _listeBoutons.Add(btn90);
            _listeBoutons.Add(btn91);
            _listeBoutons.Add(btn92);
            _listeBoutons.Add(btn93);
            _listeBoutons.Add(btn94);
            _listeBoutons.Add(btn95);
            _listeBoutons.Add(btn96);
            _listeBoutons.Add(btn97);
            _listeBoutons.Add(btn98);
            _listeBoutons.Add(btn99);
            _listeBoutons.Add(btn100);
            _listeBoutons.Add(btn101);
            _listeBoutons.Add(btn102);
            _listeBoutons.Add(btn103);
            _listeBoutons.Add(btn104);
            _listeBoutons.Add(btn105);
            _listeBoutons.Add(btn106);
            _listeBoutons.Add(btn107);
            _listeBoutons.Add(btn108);
            _listeBoutons.Add(btn109);
            _listeBoutons.Add(btn110);
            _listeBoutons.Add(btn111);
            _listeBoutons.Add(btn112);
            _listeBoutons.Add(btn113);
            _listeBoutons.Add(btn114);
            _listeBoutons.Add(btn115);
            _listeBoutons.Add(btn116);
            _listeBoutons.Add(btn117);
            _listeBoutons.Add(btn118);
            _listeBoutons.Add(btn119);
            _listeBoutons.Add(btn120);
            _listeBoutons.Add(btn121);
            _listeBoutons.Add(btn122);
            _listeBoutons.Add(btn123);
            _listeBoutons.Add(btn124);
            _listeBoutons.Add(btn125);
            _listeBoutons.Add(btn126);
            _listeBoutons.Add(btn127);
            _listeBoutons.Add(btn128);
            _listeBoutons.Add(btn129);
            _listeBoutons.Add(btn130);
            _listeBoutons.Add(btn131);
            _listeBoutons.Add(btn132);
            _listeBoutons.Add(btn133);
            _listeBoutons.Add(btn134);
            _listeBoutons.Add(btn135);
            _listeBoutons.Add(btn136);
            _listeBoutons.Add(btn137);
            _listeBoutons.Add(btn138);
            _listeBoutons.Add(btn139);
            _listeBoutons.Add(btn140);
            _listeBoutons.Add(btn141);
            _listeBoutons.Add(btn142);
            _listeBoutons.Add(btn143);
            _listeBoutons.Add(btn144);
            _listeBoutons.Add(btn145);
            _listeBoutons.Add(btn146);
            _listeBoutons.Add(btn147);
            _listeBoutons.Add(btn148);
            _listeBoutons.Add(btn149);
            _listeBoutons.Add(btn150);
            _listeBoutons.Add(btn151);
            _listeBoutons.Add(btn152);
            _listeBoutons.Add(btn153);
            _listeBoutons.Add(btn154);
            _listeBoutons.Add(btn155);
            _listeBoutons.Add(btn156);
            _listeBoutons.Add(btn157);
            _listeBoutons.Add(btn158);
            _listeBoutons.Add(btn159);
            _listeBoutons.Add(btn160);
            _listeBoutons.Add(btn161);
            _listeBoutons.Add(btn162);
            _listeBoutons.Add(btn163);
            _listeBoutons.Add(btn164);
            _listeBoutons.Add(btn165);
            _listeBoutons.Add(btn166);
            _listeBoutons.Add(btn167);
            _listeBoutons.Add(btn168);
            _listeBoutons.Add(btn169);
            _listeBoutons.Add(btn170);
            _listeBoutons.Add(btn171);
            _listeBoutons.Add(btn172);
            _listeBoutons.Add(btn173);
            _listeBoutons.Add(btn174);
            _listeBoutons.Add(btn175);
            _listeBoutons.Add(btn176);
            _listeBoutons.Add(btn177);
            _listeBoutons.Add(btn178);
            _listeBoutons.Add(btn179);
            _listeBoutons.Add(btn180);
            _listeBoutons.Add(btn181);
            _listeBoutons.Add(btn182);
            _listeBoutons.Add(btn183);
            _listeBoutons.Add(btn184);
            _listeBoutons.Add(btn185);
            _listeBoutons.Add(btn186);
            _listeBoutons.Add(btn187);
            _listeBoutons.Add(btn188);
            _listeBoutons.Add(btn189);
            _listeBoutons.Add(btn190);
            _listeBoutons.Add(btn191);
            _listeBoutons.Add(btn192);
            _listeBoutons.Add(btn193);
            _listeBoutons.Add(btn194);
            _listeBoutons.Add(btn195);
            _listeBoutons.Add(btn196);
            _listeBoutons.Add(btn197);
            _listeBoutons.Add(btn198);
            _listeBoutons.Add(btn199);
        }

        /// <summary>
        /// Insertion des picturebox dans une liste
        /// </summary>
        private void InitialiserTicketsTableauMisterX()
        {
            //_listeTicketsMisterX.Add(new PictureBox());
            _listeTicketsMisterX.Add(PibCheminMisterX1);
            _listeTicketsMisterX.Add(PibCheminMisterX2);
            _listeTicketsMisterX.Add(PibCheminMisterX3);
            _listeTicketsMisterX.Add(PibCheminMisterX4);
            _listeTicketsMisterX.Add(PibCheminMisterX5);
            _listeTicketsMisterX.Add(PibCheminMisterX6);
            _listeTicketsMisterX.Add(PibCheminMisterX7);
            _listeTicketsMisterX.Add(PibCheminMisterX8);
            _listeTicketsMisterX.Add(PibCheminMisterX9);
            _listeTicketsMisterX.Add(PibCheminMisterX10);
            _listeTicketsMisterX.Add(PibCheminMisterX11);
            _listeTicketsMisterX.Add(PibCheminMisterX12);
            _listeTicketsMisterX.Add(PibCheminMisterX13);
            _listeTicketsMisterX.Add(PibCheminMisterX14);
            _listeTicketsMisterX.Add(PibCheminMisterX15);
            _listeTicketsMisterX.Add(PibCheminMisterX16);
            _listeTicketsMisterX.Add(PibCheminMisterX17);
            _listeTicketsMisterX.Add(PibCheminMisterX18);
            _listeTicketsMisterX.Add(PibCheminMisterX19);
            _listeTicketsMisterX.Add(PibCheminMisterX20);
            _listeTicketsMisterX.Add(PibCheminMisterX21);
            _listeTicketsMisterX.Add(PibCheminMisterX22);
        }
    }
}