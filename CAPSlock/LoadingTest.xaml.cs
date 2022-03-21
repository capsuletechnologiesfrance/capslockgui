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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CAPSlock
{
    /// <summary>
    /// Logique d'interaction pour LoadingTest.xaml
    /// </summary>
    public partial class LoadingTest : UserControl
    {
        public LoadingTest()
        {
            InitializeComponent();
            //Récupération du GIF présent dans les dossiers de l'application
            media.Source = new Uri(Environment.CurrentDirectory + @"\load2.gif");
        }
        //Lancement et continuation du GIF
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            media.Position = new TimeSpan(0, 0, 1);
            media.Play();
        }

        
    }
}
