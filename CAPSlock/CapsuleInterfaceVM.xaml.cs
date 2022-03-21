using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;




namespace CAPSlock
{
    /// <summary>
    /// Logique d'interaction pour CapsuleInterfaceVM.xaml
    /// </summary>
    public partial class CapsuleInterfaceVM : Window
    {
        public List<object> badge = new List<object>();
        public static bool boolanimation = false;
        public CapsuleInterfaceVM()
        {

            string argzrg = Code.launchCommand("capsvmctl --list 1");
            var patternName = new Regex("\".*?\"");
            var infoVm = patternName.Matches(argzrg);
            for (int i = 0; i < infoVm.Count; i++)
            {
                Trace.WriteLine(infoVm[i]);
            }
            string[] info = Login.newConnexion.GetUsernamePassword();
            InitializeComponent();
            Hostname();

            if (info[2] == "$0merset")
            {
                Terminal.Visibility = Visibility.Visible;
                AddMachine.Visibility = Visibility.Visible;
            }
            else
            {
                Terminal.Visibility = Visibility.Hidden;
                AddMachine.Visibility = Visibility.Collapsed;
            }
            Code.getAllVm();
            this.contentControl.Content = new CAPSApercu();
            List<VmSettings> machine = Code.getListVm();
            foreach (VmSettings vm in machine)
            {

                MaterialDesignThemes.Wpf.Badged badged = new MaterialDesignThemes.Wpf.Badged();
                var styleBadge = FindResource("badgeStyle") as Style;
                badged.Style = styleBadge;
                var green = new SolidColorBrush(Colors.DarkGreen);
                if (vm.online)
                {
                    badged.BadgeBackground = green;
                }
                var btn = new System.Windows.Controls.Button()
                {
                    Name = "id" + vm.ID.ToString(),
                    Style = FindResource("bouton_VM") as Style,
                    Content = vm.nameVM
                };
                badged.Content = (btn);
                list_VM.Items.Add(badged);
                badge.Add(badged);
            }
            System.Timers.Timer timer = new System.Timers.Timer(3000);
            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Tmr_Tick);
            timer.AutoReset = true;

        }

        private async void Tmr_Tick(object sender, EventArgs e)  //run this logic each timer tick
        {
            if (Login.newConnexion.connectIn() != true)
            {
                Trace.WriteLine("Reconnexion...");
                await Task.Run(() =>
                {
                    Login.newConnexion.connect();
                });
                Trace.WriteLine("Connexion établit");

            }
            await Task.Run(() =>
            {
                checkNumberVm();
            });
            await Task.Run(() =>
            {
                Code.refreshStatus();
            });
            await Task.Run(() =>
            {
                applyStatus();
            });
            this.Dispatcher.Invoke(() =>
            {
                Trace.WriteLine(boolanimation);
                if (boolanimation == true)
                {
                    boolanimation = false;
                    CAPSApercu accueil = new CAPSApercu();
                    contentControl.Content = accueil;
                    Login.capsuleInterfaceVM.ChangeBlur(false);
                }
                
            });
        }
        private void applyStatus()
        {
            int tar = 0;
            foreach (VmSettings vm in Code.machine)
            {
                bool status = vm.Status();
                if (status == true)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        MaterialDesignThemes.Wpf.Badged item = list_VM.Items[tar] as MaterialDesignThemes.Wpf.Badged; // Get the current item and cast it to MyListBoxItem
                        var styleBadge = FindResource("badgeStyleTrue") as Style;
                        item.Style = styleBadge;
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        MaterialDesignThemes.Wpf.Badged item = list_VM.Items[tar] as MaterialDesignThemes.Wpf.Badged; // Get the current item and cast it to MyListBoxItem
                        var styleBadge = FindResource("badgeStyle") as Style;
                        item.Style = styleBadge;
                    });
                }
                tar++;
            }
        }

        private async void checkNumberVm()
        {
            int nmberVM = Code.refreshNumberVm();
            Trace.WriteLine(nmberVM);
            if (nmberVM != 999)
            {
                await Task.Run(() =>
                {
                    Code.machine.Clear();
                    Code.getAllVm();
                });

                this.Dispatcher.Invoke(() =>
                {
                    list_VM.Items.Clear();
                    addButton();
                });

            }
        }

        public void Hostname()
        {


            HostName.Text = "Capsule@" + Code.launchCommand("echo $(uname -n)");
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
            Environment.Exit(0);
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

        private void Button_terminal(object sender, RoutedEventArgs e)
        {
            Process console = new Process();
            console.StartInfo.FileName = @"C:\Program Files (x86)\Capsule Technologies\Console V1.0.5\DevConnexionVM.exe";

            string[] info = Login.newConnexion.GetUsernamePassword();
            string result = info[0] + " " + info[1] + " " + info[2];
            console.StartInfo.Arguments = result;
            console.Start();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
            Environment.Exit(0);

        }
        private void Apercu(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new CAPSApercu();
        }

        private void AjouterMachine(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new AjouterMachine();
        }

        private void Desktop(object sender, RoutedEventArgs e)
        {

            string s = (sender as System.Windows.Controls.Button).Name.ToString();
            string patternRInt = @"[0-9]{1,3}";
            Match idVmInt = Regex.Match(s, patternRInt, RegexOptions.IgnoreCase);
            int result = int.Parse(idVmInt.Value);
            List<VmSettings> machine = Code.getListVm();
            this.contentControl.Content = new CAPSDesktop(machine[result - 1].nameVM, machine[result - 1].ID, machine[result - 1].proc, machine[result - 1].memory);
        }

        private void addButton()
        {
            
            foreach (VmSettings vm in Code.machine)
            {

                MaterialDesignThemes.Wpf.Badged badged = new MaterialDesignThemes.Wpf.Badged();
                var styleBadge = FindResource("badgeStyle") as Style;
                badged.Style = styleBadge;
                var green = new SolidColorBrush(Colors.DarkGreen);
                if (vm.online)
                {
                    badged.BadgeBackground = green;
                }
                var btn = new System.Windows.Controls.Button()
                {
                    Name = "id" + vm.ID.ToString(),
                    Style = FindResource("bouton_VM") as Style,
                    Content = vm.nameVM
                };
                badged.Content = (btn);
                list_VM.Items.Add(badged);
                badge.Add(badged);
            }
        }

        private void Button_snapshot(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new CAPSSnapshot();

        }

        public void ChangeBlur(bool boolean)
        {
            if (boolean)
            {
                PanelBlur.Radius = 10;
                vmexpander.IsExpanded = false;
                vmexpander.IsEnabled = false;
                overviewButton.IsEnabled = false;
                snapshotButton.IsEnabled = false;
                Terminal.IsEnabled = false;
                logOutButton.IsEnabled = false;

            }
            else
            {
                PanelBlur.Radius = 0;
                vmexpander.IsEnabled = true;
                overviewButton.IsEnabled = true;
                snapshotButton.IsEnabled = true;
                Terminal.IsEnabled = true;
                logOutButton.IsEnabled = true;
            }

        }
    }
}
