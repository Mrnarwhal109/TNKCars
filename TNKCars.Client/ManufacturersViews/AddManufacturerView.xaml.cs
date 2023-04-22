using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
            e.Handled = IsNumsOnly(e.Text);
        }

        private bool IsNumsOnly(string text)
        {
            Regex numsOnly = new Regex("[^0-9]+");
            return numsOnly.IsMatch(text);
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => DAOCars.InsertManufacturer(connection, txtTitle.Text, Convert.ToInt32(txtFoundedYear.Text)));
        }
    }
}
