using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FontsStylesAndThemes.Themes
{
    public static class ThemeHelper
    {
        public static string CurrentTheme;

        public static void ChangeTheme(string theme)
        {
            // don't change to the same theme
            if (theme == CurrentTheme) return;

            // clear all the resources
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.Clear();
            ResourceDictionary applicationResourceDictionary = Application.Current.Resources;
            ResourceDictionary newTheme = null;


            switch (theme.ToLowerInvariant())
            {
                case "dark":
                    newTheme = new DarkTheme();
                    break;
                case "disco":
                    newTheme = new DiscoTheme();
                    break;
                default:
                    newTheme = new LightTheme();
                    break;
            }

            foreach (var merged in newTheme.MergedDictionaries)
            {
                applicationResourceDictionary.MergedDictionaries.Add(merged);
            }

            ManuallyCopyThemes(newTheme, applicationResourceDictionary);

            CurrentTheme = theme;
            //var platformManager = DependencyService.Get<IPlatformThemeManager>();
            //if (platformManager != null)
            //{
            //    platformManager.ChangeTheme(theme);
            //}

        }

        private static void ManuallyCopyThemes(ResourceDictionary fromResource, ResourceDictionary toResource)
        {
            foreach (var item in fromResource.Keys)
            {
                toResource[item] = fromResource[item];
            }
        }
    }

}
