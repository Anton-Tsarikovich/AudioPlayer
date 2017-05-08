using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AudioPlayer
{
	public partial class AlbumView : ContentPage
	{
		public AlbumView ()
		{
            InitializeComponent();
            BindingContext = new AlbumViewModel();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Album a = e.Item as Album;
            Navigation.PushAsync(new AllMusicView(new AllMusicViewModel(a)));
        }
    }
}
