
using Xamarin.Forms;

namespace AudioPlayer
{
	public partial class AllMusicView : ContentPage
	{
		public AllMusicView ()
		{
			InitializeComponent ();
            BindingContext = new AllMusicViewModel();

		}
	}
}
