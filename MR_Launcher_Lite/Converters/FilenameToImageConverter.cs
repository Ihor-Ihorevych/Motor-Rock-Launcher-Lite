using System;
using System.Globalization;
using System.Windows.Data;

namespace MR_Launcher_Lite.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class FilenameToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"pack://application:,,,/ImageResources/{parameter}.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
