namespace KooliProjekt.Application.Dto
{
    public class ProductFileDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public string ContentType { get; set; }
        public long SizeBytes { get; set; }
        public bool FileExists { get; set; }
        public string AltText { get; set; }
        public int SortOrder { get; set; }
        public bool IsMain { get; set; }
    }
}
