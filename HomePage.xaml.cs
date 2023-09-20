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
    public partial class HomePage : Page
    {
        private Dictionary<Image, SeriesItem> contentList = new();
        MainWindow mainWindow;

        public HomePage( MainWindow window )
        {
            InitializeComponent();
            mainWindow = window;

            SeriesItem gameOfThrones = SeriesItem.MakeSeries( SeriesData.gameOfThrones );
            SeriesItem starTrekDS9 = SeriesItem.MakeSeries( SeriesData.starTrekDS9 );

            contentList.Add( gameOfThronesImage, gameOfThrones );
            contentList.Add( ds9Image, starTrekDS9 );
        }

        private void Image_MouseEnter( object sender, MouseEventArgs e )
        {
            try
            {
                ( (Border )( sender as Image ).Parent ).BorderThickness = new( 1 );
            }
            catch { }

            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void Image_MouseLeave( object sender, MouseEventArgs e )
        {
           try
            {
                ( ( Border )( sender as Image ).Parent ).BorderThickness = new( 0 );
            }
            catch { }

            Mouse.OverrideCursor = null;
        }

        private void Image_MouseLeftButtonDown( object sender, MouseButtonEventArgs e )
        {
            contentList.TryGetValue( sender as Image, out SeriesItem series );
            mainWindow.SwitchPage( PageEnum.SelectionPage, series );
        }

        private void Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Close();
        }
    }
}