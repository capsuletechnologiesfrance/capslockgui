namespace CAPSlock
{
    public class VmSettings
    {
        /// <VmSettings>
        /// Cette classe nous permet de définir une instance lié a une machine virtuelle. On la déclare dans le fichier Code.cs
        /// </VmSettings>
        public int ID { get; private set; }
        public string nameVM { get; private set; }

        public string typeOS { get; private set; }
        public bool online { get; private set; }
        public string proc { get; private set; }
        public string memory { get; private set; }
        public string configFilePath { get; private set; }
        public int portVNC { get; private set; }
        public string osUsed { get; private set; }

        public VmSettings(string nameVM, string proc, string memory, bool online, string configFilePath, int ID, int portVNC, string osUsed)
        {
            this.nameVM = nameVM;

            this.online = online;
            this.proc = proc;
            this.memory = memory;
            this.configFilePath = configFilePath;
            this.ID = ID;
            this.portVNC = portVNC;
            this.osUsed = osUsed;
        }

        public string getPathConfigFile()
        {
            return configFilePath;
        }

        public void changeStatus(bool res)
        {
            online = res;
        }
        public bool Status()
        {
            return online;
        }

        public int getID()
        {
            return ID;
        }
    }
}
