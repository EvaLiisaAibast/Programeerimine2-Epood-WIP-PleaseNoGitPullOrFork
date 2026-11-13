using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Infrastructure.Files
{
    public interface IFileClient
    {
        Task Save(string fileName, string fileStore, Stream inputStream);
        Task Save(string fileName, string fileStore, string subFolder, Stream inputStream);
        Task<Stream> Get(string fileName, string fileStore, string subFolder);
        Task Delete(string fileName, string fileStore, string subFolder);
        Task<IList<string>> List(string fileStore, string subFolder);
        bool Exists(string fileName, string fileStore, string subFolder);
        long GetSize(string fileName, string fileStore, string subFolder);
    }
}
