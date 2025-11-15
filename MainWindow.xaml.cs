using _25._10.ViewModels;
using System.Windows;

namespace _25._10
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}