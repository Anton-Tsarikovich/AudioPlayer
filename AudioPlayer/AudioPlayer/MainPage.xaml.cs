using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace AudioPlayer
{
	public partial class MainPage : MasterDetailPage
	{
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageModelView();

            mainMenu.ItemSelected += OnItemSelected;

            
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutMenuModel;
            if(item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            }
            IsPresented = false;
            mainMenu.SelectedItem = null;
        }

    }
}
