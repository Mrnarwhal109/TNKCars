using Npgsql;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TNKCars.DataAccess.DbHelpers;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for AddManufacturerView.xaml
    /// </summary>
    public partial class AddManufacturerView : Window
    {
        NpgsqlConnection connection;

        public AddManufacturerView(NpgsqlConnection connect)
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
            await Task.Run(() => DAOCars.InsertManufacturer(connection, txtTitle.Text, Convert.ToInt32(txtFoundedYear.Text)));
        }
    }
}
