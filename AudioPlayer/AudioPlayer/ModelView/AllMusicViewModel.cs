using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace AudioPlayer
{
    public class AllMusicViewModel : BaseViewModel
    {

        public ICommand Play { get; set; }
        private Command itemSelectedCommand;
        private AudioProperties selectedTrack { get; set; }
        public Image image { get; set; }
        public ObservableCollection<AudioProperties> SongList { get; set; }


        public AudioProperties SelectedTrack
        {
            get { return selectedTrack; }
            set
            {
                selectedTrack = value;
            }
        }



        public AllMusicViewModel()
        {
            //Play = new Command(OnPlayAsync);
            SongList = new ObservableCollection<AudioProperties>(musicDatabase.GetAllMusic());

            image = new Image() { Source = "TrebleClef.png" };
        }

        public AllMusicViewModel(Artist artist)
        {
            SongList = new ObservableCollection<AudioProperties>(musicDatabase.GetArtistsTrack(artist.ArtistName));
        }

        public AllMusicViewModel(Album album)
        {
            SongList = new ObservableCollection<AudioProperties>(musicDatabase.GetAlbumsTrack(album.AlbumName));
        }

        protected override void UpdateSongList()
        {

            List<string> songs = new List<string>();
            ScanMemory(songs);
            SongList.Clear();
            foreach (var i in songs)
            {
                SongList.Add(AudioParams.GetParam(i));
                musicDatabase.CreateTrack(AudioParams.GetParam(i));
            }
        }

    }
}







