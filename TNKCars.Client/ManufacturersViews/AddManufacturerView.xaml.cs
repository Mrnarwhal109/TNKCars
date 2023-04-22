using Npgsql;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TNKCars.DataAccess;
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
            string title = txtTitle.Text;
            int foundedYear = Convert.ToInt32(txtFoundedYear.Text);
            var insertedManufacturer = await DAOInsert.InsertRetrieveManufacturer(connection, title, foundedYear);
        }
    }
}
