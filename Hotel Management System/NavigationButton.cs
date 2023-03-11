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

namespace Project
{
    [Serializable]
    public class NavigationButton : ListBoxItem
    {
        static NavigationButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationButton), new FrameworkPropertyMetadata(typeof(NavigationButton)));
        }

        public Uri Navigationlink
        {
            get { return (Uri)GetValue(NavigationlinkProperty); }
            set { SetValue(NavigationlinkProperty, value); }
        }
        public static readonly DependencyProperty NavigationlinkProperty =
            DependencyProperty.Register("Navigationlink", typeof(Uri), typeof(NavigationButton),
            new PropertyMetadata(null));
        
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Image), typeof(NavigationButton),
            new PropertyMetadata(null));
    }
}
