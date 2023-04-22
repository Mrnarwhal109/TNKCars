using Npgsql;
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
using TNKCars.Client;
using TNKCars.DataAccess.DbHelpers;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        List<DataAccess.Car> cars = new List<DataAccess.Car>(); 

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Main Menu Button Clicks
        private void BtnCars_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Hidden;

            CarsMenu.Visibility = Visibility.Visible;

            SetCarHeaderDG();
        }

        private void BtnManufacturers_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Hidden;

            ManufacturersMenu.Visibility = Visibility.Visible;

            SetManufacturerHeaderDG();
        }

        private void BtnEngines_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Hidden;

            EnginesMenu.Visibility = Visibility.Visible;

            SetEngineHeaderDG();
        }

        private void BtnTransmissions_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Hidden;

            TransmissionsMenu.Visibility = Visibility.Visible;

            SetTransmissionHeaderDG();
        }
        #endregion

        #region Cars Button Clicks
        private void BtnCarsBack_Click(object sender, RoutedEventArgs e)
        {
            CarsMenu.Visibility = Visibility.Hidden;

            MainMenu.Visibility = Visibility.Visible;

            SetEmptyHeaderDG();
        }

        private void BtnAddCar_Click(object sender, RoutedEventArgs e) 
        {
            AddCarView dialog = new AddCarView();

            dialog.Show();
        }

        private void BtnEditCar_Click(object sender, RoutedEventArgs e)
        {
            EditCarView dialog = new EditCarView();

            dialog.Show();
        }

        private void BtnRemoveCar_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Manufacturers Button Clicks
        private void BtnManufacturersBack_Click(object sender, RoutedEventArgs e)
        {
            ManufacturersMenu.Visibility = Visibility.Hidden;

            MainMenu.Visibility = Visibility.Visible;

            SetEmptyHeaderDG();
        }

        private void BtnAddManufacturers_Click(object sender, RoutedEventArgs e)
        {
            AddManufacturerView dialog = new AddManufacturerView();

            dialog.Show();
        }

        private void BtnRemoveManufacturer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditManufacturer_Click(object sender, RoutedEventArgs e)
        {
            EditManufacturerView dialog = new EditManufacturerView();

            dialog.Show();
        }
        #endregion

        #region Engines Button Clicks
        private void BtnEngineBack_Click(object sender, RoutedEventArgs e)
        {
            EnginesMenu.Visibility = Visibility.Hidden;

            MainMenu.Visibility = Visibility.Visible;

            SetEmptyHeaderDG();
        }

        private void BtnAddEngine_Click(object sender, RoutedEventArgs e)
        {
            AddEngineView dialog = new AddEngineView();

            dialog.Show();
        }

        private void BtnRemoveEngine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditEngine_Click(object sender, RoutedEventArgs e)
        {
            EditEngineView dialog = new EditEngineView();

            dialog.Show();
        }
        #endregion

        #region Transmissions Button Clicks
        private void BtnTransmissionBack_Click(object sender, RoutedEventArgs e)
        {
            TransmissionsMenu.Visibility = Visibility.Hidden;

            MainMenu.Visibility = Visibility.Visible;

            SetEmptyHeaderDG();
        }

        private void BtnAddTransmission_Click(object sender, RoutedEventArgs e)
        {
            AddTransmissionView dialog = new AddTransmissionView();

            dialog.Show();
        }

        private void BtnRemoveTransmission_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditTransmission_Click(object sender, RoutedEventArgs e)
        {
            EditTransmissionView dialog = new EditTransmissionView();

            dialog.Show();
        }
        #endregion

        private void SetEmptyHeaderDG()
        {
            dgTable.Columns.Clear();
            //dgTable.ItemsSource = null;
            dgTable.Items.Refresh();
        }

        private void SetCarHeaderDG()
        {
            dgTable.Columns.Clear();
            //dgTable.ItemsSource = null;
            dgTable.Items.Refresh();

            List<DataGridTextColumn> dataGridTextColumn = new List<DataGridTextColumn>();

            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[0].Header = "ID";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[1].Header = "Model";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[2].Header = "Price";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[3].Header = "Series Year";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[4].Header = "Horsepower";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[5].Header = "Added at";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[6].Header = "Manufacturer";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[7].Header = "Engine";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[8].Header = "Transmission";

            dgTable.Columns.Add(dataGridTextColumn[0]);
            dgTable.Columns.Add(dataGridTextColumn[1]);
            dgTable.Columns.Add(dataGridTextColumn[2]);
            dgTable.Columns.Add(dataGridTextColumn[3]);
            dgTable.Columns.Add(dataGridTextColumn[4]);
            dgTable.Columns.Add(dataGridTextColumn[5]);
            dgTable.Columns.Add(dataGridTextColumn[6]);
            dgTable.Columns.Add(dataGridTextColumn[7]);
            dgTable.Columns.Add(dataGridTextColumn[8]);


            //var connection = await DatabaseUtility.EstablishConnection();
            //cars = await DAOCars.GetAllCarsWithoutDetails(connection);

            //dgTable.ItemsSource = cars;
        }

        private void SetManufacturerHeaderDG()
        {
            dgTable.Columns.Clear();
            //dgTable.ItemsSource = null;
            dgTable.Items.Refresh();

            List<DataGridTextColumn> dataGridTextColumn = new List<DataGridTextColumn>();

            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[0].Header = "ID";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[1].Header = "Name";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[2].Header = "Founded Year";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[3].Header = "Added at";

            dgTable.Columns.Add(dataGridTextColumn[0]);
            dgTable.Columns.Add(dataGridTextColumn[1]);
            dgTable.Columns.Add(dataGridTextColumn[2]);
            dgTable.Columns.Add(dataGridTextColumn[3]);
        }

        private void SetEngineHeaderDG()
        {
            dgTable.Columns.Clear();
            //dgTable.ItemsSource = null;
            dgTable.Items.Refresh();

            List<DataGridTextColumn> dataGridTextColumn = new List<DataGridTextColumn>();

            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[0].Header = "ID";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[1].Header = "Name";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[2].Header = "Cylinder Count";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[3].Header = "Displacement";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[4].Header = "Added at";

            dgTable.Columns.Add(dataGridTextColumn[0]);
            dgTable.Columns.Add(dataGridTextColumn[1]);
            dgTable.Columns.Add(dataGridTextColumn[2]);
            dgTable.Columns.Add(dataGridTextColumn[3]);
            dgTable.Columns.Add(dataGridTextColumn[4]);
        }

        private void SetTransmissionHeaderDG()
        {
            dgTable.Columns.Clear();
            //dgTable.ItemsSource = null;
            dgTable.Items.Refresh();

            List<DataGridTextColumn> dataGridTextColumn = new List<DataGridTextColumn>();

            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[0].Header = "ID";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[1].Header = "Name";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[2].Header = "Gear Count";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[3].Header = "Automatic";
            dataGridTextColumn.Add(new DataGridTextColumn());
            dataGridTextColumn[4].Header = "Added at";

            dgTable.Columns.Add(dataGridTextColumn[0]);
            dgTable.Columns.Add(dataGridTextColumn[1]);
            dgTable.Columns.Add(dataGridTextColumn[2]);
            dgTable.Columns.Add(dataGridTextColumn[3]);
            dgTable.Columns.Add(dataGridTextColumn[4]);
        }
    }
}

