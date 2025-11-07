using _25._10.Models.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _25._10.Converters
{
    public class EnrollmentToButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString() switch
            {
                "NOT_APPLIED" => "Записаться",
                "PENDING" => "Отозвать отклик",
                "REJECTED" => "Записаться",
                "APPROVED" => "Перейти к курсу",
                _ => "Записаться"
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
