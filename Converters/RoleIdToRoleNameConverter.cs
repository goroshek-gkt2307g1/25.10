using System;
using System.Globalization;
using System.Windows.Data;

namespace _25._10.Converters
{
    public class RoleIdToRoleNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int roleId)
            {
                return roleId switch
                {
                    1 => "Администратор",
                    2 => "Ментор",
                    3 => "Ученик",
                    _ => "Неизвестно"
                };
            }
            return "Неизвестно";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}