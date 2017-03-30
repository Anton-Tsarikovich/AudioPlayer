using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class FileScanner
    {
        public async void GetDirectory(List<string> songs, string path = "/storage")
        {
            List<string> a = new List<string>();
            List<string> b = new List<string>();
            try
            {
                a = (from filepath in Directory.EnumerateDirectories(path).AsParallel()
                     select Path.GetFullPath(filepath)).ToList();
                b = (from filepath in Directory.EnumerateFiles(path).AsParallel()
                     select Path.GetFullPath(filepath)).ToList();
            }
            catch(Exception e)
            {

            }
            List<string> result = new List<string>();
            result.AddRange(a);
            result.AddRange(b);
            List<string> x = await ScanSubDirs(songs, result);
            songs.AddRange(x);
        }

        public async Task<List<string>> ScanSubDirs(List<string> songs, List<string> rootDirectory)
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
                    if(await CheckPattern(subDir.ToString()))
                    {
                        songList.Add(subDir);
                    }
                }
            }
            return await Task.FromResult(songList);
        }

        private async Task<bool> CheckPattern(string songName)
        {
            const string mp3Pattern = ".mp3";
            const string flacPattern = ".flac";

            return await Task.FromResult(songName.EndsWith(mp3Pattern) || songName.EndsWith(flacPattern));
        }
    }
}
