using Npgsql;
using System.Windows;
using System.Windows.Input;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for EditTransmissionView.xaml
    /// </summary>
    public partial class EditTransmissionView : Window
    {
        NpgsqlConnection connection;

        public EditTransmissionView(NpgsqlConnection connect)
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
            //await Task.Run(() => DAOCars.UpdateTransmissionWithID(connection, txtTitle.Text, Convert.ToInt32(txtGearCount.Text), ComboBox box value));
        }
    }
}
