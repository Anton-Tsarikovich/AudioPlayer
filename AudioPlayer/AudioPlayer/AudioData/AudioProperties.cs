using System;
using System.Collections.Generic;
using System.Text;
using AudioPlayer.SQLite;
using SQLite;

namespace AudioPlayer
{
    [Table(nameof(AudioProperties))]
    public class AudioProperties
    {
        private string trackPath { get; set; }
        private string title { get; set; }
        private string album { get; set; }
        private string artist { get; set; }
        private string bitrate { get; set; }
        private int id { get; set; }

        [NotNull, MaxLength(250), Unique]
        public string TrackPath
        {
            get { return trackPath; }
            set
            {
                trackPath = value;
            }
        }

        [MaxLength(250)]
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
            }
        }
        [MaxLength(250)]
        public string Album
        {
            get { return album; }
            set
            {
                album = value;
            }
        }
        [NotNull, MaxLength(250)]
        public string Artist
        {
            get { return artist; }
            set
            {
                artist = value;
            }
        }

        [MaxLength(250)]
        public string Bitrate
        {
            get { return bitrate; }
            set
            {
                bitrate = value;
            }
        }

        [PrimaryKey, AutoIncrement, Unique]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
    }
}
