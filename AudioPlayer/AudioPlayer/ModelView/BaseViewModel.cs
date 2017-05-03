using AudioPlayer.SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using FreshMvvm;

namespace AudioPlayer
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<AudioProperties> SongList { get; set; }

        private bool isBusy;
        private Command loadTrackCommand;
        private MusicRepository musicDatabase;
        private FileScanner fileScanner;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy == value) { return; }
                isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public BaseViewModel()
        {
            musicDatabase = new MusicRepository(SQLiteAsyncDroid.GetDatabasePath("Songs.db"));
            fileScanner = new FileScanner();
            SongList = new ObservableCollection<AudioProperties>();
            List<AudioProperties> qq = new List<AudioProperties>();
            qq = musicDatabase.GetAllMusic();
            foreach (var i in qq)
            {
                SongList.Add(i);
            }

        }
        

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
            if (IsBusy) { return; }

            IsBusy = true;

            LoadTrackCommand.ChangeCanExecute();

            await Task.Run(() =>
            {
                List<string> songs = new List<string>();
                fileScanner.Start(songs);
                SongList.Clear();
                foreach (var i in songs)
                {
                    SongList.Add(AudioParams.GetParam(i));
                    musicDatabase.CreateTrack(AudioParams.GetParam(i));
                }
                List<AudioProperties> lol = new List<AudioProperties>();
            });
            
            //await ScanMem();
           
            IsBusy = false;

            LoadTrackCommand.ChangeCanExecute();
        }

        protected async Task<ObservableCollection<AudioProperties>> ScanMem()
        {
            List<string> songs = new List<string>();
            fileScanner.Start(songs);
            foreach (var i in songs)
            {
                SongList.Add(AudioParams.GetParam(i));
                //musicDatabase.CreateTrack(AudioParams.GetParam(i));
            }
            List<AudioProperties> lol = new List<AudioProperties>();
           /* lol = musicDatabase.GetAllMusic();
            SongList.Clear();
            foreach (var i in lol)
            {
                SongList.Add(i);
            }*/

            return SongList;
        }


        protected void OnPropertyChanged([CallerMemberName]string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
