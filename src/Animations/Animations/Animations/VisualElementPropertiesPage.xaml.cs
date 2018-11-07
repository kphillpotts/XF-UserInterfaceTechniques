using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Animations
{
    public partial class VisualElementPropertiesPage : ContentPage
    {
        public VisualElementPropertiesPage()
        {
            InitializeComponent();
        }
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            ScaleSlider.Value = 1;
            OpacitySlider.Value = 1;
            RotationSlider.Value = 0;
            RotationXSlider.Value = 0;
            RotationYSlider.Value = 0;
            TranslationXSlider.Value = 0;
            TranslationYSlider.Value = 0;
        }
    }
}
