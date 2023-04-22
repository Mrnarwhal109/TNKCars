using Npgsql;
using System.Windows;
using System.Windows.Input;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for EditEngineView.xaml
    /// </summary>
    public partial class EditEngineView : Window
    {
        NpgsqlConnection connection;

        public EditEngineView(NpgsqlConnection connect)
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
            //await Task.Run(() => DAOCars.InsertEngine(connection, txtTitle.Text, Convert.ToInt32(txtCylinderCount.Text), Convert.ToDouble(txtDisplacement.Text)));
        }
    }
}
