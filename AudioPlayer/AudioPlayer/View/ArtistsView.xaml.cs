using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AudioPlayer
{
	public partial class ArtistsView : ContentPage
	{
		public ArtistsView ()
		{
			InitializeComponent ();
            BindingContext = new ArtistsViewModel() { Navigation = this.Navigation };
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Artist a = e.Item as Artist;
            Navigation.PushAsync(new AllMusicView(new AllMusicViewModel(a)));
        }
    }
}
