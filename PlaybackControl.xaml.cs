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

namespace Pireflix
{
    public partial class PlaybackControl : UserControl
    {
        private MediaElement mediaPlayer = new();
        private EpisodeItem episodeItem;
        private bool isPlayButton = true;
        private string currentPosition = "0:00:00";
        int hours = 0;
        int minutes = 0;
        int seconds = 0;
        public DispatcherTimer playbackTimer = new();

        private void UpdateSliderPosition( object sender, EventArgs e )
        {
            mediaSlider.Value += 1;
        }

        private int StringToDuration( out int hours, out int minutes, out int seconds )
        {
            hours = 0;
            minutes = 0;
            seconds = 0;

            for ( int i = 0; i < episodeItem.duration.Length; i++ )
            {
                for ( int j = 0; j < episodeItem.duration.Length; j++ )
                {
                    if ( episodeItem.duration[j] == ':' )
                    {
                        hours = int.Parse( episodeItem.duration[i..j] );
                        i = j + 1;
                        break;
                    }
                }

                for ( int j = i; j < episodeItem.duration.Length; j++ )
                {
                    if ( episodeItem.duration[j] == ':' )
                    {
                        minutes = int.Parse( episodeItem.duration[i..j] );
                        i = j + 1;
                        break;
                    }
                }

                for ( int j = i; j <= episodeItem.duration.Length; j++ )
                {
                    if ( j == episodeItem.duration.Length )
                    {
                        seconds = int.Parse( episodeItem.duration[i..j] );
                        break;
                    }
                }

                break;
            }

            return ( 60 * 60 * hours ) + ( 60 * minutes ) + seconds;
        }

        private string DurationToString( int seconds )
        {
            string hours = ( seconds / ( 60 * 60 ) ).ToString();
            string minutes = ( seconds / 60 - ( int.Parse( hours ) * 60 )  ).ToString();
            string _seconds = ( seconds - ( int.Parse( minutes ) * 60 ) - int.Parse( hours ) * 60 * 60 ).ToString();

            if ( hours == "0" && minutes == "0" )
            {
                _seconds = seconds.ToString();
            }

            if ( minutes.Length == 1 )
            {
                minutes = minutes.Insert( 0, "0" );
            }

            if ( _seconds.Length == 1 )
            {
                _seconds = _seconds.Insert( 0, "0" );
            }
            this.hours = int.Parse( hours );
            this.minutes = int.Parse( minutes );
            this.seconds = int.Parse( _seconds );

            return hours + ":" + minutes + ":" + _seconds;
        }

        public PlaybackControl( MediaElement mediaPlayer, EpisodeItem episodeItem )
        {
            InitializeComponent();

            this.mediaPlayer = mediaPlayer;
            this.episodeItem = episodeItem;

            this.mediaSlider.Minimum = 0;
            this.mediaSlider.Maximum = StringToDuration( out _, out _, out _ );

            durationBlock.Text = currentPosition + "/" + episodeItem.duration;

            playbackTimer.Tick += UpdateSliderPosition;
            playbackTimer.Interval = TimeSpan.FromSeconds( 1 );
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
            if ( isPlayButton == true )
            {
                mediaPlayer.Play();
                playbackTimer.Start();
                playPauseImage.Source = new BitmapImage( new( @"\images\pausebutton.png", UriKind.RelativeOrAbsolute ) );
            }
            else
            {
                mediaPlayer.Pause();
                playbackTimer.Stop();
                playPauseImage.Source = new BitmapImage( new( @"\images\playbutton.png", UriKind.RelativeOrAbsolute ) );
            }

            isPlayButton = !isPlayButton;
        }

        private void Playback_MouseLeave( object sender, MouseEventArgs e )
        {
            this.Opacity = 0;
        }

        private void Playback_MouseEnter( object sender, MouseEventArgs e )
        {
            this.Opacity = 100;
        }

        private void mediaSlider_ValueChanged( object sender, RoutedPropertyChangedEventArgs<double> e )
        {
            currentPosition = DurationToString( ( int )mediaSlider.Value );
            durationBlock.Text = currentPosition + "/" + episodeItem.duration;
        }

        private void mediaSlider_MouseLeftButtonUp( object sender, MouseButtonEventArgs e )
        {
            mediaPlayer.Position = new TimeSpan( hours, minutes, seconds );
        }
    }
}
