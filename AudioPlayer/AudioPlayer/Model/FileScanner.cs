using AudioPlayer.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public class FileScanner
    {
        public async void Start(List<string> Songs)
        {
            List<string> external = new List<string>();
            List<string> internalSt = new List<string>();
            GetDirectory(external);
            GetDirectory(internalSt, Android.OS.Environment.ExternalStorageDirectory.AbsolutePath);
            Songs.AddRange(external);
            Songs.AddRange(internalSt);
        }

        public void GetDirectory(List<string> songs, string path = "/storage")
        {
            List<string> directory = new List<string>();
            List<string> file = new List<string>();
            try
            {
                directory = (from filepath in Directory.EnumerateDirectories(path).AsParallel()
                     select Path.GetFullPath(filepath)).ToList();
                file = (from filepath in Directory.EnumerateFiles(path).AsParallel()
                     select Path.GetFullPath(filepath)).ToList();
            }
            catch(Exception e)
            {
                //throw new Exception("Some exception in scanning");
            }
            List<string> result = new List<string>();
            result.AddRange(directory);
            result.AddRange(file);
            List<string> songPath = ScanSubDirs(songs, result);
            songs.AddRange(songPath);
        }

        public List<string> ScanSubDirs(List<string> songs, List<string> rootDirectory)
        {

            List<string> songList = new List<string>();
            foreach(var subDir in rootDirectory)
            {
                if(Directory.Exists(subDir))
                {
                    GetDirectory(songs, subDir);
                }
                else
                {
                    if(CheckPattern(subDir.ToString()))
                    {
                        songList.Add(subDir);
                    }
                }
            }
            return songList;
        }

        private bool CheckPattern(string songName)
        {
            const string mp3Pattern = ".mp3";
           // const string flacPattern = ".flac";

            return songName.EndsWith(mp3Pattern);
        }
    }
}
