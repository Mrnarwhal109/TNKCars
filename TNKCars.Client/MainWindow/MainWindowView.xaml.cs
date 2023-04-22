using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using TNKCars.DataAccess.DbHelpers;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        NpgsqlConnection connection;

        public MainWindow()
        {
            InitializeComponent();
            Task.Run(
                async () =>
                {
                    await Load();
                });
        }

        public async Task Load()
        {
            connection = await DatabaseUtility.EstablishConnection();
            await SetAllCarDataGrid();
        }

        #region Main Menu Button Clicks
        private async void BtnCars_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Hidden;

            CarsMenu.Visibility = Visibility.Visible;

            await SetCarDataGrid();
        }

        private async void BtnManufacturers_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Hidden;

            ManufacturersMenu.Visibility = Visibility.Visible;

            await SetManufacturerDataGrid();
        }

        private async void BtnEngines_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Hidden;

            EnginesMenu.Visibility = Visibility.Visible;

            await SetEngineDataGrid();
        }

        private async void BtnTransmissions_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Hidden;

            TransmissionsMenu.Visibility = Visibility.Visible;

            await SetTransmissionDataGrid();
        }
        #endregion

        #region Cars Button Clicks
        private async void BtnCarsBack_Click(object sender, RoutedEventArgs e)
        {
            CarsMenu.Visibility = Visibility.Hidden;

            MainMenu.Visibility = Visibility.Visible;
        }

        private async void BtnAddCar_Click(object sender, RoutedEventArgs e) 
        {
            AddCarView dialog = new AddCarView(connection);

            dialog.Show();
        }

        private async void BtnEditCar_Click(object sender, RoutedEventArgs e)
        {
            EditCarView dialog = new EditCarView(connection);

            dialog.Show();
        }

        private async void BtnRemoveCar_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Manufacturers Button Clicks
        private async void BtnManufacturersBack_Click(object sender, RoutedEventArgs e)
        {
            ManufacturersMenu.Visibility = Visibility.Hidden;

            MainMenu.Visibility = Visibility.Visible;
        }

        private async void BtnAddManufacturers_Click(object sender, RoutedEventArgs e)
        {
            AddManufacturerView dialog = new AddManufacturerView(connection);

            dialog.Show();
        }

        private async void BtnRemoveManufacturer_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void BtnEditManufacturer_Click(object sender, RoutedEventArgs e)
        {
            EditManufacturerView dialog = new EditManufacturerView(connection);

            dialog.Show();
        }
        #endregion

        #region Engines Button Clicks
        private async void BtnEngineBack_Click(object sender, RoutedEventArgs e)
        {
            EnginesMenu.Visibility = Visibility.Hidden;

            MainMenu.Visibility = Visibility.Visible;
        }

        private async void BtnAddEngine_Click(object sender, RoutedEventArgs e)
        {
            AddEngineView dialog = new AddEngineView(connection);

            dialog.Show();
        }

        private async void BtnRemoveEngine_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void BtnEditEngine_Click(object sender, RoutedEventArgs e)
        {
            EditEngineView dialog = new EditEngineView(connection);

            dialog.Show();
        }
        #endregion

        #region Transmissions Button Clicks
        private async void BtnTransmissionBack_Click(object sender, RoutedEventArgs e)
        {
            TransmissionsMenu.Visibility = Visibility.Hidden;

            MainMenu.Visibility = Visibility.Visible;
        }

        private async void BtnAddTransmission_Click(object sender, RoutedEventArgs e)
        {
            AddTransmissionView dialog = new AddTransmissionView(connection);

            dialog.Show();
        }

        private async void BtnRemoveTransmission_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void BtnEditTransmission_Click(object sender, RoutedEventArgs e)
        {
            EditTransmissionView dialog = new EditTransmissionView(connection);

            dialog.Show();
        }
        #endregion

        #region Data Grid Setters
        private async Task SetAllCarDataGrid()
        {
            List<DataAccess.Car> cars = await DAOCars.GetAllCarsWithDetails(connection);

            dgTable.ItemsSource = cars;
        }

        private async Task SetCarDataGrid()
        {
            List<DataAccess.Car> cars = await DAOCars.GetAllCarsWithoutDetails(connection);

            dgTable.ItemsSource = cars;
        }

        private async Task SetManufacturerDataGrid()
        {
            List<DataAccess.Manufacturer> manufacturers = await DAOCars.GetAllManufacturers(connection);

            dgTable.ItemsSource = manufacturers;
        }

        private async Task SetEngineDataGrid()
        {
            List<DataAccess.Engine> engines = await DAOCars.GetAllEngines(connection);

            dgTable.ItemsSource = engines;
        }

        private async Task SetTransmissionDataGrid()
        {
            List<DataAccess.Transmission> transmissions = await DAOCars.GetAllTransmissions(connection);

            dgTable.ItemsSource = transmissions;
        }
        #endregion


    }
}