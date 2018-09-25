using System;
using System.Text.RegularExpressions;

namespace aspcorewebapi_duis.Helpers
{
    public class ControllersHelper
    {
        public static string RemoveVersionFromControllerName(string nameController)
        {
            const string pattern = @"\d{1,5}$";
            if (Regex.Match(nameController, pattern).Success)
            {
                return Regex.Replace(nameController.ToLower(), pattern, String.Empty);
            }
            return nameController.ToLower();
        }
    }
}