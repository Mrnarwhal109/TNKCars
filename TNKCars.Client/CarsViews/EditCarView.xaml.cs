using Npgsql;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for EditCarView.xaml
    /// </summary>
    public partial class EditCarView : Window
    {
        NpgsqlConnection connection;

        public EditCarView(NpgsqlConnection connect)
        {
            InitializeComponent();
            connection = connect;
        }

        private void TextBoxNumbersOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = TextHelpers.IsNumsOnly(e.Text);
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            //await Task.Run(() => DAOCars.UpdateCar(connection, txtTitle.Text, Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtSeriesYear.Text), Convert.ToInt32(txtHorsePower.Text)))
        }

        private async Task SetManufacturerComboBox()
        {
            await ComboBoxDataHelpers.FillComboBoxWithManufacturers(connection, cmbManufacturer);
        }

        private async Task SetEngineComboBox()
        {
            await ComboBoxDataHelpers.FillComboBoxWithEngines(connection, cmbEngine);
        }

        private async Task GetTransmissions()
        {
            await ComboBoxDataHelpers.FillComboBoxWithTransmissions(connection, cmbEngine);
        }
    }
}
