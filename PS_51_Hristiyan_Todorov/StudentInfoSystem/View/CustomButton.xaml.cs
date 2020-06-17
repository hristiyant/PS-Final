using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StudentInfoSystem.View
{
    /// <summary>
    /// Interaction logic for CustomButton.xaml
    /// </summary>
    public partial class CustomButton : Button
    {
        readonly static Brush DefaultHoverBackgroundValue = new BrushConverter().ConvertFromString("#FFBEE6FD") as Brush;

        public CustomButton()
        {
            InitializeComponent();
        }

        public Brush HoverBackground
        {
            get { return (Brush)GetValue(HoverBackgroundProperty); }
            set { SetValue(HoverBackgroundProperty, value); }
        }
        public static readonly DependencyProperty HoverBackgroundProperty = DependencyProperty.Register(
          "HoverBackground", typeof(Brush), typeof(CustomButton), new PropertyMetadata(DefaultHoverBackgroundValue));
    }
}
