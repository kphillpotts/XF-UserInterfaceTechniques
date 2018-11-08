using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animations
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ParallaxHeader : ContentPage
	{
        List<string> ListItems { get; set; }

        public ParallaxHeader ()
		{
            InitializeComponent();

            ListItems = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                ListItems.Add($"Item {i}");
            }

            MyListView.ItemsSource = ListItems;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // attach our effect
            var lvsEffect = new ScrollReporterEffect();
            MyListView.Effects.Add(lvsEffect);
            lvsEffect.ScrollChanged += LvsEffect_ScrollChanged;
        }

        private void LvsEffect_ScrollChanged(object sender, ScrollReporterEffect.ScrollEventArgs e)
        {
            var scrollValue = e.ScrollY;
            var parallaxScale = 2.5;

            Rocket.TranslationY = scrollValue / parallaxScale;
            Moon.TranslationY = scrollValue / 1.5;
            //Clouds.TranslationY = scrollValue / 2.5;
            Clouds2.TranslationY = scrollValue / 2.2;
            Background.TranslationY = scrollValue;
            Stars.TranslationY = scrollValue;
        }
    }
}