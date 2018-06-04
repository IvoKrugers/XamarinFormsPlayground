
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using Playground.Controls;
using Playground.Droid.Renderers;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ASwitch = Android.Widget.Switch;

[assembly: ExportRenderer(typeof(ExtendedSwitch), typeof(ExtendedSwitchRenderer))]

namespace Playground.Droid.Renderers
{
    class ExtendedSwitchRenderer : ViewRenderer<ExtendedSwitch, ASwitch>, CompoundButton.IOnCheckedChangeListener
    {
        public ExtendedSwitchRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        public override SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
        {
            SizeRequest sizeConstraint = base.GetDesiredSize(widthConstraint, heightConstraint);

            if (sizeConstraint.Request.Width == 0)
            {
                int width = widthConstraint;
                if (widthConstraint <= 0)
                {
                    width = (int)Context.GetThemeAttributeDp(global::Android.Resource.Attribute.SwitchMinWidth);
                }
                sizeConstraint = new SizeRequest(
                    new Xamarin.Forms.Size(width, sizeConstraint.Request.Height),
                    new Xamarin.Forms.Size(width, sizeConstraint.Minimum.Height)
                    );
            }

            return sizeConstraint;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && Control != null)
            {
                if (Element != null)
                    Element.Toggled -= HandleToggled;

                Control.SetOnCheckedChangeListener(null);
            }

            base.Dispose(disposing);
        }

        protected override ASwitch CreateNativeControl()
        {
            return new ASwitch(Context);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ExtendedSwitch> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
                e.OldElement.Toggled -= HandleToggled;

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var aswitch = CreateNativeControl();
                    aswitch.SetOnCheckedChangeListener(this);
                    SetNativeControl(aswitch);
                }
                else
                    UpdateEnabled(); // Normally set by SetNativeControl, but not when the Control is reused.

                e.NewElement.Toggled += HandleToggled;
                Control.Checked = e.NewElement.IsToggled;

                UpdateStateColors();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ExtendedSwitch.OffTintColorProperty.PropertyName)
                UpdateStateColors();
            if (e.PropertyName == ExtendedSwitch.IsEnabledProperty.PropertyName)
                UpdateEnabled();
            if (e.PropertyName == ExtendedSwitch.IsToggledProperty.PropertyName)
                UpdateStateColors();
        }

        void CompoundButton.IOnCheckedChangeListener.OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            ((IViewController)Element).SetValueFromRenderer(Xamarin.Forms.Switch.IsToggledProperty, isChecked);
        }

        void HandleToggled(object sender, EventArgs e)
        {
            Control.Checked = Element.IsToggled;
        }

        void UpdateEnabled()
        {
            Control.Enabled = Element.IsEnabled;
        }

        void UpdateStateColors()
        {
            if (Element != null)
            {            
                //ShapeDrawable borderShape = new ShapeDrawable(new OvalShape());
                //borderShape.SetColorFilter(Xamarin.Forms.Color.Red.ToAndroid(), PorterDuff.Mode.SrcIn);
                //Control.SetBackground(borderShape);

                Control.ThumbDrawable.SetColorFilter(Xamarin.Forms.Color.White.ToAndroid(), PorterDuff.Mode.Multiply);

                if (Element.IsToggled)
                {
                    Control.TrackDrawable.SetColorFilter(Xamarin.Forms.Color.Lime.ToAndroid(), PorterDuff.Mode.DstAtop);
                }
                else
                {
                    Control.TrackDrawable.SetColorFilter(Element.OffTintColor.ToAndroid(), PorterDuff.Mode.DstAtop);
                }       
            }
        }
    }
}