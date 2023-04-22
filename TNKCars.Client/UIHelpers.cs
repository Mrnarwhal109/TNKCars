using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TNKCars.Client
{
    internal static class UIHelpers
    {
        internal static async Task InvokeOnUIThread(Action action)
        {
            await Task.Run(() => Application.Current.Dispatcher.Invoke(action));
        }
    }
}
