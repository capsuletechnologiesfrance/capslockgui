using System.Collections.Generic;
using System.Windows.Forms;

namespace CAPSlock
{
    public partial class CAPSControl : Form
    {
        public string ip { get; set; }
        public bool verifConnexion { get; set; }

        public CAPSControl(int ID)
        {
            InitializeComponent();
            
            List<VmSettings> machine = Code.getListVm();
            
            //Essaie de se connecter en VNC à la machine
            try
            {
                //Récupération du port VNC de la machine
                remoteDesktop1.VncPort = machine[ID - 1].portVNC;
                //Récupération de l'adresse IP de la macine
                remoteDesktop1.Connect(Login.IP);
                //Activation de la mise à l'échelle
                remoteDesktop1.SetScalingMode(true);
            }
            //Si cela ne marche pas, un message d'erreur va s'afficher demandant de vérifier si la machine est allumée
            catch
            {
                //Affichage du message d'erreur
                new MessageBoxCustom("Please check if the machine is turned on", MessageType.Confirmation, MessageButtons.Ok, "", "").ShowDialog();
                //Préviens que la connexion n'a pas pu être établie
                verifConnexion = false;
                return;
            }
            //Préviens que la connexion a été établie
            verifConnexion = true;

        }

        public bool checkConnectionStatus()
        {
            return verifConnexion;
        }

        private void remoteDesktop1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
