using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace AudioPlayer
{
    public class ArtistsViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public ObservableCollection<object> Artists { get; set; }

        public ArtistsViewModel()
        {
            Artists = new ObservableCollection<object>(musicDatabase.GetArtists());
        }

        protected override void UpdateSongList()
        {
            List<string> songs = new List<string>();
            ScanMemory(songs);
            Artists.Clear();
            foreach (var i in songs)
            {
                musicDatabase.CreateTrack(AudioParams.GetParam(i));
            }
        }
    }
}
