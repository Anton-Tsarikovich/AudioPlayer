using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AudioPlayer
{
    public class AlbumViewModel : BaseViewModel
    {
        public ObservableCollection<Album> Albums { get; set; }

        public AlbumViewModel()
        {
            Albums = new ObservableCollection<Album>(musicDatabase.GetAlbums());
        }

        protected override void UpdateSongList()
        {

            List<string> songs = new List<string>();
            ScanMemory(songs);
            Albums.Clear();
            foreach (var i in songs)
            {
                musicDatabase.CreateTrack(AudioParams.GetParam(i));
            }
        }
    }
}
