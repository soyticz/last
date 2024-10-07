using System.Windows;

namespace wpf1
{
    public class BooleanToVisibilityConverter : BooleanToValueConverter<Visibility>
    {
        public override Visibility TrueValue => Visibility.Visible;
        public override Visibility FalseValue => Visibility.Collapsed;
    }
}
