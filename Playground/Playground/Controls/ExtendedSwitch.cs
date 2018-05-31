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

    }
}
