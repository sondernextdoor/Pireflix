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
    public partial class EpisodeControl : UserControl
    {
        public EpisodeControl()
        {
            InitializeComponent();
            this.Background = ( Brush )new BrushConverter().ConvertFrom( "#141414" );
        }

        private void EpisodeControl_MouseEnter( object sender, MouseEventArgs e )
        {
                border.BorderThickness = new( 2 );
        }

        private void EpisodeControl_MouseLeave( object sender, MouseEventArgs e )
        {
                border.BorderThickness = new( 0 );
        }
    }
}