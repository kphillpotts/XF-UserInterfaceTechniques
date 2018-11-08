using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Animations
{
    public class ScrollReporterEffect : RoutingEffect
    {
        public class ScrollEventArgs : EventArgs
        {
            public ScrollEventArgs(double ScrollY)
            {
                this.ScrollY = ScrollY;
            }

            public double ScrollY { get; set; }
        }

        public event Action<Object, ScrollEventArgs> ScrollChanged;

        public ScrollReporterEffect() : base("Xamarin.ScrollReporterEffect"){}

        public void OnScrollChanged(Object sender, ScrollEventArgs e)
        {
            ScrollChanged?.Invoke(sender, e);
        }

    }
}
