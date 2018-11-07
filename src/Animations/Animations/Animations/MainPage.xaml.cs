using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Animations
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void Handle_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AnimationPage());
        }

        public void BindablePropertiesButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VisualElementPropertiesPage());
        }


    }
}
