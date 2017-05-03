using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using AudioPlayer.SQLite;

namespace AudioPlayer
{
    public class AllMusicViewModel : BaseViewModel
    {
#region list
        public List<string> Songs { get; set; }
        private MusicRepository musicDatabase;
        private FileScanner f;
        public ICommand Play { get; set; }
        public INavigation Navigation { get; set; }


#endregion
        
        public AllMusicViewModel()
        {
            Songs = new List<string>();
            f = new FileScanner();
            Play = new Command(OnPlayAsync);
         //   musicDatabase = new MusicRepository("Songs.db");
            List<AudioProperties> a = new List<AudioProperties>();
            //Task<List<AudioProperties>> getAudio = musicDatabase.GetItemsAsync();
     /*       getAudio.Wait();
            foreach(var audio in getAudio.Result)
            {
                SongList.Add(audio);
            }*/
           // GetAllFromDatabase();

        }   

        private async void GetAllFromDatabase()
        {
            List<AudioProperties> tempList = new List<AudioProperties>();
           // tempList = await musicDatabase.GetItemsAsync();
        }

        private async void OnPlayAsync(object track)
        {
            AudioProperties a = track as AudioProperties;
            await Navigation.PushAsync(new PlayerView(new PlayerModelView(a.TrackPath)));
        }

       /* private async Task<int> Scan()
        {
            Songs.Clear();
            SongList.Clear();
            f.Start(Songs);
            int result = 0;
            foreach (var i in Songs)
            {
                SongList.Add(AudioParams.GetParam(i));
                result += await musicDatabase.SaveItemAsync(SongList[SongList.Count - 1]);
            }
            return result;
        }*/
    }
}







