using Renci.SshNet;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CAPSlock
{
    /// <summary>
    /// Logique d'interaction pour CAPSinfo.xaml
    /// </summary>
    public partial class CAPSInformations : UserControl
    {
        SshClient hyperviseurSsh = Login.newConnexion.GetSshClient();

        public int ID { get; set; }
        public CAPSInformations(string name, int ID, string proce, string memory)
        {
            string[] info = Login.newConnexion.GetUsernamePassword();
            InitializeComponent();
            //Gestion de la visibilité du bouton Delete selon la connexion en utilisateur ou administrateur
            if (info[2] != "$0merset")
            {
                Delete.Visibility = Visibility.Collapsed;
            }
            //Affectation des données de la VM récupéré dynamiquement en paramètre au textbox
            nameVM.Text = name;
            proc.Text = proce;
            memoire.Text = memory;
            //Affectation de l'id en paramètre à la variable ID
            this.ID = ID;
            //Création d'une commande SSH à travers C#
            SshCommand sm = hyperviseurSsh.CreateCommand("capsvmctl --status");
            int IdO = ID - 1;
            sm.Execute();
            string rm = sm.Result;
            //Regex pour vérifier l'état de la machine
            var patternStatus = new Regex("Stopped|Running");
            var status = patternStatus.Matches(rm);
            //Récupération en string du résultat selon l'ID pour l'utiliser en tant que string pour l'affectation de valeur
            string statusV2 = status[IdO].Value;
            //Affichage du status de la VM
            Status.Text = statusV2;
        }
        //Création d'un nouvel user control de CAPSDesktop lors du clic sur le boutton
        private void Machine(object sender, RoutedEventArgs e)
        {
            // On passe en paramètre les informations pour pouvoir les réutiliser dans le user control Desktop
            CAPSDesktop capsuleD = new CAPSDesktop(nameVM.Text, ID, proc.Text, memoire.Text);
            this.contentControlInformations.Content = capsuleD;
        }

        private async void deleteButton(object sender, RoutedEventArgs e)
        {
            string namevm = nameVM.Text;
            //Message de confirmation pour la suppression de la VM
            bool? result = new MessageBoxCustom("Do you really want to delete this VM?", MessageType.Confirmation, MessageButtons.YesNo, "Yes", "No").ShowDialog();
            switch (result.Value)
            {
                //Case lorsqu'on appuie sur yes, on supprime la VM
                case true:
                    //Page de chargement qui dure tout le long de l'exécution/suppression de la VM
                    Login.capsuleInterfaceVM.ChangeBlur(true);
                    LoadingTest chargement = new LoadingTest();
                    this.Content = chargement;
                    foreach (VmSettings vm in Code.machine)
                    {
                        //Vérification que le nom de la VM présente est le même que celle du fichier
                        if (namevm == vm.nameVM)
                        {

                            //Récupération du fichier de la VM
                            string path = vm.getPathConfigFile();
                            await Task.Run(() =>
                            {
                                //Suppression de la machine choisi
                                Code.launchCommand("rm " + path);
                                Trace.WriteLine("Deleting " + namevm + " in " + path);
                            });
                            //Fin du chargement
                            CapsuleInterfaceVM.boolanimation = true;
                            return;


                        }
                    }
                    break;
                case false:

                    break;
                default:

                    break;
            }
            
           
        }
    }
}
