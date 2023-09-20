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
    public partial class PlaybackHeaderControl : UserControl
    {
        MainWindow mainWindow;
        SeriesItem seriesItem;
        EpisodeItem episodeItem;

        public PlaybackHeaderControl( MainWindow mainWindow, SeriesItem seriesItem, EpisodeItem episodeItem )
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.seriesItem = seriesItem;
            this.episodeItem = episodeItem;

            this.title.Text = episodeItem.title;
            this.description.Text = episodeItem.description;
            this.Opacity = 0;
        }

        private void OnMouseEnter( object sender, MouseEventArgs e )
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void OnMouseLeave( object sender, MouseEventArgs e )
        {
            Mouse.OverrideCursor = null;
        }

        private void OnHeaderMouseEnter( object sender, MouseEventArgs e )
        {
            this.Opacity = 100;
        }

        private void OnHeaderMouseLeave(object sender, MouseEventArgs e)
        {
            this.Opacity = 0;
        }

        private void OnMouseLeftButtonDown( object sender, MouseButtonEventArgs e )
        {
            mainWindow.SwitchPage( PageEnum.SelectionPage, seriesItem );
        }
    }
}