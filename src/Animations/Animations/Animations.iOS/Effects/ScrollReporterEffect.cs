using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using PlatformEffects = Animations.iOS.Effects;
using RoutingEffects = Animations;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(PlatformEffects.ScrollReporterEffect), "ScrollReporterEffect")]
namespace Animations.iOS.Effects
{
    public class ScrollReporterEffect : PlatformEffect
    {
        private IDisposable _offsetObserver;
        private UITableView nativeControl;
        private RoutingEffects.ScrollReporterEffect effect;

        protected override void OnAttached()
        {
            if (Element is ListView == false)
                return;

            // find our effect
            effect = (RoutingEffects.ScrollReporterEffect)Element.Effects.FirstOrDefault(e => e is RoutingEffects.ScrollReporterEffect);

            // implement our effect
            nativeControl = ((UITableView)Control);
            _offsetObserver = nativeControl.AddObserver("contentOffset", NSKeyValueObservingOptions.New, HandleAction);
        }

        private void HandleAction(NSObservedChange obj)
        {
            Debug.WriteLine($"Scroll Position is {nativeControl.ContentOffset.Y}");
            effect.OnScrollChanged(Element,
                new RoutingEffects.ScrollReporterEffect.ScrollEventArgs(nativeControl.ContentOffset.Y));
        }

        protected override void OnDetached()
        {
            _offsetObserver.Dispose();
            _offsetObserver = null;
        }
    }
}