using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;

namespace AudioPlayer
{
    public class AllMusicViewModel : BaseViewModel
    {
#region list
        public List<string> Songs { get; set; }

        public ObservableCollection<AudioProperties> SongList { get; set; }
        private FileScanner f;
        public ICommand Play { get; set; }
        public INavigation Navigation { get; set; }


#endregion

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if(isBusy == value) { return; }
                isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }


        private Command loadTrackCommand;

        public Command LoadTrackCommand
        {
            get
            {
                return loadTrackCommand ?? (loadTrackCommand = new Command(ExecuteLoad, () =>
                {
                    return !IsBusy;
                }));
            }
        }

        private async void ExecuteLoad()
        {
            if(IsBusy) { return; }

            IsBusy = true;

            LoadTrackCommand.ChangeCanExecute();
#region scan

            await Task.Run(() =>
            {
                Songs.Clear();
                SongList.Clear();
                f.Start(Songs);
                foreach (var i in Songs)
                {
                    SongList.Add(AudioParams.GetParam(i));
                }
            });

#endregion

            IsBusy = false;

            LoadTrackCommand.ChangeCanExecute();
        }

        public AllMusicViewModel()
        {
            Songs = new List<string>();
            SongList = new ObservableCollection<AudioProperties>();
            f = new FileScanner();
            Play = new Command(OnPlayAsync);

        }

        private async void OnPlayAsync(object track)
        {
            AudioProperties a = track as AudioProperties;
            await Navigation.PushAsync(new PlayerView(new PlayerModelView(a.TrackPath)));
        }
    }
}







