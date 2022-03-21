using Renci.SshNet;
using System.Threading;
using System.Threading.Tasks;

namespace CAPSlock
{
    public class Connexion
    {
        private string username { get; set; }
        private string password { get; set; }
        private string ip { get; set; }
        private SftpClient sftpSession { get; set; }
        private SshClient sshSession { get; set; }
        private ScpClient scpSession { get; set; }

        public Connexion(string username, string password, string ip)
        {
            this.username = username;
            this.password = password;
            this.ip = ip;
        }
        Thread newWindowThread = new Thread(new ThreadStart(() =>
        {
            // create and show the window
            bool? obj = new MessageBoxCustom("Please write correct informations", MessageType.Confirmation, MessageButtons.Ok, "", "").ShowDialog();


            // start the Dispatcher processing  
            System.Windows.Threading.Dispatcher.Run();
        }));

   
        public async Task connect()
        {

                await Task.Run(() =>
                {
                    SftpClient client = new SftpClient(ip, username, password);
                    SshClient clientssh = new SshClient(ip, username, password);
                    ScpClient clientscp = new ScpClient(ip, username, password);
                    try
                    {
                        client.Connect();
                    }
                    catch
                    {
                        // set the apartment state  
                        newWindowThread.SetApartmentState(ApartmentState.STA);

                        // make the thread a background thread  
                        newWindowThread.IsBackground = true;
                        // start the thread  
                        newWindowThread.Start();
                        return;
                    }try
                    {
                        clientssh.Connect();
                    }
                    catch
                    {
                        // set the apartment state  
                        newWindowThread.SetApartmentState(ApartmentState.STA);

                        // make the thread a background thread  
                        newWindowThread.IsBackground = true;

                        // start the thread  
                        newWindowThread.Start();
                        return;
                    }
                    try
                    {
                        clientscp.Connect();
                    }
                    catch
                    {
                        // set the apartment state  
                        newWindowThread.SetApartmentState(ApartmentState.STA);

                        // make the thread a background thread  
                        newWindowThread.IsBackground = true;

                        // start the thread  
                        newWindowThread.Start();
                        return;
                    }
                    this.sftpSession = client;
                    this.sshSession = clientssh;
                    this.scpSession = clientscp;
                });


        }

        public bool connectIn()
        {
            try
            {
                if (sshSession.IsConnected && sftpSession.IsConnected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            
        }

        public SshClient GetSshClient()
        {
            return sshSession;
        }
        public SftpClient GetSftpClient()
        {
            return sftpSession;
        }

        public ScpClient GetScpClient()
        {
            return scpSession;
        }

        public string[] GetUsernamePassword()
        {
            string[] info = { ip, username, password };
            return info;
        }
    }
}
