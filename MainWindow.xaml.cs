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

namespace Pireflix
{

    public enum PageEnum
    {
        HomePage,
        SelectionPage,
        MediaPage
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Content = new HomePage( this );
        }

        public void SwitchPage( PageEnum page, SeriesItem seriesItem = null, EpisodeItem episodeItem = null )
        {
            if ( page == PageEnum.HomePage )
            {
                this.Content = new HomePage( this );
            }
            else if ( page == PageEnum.SelectionPage )
            {
                this.Content = new SelectionPage( this, seriesItem );
            }
            else if ( page == PageEnum.MediaPage )
            {
                this.Content = new MediaPage( this, seriesItem, episodeItem );
            }
        }
    }
}