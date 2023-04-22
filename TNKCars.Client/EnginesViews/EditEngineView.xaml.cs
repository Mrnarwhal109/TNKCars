using Npgsql;
using System;
using System.Windows;
using System.Windows.Input;
using TNKCars.DataAccess;
using TNKCars.DataAccess.DbHelpers;

namespace TNKCars.Client
{
    /// <summary>
    /// Interaction logic for EditEngineView.xaml
    /// </summary>
    public partial class EditEngineView : Window
    {
        NpgsqlConnection connection;
        Engine _focusedEngine;

        public EditEngineView(NpgsqlConnection connect, Engine focusedEngine)
        {
            InitializeComponent();
            connection = connect;
            _focusedEngine = focusedEngine;

            // If there was more time, these would all be set with databinding
            txtTitle.Text = _focusedEngine.Title;
            txtCylinderCount.Text = _focusedEngine.CylinderCount.ToString();
            txtDisplacement.Text = _focusedEngine.Displacement.ToString();
        }

        private void TextBoxNumbersOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = TextHelpers.IsNumsOnly(e.Text);
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            int cyl = Convert.ToInt32(txtCylinderCount.Text);
            double displacement = Convert.ToDouble(txtDisplacement.Text);
            await DAOUpdate.UpdateEngineWithId(connection, _focusedEngine.Id, title, cyl, displacement);
        }
    }
}
