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
    public class EpisodeItem
    {
        public string title;
        public string description;
        public string imageSource;
        public string mediaSource;
        public string duration;
    }

    public class SeasonItem
    {
        public int seasonNumber;
        public List<EpisodeItem> episodeList = new();

        public SeasonItem( int seasonNumber = -1 )
        {
            this.seasonNumber = seasonNumber;
        }

        public bool IsNull()
        {
            return seasonNumber == -1;
        }

        public bool AddEpisode( EpisodeItem episodeItem )
        {
            if ( seasonNumber == -1 )
            {
                return false;
            }

            foreach ( EpisodeItem episode in episodeList )
            {
                if ( episode.title.Equals( episodeItem.title ) == true )
                {
                    return false;
                }
            }

            episodeList.Add( episodeItem );
            return true;
        }
    }

    public class SeriesItem
    {
        public string title;
        public string airDate;
        public List<SeasonItem> seasonList = new();
        public List<EpisodeItem> episodeList = new();

        public SeriesItem( string title, string airDate )
        {
            this.title = title;
            this.airDate = airDate;
        }

        public bool AddSeason( int seasonNumber )
        {
            foreach ( SeasonItem season in seasonList )
            {
                if ( season.seasonNumber == seasonNumber )
                {
                    return false;
                }
            }

            seasonList.Add( new( seasonNumber ) );
            return true;
        }

        public bool AddSeason( SeasonItem seasonItem )
        {
            foreach ( SeasonItem season in seasonList )
            {
                if ( season.seasonNumber == seasonItem.seasonNumber)
                {
                    return false;
                }
            }

            seasonList.Add( seasonItem );
            return true;
        }

        public bool AddEpisode( int seasonNumber, EpisodeItem episodeItem )
        {
            SeasonItem desiredSeason = new();

            foreach ( SeasonItem season in seasonList )
            {
                if ( season.seasonNumber == seasonNumber )
                {
                    desiredSeason = season;
                    break;
                }
            }

            if ( desiredSeason.IsNull() == true )
            {
                return false;
            }

            episodeList.Add( episodeItem );
            return desiredSeason.AddEpisode( episodeItem );
        }

        public static SeriesItem MakeSeries( string[] data )
        {
            SeriesItem seriesItem = new( data[0], data[1] );
            
            for ( int i = 1; i <= int.Parse( data[2] ); i++ )
            {
                seriesItem.AddSeason( i );
            }

            for ( int i = 3, j = 1; i + 4 < data.Length; )
            {
                EpisodeItem episodeItem = new();

                if ( data[i] == "Pireflix Season End Id" )
                {
                    if ( i == data.Length - 1 )
                    {
                        return seriesItem;
                    }

                    j += 1;
                }

                episodeItem.title = data[i];
                episodeItem.description = data[i + 1];
                episodeItem.imageSource = data[i + 2];
                episodeItem.mediaSource = data[i + 3];
                episodeItem.duration = data[i + 4];

                seriesItem.AddEpisode( j, episodeItem );
                i += 5;
            }

            return seriesItem;
        }
    }
}