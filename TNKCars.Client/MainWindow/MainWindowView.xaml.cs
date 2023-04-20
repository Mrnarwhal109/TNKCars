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
using TNKCars.Client.CarsUI;

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
        }

        #region Main Menu Button Clicks
        private void BtnCars_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Hidden;

            CarsMenu.Visibility = Visibility.Visible;
        }

        private void BtnManufacturers_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Hidden;

            ManufacturersMenu.Visibility = Visibility.Visible;
        }

        private void BtnTransmissions_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Hidden;

            TransmissionsMenu.Visibility = Visibility.Visible;
        }

        private void BtnEngines_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Hidden;

            EnginesMenu.Visibility = Visibility.Visible;
        }
        #endregion
        #region Cars Button Clicks
        private void BtnCarsBack_Click(object sender, RoutedEventArgs e)
        {
            CarsMenu.Visibility = Visibility.Hidden;

            MainMenu.Visibility = Visibility.Visible;
        }

        private void BtnAddCar_Click(object sender, RoutedEventArgs e) 
        {
            AddCarView addCarView = new AddCarView();

            addCarView.Show();
        }
        #endregion
    }
}
