using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Animations
{
    public partial class AnimationPage : ContentPage
    {
        public AnimationPage()
        {
            InitializeComponent();
        }

        bool isExpanded = true;

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            if (isExpanded)
                AnimateIn();
            else
                AnimateOut();

            isExpanded = !isExpanded;
        }

        Rectangle expandedRect;
        Rectangle detailsRect;
        private uint animationSpeed = 600;

        private void AnimateIn()
        {
            MainImage.LayoutTo(detailsRect, animationSpeed, Easing.SpringOut);
            BottomFrame.TranslateTo(0, 0, animationSpeed, Easing.SpringOut);
            Title.TranslateTo(0, 0, animationSpeed, Easing.SpringOut);
            Title.Opacity = 1;
            ExpandBar.FadeTo(.01, 250, Easing.SinInOut);
        }

        private void AnimateOut()
        {
            MainImage.LayoutTo(expandedRect, animationSpeed, Easing.SpringOut);
            BottomFrame.TranslateTo(0, BottomFrame.Height, animationSpeed, Easing.SpringOut);
            Title.TranslateTo(-Title.Width, 0, animationSpeed, Easing.SpringOut);
            Title.Opacity = 0;
            ExpandBar.FadeTo(1, 250, Easing.SinInOut);
        }


        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            detailsRect = new Rectangle(0, 0, width, BottomFrame.Bounds.Top + 20);
            expandedRect = new Rectangle(0, 0, width, height);

            if (isExpanded)
            {
                MainImage.Layout(expandedRect);
                BottomFrame.TranslationY = BottomFrame.Height;
                Title.Opacity = 0;
                Title.TranslationX = -Title.Width;
            }
            else
            {
                MainImage.Layout(detailsRect);
                BottomFrame.TranslationY = 0;
                Title.TranslationX = 0;
            }
        }
    }
}