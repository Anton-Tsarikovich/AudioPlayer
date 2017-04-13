using System;
using System.Collections.Generic;
using System.Text;

namespace AudioPlayer
{
    public class AudioProperties
    {
        private string trackPath { get; set; }
        private string title { get; set; }
        private string album { get; set; }
        private string artist { get; set; }
        private string bitrate { get; set; }

        public string TrackPath
        {
            get { return trackPath; }
            set
            {
                trackPath = value;
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
            }
        }

        public string Album
        {
            get { return album; }
            set
            {
                album = value;
            }
        }

        public string Artist
        {
            get { return artist; }
            set
            {
                artist = value;
            }
        }

        public string Bitrate
        {
            get { return bitrate; }
            set
            {
                bitrate = value;
            }
        }
    }
}
