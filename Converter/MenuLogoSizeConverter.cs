using System.Windows;

namespace wpf1
{
    public class MenuLogoSizeConverter : BooleanToValueConverter<double>
    {
        public override double TrueValue => 80;
        public override double FalseValue => 50;
    }
}
