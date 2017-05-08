using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace AudioPlayer
{
    public class PlayerModelView : BaseViewModel
    {
        private List<AudioProperties> trackPath { get; set; }
        private AudioProperties currentTrack { get; set; }
        private bool isPlay = false;
        private PlayerModel pl;
        private int duration = 0;
        private Image playPauseImage;

        public ICommand PlayCommand { protected set; get; }


        public PlayerModelView(BaseViewModel collect, AudioProperties track)
        {
            playPauseImage = new Image { Source = "Play.png" };
           // trackPath = collect;
            PlayCommand = new Command(OnClick);
            currentTrack = track;
            pl = new PlayerModel(currentTrack.TrackPath);
        }

        private void OnClick()
        {
            isPlay = !isPlay;
            pl.OnPlay(isPlay, duration);
            duration = pl.GetDuration();
            OnPropertyChanged("Play");
        }

        protected override void UpdateSongList()
        {
            throw new NotImplementedException();
        }
    }
}
