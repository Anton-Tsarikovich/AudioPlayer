using AudioPlayer.SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text;
using FreshMvvm;

namespace AudioPlayer
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private bool isBusy;
        private Command loadTrackCommand;
        protected MusicRepository musicDatabase;
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
                UpdateSongList();
            });
            
            //await ScanMem();
           
            IsBusy = false;

            LoadTrackCommand.ChangeCanExecute();
        }

        protected abstract void UpdateSongList();

        protected void ScanMemory(List<string> songs)
        {
            fileScanner.Start(songs);

        }


        protected void OnPropertyChanged([CallerMemberName]string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
