using Npgsql;
using System;
using System.Windows;
using System.Windows.Input;
using TNKCars.DataAccess;
using TNKCars.DataAccess.DbHelpers;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for EditManufacturerView.xaml
    /// </summary>
    public partial class EditManufacturerView : Window
    {
        NpgsqlConnection connection;
        Manufacturer _focusedManufacturer;

        public EditManufacturerView(NpgsqlConnection connect, Manufacturer focusedManufacturer)
        {
            InitializeComponent();
            connection = connect;
            _focusedManufacturer = focusedManufacturer;

            // If there was more time, these would all be set with databinding
            txtTitle.Text = _focusedManufacturer.Title;
            txtFoundedYear.Text = _focusedManufacturer.FoundedYear.ToString();
        }

        private void TextBoxNumbersOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = TextHelpers.IsNumsOnly(e.Text);
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            int foundedYear = Convert.ToInt32(txtFoundedYear.Text);
            await DAOUpdate.UpdateManufacturerWithId(connection, _focusedManufacturer.Id, title, foundedYear);
        }
    }
}
