using Npgsql;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TNKCars.DataAccess.DbHelpers;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for AddCarView.xaml
    /// </summary>
    public partial class AddCarView : Window
    {
        NpgsqlConnection connection;

        public AddCarView(NpgsqlConnection connect)
        {
            InitializeComponent();
            connection = connect;
        }

        private void TextBoxNumbersOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = TextHelpers.IsNumsOnly(e.Text);
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => DAOInsert.InsertCar(connection, txtTitle.Text, Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtSeriesYear.Text), Convert.ToInt32(txtHorsePower.Text)));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ComboBoxDataHelpers.FillComboBoxWithManufacturers(connection, cmbManufacturer);
            await ComboBoxDataHelpers.FillComboBoxWithEngines(connection, cmbEngine);
            await ComboBoxDataHelpers.FillComboBoxWithTransmissions(connection, cmbEngine);
        }
    }
}
