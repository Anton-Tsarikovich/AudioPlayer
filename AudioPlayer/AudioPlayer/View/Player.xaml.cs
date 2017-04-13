using Xamarin.Forms;

namespace AudioPlayer
{
	public partial class Player : ContentView
	{
        public PlayerModelView ViewModel { get; private set; }
		public Player (PlayerModelView vm)
		{
			InitializeComponent ();
            ViewModel = vm;
            BindingContext = ViewModel;
		}
	}
}
