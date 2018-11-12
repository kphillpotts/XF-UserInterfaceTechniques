using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Layouts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void overlappingGridButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ResponsiveGrid());
        }


        private void circleImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CircleImagePage());
        }

        private void viewCellOverlappingButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewCellOverlapping());
        }

        private void nonRectuangularHeaderButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NonRectangularHeader());
        }

        private void profileButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }
    }
}
