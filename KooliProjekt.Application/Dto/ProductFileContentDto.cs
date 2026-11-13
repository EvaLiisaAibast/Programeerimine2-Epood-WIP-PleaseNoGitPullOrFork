using System.IO;

namespace KooliProjekt.Application.Dto
{
    public class ProductFileContentDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long SizeBytes { get; set; }
        public Stream Stream { get; set; }
    }
}
