using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Infrastructure.Files
{
    public class LocalFileClient : IFileClient
    {
        private readonly string _filesRoot;

        public LocalFileClient(string filesRoot)
        {
            if (string.IsNullOrWhiteSpace(filesRoot))
            {
                throw new ArgumentException("FilesRoot peab olema seadistatud.", nameof(filesRoot));
            }

            _filesRoot = Path.TrimEndingDirectorySeparator(Path.GetFullPath(filesRoot));
        }

        public Task Save(string fileName, string fileStore, Stream inputStream)
        {
            return Save(fileName, fileStore, null, inputStream);
        }

        public async Task Save(string fileName, string fileStore, string subFolder, Stream inputStream)
        {
            if (inputStream == null)
            {
                throw new ArgumentNullException(nameof(inputStream));
            }

            var filePath = GetFilePath(fileName, fileStore, subFolder);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            await inputStream.CopyToAsync(fileStream);
        }

        public Task<Stream> Get(string fileName, string fileStore, string subFolder)
        {
            var filePath = GetFilePath(fileName, fileStore, subFolder);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Faili ei leitud.", filePath);
            }

            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            return Task.FromResult(stream);
        }

        public Task Delete(string fileName, string fileStore, string subFolder)
        {
            var filePath = GetFilePath(fileName, fileStore, subFolder);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            return Task.CompletedTask;
        }

        public Task<IList<string>> List(string fileStore, string subFolder)
        {
            var folderPath = Path.GetDirectoryName(GetFilePath("placeholder", fileStore, subFolder));

            IList<string> fileNames = Directory.Exists(folderPath)
                ? Directory.GetFiles(folderPath).Select(Path.GetFileName).OrderBy(x => x).ToList()
                : new List<string>();

            return Task.FromResult(fileNames);
        }

        public bool Exists(string fileName, string fileStore, string subFolder)
        {
            return File.Exists(GetFilePath(fileName, fileStore, subFolder));
        }

        public long GetSize(string fileName, string fileStore, string subFolder)
        {
            var filePath = GetFilePath(fileName, fileStore, subFolder);

            return File.Exists(filePath) ? new FileInfo(filePath).Length : 0;
        }

        private string GetFilePath(string fileName, string fileStore, string subFolder)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("Faili nimi puudub.", nameof(fileName));
            }

            if (fileName != Path.GetFileName(fileName))
            {
                throw new ArgumentException("Faili nimi ei tohi sisaldada kaustateed.", nameof(fileName));
            }

            if (string.IsNullOrWhiteSpace(fileStore))
            {
                throw new ArgumentException("Failide kaust puudub.", nameof(fileStore));
            }

            var folderPath = Path.Combine(_filesRoot, fileStore);

            if (!string.IsNullOrWhiteSpace(subFolder))
            {
                folderPath = Path.Combine(folderPath, subFolder);
            }

            var filePath = Path.GetFullPath(Path.Combine(folderPath, fileName));
            var relativePath = Path.GetRelativePath(_filesRoot, filePath);

            if (Path.IsPathRooted(relativePath) ||
                relativePath.Equals("..", StringComparison.Ordinal) ||
                relativePath.StartsWith(".." + Path.DirectorySeparatorChar, StringComparison.Ordinal))
            {
                throw new InvalidOperationException("Faili asukoht väljub FilesRoot kaustast.");
            }

            return filePath;
        }
    }
}
