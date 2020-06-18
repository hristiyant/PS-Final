using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StudentInfoSystem.View
{
    /// <summary>
    /// Interaction logic for CustomButton.xaml
    /// </summary>
    public partial class CustomButtonView : Button
    {
        readonly static Brush DefaultHoverBackgroundValue = new BrushConverter().ConvertFromString("#FFBEE6FD") as Brush;
        public event EventHandler CustomButtonClicked;

        public CustomButtonView()
        {
            InitializeComponent();
        }

        public override void OnApplyTemplate()
        {
            Button btn = this.FindName("myCustomButton") as Button;

            if (btn == null) throw new Exception("Couldn't find 'Button'");

            btn.Click += new System.Windows.RoutedEventHandler(btn_Click);
        }

        void btn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnCustomButtonClicked();
        }

        private void OnCustomButtonClicked()
        {
            if (CustomButtonClicked != null)
                CustomButtonClicked(this, EventArgs.Empty);
        }

        public Brush HoverBackground
        {
            get { return (Brush)GetValue(HoverBackgroundProperty); }
            set { SetValue(HoverBackgroundProperty, value); }
        }
        public static readonly DependencyProperty HoverBackgroundProperty = DependencyProperty.Register(
          "HoverBackground", typeof(Brush), typeof(CustomButtonView), new PropertyMetadata(DefaultHoverBackgroundValue));
    }
}
