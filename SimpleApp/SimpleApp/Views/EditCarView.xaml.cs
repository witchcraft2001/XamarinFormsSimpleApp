using SimpleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditCarView : ContentPage
	{
		public EditCarView (int id)
		{
			InitializeComponent ();
            BindingContext = new EditCarViewModel(id);
        }
	}
}