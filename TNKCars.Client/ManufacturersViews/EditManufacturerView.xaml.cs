using Npgsql;
using System.Windows;
using System.Windows.Input;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for EditManufacturerView.xaml
    /// </summary>
    public partial class EditManufacturerView : Window
    {
        NpgsqlConnection connection;

        public EditManufacturerView(NpgsqlConnection connect)
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
            //await Task.Run(() => DAOCars.InsertManufacturer(connection, txtTitle.Text, Convert.ToInt32(txtFoundedYear.Text)));
        }
    }
}
