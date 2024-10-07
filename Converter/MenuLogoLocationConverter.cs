using System.Windows;

namespace wpf1
{
    public class MenuLogoLocationConverter : BooleanToValueConverter<Thickness>
    {
        public override Thickness TrueValue => new Thickness(55, -25, 0, 0);
        public override Thickness FalseValue => new Thickness(10, -30, 0, 0);
    }
}
