
using System;
using Xamarin.Forms;

namespace AudioPlayer
{
	public partial class AllMusicView : ContentPage
	{
        public AllMusicView()
        {
            InitializeComponent();
            BindingContext = new AllMusicViewModel() { Navigation = this.Navigation };

		}

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            AudioProperties a = e.Item as AudioProperties;
            Navigation.PushAsync(new PlayerView(new PlayerModelView(a.TrackPath)));
        }
        public void OnBackButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
