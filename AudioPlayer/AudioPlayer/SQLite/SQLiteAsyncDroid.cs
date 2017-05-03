using AudioPlayer.SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAsyncDroid))]
namespace AudioPlayer.SQLite
{
    public class SQLiteAsyncDroid
    {
        public SQLiteAsyncDroid() { }

        public static string GetDatabasePath(string filename)
        {
            string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = Path.Combine(docsPath, filename);

            if(!File.Exists(path))
            {
                var dbAssetStream = Forms.Context.Assets.Open(filename);
                var dbFileStream = new FileStream(path, FileMode.OpenOrCreate);

                byte[] buffer = new byte[1024];
                int length;

                while((length = dbAssetStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    dbFileStream.Write(buffer, 0, length);
                }
                dbFileStream.Flush();
                dbFileStream.Close();
                dbAssetStream.Close();
            }

            return path;
        }
    }
}
