using Renci.SshNet;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CAPSlock
{
    public class txtCreation
    {
        public string vmName { get; private set; }
        public string vmVersion { get; private set; }
        public int vmProcessor { get; private set; }
        public string disk { get; private set; }

        public txtCreation(string vmName, string vmVersion, int vmProcessor, string disk)
        {
            this.vmName = vmName;
            this.vmVersion = vmVersion;
            this.vmProcessor = vmProcessor;
            this.disk = disk;
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        public static void createConfigFile(string profile, string name,string numalist, string cpu, string memory, string network, string os, string cdrom, string raid,string startAuto)
        {
            string uuid = Guid.NewGuid().ToString();
            string patternRInt = @"^.{0,8}";
            Match msid = Regex.Match(uuid, patternRInt, RegexOptions.IgnoreCase);
            string answer = Code.launchCommand("capsvmctl --list all");

            
            string getpath(int number)
            {
                string pattern = @"vm-" + number;
                MatchCollection matches = Regex.Matches(answer, pattern);
                if(matches.Count != 0)
                {
                    number++;
                    return getpath(number);
                }
                return pattern;
            }
            
            string path = getpath(1);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, "vm_profile=\"server\"\n");
                AddText(fs, "vm_label=\"" + name + "\"\n");
                AddText(fs, "vm_memory=\"" + memory + "\"\n");
                AddText(fs, "vm_nb_cpus=\"" + cpu + "\"\n");
                AddText(fs, "vm_numa_list=\"" + numalist   +"\"\n");
                AddText(fs, "vm_backing_hdd=\"win10-templ.qcow2\"\n");
                AddText(fs, "vm_os_hdd=\"win10.qcow2\"\n");
                AddText(fs, "vm_os_serial=\"CAPS001\"\n");
                AddText(fs, "vm_smbios_serial=\"" + msid + "\"\n");
                AddText(fs, "vm_smbios_uuid=\"" + uuid + "\"\n");
                AddText(fs, "vm_autostart=\"" + startAuto + "\"\n");
                AddText(fs, "vm_pcidev=\"\"\n");
                AddText(fs, "vm_cdrom=\"" + cdrom +  "\"\n");
            }
            //ScpClient scp = Login.newConnexion.GetScpClient();
            //FileStream lr = new FileStream(path, FileMode.Open, FileAccess.Read);
            //scp.Upload(lr, "opt/CAPS/etc/capsvm.d/enabled");
            string execPath = AppDomain.CurrentDomain.BaseDirectory;
            string pathfile = execPath+path;
            FileInfo f = new FileInfo(pathfile);
            string uploadfile = f.FullName;
            SftpClient client = Login.newConnexion.GetSftpClient();
            if (client.IsConnected)
            {
                var fileStream = new FileStream(uploadfile, FileMode.Open);
                if (fileStream != null)
                {
                    //If you have a folder located at sftp://ftp.example.com/share
                    //then you can add this like:
                    client.UploadFile(fileStream, "/opt/CAPS/etc/capsvm.d/enabled/" + f.Name, null);
                }
            }
            Code.refreshNumberVm();
            
        }
    }
}
