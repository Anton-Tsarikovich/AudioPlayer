using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioPlayer
{
    public class Artist
    {
        private string artistName { get; set; }

        public string ArtistName
        {
            get { return artistName; }
            set
            {
                artistName = (value == "") ? "Unknown artist" : value;
            }
        }
    }
}
