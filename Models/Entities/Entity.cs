using System.ComponentModel;

namespace _25._10.Models.Entities
{
    public class Entity : INotifyPropertyChanged
    {
        private int intProperty;
        private string strProperty;

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
        public string StrProperty
        {
            get => strProperty;
            set
            {
                 strProperty = value;
                 OnPropertyChanged();
            }
        }

        public Entity() { }

        public Entity(int intProperty, string strProperty)
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
