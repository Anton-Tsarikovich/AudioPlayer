using System;
using System.Collections.Generic;
using System.Text;

namespace AudioPlayer
{
    public class Album
    {
        private string album { get; set; }

        public string AlbumName
        {
            get { return album; }
            set
            {
                album = value;
            }
        }
    }
}
