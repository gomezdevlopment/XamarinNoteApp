using System;
using System.Globalization;
using Xamarin.Forms;
using XamarinNoteApp.Enum;

namespace XamarinNoteApp.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? color = value as int?;
            if (color != null)
            {
                if (color == (int)Colors.Yellow)
                    return Color.FromHex("#FCEE96");
                if (color == (int)Colors.Green)
                    return Color.FromHex("#D2FBA4");
                if (color == (int)Colors.Blue)
                    return Color.FromHex("#7EB6D7");
                if (color == (int)Colors.Purple)
                    return Color.FromHex("#D3B5E5");
                if (color == (int)Colors.Pink)
                    return Color.FromHex("#FFD4DB");
                if (color == (int)Colors.Red)
                    return Color.FromHex("#E77480");
                if (color == (int)Colors.Orange)
                    return Color.FromHex("#F7BA8E");
            }

            return Color.LightGray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}