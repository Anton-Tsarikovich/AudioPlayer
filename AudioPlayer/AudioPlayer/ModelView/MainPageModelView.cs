using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AudioPlayer
{
    public class MainPageModelView : BaseViewModel
    {
        public ObservableCollection<FlyoutMenuModel> MenuItems { get; set; }

        private FlyoutMenuModel selectedItem;
        public FlyoutMenuModel SelectedItem {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public MainPageModelView()
        {
            MenuItems = new ObservableCollection<FlyoutMenuModel>
            {
                new FlyoutMenuModel {Title = "Вся музыка", TargetType = typeof(AllMusicView)},
                new FlyoutMenuModel {Title = "Альбомы", TargetType = typeof(AlbumView)},
                new FlyoutMenuModel {Title = "Исполнители", TargetType = typeof(ArtistsView)},
                new FlyoutMenuModel {Title = "Папки", TargetType = typeof(FoldersView)} 
            };
        }
    }
}
