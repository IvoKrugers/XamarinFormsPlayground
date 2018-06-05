using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarouselItem : ContentView
	{
        public static readonly BindableProperty TapCommandProperty =
           BindableProperty.Create("TapCommand", typeof(ICommand), typeof(CarouselItem));

        public ICommand TapCommand
        {
            get { return (ICommand)GetValue(TapCommandProperty); }
            set { SetValue(TapCommandProperty, value); }
        }

        public CarouselItem ()
		{
			InitializeComponent ();
		}
	}
}