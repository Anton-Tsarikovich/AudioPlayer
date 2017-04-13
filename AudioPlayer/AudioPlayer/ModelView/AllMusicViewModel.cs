using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AudioPlayer
{
    public class AllMusicViewModel : BaseViewModel
    {
#region list
        public List<string> Songs { get; set; }

        public ObservableCollection<Song> SongList { get; set; }
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
            FileScanner f = new FileScanner();
            Songs.Clear();
            SongList.Clear();
            f.Start(Songs);
            foreach(var i in Songs)
            {
                SongList.Add(new Song { SongPath = i });
                AudoiParams.GetParam(i);
            }

#endregion

            IsBusy = false;

            LoadTrackCommand.ChangeCanExecute();
        }

        public AllMusicViewModel()
        {
            Songs = new List<string>();
            SongList = new ObservableCollection<Song>();
           
        }
    }
}
