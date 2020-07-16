using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Admin.DataConverter
{
    public class FaultToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is LightFaultEnum)
            {
                string c = AppDomain.CurrentDomain.BaseDirectory;
                string path = c + @"Image\Markers\" + ((int)value).ToString() + ".png";
                BitmapImage bitMapImage = new BitmapImage(new Uri(path, UriKind.Absolute));
                return bitMapImage;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
