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
            string title = txtTitle.Text;
            int cylinderCount = Convert.ToInt32(txtCylinderCount.Text);
            double displacement = Convert.ToDouble(txtDisplacement.Text);

            await DAOInsert.InsertEngine(connection, title, cylinderCount, displacement);
        }
    }
}
