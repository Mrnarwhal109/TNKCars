using Npgsql;
using System.Windows;
using System.Windows.Input;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for AddTransmissionView.xaml
    /// </summary>
    public partial class AddTransmissionView : Window
    {
        NpgsqlConnection connection;

        public AddTransmissionView(NpgsqlConnection connect)
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
            //await Task.Run(() => DAOCars.InsertTransmission(connection, txtTitle.Text, Convert.ToInt32(txtGearCount.Text), ComboBox box value));
        }
    }
}
