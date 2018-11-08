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
	public partial class ShakeAnimation : ContentPage
	{
		public ShakeAnimation ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!IsValidLogin())
            {
                await InvalidLoginAnimation();
            }
            else
            {
                await ValidLoginAnimation();
            }
        }

        private async Task ValidLoginAnimation()
        {
            await LoginContainer.FadeTo(0, 250);
            AnimationView.Opacity = 1;
            await AnimationView.TranslateTo(0, 0, 2000, Easing.SinInOut);
            ConfettiView.Opacity = 1;
            ConfettiView.Play();
            ConfettiView.OnFinish += ConfettiView_OnFinish;
            await Task.Delay(1000);
            await AnimationView.TranslateTo(300, 0, 2000, Easing.SinInOut);
            AnimationView.Opacity = 0;
        }

        private bool IsValidLogin()
        {
            return PasswordEntry.Text.Equals("password", StringComparison.InvariantCultureIgnoreCase);
        }

        private void ConfettiView_OnFinish(object sender, EventArgs e)
        {
            ConfettiView.Opacity = 0;
        }

        private async Task InvalidLoginAnimation()
        {
            uint speed = 50;
            Easing easing = Easing.Linear;

            await LoginContainer.TranslateTo(-15, 0, speed, easing);
            await LoginContainer.TranslateTo(15, 0, speed, easing);
            await LoginContainer.TranslateTo(-10, 0, speed, easing);
            await LoginContainer.TranslateTo(+10, 0, speed, easing);
            await LoginContainer.TranslateTo(-5, 0, speed, easing);
            await LoginContainer.TranslateTo(5, 0, speed, easing);
            await LoginContainer.TranslateTo(0, 0, speed, easing);
        }


    }
}