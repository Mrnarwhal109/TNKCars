using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using TNKCars.DataAccess;
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
            dgTable.SelectionMode = System.Windows.Controls.DataGridSelectionMode.Single;
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
            dialog.ShowDialog();
            await SetCarDataGrid();
        }

        private async void BtnEditCar_Click(object sender, RoutedEventArgs e)
        {
            EditCarView dialog = new EditCarView(connection);
            dialog.ShowDialog();
            await SetCarDataGrid();
        }

        private async void BtnRemoveCar_Click(object sender, RoutedEventArgs e)
        {
            var selectedInGrid = dgTable.SelectedItem as Car;
            if (selectedInGrid == null) { return; }

            await DAODelete.RemoveCarsFromParents(connection, selectedInGrid.Id);
            await SetCarDataGrid();
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
            dialog.ShowDialog();
            await SetManufacturerDataGrid();
        }

        private async void BtnRemoveManufacturer_Click(object sender, RoutedEventArgs e)
        {
            var selectedInGrid = dgTable.SelectedItem as Manufacturer;
            if (selectedInGrid == null) { return; }

            await DAODelete.DeleteManufacturerWithId(connection, selectedInGrid.Id);
            await SetManufacturerDataGrid();
        }

        private async void BtnEditManufacturer_Click(object sender, RoutedEventArgs e)
        {
            var selectedInGrid = dgTable.SelectedItem as Manufacturer;
            if (selectedInGrid == null) { return; }

            EditManufacturerView dialog = new EditManufacturerView(connection, selectedInGrid);
            dialog.ShowDialog();
            await SetManufacturerDataGrid();
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
            dialog.ShowDialog();
            await SetEngineDataGrid();
        }

        private async void BtnRemoveEngine_Click(object sender, RoutedEventArgs e)
        {
            var selectedInGrid = dgTable.SelectedItem as Engine;
            if (selectedInGrid == null) { return; }

            await DAODelete.DeleteEngineWithId(connection, selectedInGrid.Id);
            await SetEngineDataGrid();
        }

        private async void BtnEditEngine_Click(object sender, RoutedEventArgs e)
        {
            var selectedInGrid = dgTable.SelectedItem as Engine;
            if (selectedInGrid == null) { return; }

            EditEngineView dialog = new EditEngineView(connection, selectedInGrid);
            dialog.ShowDialog();
            await SetEngineDataGrid();
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
            dialog.ShowDialog();
            await SetTransmissionDataGrid();
        }

        private async void BtnRemoveTransmission_Click(object sender, RoutedEventArgs e)
        {
            var selectedInGrid = dgTable.SelectedItem as Transmission;
            if (selectedInGrid == null) { return; }

            await DAODelete.DeleteTransmissionWithId(connection, selectedInGrid.Id);
            await SetTransmissionDataGrid();
        }

        private async void BtnEditTransmission_Click(object sender, RoutedEventArgs e)
        {
            var selectedInGrid = dgTable.SelectedItem as Transmission;
            if (selectedInGrid == null) { return; }

            EditTransmissionView dialog = new EditTransmissionView(connection, selectedInGrid);
            dialog.ShowDialog();
            await SetTransmissionDataGrid();
        }
        #endregion

        #region Data Grid Setters
        private async Task SetAllCarDataGrid()
        {
            List<DataAccess.Car> cars = await DAOSelect.GetAllCarsWithDetails(connection);

            ObservableCollection<DataAccess.Car> obsColl = new ObservableCollection<DataAccess.Car>();
            foreach (var car in cars)
            {
                obsColl.Add(car);
            }

            await UIHelpers.InvokeOnUIThread(() => dgTable.ItemsSource = cars);   
        }

        private async Task SetCarDataGrid()
        {
            List<DataAccess.Car> cars = await DAOSelect.GetAllCarsWithoutDetails(connection);

            dgTable.ItemsSource = cars;
        }

        private async Task SetManufacturerDataGrid()
        {
            List<DataAccess.Manufacturer> manufacturers = await DAOSelect.GetAllManufacturers(connection);

            dgTable.ItemsSource = manufacturers;
        }

        private async Task SetEngineDataGrid()
        {
            List<DataAccess.Engine> engines = await DAOSelect.GetAllEngines(connection);

            dgTable.ItemsSource = engines;
        }

        private async Task SetTransmissionDataGrid()
        {
            List<DataAccess.Transmission> transmissions = await DAOSelect.GetAllTransmissions(connection);

            dgTable.ItemsSource = transmissions;
        }
        #endregion


    }
}