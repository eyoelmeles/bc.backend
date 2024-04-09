using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class FileModel : BaseModel
    {
        public Guid FolderId {  get; set; }
        public string FileName { get; set; }
        public string File { get; set; }
    }

    public class FileModelDTO
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string File { get; set; }
    }

    public enum FileDetailType
    {
        note,
        rfi
    }

    public class FileDetail : BaseModel
    {
        public Guid FileId { get; set; }
        public string Details { get; set; }
        public FileDetailType FileType { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
    public class FileDetailDTO
    {
        public Guid Id { get; set; }
        public string Details { get; set; }
        public FileDetailType FileType { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
    }
}
