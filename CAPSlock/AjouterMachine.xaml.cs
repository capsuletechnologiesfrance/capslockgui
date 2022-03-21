using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;


namespace CAPSlock
{
    /// <summary>
    /// Logique d'interaction pour AjouterMachine.xaml
    /// </summary>
    public partial class AjouterMachine : UserControl
    {
        public AjouterMachine()
        {
            InitializeComponent();
            //Récupération du nombre de CPU présent sur la machine hôte
            string restult = Code.launchCommandSingleLine("echo $(/usr/bin/nproc)");
            string retult = Code.launchCommand("capsvmctl --listcd");
           
            List<string> listCd = retult.Split('\n').ToList();
            listCd.RemoveAt(0);
            listCd.RemoveAt(listCd.Count - 1);
            //Boucle pour ajouter le nombre de CPU dans la listBox 
            for (int i = int.Parse(restult) - 1; i >= 0; i--)
            {
                string testc = i.ToString();
                cpu.Items.Add(testc);
            }

            foreach(string testc in listCd)
            {
                cdrom.Items.Add(testc);
            }
           
        }
        private void checkBox_Yes_Checked(object sender, RoutedEventArgs e)
        {
            AutoStart.Content = "Yes";
        }

        private void checkBox_No_Unchecked(object sender, RoutedEventArgs e)
        {
            AutoStart.Content = "No";
        }
        //Méthode pour ajouter une machine lors du clic sur le bouton
        private void Add_button(object sender, RoutedEventArgs e)
        {
            //Appel de la page de chargement
            Login.capsuleInterfaceVM.ChangeBlur(true);
            LoadingTest chargement = new LoadingTest();
            this.Content = chargement;
            string startAuto;
            if (AutoStart.IsChecked == true)
            {
                startAuto = "Yes";
            }
            else
            {
                startAuto = "No";
            }
            //Association des entrées utilisateur à des variables
            string Rname = name.Text;
            string Rcpu = CPURec.Text;
            string Rcnumalist = cpu.SelectedItems.Count.ToString();
            string Rmemory = memory.Text;
            string Rnetwork = network.Text;
            string Ros = os.Text;
            string Rcdrom = cdrom.SelectedItem.ToString();
            
            //Création du fichier de config de la VM avec les entrées utilisateur
            txtCreation.createConfigFile("server", Rname, Rcpu.Remove(Rcpu.Length - 1), Rcnumalist, Rmemory, Rnetwork, Ros, Rcdrom, "",startAuto);
            //Fin du chargement
            CapsuleInterfaceVM.boolanimation = true;
        }

       
        private void AddOS(object sender, RoutedEventArgs e)
        {
            /*
           OpenFileDialog openFileDialog = new OpenFileDialog();
           //Filtre qui permet d'afficher uniquement le type de fichier voulu
           openFileDialog.Filter = "Fichier code|*.iso|Tous les fichiers|*.*";
           bool? result = openFileDialog.ShowDialog();
           if (result.HasValue && result.Value)
           {
               if (Path.GetExtension(openFileDialog.FileName) != ".iso")
               {
                   cdrom.Text = "Ceci n'est pas un fichier image d'OS";
               }
               else
               {
                   cdrom.Text = openFileDialog.SafeFileName;
               }


               //    //string path = openFileDialog.FileName;
               //    //string content = File.ReadAllText(path);
               //    //openText.Text = content;
               //}
           }  */
        }

        //Permet de choisir les CPU pour la numalist
        private void GetCPU_Click(object sender, RoutedEventArgs e)
        {
            //Association des items choisi(CPU choisi) à une textbox
            foreach(object cpuNumber in cpu.SelectedItems)
            {
                CPURec.Text += cpuNumber.ToString() + ",";
            
            }

            bool? result = new MessageBoxCustom(CPURec.Text, MessageType.CPU, MessageButtons.YesNo, "Ok", "Reset").ShowDialog();
            switch (result.Value)
            {
                case true:
                   
                    break;
                case false:
                    CPURec.Text = "";
                    cpu.SelectedItems.Clear();
                    break; 
                
            }

        }
    }
}
