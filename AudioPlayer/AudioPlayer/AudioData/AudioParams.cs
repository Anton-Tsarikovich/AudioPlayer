using System;
using System.Collections.Generic;
using System.Text;

namespace AudioPlayer
{
    public static class AudioParams
    {
        public static AudioProperties GetParam(string path)
        {
            Android.Media.MediaMetadataRetriever reader = new Android.Media.MediaMetadataRetriever();
            reader.SetDataSource(path);
            string title = reader.ExtractMetadata(Android.Media.MediaMetadataRetriever.MetadataKeyTitle);
            string album = reader.ExtractMetadata(Android.Media.MediaMetadataRetriever.MetadataKeyAlbum);
            string artist = reader.ExtractMetadata(Android.Media.MediaMetadataRetriever.MetadataKeyArtist);
            string bitrate = reader.ExtractMetadata(Android.Media.MediaMetadataRetriever.MetadataKeyBitrate);

            return new AudioProperties { Title = title,
                                        Album = album,
                                        Artist = artist,
                                        Bitrate = bitrate,
                                        TrackPath = path };
        }
    }
}
