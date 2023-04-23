using Npgsql;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using TNKCars.DataAccess;
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
            
            var manu = cmbManufacturer.SelectedItem as Manufacturer;
            var eng = cmbEngine.SelectedItem as Engine;
            var tran = cmbTransmission.SelectedItem as Transmission;

            var manu_id = manu.Id;
            var eng_id = eng.Id;
            var tran_id = tran.Id;

            await UIHelpers.InvokeOnUIThread(async () => await
                DAOInsert.AddCarUsingChilds
                (connection, 
                txtTitle.Text, 
                Convert.ToInt32(txtPrice.Text), 
                Convert.ToInt32(txtSeriesYear.Text), 
                Convert.ToInt32(txtHorsePower.Text),
                manu_id,
                eng_id,
                tran_id
                ));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ComboBoxDataHelpers.FillComboBoxWithManufacturers(connection, cmbManufacturer);
            await ComboBoxDataHelpers.FillComboBoxWithEngines(connection, cmbEngine);
            await ComboBoxDataHelpers.FillComboBoxWithTransmissions(connection, cmbTransmission);
        }
    }
}
