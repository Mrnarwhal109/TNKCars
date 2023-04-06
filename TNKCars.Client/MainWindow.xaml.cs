using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // It is quite possible this needs to be moved as well.
            DataContext = new MainWindowViewModel();
        }

        /// <summary>
        /// This needs to be replaced because it doesn't follow MVVM. The code-behind (this file) shouldn't have any code except for the constructor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnTestingOnly_Click(object sender, RoutedEventArgs e)
        {
            var badPractice = DataContext as MainWindowViewModel;
            await badPractice.btnTestingOnly_Click(sender, e);
        }
    }
}
