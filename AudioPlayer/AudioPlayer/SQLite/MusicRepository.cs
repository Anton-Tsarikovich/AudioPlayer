using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AudioPlayer.SQLite
{
    public class MusicRepository
    {

        const string quote = "\"";
        private readonly SQLiteConnection connection;

        public string StatusMessage { get; set; }

        public MusicRepository(string path)
        {

            connection = new SQLiteConnection(path);
            connection.CreateTable<AudioProperties>();
        }

        
        public async Task CreateTrack(AudioProperties track)
        {
            try
            {
                int result = 0;
                if (string.IsNullOrEmpty(track.TrackPath))
                {
                    throw new Exception("Path is required");
                }
                if (track.Id == 0)
                {
                    result = connection.Insert(track);
                }
                else
                {
                    result = connection.Update(track);
                }
                StatusMessage = $"{result} record added [Track Name: {track.Title}]";
            }
            catch (Exception e)
            {
                StatusMessage = $"Failed to create [Track Name: {track.Title}]. Error: {e.Message}";
            }
        }

        public List<AudioProperties> GetAllMusic()
        {
            return (from i in connection.Table<AudioProperties>() select i).ToList();
        }

        public List<Artist> GetArtists()
        {
            var query = connection.Query<AudioProperties>("SELECT Artist FROM AudioProperties", new object[] { });
            var kek = (from i in query select i.Artist).Distinct().ToList();
            List<Artist> ar = new List<Artist>();
            foreach(var i in kek)
            {
                ar.Add(new Artist { ArtistName = i });
            }
            return ar;
        }

        public List<Album> GetAlbums()
        {
            var query = connection.Query<AudioProperties>("SELECT Album FROM AudioProperties", new object[] { });
            var kek = (from i in query select i.Album).Distinct().ToList();
            List<Album> ar = new List<Album>();
            foreach (var i in kek)
            {
                ar.Add(new Album { AlbumName = i });
            }
            return ar;
        }

        public List<AudioProperties> GetArtistsTrack(string artistName)
        {
            var query = connection.Query<AudioProperties>(@"SELECT * FROM AudioProperties WHERE Artist = " + quote 
                + artistName + quote, new object[] { });
            var kek = (from i in query select i).ToList();
            return kek;
        }

        public List<AudioProperties> GetAlbumsTrack(string album)
        {
            var query = connection.Query<AudioProperties>(@"SELECT * FROM AudioProperties WHERE Album = " + quote
                + album + quote, new object[] { });
            var kek = (from i in query select i).ToList();
            return kek;
        }







        /*SQLiteAsyncConnection database;
        public MusicRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteAsyncConnection(databasePath);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<AudioProperties>();
        }

        public async Task<AudioProperties> GetItemAsync(int id)
        {
            return await database.GetAsync<AudioProperties>(id);
        }

        public async Task<List<AudioProperties>> GetItemsAsync()
        {
            return await database.QueryAsync<AudioProperties>("select * from songs");
        }

        public async Task<int> DeleteItemAsync(AudioProperties item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> AddRange(List<AudioProperties> items)
        {
            return await database.InsertAllAsync(items);
        }

        public async Task<int> SaveItemAsync(AudioProperties item)
        {
            if(item.Id != 0)
            {
                await database.UpdateAsync(item);
                return item.Id;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }

    */
    }
}
