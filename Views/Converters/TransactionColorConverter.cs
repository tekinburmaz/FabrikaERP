using FabrikaERP.Models;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FabrikaERP.Views.Converters
{
    public class TransactionColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TransactionType type)
            {
                return type == TransactionType.Receipt 
                    ? new SolidColorBrush(Color.FromRgb(63, 185, 80)) // Green
                    : new SolidColorBrush(Color.FromRgb(248, 81, 73)); // Red
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
