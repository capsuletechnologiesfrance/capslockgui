using Renci.SshNet;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CAPSlock
{
    /// <summary>
    /// Logique d'interaction pour CAPSApercu.xaml
    /// </summary>
    public partial class CAPSApercu : UserControl
    {
        public CAPSApercu()
        {
            string[] info = Login.newConnexion.GetUsernamePassword();
            InitializeComponent();
            Hour.Text = "System time : " + DateTime.Now.ToString("d MMMM yyyy HH:mm");
            commandA();
            if (info[2] != "$0merset")
            {
                restart.Visibility = Visibility.Hidden;
                Stop.Visibility = Visibility.Hidden;
            }
            System.Timers.Timer timer = new System.Timers.Timer(10000);
            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Tmr_Tick);
            timer.AutoReset = true;
            usedCPU.Text = "CPU : loading...";
        }



        private void Tmr_Tick(object sender, EventArgs e)  //run this logic each timer tick
        {
            commandA();
            this.Dispatcher.Invoke(() =>
            {
                Hour.Text = "System time : " + DateTime.Now.ToString("d MMMM yyyy HH:mm");
            });

        }

        public void Uptime()
        {
            SshClient hyperviseurSsh = Login.newConnexion.GetSshClient();
            SshCommand uptime = hyperviseurSsh.CreateCommand("uptime -p");
            string duree = uptime.Execute();
            this.Dispatcher.Invoke(() =>
            {
                UpTime.Text = "Uptime : " + duree.Replace("\n", "").Replace("\r", "");
            });
        }

        private void Restart_CAPS_OS(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Do you really want to reboot CAPS-OS ?", MessageType.Confirmation, MessageButtons.YesNo, "Yes", "No").ShowDialog();
            switch (result.Value)
            {
                case true:
                    SshClient hyperviseurSsh = Login.newConnexion.GetSshClient();
                    SshCommand reboot = hyperviseurSsh.CreateCommand("reboot");
                    reboot.Execute();
                    MessageBox.Show("Restarting CAPS-OS");
                    break;
                case false:

                    break;
                default:

                    break;
            }

        }

        private void Close_CAPS_OS(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Do you really want to shutdown CAPS-OS ?", MessageType.Confirmation, MessageButtons.YesNo, "Yes", "No").ShowDialog();
            switch (result.Value)
            {
                case true:
                    SshClient hyperviseurSsh = Login.newConnexion.GetSshClient();
                    SshCommand shutdown = hyperviseurSsh.CreateCommand("shutdown");
                    shutdown.Execute();
                    MessageBox.Show("System shutdown in 1 minute");
                    break;
                case false:

                    break;
                default:

                    break;
            }

        }


        public async void commandA()
        {
            string rm = "";
            string lU = "";
           
            string m = "";
            string capsId = "";
            string ramU = "";
            string memoryVm = "";
            await Task.Run(() =>
            {
                rm = Code.launchCommandSingleLine("echo $(uname -n)");
            });
            //----------------------------------------//
            await Task.Run(() =>
            {
                lU = Code.launchCommandSingleLine("echo $(uname -v)");
            });
           
            //----------------------------------------//
            await Task.Run(() =>
            {
                m = Code.launchCommandSingleLine("echo $(dmidecode -s system-manufacturer) $(dmidecode -s system-product-name)");
            });
            //----------------------------------------//
            await Task.Run(() =>
            {
                capsId = Code.launchCommandSingleLine("cat /etc/machine-id");
            });

            //----------------------------------------//
            await Task.Run(() =>
            {
                ramU = Code.launchCommandSingleLine("free --mega");
            });

            //----------------------------------------//





            //---------------------------------------//
            await Task.Run(() =>
            {
                var patternName = new Regex("[0-9]{1,15}");
                var infoVm = patternName.Matches(ramU);
                for (int i = 0; i < infoVm.Count; i++)
                {
                    memoryVm = infoVm[1].ToString() + " MB / " + infoVm[0].ToString() + " MB";
                }
            });


            
            refreshCPU();
            informationA(rm, lU,  m, capsId, memoryVm);
        }

        public async void refreshCPU()
        {
            await Task.Run(() =>
            {
                string cpuU = Code.launchCommandSingleLine(" echo $(top -bn2 | grep '%Cpu' | tail -1 | grep -P '(....|...) id,'|awk '{print 100-$8 \" % \"}') \" of \" $(/usr/bin/nproc) \" CPU\"");
                this.Dispatcher.Invoke(() =>
                {
                    usedCPU.Text = "CPU : " + cpuU;
                });
            });
        }

        public void informationA(string rm, string lU,  string m, string capsId, string memoryVm)
        {
            Uptime();

            this.Dispatcher.Invoke(() =>
            {
                hostName.Text = "Hostname : " + rm;
                update.Text = "Last update : " + lU;
                
                M.Text = "Model : " + m;
                IDmachine.Text = "Machine ID : " + capsId;
                usedRAM.Text = "Memory : " + memoryVm;

            });
        }

        public void refresh()
        {

        }
    }
}
