using _25._10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _25._10.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MyClass> Collection { get; set; }
        private MyCommand? addItemCommand = null;

        public MyCommand AddItemCommand
        {
            get => addItemCommand ??= new(
                (obj) =>
                {
                    Collection.Add(new MyClass(123, "123"));
                },
                (obj) =>  Collection.Count < 10
                );
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowViewModel()
        {
            Collection = new ObservableCollection<MyClass>();
        }

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
