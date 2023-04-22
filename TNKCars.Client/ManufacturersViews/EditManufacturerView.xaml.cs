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
            e.Handled = IsNumsOnly(e.Text);
        }

        private bool IsNumsOnly(string text)
        {
            Regex numsOnly = new Regex("[^0-9]+");
            return numsOnly.IsMatch(text);
        }
    }
}
