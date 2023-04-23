using Npgsql;
using System;
using System.Windows;
using System.Windows.Input;
using TNKCars.DataAccess;
using TNKCars.DataAccess.DbHelpers;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for EditTransmissionView.xaml
    /// </summary>
    public partial class EditTransmissionView : Window
    {
        NpgsqlConnection connection;
        Transmission _focusedTransmission;

        public EditTransmissionView(NpgsqlConnection connect, Transmission focusedTransmission)
        {
            InitializeComponent();
            connection = connect;
            _focusedTransmission = focusedTransmission;

            // If there was more time, these would all be set with databinding
            txtTitle.Text = _focusedTransmission.Title;
            txtGearCount.Text = _focusedTransmission.GearCount.ToString();
            cmbAutomatic.IsChecked = (bool)_focusedTransmission.IsAutomatic;
        }

        private void TextBoxNumbersOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = TextHelpers.IsNumsOnly(e.Text);
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            int gears = Convert.ToInt32(txtGearCount.Text);
            bool isAuto = (bool)cmbAutomatic.IsChecked;
            await DAOUpdate.UpdateTransmissionWithId(connection, _focusedTransmission.Id, title, gears, isAuto);
        }
    }
}
