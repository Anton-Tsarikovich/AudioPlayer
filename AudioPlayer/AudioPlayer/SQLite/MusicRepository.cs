using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AudioPlayer.SQLite
{
    public class MusicRepository
    {
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
