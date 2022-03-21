//Import des différents DLL. 
using Renci.SshNet;
//(cf. https://github.com/sshnet/SSH.NET)
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;

/// <Version>
/// V1.0.0 Capable de récupérer les Machines virtuelles automatiquement au lancement de l'application
/// V1.0.1 Ajout de la méthode qui fait un refresh du status des VMs
/// V1.0.2 Optimisation
/// V1.1.0 UPDATE : Commentaire + optimisation (gain de temps notable)
/// </Version>
namespace CAPSlock
{
    public partial class Code : Window
    {

        // ici on crée une liste qui va récupérer toutes les machines virtuelles. 
        public static List<VmSettings> machine = new List<VmSettings>();
        // Méthode getListVm qui récupère la liste des VMs.
        public static List<VmSettings> getListVm() => machine;
        //Méthode publique permettant de récupérer la méthode connexion via SFTP.
        public static SftpClient getSftpClient()
        {
            return Login.newConnexion.GetSftpClient();
        }
        //Méthode publique permettant de récupérer la méthode connexion via SSH.
        public static SshClient getSshClient()
        {
            return Login.newConnexion.GetSshClient();
        }
        //Méthode publique permettant de récupérer la méthode connexion via SCP.
        public static ScpClient getScpClient()
        {
            return Login.newConnexion.GetScpClient();
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        /// <getAllVm>
        /// La méthode getAllVm() permet de récupérer toutes les informations de chaque machine virtuelle présente sur le serveur/hyperviseur.
        /// Plus particulièrement on récupère toutes les informations nécessaires au bon fonctionnement de l'application. 
        /// Une fois toutes les informations récupérées, elles sont envoyées directement dans la list "machine" qui contient chaque instance de chaque VM.
        /// </getAllVm>

        public static void getAllVm()
        {
            // Déclaration de la variables qui permet de communiquer ent
            SshClient hyperviseurSsh = getSshClient();

            //Execution de la 1ère commande (capsvmctl --list all) récupérant ainsi le nombre de VMs disponible sur l'hyperviseur et on récupère le résultat de la commande
            string answer = launchCommand("capsvmctl --list all");

            //Création d'un pattern pour utilisation d'un regex (cf. https://docs.microsoft.com/fr-fr/dotnet/standard/base-types/regular-expression-language-quick-reference)
            string pattern = @"Configuration for VM id [0-9]{1,3}";

            //Utilisation de regex(Match) permettant de récupérer la ligne concernant l'ID de la machine virtuelle.
            //Regex.match permet de trouver une cohérence entre le pattern ainsi que notre chaine de caractère.
            //Ainsi si il y a une cohérence alors on récupère toutes les cohérences qui sont présentes.
            Match totalVm = Regex.Match(answer, pattern, RegexOptions.IgnoreCase);

            //Déclaration d'une variable permettant d'avoir le nombre total de machine virtuelle qui va être incrémenté à l'aide d'une boucle ainsi que du match totalVm.
            int totalVmInt = 0;
            //Condition : Si le regex ne trouve pas de/des VM(s) alors :
            if (totalVm.Success == false)
            {
                //Affichage dans la console qu'il ny a pas de VM)
                Trace.WriteLine("Il n'y a pas de machine virtuelle sur l'hyperviseur.");
                //Il n'y a pas pour le moment de système d'erreur qui traite ce sujet.
            }
            else
            {
                //Condition : Tant qu'il y a des VMs à traiter alors : 
                while (totalVm.Success)
                {
                    //On augmente de 1 le nombre de VM total.
                    totalVmInt++;
                    //Création d'un pattern pour récupérer.
                    string patternInt = @"[0-9]{1,3}";
                    //Ici on recherche les IDs des VMs.
                    Match idVm = Regex.Match(totalVm.Value, patternInt, RegexOptions.IgnoreCase);
                    int idVM = int.Parse(idVm.Value);
                    //On récupère le fichier chemin du fichier de configuration en fonction de l'ID de la VM.
                    string configFilePath = launchCommandSingleLine("capsvmctl --getfilename " + idVM);
                    Trace.WriteLine(configFilePath);
                    //On execute la commande capsvmctl --list avec l'id de la vm pour avoir les informations d'uniquement 1 VM pour pouvoir ensuite la traiter.
                    string vm = launchCommand("capsvmctl --list " + idVM);
                    //Ce pattern nous permet de savoir combien de retour à la ligne il y a. Ainsi on peut avoir 
                    var patternName = new Regex("\".*?\"");
                    //On fait le match pour savoir le nombre de ligne.
                    var infoVm = patternName.Matches(vm);
                    //Déclaration des variables pour le traitement
                    string nameVm = "";
                    string procVm = "";
                    string memoryVm = "";
                    string osUsed = "";
                    //Condition pour le nombre de ligne alors on rajout 1 à i
                    for (int i = 0; i < infoVm.Count; i++)
                    {
                        //Ici, on fait un switch case pour récupérer les informations en fonction des lignes. Exemple la ligne 1 donc (0) récupère le nom de la vm;
                        switch (i)
                        {
                            case 0:
                                nameVm = infoVm[0].ToString();
                                nameVm = nameVm.Replace("\"", "");
                                break;
                            case 5:
                                procVm = infoVm[5].ToString();
                                procVm = procVm.Replace("\"", "");
                                break;
                            case 6:
                                memoryVm = infoVm[6].ToString();
                                memoryVm = memoryVm.Replace("\"", "");
                                break;
                            case 8:
                                osUsed = infoVm[8].ToString();
                                osUsed = osUsed.Replace("\"", "");
                                break;

                        }
                    }
                    //Même principe que la boucle du dessu mais la on récupère le status des VM
                    string rm = launchCommand("capsvmctl --status");
                    bool resstatus = false;
                    //Condition : Pour count = 0 , si count est < au nombre de vm total alors count  prends +1;
                    for (int count = 0; count < totalVmInt; count++)
                    {
                        //Pattern pour récupérer le stopped ou running
                        var patternStatus = new Regex("Stopped|Running");
                        var status = patternStatus.Matches(rm);
                        //On vérifie le status de la vm.
                        switch (status[count].Value)
                        {
                            case "Stopped":
                                resstatus = false;
                                break;
                            case "Running":
                                resstatus = true;
                                break;
                        }

                    }

                    Trace.Write(resstatus);

                    //Ajout port VNC
                    //Création du pattern pour récupérer le port
                    string patternRInt = @"[0-9]{2,4}";
                    //Match pour voir si il y a un port.
                    Match vncport = Regex.Match(launchCommand("capsvmctl --getvnc " + idVM), patternRInt, RegexOptions.IgnoreCase);
                    //On récupère le port qu'on tranforme en int
                    int vncres = int.Parse(vncport.Value);
                    //On ajoute une machine 
                    machine.Add(new VmSettings(nameVm, procVm, memoryVm, resstatus, configFilePath, idVM, vncres, osUsed));
                    //Prochain match
                    totalVm = totalVm.NextMatch();
                }
            }

        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        /// <refreshStatus>
        /// La méthode refreshStatus() permet de rafraichir le status des machines virtuelles.
        /// </refreshStatus>

        public static void refreshStatus()
        {
            //On lance la commande capsvmctl --status qui permet de récupérer le status de toutes les machines présentes sur l'application.
            string rm = launchCommand("capsvmctl --status");
            bool resstatus = false;
            //Condition : Pour count = 0 , si count est < au nombre de vm total alors count  prends +1;
            for (int count = 0; count < machine.Count; count++)
            {
                //Pattern pour récupérer le stopped ou running
                var patternStatus = new Regex("Stopped|Running");
                var status = patternStatus.Matches(rm);
                //On vérifie le status de la vm.
                Trace.WriteLine(status[count].Value);
                switch (status[count].Value)
                {
                    case "Stopped":
                        resstatus = false;
                        break;
                    case "Running":
                        resstatus = true;
                        break;
                }
                machine[count].changeStatus(resstatus);
            }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        /// <launchCommand>
        /// Cette méthode permet de pouvoir lancer une commande sur n'importe quelle classe. La méthode est accessible partout grâce a la propriété static
        /// </launchCommand>
        /// <param name="line">Chaine de caractère qui correspond à la commande bash qu'on souhaite lancer sur l'hyperviseur</param>
        /// <returns>Return le résultat de la commande (une chaine de caractère peut contenir des retours à la ligne)</returns>
        public static string launchCommand(string line)
        {
            //Déclaration des variables qu'on récupère à la connexion.
            SshClient command = getSshClient();
            //On créer la commande qu'on souhaite envoyer. 
            SshCommand cm = command.CreateCommand(line);
            //Try / catch pour executer la commande. Si il y a un problème alors on affiche l'erreur sur la console.
            try { cm.Execute(); } catch { Trace.WriteLine("Problème pour la commande " + line); }
            //On récupère le résultat
            string result = cm.Result;
            //On dispose (libère) l'instance sans la détruire;
            cm.Dispose();
            return result;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        /// <launchCommandSingleLine>
        /// Cette méthode permet de pouvoir lancer une commande sur n'importe quelle classe. La méthode est accessible partout grâce a la propriété static
        /// </launchCommandSingleLine>
        /// <param name="line">Chaine de caractère qui correspond à la commande bash qu'on souhaite lancer sur l'hyperviseur</param>
        /// <returns>Return le résultat de la commande </returns>
        /// WARNING : Cette méthode ne renvoie uniquement qu'une ligne et évite d'avoir un retour à la ligne.
        public static string launchCommandSingleLine(string line)
        {
            SshClient command = getSshClient();
            SshCommand cm = command.CreateCommand(line);
            try { cm.Execute(); } catch { Trace.WriteLine("Problème pour la commande " + line); }
            string result = cm.Result;
            cm.Dispose();
            //Ici on fait un traitement qui permet de remplacer les retours à la ligne par leurs suppresion. 
            result = result.Replace("\n", "").Replace("\r", "");
            return result;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        /// <refreshNumberVm>
        /// Cette méthode permet de regarder le nombre de Vm entre hyperviseur et logiciel.
        /// </refreshNumberVm>
        /// <returns>retourne 999 si il n'y a aucune changement OU alors l'ID de la VM à supprimer/ajouter</returns>
        public static int refreshNumberVm()
        {
            SftpClient hyperviseurSftp = getSftpClient();
            SshClient hyperviseurSsh = getSshClient();
            //Execution de la 1ère commande (capsvmctl --list all) récupérant ainsi le nombre de VMs disponible sur l'hyperviseur

            //On réucpère le résultat de la commande
            string answer = launchCommand("capsvmctl --list all");

            //Création d'un pattern pour utilisation d'un regex (cf. https://docs.microsoft.com/fr-fr/dotnet/standard/base-types/regular-expression-language-quick-reference)
            string pattern = @"Configuration for VM id [0-9]{1,3}";
            //Utilisation de regex(Match) permettant de récupérer la ligne cocnernant l'ID de la machine virtuelle.
            Match totalVm = Regex.Match(answer, pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = Regex.Matches(answer, pattern);
            //Déclaration d'une variable permettant d'avoir le nombre total de machine virtuelle.
            int totalVmInt = 0;
            //Condition : Si le regex ne trouve pas de/des VM(s) alors :
            if (totalVm.Success == false)
            {
                //Affichage dans la console qu'il ny a pas de VM)
                Trace.WriteLine("Il n'y a pas de machine virtuelle sur l'hyperviseur.");
                return 999;
            }
            else
            {
                int newtotalVmInt = matches.Count;
                Trace.WriteLine("Nombre dans la list Machine" + machine.Count);
                Trace.WriteLine("Nombre dans l'hyperviseur" + newtotalVmInt);
                // Condition : Si il y a plus de machine dans l'hyperviseur alors :
                if (newtotalVmInt < machine.Count)
                {
                    List<string> path = new List<string>();
                    int numbervm = 1;
                    while (totalVm.Success)
                    {
                        //On récupère le chemin de la machine qui est à supprimer.
                        string testt = launchCommandSingleLine("capsvmctl --getfilename " + numbervm);
                        path.Add(testt);
                        numbervm++;
                        totalVm = totalVm.NextMatch();
                    }
                    //Dans chaque machine présente dans la liste machine (cf. le haut de la page)
                    foreach (VmSettings vm in machine)
                    {
                        //Condition : Si le fichier de configuration existe dans une des machines présente sur l'application alors
                        if (path.Exists(x => x != vm.getPathConfigFile()))
                        {
                            Trace.WriteLine("Envoie de la suppresion de la vm " + vm.getID() + " avec le chemin " + vm.getPathConfigFile());
                            return vm.getID();
                            //On return la machine à supprimer.
                        }
                    }
                }
                //Sinon si il y a plus de machine ou alors autant de machine :
                else
                {
                    //On fait une boucle tant qu'il y a des VMs.
                    while (totalVm.Success)
                    {
                        //On augmente de 1 le nombre de VM total.
                        totalVmInt++;
                        //Création d'un pattern pour récupérer.
                        string patternInt = @"[0-9]{1,3}";
                        //Ici on recherche les IDs des VMs.
                        Match idVm = Regex.Match(totalVm.Value, patternInt, RegexOptions.IgnoreCase);
                        int vmID = int.Parse(idVm.Value);
                        //Condition : Pour i = 0 , si count est < au nombre de vm total alors i prend +1;
                        for (int i = 0; i < machine.Count; i++)
                        {
                            //Si la machine existe pas alors on ajoute la machine
                            if (machine[i].getID() != vmID)
                            {
                                //On return la machine à ajouter
                                return vmID;
                            }
                        }
                        totalVm = totalVm.NextMatch();
                    }
                }
                //Si il n'y a pas de moficiation alors return 999 (default)
                return 999;
            }
        }
    }
}

