using Playground.Controls;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedSwitch), typeof(Playground.iOS.Renderers.ExtendedSwitchRenderer))]
namespace Playground.iOS.Renderers
{
    class ExtendedSwitchRenderer : SwitchRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control != null)
                {
                    // Control. = UIKit.UITextBorderStyle.None;
                }
                UpdateBorderColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(nameof(ExtendedSwitch.BorderColor)))
            {
                UpdateBorderColor();
            }
        }

        protected void UpdateBorderColor()
        {
            if (Control != null)
            {
                //Control.OnTintColor = Color.AliceBlue.ToUIColor();//((ExtendedSwitch)Element).TintColor.ToUIColor();
                //Control.ThumbTintColor = Color.Lime.ToUIColor();
                if (((ExtendedSwitch)Element).BorderColor != null)
                {
                    Control.TintColor = ((ExtendedSwitch)Element).BorderColor.ToUIColor();
                    Control.BackgroundColor = ((ExtendedSwitch)Element).BackgroundColor.ToUIColor();
                    Control.Layer.CornerRadius = 16.0f;
                }
                else
                {
                    ////var s = new UISwitch();
                    ////Control.TintColor = s.TintColor;
                    ////Control.BackgroundColor = s.BackgroundColor;
                    ////Control.Layer.CornerRadius = s.Layer.CornerRadius;
                }
            }
        }
    }
}