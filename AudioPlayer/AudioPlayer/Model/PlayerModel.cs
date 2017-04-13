using Android.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioPlayer
{
    public class PlayerModel
    {
        private MediaPlayer player;
        private string path;

        public PlayerModel(string path)
        {
            player = new MediaPlayer();
            player.Reset();
            player.SetDataSource(path);
            player.Prepare();

            this.path = path;
        }

        public async void OnPlay(bool isPlay, int duration)
        {
            if (player != null && isPlay)
            {
                player.Start();
            } else if (!isPlay)
            {
                player.Pause();
            }
        }

        public int GetDuration()
        {
            return player.Duration;
        }
    }
}
