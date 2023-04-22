using System.Text.RegularExpressions;

namespace TNKCars.Client
{
    internal static class TextHelpers
    {
        internal static bool IsNumsOnly(string text)
        {
            Regex numsOnly = new Regex("[^0-9]+");
            return numsOnly.IsMatch(text);
        }
    }
}
