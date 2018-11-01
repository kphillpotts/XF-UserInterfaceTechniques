using FontsStylesAndThemes.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FontsStylesAndThemes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ThemePicker.SelectedItem = Settings.Theme;
        }

        private void ThemePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                var themeName = picker.Items[selectedIndex];

                Title = themeName;
                Settings.Theme = themeName;
                ThemeHelper.ChangeTheme(themeName);
            }
        }
    }
}
