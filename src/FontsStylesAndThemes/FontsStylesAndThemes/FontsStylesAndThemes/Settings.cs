using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FontsStylesAndThemes
{
    public static class Settings
    {
        public static string Theme
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("Theme"))
                {
                    string theme = Application.Current.Properties["Theme"].ToString();
                    return theme;
                }
                return "Light";
            }
            set
            {
                Application.Current.Properties["Theme"] = value.ToString();
                Application.Current.SavePropertiesAsync();
            }
        }
    }
}
