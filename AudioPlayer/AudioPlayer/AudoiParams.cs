using System;
using System.Collections.Generic;
using System.Text;

namespace AudioPlayer
{
    public static class AudoiParams
    {
        public static void GetParam(string path)
        {
            Android.Media.MediaMetadataRetriever reader = new Android.Media.MediaMetadataRetriever();
            reader.SetDataSource(path);
            string title = reader.ExtractMetadata(Android.Media.MediaMetadataRetriever.MetadataKeyTitle);
            string album = reader.ExtractMetadata(Android.Media.MediaMetadataRetriever.MetadataKeyAlbum);
            string artist = reader.ExtractMetadata(Android.Media.MediaMetadataRetriever.MetadataKeyArtist);
            string bitrate = reader.ExtractMetadata(Android.Media.MediaMetadataRetriever.MetadataKeyBitrate);
            string hasAudio = reader.ExtractMetadata(Android.Media.MediaMetadataRetriever.MetadataKeyHasAudio);



        }
    }
}
