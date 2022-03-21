using System.Windows;
using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using WPFCustomMessageBox;
using MaterialDesignThemes.Wpf;

namespace CAPSlock
{
    /// <summary>
    /// Logique d'interaction pour CAPSDesktop.xaml
    /// </summary>
    public partial class CAPSDesktop : UserControl
    {
        public int ID { get; set; }

        public CAPSDesktop(string name, int ID, string proce, string memory)
        {
            InitializeComponent();
            //Affectation du nom dynamique de la VM au bouton
            VM.Text = name;
            this.ID = ID;
            //Récupération du processeur et de la mémoire dans des text hidden pour l'utiliser dans le user control informations
            hiddenV2.Text = proce;
            hiddenV3.Text = memory;
           
            //Récupération de l'id de la machine puis -1 pour que l'id corresponde au tableau utilisé par la suite
            int IdO = ID - 1; 
            //Création d'une commande SSH à travers C#
            string rm = Code.launchCommand("capsvmctl --status").ToString();
            var patternStatus = new Regex("Stopped|Running");
            var status = patternStatus.Matches(rm);
            //Récupération en string du résultat selon l'ID pour l'utiliser dans le switch
            string statusV2 = status[IdO].Value;
            //Switch pour faire apparaitre l'image de base selon l'état de la machine
            switch (statusV2)
            {
                case "Stopped":
                    StatusVMImage.Source = (DrawingImage)Resources["monitor-off"];
                    ScreenVM.Visibility = Visibility.Hidden;
                    break;
                case "Running":
                    StatusVMImage.Source = (DrawingImage)Resources["monitor"];
                    VM.Margin = new Thickness(0, 320, 0, 0);
                    ScreenVM.Visibility = Visibility.Hidden;
                    break;
            }
            //Appel de la fonction crée plus bas pour changer l'image dynamiquement et en temps réel selon l'état de la machine.
            System.Timers.Timer timer = new System.Timers.Timer(3000);
            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Tmr_Tick);
            timer.AutoReset = true;
        }

        //Création d'un nouvel user control de CAPSinfo lors du clic sur le boutton
        private void Info(object sender, RoutedEventArgs e)
        {
            // On passe en paramètre les informations pour pouvoir les utiliser dans le user control informations
            CAPSInformations capsuleInfo = new CAPSInformations(VM.Text, ID, hiddenV2.Text.ToString(), hiddenV3.Text.ToString());
            this.contentControlDesktop.Content = capsuleInfo;
            capsuleInfo.VM.Content = VM.Text;
        }
        //Bouton pour prendre le contrôle de la machine
        private void TakeControl_Click(object sender, RoutedEventArgs e)
        {
            CAPSControl form = new CAPSControl(ID);
            if (form.verifConnexion)
            {
                form.Show();
            }
        }
        //Bouton pour éteindre la VM normalement
        private void Stop_VM(object sender, RoutedEventArgs e)
        {
            //Création d'une commande ssh à travers C#
            Code.launchCommand("capsvmctl --stop " + ID);
        }
        //Bouton pour éteindre de force la VM
        private void ForceStop_VM(object sender, RoutedEventArgs e)
        {
            Code.launchCommand("capsvmctl --forcestop " + ID);
        }
        //Bouton pour lancer la VM
        private void Start_VM(object sender, RoutedEventArgs e)
        {
            Code.launchCommand("capsvmctl --start " + ID);

        }
        //Fonction pour vérifier l'état de la machine et changer l'image selon l'état
        private async void Tmr_Tick(object sender, EventArgs e)  //run this logic each timer tick
        {
            //Vérification que la connexion est bien présente et qui reconnecte l'application si elle ne l'est plus
            if (Login.newConnexion.connectIn() != true)
            {
                Trace.WriteLine("Reconnexion...");
                await Task.Run(() =>
                {
                    Login.newConnexion.connect();
                });
                Trace.WriteLine("Connexion établit");

            }
            //Appel de la fonction qui change l'affichage selon l'état de la machine
            await Task.Run(() =>
            {
                ApplyStatusVM();
            });

        }


        private void ApplyStatusVM()  //run this logic each timer tick
        {
            string nameVm = "";
            this.Dispatcher.Invoke(() =>
            {
                nameVm = VM.Text;
            });
            //Récupération de l'index
            var list = Code.machine.FindIndex(f => f.nameVM == nameVm);
            Trace.WriteLine(nameVm);
            //Condition qui vérifie s'il y a des VM présentes sur l'hyperviseur
            if(list == -1)
            {
                return;
            }
            else
            {
                //Switch qui vérifie sur la machine choisi si elle est en ligne ou non
                switch (Code.machine[list].online)
                {
                    //Case où elle est hors ligne, on affiche le moniteur en rouge et le nom de la VM à l'intérieur de celui-ci
                    case false:
                        this.Dispatcher.Invoke(() =>
                        {
                            StatusVMImage.Source = (DrawingImage)Resources["monitor-off"];
                            VM.Margin = new Thickness(0, -40, 0, 0);
                            ScreenVM.Visibility = Visibility.Hidden;
                        });

                        break;
                    //Case où la machine est en ligne, on affiche le moniteur en vert et le nom de la VM en dessous de celui-ci
                    case true:
                        this.Dispatcher.Invoke(() =>
                        {
                            StatusVMImage.Source = (DrawingImage)Resources["monitor"];
                            VM.Margin = new Thickness(0, 320, 0, 0);
                            ScreenVM.Visibility = Visibility.Hidden;
                        });

                        break;
                }
            }
            

        }
        //Fonction qui permet de prendre des snapshot de la VM ou de restaurer un snapshot de cette même VM
        private async void MakeSnapshot(object sender, RoutedEventArgs e)
        {
            //MessageBox customisé avec les deux choix disponible pour les snapshots
            bool? result = new MessageBoxCustom("Do you want to take a snapshot or to restore one?", MessageType.Confirmation, MessageButtons.YesNo,"Take snapshot","Restore snapshot").ShowDialog();
            //Switch pour définir les actions choisis lors du clic sur l'un des boutons
            switch (result.Value)
            {
                //Code qui va permettre de prendre un snapshot lors du clic sur Take snapshot
                case true:
                    //Page de chargement qui va durer tout le long de l'exécution du snapshot
                    LoadingTest loading = new LoadingTest();
                    this.Content = loading;
                    Login.capsuleInterfaceVM.ChangeBlur(true);
                    //Foreach qui va parcourir le fichier
                    foreach (VmSettings vm in Code.machine)
                    {
                        if (VM.Text == vm.nameVM)
                        {
                            await Task.Run(() =>
                            {
                                //Récupération de la date du jour et affectation à une variable
                                string DateDuJour = Code.launchCommandSingleLine("date +%d%m%Y");
                                //Récupération du chemin pour stocker les snapshots
                                string pathfile = "/opt/CAPS/VMs/HDs/";
                                //Copie du disque dur sur laquelle la machine travaille puis on rajoute .bak ainsi que la date du jour
                                string SingleSnapshot = "cp " + pathfile + vm.osUsed + " " + pathfile + vm.osUsed + ".bak" + DateDuJour;
                                Code.launchCommand(SingleSnapshot);
                            });
                            CapsuleInterfaceVM.boolanimation = true;

                        }
                    }
                    break;
                //Code qui va permettre de restaurer un snapshot lors du clic sur Restore snapshot
                case false:

                    break;
                default:

                    break;
            }

        }

    }
}






