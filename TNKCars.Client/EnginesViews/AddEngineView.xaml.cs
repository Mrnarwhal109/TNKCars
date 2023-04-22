using Npgsql;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TNKCars.DataAccess.DbHelpers;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for AddEngineView.xaml
    /// </summary>
    public partial class AddEngineView : Window
    {
        NpgsqlConnection connection;

        public AddEngineView(NpgsqlConnection connect)
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
            await Task.Run(() => DAOCars.InsertEngine(connection, txtTitle.Text, Convert.ToInt32(txtCylinderCount.Text), Convert.ToDouble(txtDisplacement.Text)));
        }
    }
}
