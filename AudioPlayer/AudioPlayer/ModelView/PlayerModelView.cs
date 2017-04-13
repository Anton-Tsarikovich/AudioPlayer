using System.Windows.Input;
using Xamarin.Forms;

namespace AudioPlayer
{
    public class PlayerModelView : BaseViewModel
    {
        public string PlayButtonText { get; set; }
        private string trackPath { get; set; }
        private bool isPlay = false;
        private PlayerModel pl;
        private int duration = 0;

        public ICommand PlayCommand { protected set; get; }


        public PlayerModelView(string path)
        {
            PlayButtonText = "Play";
            trackPath = path;
            PlayCommand = new Command(OnClick);
            pl = new PlayerModel(trackPath);
        }
        private void OnClick()
        {
            PlayButtonText = isPlay ? "Play" : "Stop";
            isPlay = !isPlay;
            pl.OnPlay(isPlay, duration);
            duration = pl.GetDuration();
            OnPropertyChanged("Play");
        }

    }
}
