using SmallEarthTech.AntPlus;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamAntClientApp.Converters
{
    public class StreamToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageSource.FromStream(() => ((AntDevice)value).DeviceImageStream);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
