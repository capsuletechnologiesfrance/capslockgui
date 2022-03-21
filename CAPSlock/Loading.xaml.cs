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
    /// Logique d'interaction pour Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        public Loading()
        {
            InitializeComponent();
            media.Source = new Uri(Environment.CurrentDirectory + @"\load2.gif");
            Loadings();
           
        }
       

        DispatcherTimer timer = new DispatcherTimer();

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            media.Position = new TimeSpan(0, 0, 1);
            media.Play();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            timer.Stop();
            //Hide();
                //realApp win = new realApp();
                //win.ShowDialog();

        }

        void Loadings()
        {
            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
        }
    }
}
