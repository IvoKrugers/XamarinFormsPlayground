using Playground.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ControlsPages : ContentPage
	{
      		public ControlsPages ()
		{
			InitializeComponent ();
            BindingContext = new ControlsViewModel();
		}
	}
}