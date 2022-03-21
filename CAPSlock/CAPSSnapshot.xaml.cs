using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Controls;
namespace CAPSlock
{
    /// <summary>
    /// Logique d'interaction pour CAPSSnapshot.xaml
    /// </summary>
    public partial class CAPSSnapshot : UserControl
    {
        public CAPSSnapshot()
        {
            InitializeComponent();
            //Appel de la méthode LastSlot
            LastSlot();
            //Appel de la méthode RecuperationHDD
            RecuperationHDD();
            
        }

        /// <ButtonSnapshotAll>
        /// Méthode permettant au bouton "Make Snapshot of all VM" de faire une snapshot de toutes les VM
        /// </ButtonSnapshotAll>
        private void ButtonSnapshotAll(object sender, System.Windows.RoutedEventArgs e)
        {
            //Execute la commande "capsvm_makesnapshot"
            Code.launchCommand("capsvm_makesnapshot");
        }

        private void SelectionChanged(object sender, EventArgs e)
        {

        }

        private void RecuperationHDD()
        {
            /*Trace.WriteLine("------------\nDebug HDD");
            string ListHDD = Code.launchCommand("capsvmctl --listhdd");
            List<string> list = new List<string>(
                           ListHDD.Split(new string[] { "\r\n" },
                           StringSplitOptions.RemoveEmptyEntries));
            foreach(string item in list)
            {
                Trace.WriteLine(item);
            }
            Selection.Items.Add(list);*/
        }

        /// <LastSlot>
        /// Affiche le fichier slot de la dernière snapshot
        /// </LastSlot>
        private void LastSlot()
        {
            //Lecture du fichier "lastslot.txt" afin de récupérer l'emplacement de la dernière snapshot
            string lS = Code.launchCommand("cat /VM_SNAPSHOTS/lastslot.txt");
            //Affichage du numéro correspondant à la dernière snapshot
            lastSlot.Text = lastSlot.Text + lS.Replace("\n", "").Replace("\r", "");
        }
    }
}
