using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Playground.Controls
{
    public class ExtendedSwitch: Switch
    {
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(ExtendedSwitch), Color.Black, propertyChanged: BorderColorChanged);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value); 
        }

        private static void BorderColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var extSwitch = (ExtendedSwitch)bindable;
            extSwitch.BorderColor = (Color)newValue;
        }

        public static readonly BindableProperty OffTintColorProperty =
            BindableProperty.Create(nameof(OffTintColor), typeof(Color), typeof(ExtendedSwitch), Color.Black, propertyChanged: OffTintColorChanged);

        public Color OffTintColor
        {
            get => (Color)GetValue(OffTintColorProperty);
            set => SetValue(OffTintColorProperty, value);
        }

        private static void OffTintColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var extSwitch = (ExtendedSwitch)bindable;
            extSwitch.OffTintColor = (Color)newValue;
        }
    }
}
