namespace Moodle.Domain
{
    public abstract class File
    {
        public int Id { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}
    