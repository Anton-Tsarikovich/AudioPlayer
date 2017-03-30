using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer.Model
{
    interface IFileWorker
    {
        Task<bool> ExistsAsync(string filename);
        Task<IEnumerable<string>> GetFilesAsynk();
    }
}
