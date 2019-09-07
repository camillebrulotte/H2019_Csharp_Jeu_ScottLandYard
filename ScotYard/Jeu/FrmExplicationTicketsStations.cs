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
    /// Cette classe est une légende des couleurs des et des stations.
    /// </summary>
    public partial class ExplicationTicketsStations : Form
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public ExplicationTicketsStations()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        /// <summary>
        /// Ferme le form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
