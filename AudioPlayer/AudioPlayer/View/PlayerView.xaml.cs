using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AudioPlayer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayerView : ContentPage
	{
        public PlayerModelView ViewModel { get; private set; }
        public PlayerView (PlayerModelView vm)
		{
            InitializeComponent();
            ViewModel = vm;
            BindingContext = ViewModel;

        }
	}
}
