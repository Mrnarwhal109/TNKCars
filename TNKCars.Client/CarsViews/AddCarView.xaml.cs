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
    /// Interaction logic for AddCarView.xaml
    /// </summary>
    public partial class AddCarView : Window
    {
        public string MyValue { get; set; }

        public AddCarView()
        {
            InitializeComponent();
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

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //var connection = await DatabaseUtility.EstablishConnection();
            //DAOCars.InsertCar(connection, txtTitle.Text, Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtSeriesYear.Text), Convert.ToInt32(txtHorsePower.Text));
        }
    }
}
