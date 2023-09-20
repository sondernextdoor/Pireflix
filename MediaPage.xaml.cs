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
    public partial class MediaPage : Page
    {
        private SeriesItem seriesItem;
        private EpisodeItem episodeItem;
        private MainWindow mainWindow;
        private PlaybackControl playbackControl;
        private PlaybackHeaderControl playbackHeader;

        public MediaPage( MainWindow mainWindow, SeriesItem seriesItem, EpisodeItem episodeItem )
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.seriesItem = seriesItem;
            this.episodeItem = episodeItem;

            mediaPlayer.Source = new( episodeItem.mediaSource, UriKind.RelativeOrAbsolute );
            playbackControl = new( mediaPlayer, episodeItem );
            playbackControl.Margin = new( 0, 1020, 0, 0 );

            playbackHeader = new( mainWindow, seriesItem, episodeItem );
            playbackHeader.Margin = new( 0, 0, 0, 0 );

            mediaCanvas.Children.Add( playbackControl );
            mediaCanvas.Children.Add( playbackHeader );
        }
    }
}
