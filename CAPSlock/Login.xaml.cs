using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace CAPSlock
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// 

    /// </summary>
    public partial class Login : Window
    {
        public static Connexion newConnexion { get; set; }
        public static string IP { get; set; }

        public static CapsuleInterfaceVM capsuleInterfaceVM;
        public Login()
        {

            InitializeComponent();

            LoadLogin();

        }

        private void checkBox_showPassword_Checked(object sender, RoutedEventArgs e)
        {
            PasswordUnmask.Visibility = Visibility.Visible;
            FloatingPasswordBox.Visibility = Visibility.Hidden;
            PasswordUnmask.Text = FloatingPasswordBox.Password;
        }

        private void checkBox_showPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordUnmask.Visibility = Visibility.Hidden;
            FloatingPasswordBox.Visibility = Visibility.Visible;
            FloatingPasswordBox.Password = PasswordUnmask.Text;
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != (WindowState)FormWindowState.Maximized)
            {
                this.WindowState = (WindowState)FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = (WindowState)FormWindowState.Normal;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = (WindowState)FormWindowState.Minimized;

        }

        private async void connexionButton(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            btnC.IsEnabled = false;
            string username = userBox.Text;
            string password = FloatingPasswordBox.Password;
            string ip = IPBox.Text;

            newConnexion = new Connexion(username, password, ip);
            await newConnexion.connect();
            IP = ip;

            if (newConnexion.connectIn() == true)
            {
                System.Windows.Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    SaveLogin();
                    capsuleInterfaceVM = new CapsuleInterfaceVM();
                    capsuleInterfaceVM.Show();
                    this.Close();
                    Mouse.OverrideCursor = null;
                });


            }
            else
            {
                btnC.IsEnabled = true;
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                return;
            }
            return;
        }
        private void LoadLogin()
        {

            if (Properties.Settings.Default.IPBox != string.Empty)
            {
                userBox.Text = Properties.Settings.Default.userBox;
                FloatingPasswordBox.Password = Properties.Settings.Default.FloatingPasswordBox;
                IPBox.Text = Properties.Settings.Default.IPBox;
                RememberMe.IsChecked = true;
            }
        }

        private void SaveLogin()
        {

            if (RememberMe.IsChecked == true)
            {
                Properties.Settings.Default.IPBox = IPBox.Text;
                Properties.Settings.Default.FloatingPasswordBox = FloatingPasswordBox.Password;
                Properties.Settings.Default.userBox = userBox.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.IPBox = "";
                Properties.Settings.Default.FloatingPasswordBox = "";
                Properties.Settings.Default.userBox = "";
                Properties.Settings.Default.Save();
            }
        }

        private async void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                btnC.IsEnabled = false;
                string username = userBox.Text;
                string password = FloatingPasswordBox.Password;
                string ip = IPBox.Text;

                newConnexion = new Connexion(username, password, ip);
                await newConnexion.connect();
                IP = ip;

                if (newConnexion.connectIn() == true)
                {
                    System.Windows.Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        SaveLogin();
                        capsuleInterfaceVM = new CapsuleInterfaceVM();
                        capsuleInterfaceVM.Show();
                        this.Close();
                        Mouse.OverrideCursor = null;
                    });


                }
                else
                {
                    btnC.IsEnabled = true;
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                    return;
                }
                return;
            }
        }


    }
}
