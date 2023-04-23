using Npgsql;
using System;
using System.Windows;
using System.Windows.Input;
using TNKCars.DataAccess.DbHelpers;

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
            string title = txtTitle.Text;
            int gears = Convert.ToInt32(txtGearCount.Text);
            bool isAuto = (bool)cmbAutomatic.IsChecked;

            await DAOInsert.InsertTransmission(connection, title, gears, isAuto);
        }
    }
}
