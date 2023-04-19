using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TNKCars.DataAccess;
using TNKCars.DataAccess.DbHelpers;

namespace TNKCars.Client
{
    class MainWindowViewModel
    {
        public ICommand TestingButtonClickedCommand { get; set; }

        public MainWindowViewModel()
        {
        }

        public async Task btnTestingOnly_Click(object sender, RoutedEventArgs e)
        {
            var connection = await DatabaseUtility.EstablishConnection();
            Debug.WriteLine("TEST 1 HERE");

            var allCars = await DAOCars.GetAllCars(connection);
            Debug.WriteLine("TEST 2 HERE");
        }
    }
}
