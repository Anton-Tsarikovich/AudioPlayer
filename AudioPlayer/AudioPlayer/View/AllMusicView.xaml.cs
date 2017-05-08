
using System;
using Xamarin.Forms;

namespace AudioPlayer
{
	public partial class AllMusicView : ContentPage
	{
        public AllMusicViewModel ViewModel { get; private set; }

        public AllMusicView()
        {
            BindingContext = new AllMusicViewModel();
            InitializeComponent();
        }
        public AllMusicView(AllMusicViewModel vm)
        {
            ViewModel = vm;
            BindingContext = ViewModel;
            InitializeComponent();

        }

        private void ListView_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            AudioProperties a = e.Item as AudioProperties;
            Navigation.PushAsync(new PlayerView(new PlayerModelView(BindingContext as BaseViewModel, a)));
        }

        public void OnBackButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
