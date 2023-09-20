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
    public partial class SelectionPage : Page
    {
        private static int seasonMarginTop = 120;
        private int seasonMarginIncrement = 40;

        private static int seasonDisplayMarginTop = 0;
        private int seasonDisplayMarginIncrement = 220;

        private List<TextBlock> seasonList = new();
        private SeriesItem currentSeries;

        MainWindow mainWindow;

        public SelectionPage( MainWindow window, SeriesItem seriesItem )
        {
            InitializeComponent();
            mainWindow = window;

            if ( seriesItem == null )
            {
                return;
            }

            currentSeries = seriesItem;

            foreach ( SeasonItem season in seriesItem.seasonList )
            {
                AddSeasonListBoxEntry();
            }

            DisplaySeason( currentSeries.seasonList[0] );
        }

        private void DisplaySeason( SeasonItem seasonItem )
        {
            foreach ( EpisodeItem episode in seasonItem.episodeList )
            {
                EpisodeControl episodeControl = new();

                episodeControl.HorizontalAlignment = HorizontalAlignment.Center;
                episodeControl.VerticalAlignment = VerticalAlignment.Top;
                episodeControl.MouseEnter += new MouseEventHandler( Image_MouseEnter );
                episodeControl.MouseLeave += new MouseEventHandler( Image_MouseLeave );
                episodeControl.MouseLeftButtonDown += new MouseButtonEventHandler( OnEpisodeClick );
                episodeControl.Margin = new Thickness( 0, seasonDisplayMarginTop, 0, 0 );
                episodeControl.titleBlock.Text = episode.title;
                episodeControl.descriptionBlock.Text = episode.description;
                episodeControl.episodeImage.Source = new BitmapImage( new Uri( episode.imageSource, UriKind.RelativeOrAbsolute ) );

                seasonDisplayCanvas.Children.Add( episodeControl );
                seasonDisplayMarginTop += seasonDisplayMarginIncrement;
            }
        }

        private void AddSeasonListBoxEntry()
        {
            TextBlock seasonBlock = new();
            string seasonText = "Season ";

            seasonBlock.HorizontalAlignment = HorizontalAlignment.Left;
            seasonBlock.VerticalAlignment = VerticalAlignment.Top;
            seasonBlock.TextAlignment = TextAlignment.Center;
            seasonBlock.TextWrapping = TextWrapping.Wrap;
            seasonBlock.FontSize = 22;
            seasonBlock.FontFamily = new FontFamily( "Arial" );
            seasonBlock.Width = 100;
            seasonBlock.Height = 35;
            seasonBlock.Foreground = ( Brush )new BrushConverter().ConvertFrom( "#FFFFFF" );
            seasonBlock.MouseEnter += new MouseEventHandler( Image_MouseEnter );
            seasonBlock.MouseLeave += new MouseEventHandler( Image_MouseLeave );
            seasonBlock.MouseLeftButtonDown += new MouseButtonEventHandler( OnSeasonClick );

            if ( seasonList.Count == 0 )
            {
                seasonBlock.Text = seasonText + "1";
                seasonBlock.Margin = new Thickness( 52, seasonMarginTop, 0, 0 );

                seasonList.Add( seasonBlock );
                seasonCanvas.Children.Add( seasonBlock );

                return;
            }

            int seasonNumber = Convert.ToInt32
            ( 
                seasonList.Last().Text.Split( ' ' ).Last() 
            ) + 1;

            seasonMarginTop += seasonMarginIncrement;
            seasonBlock.Text = seasonText + seasonNumber.ToString();
            seasonBlock.Margin = new Thickness( 52, seasonMarginTop, 0, 0 );

            seasonList.Add( seasonBlock );
            seasonCanvas.Children.Add( seasonBlock );
        }

        private void Image_MouseEnter( object sender, MouseEventArgs e )
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void Image_MouseLeave( object sender, MouseEventArgs e )
        {
            Mouse.OverrideCursor = null;
        }

        private void Image_MouseLeftButtonDown( object sender, MouseButtonEventArgs e )
        {
            seasonMarginTop = 120;
            seasonDisplayMarginTop = 0;
            mainWindow.SwitchPage( PageEnum.HomePage );
        }

        private void OnSeasonClick( object sender, MouseButtonEventArgs e )
        {
            if ( currentSeries == null )
            {
                return;
            }

            seasonDisplayCanvas.Children.RemoveRange( 0, seasonDisplayCanvas.Children.Count );
            seasonDisplayMarginTop = 0;
            DisplaySeason( currentSeries.seasonList[ int.Parse( ( sender as TextBlock ).Text.Split( ' ' )[1] ) - 1] );
        }

        private void OnEpisodeClick( object sender, MouseButtonEventArgs e )
        {
            EpisodeItem episodeItem = null;

            if ( currentSeries == null )
            {
                return;
            }

            for ( int i = 0; i < currentSeries.episodeList.Count; i++ )
            {
                if ( ( sender as EpisodeControl ).titleBlock.Text == currentSeries.episodeList[i].title )
                {
                    episodeItem = currentSeries.episodeList[i];
                    break;
                }
            }

            if ( episodeItem == null )
            {
                return;
            }

            seasonMarginTop = 120;
            seasonDisplayMarginTop = 0;

            mainWindow.SwitchPage( PageEnum.MediaPage, currentSeries, episodeItem );
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = sender as ScrollViewer;

            double offset = scrollViewer.VerticalOffset - Math.Sign( e.Delta ) * 40;
            offset = Math.Min( Math.Max( offset, 0 ), scrollViewer.ExtentHeight );

            if ( scrollViewer.VerticalOffset > ( 220 * seasonDisplayCanvas.Children.Count ) - 800 && offset > scrollViewer.VerticalOffset )
            {
                e.Handled = true;
                return;
            }

            scrollViewer.ScrollToVerticalOffset( offset );
            e.Handled = true;
        }
    }
}
