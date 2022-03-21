using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CAPSlock
{
    /// <summary>
    /// Logique d'interaction pour MessageBoxCustom.xaml
    /// </summary>
    public partial class MessageBoxCustom : Window
    {
        //Création d'une MessageBox customisé pour les messages de l'application
        public MessageBoxCustom(string Message, MessageType Type, MessageButtons Buttons, string btnYesContent, string btnNoContent)
        {
            InitializeComponent();
            //Assignation du message principal à une variable
            txtMessage.Text = Message;
            //Switch pour choisir le type de message
            switch (Type)
            {
                case MessageType.Info:
                    txtTitle.Text = "Info";
                    break;
                case MessageType.Confirmation:
                    txtTitle.Text = "Confirmation";
                    break;
                case MessageType.Success:
                    {
                        txtTitle.Text = "Success";
                    }
                    break;
                case MessageType.Warning:
                    txtTitle.Text = "Warning";
                    break;
                case MessageType.CPU:
                    txtTitle.Text = "CPU Selected";
                    break;
                case MessageType.Error:
                    {
                        txtTitle.Text = "Error";
                    }
                    break;
            }
            //Switch pour choisir le type de boutons que l'on veut utiliser
            switch (Buttons)
            {
                case MessageButtons.OkCancel:
                    
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
                //Attribution des valeurs mises en paramètre pour permettre de personnaliser les messages
                case MessageButtons.YesNo:
                    btnYes.Content = btnYesContent;
                    btnNo.Content = btnNoContent;
                    btnOk.Visibility = Visibility.Collapsed; btnCancel.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.Ok:
                    btnOk.Visibility = Visibility.Visible;
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        //Action lors du clic sur le bouton lié à Yes
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
        //Action lors du clic sur le bouton lié à Cancel
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        //Action lors du clic sur le bouton lié à Ok
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
        //Action lors du clic sur le bouton lié à No
        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        //Action lors du clic sur le bouton lié à Close
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
    //Déclaration en énumération du type de MessageBox 
    public enum MessageType
    {
        Info,
        Confirmation,
        Success,
        Warning,
        CPU,
        Error,
    }
    //Déclaration en énumération du type de boutons 
    public enum MessageButtons
    {
        OkCancel,
        YesNo,
        Ok,
    }
}