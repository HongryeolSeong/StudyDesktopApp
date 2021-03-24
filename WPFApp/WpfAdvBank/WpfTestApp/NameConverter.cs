using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfTestApp
{
    public class NameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string name;

            switch ((string) parameter)
            {
                case "FormatNormal":
                    name = $"{values[0]}, {values[1]}"; // 뒤집어서 포맷팅
                    break;
                case "FormatLastFirst":
                    name = $"{values[1]}, {values[0]}"; // 기본
                    break;
                default:
                    name = $" ";
                    break;
            }

            return name;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            var splitValues = ((string)value).Split(' ');
            return splitValues;
        }
    }
}
