using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using XamarinNoteApp.Enum;
using XamarinNoteApp.Models;

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
                    return Color.Yellow;
                if (color == (int)Colors.Green)
                    return Color.Green;
                if (color == (int)Colors.Blue)
                    return Color.Blue;
                if (color == (int)Colors.Purple)
                    return Color.Purple;
                if (color == (int)Colors.Pink)
                    return Color.Pink;
                if (color == (int)Colors.Red)
                    return Color.Red;
                if (color == (int)Colors.Orange)
                    return Color.Orange;
            }

            return Color.LightGray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}