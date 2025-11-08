using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace _25._10.Models.Entities
{
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        private int intProperty;
        private string strProperty;

        [NotMapped]
        public int IntProperty
        {
            get => intProperty;
            set
            {
                if (value >= 0)
                {
                    intProperty = value;
                    OnPropertyChanged();
                }
            }
        }

        [NotMapped]
        public string StrProperty
        {
            get => strProperty;
            set
            {
                strProperty = value;
                OnPropertyChanged();
            }
        }

        public PropertyChangedBase() { }

        public PropertyChangedBase(int intProperty, string strProperty)
        {
            IntProperty = intProperty;
            StrProperty = strProperty;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
