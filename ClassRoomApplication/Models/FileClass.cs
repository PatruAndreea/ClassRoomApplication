using System.ComponentModel.DataAnnotations;

namespace ClassRoomApplication.Models
{
    public class FileClass
    {
        [Key]
        public int FileId { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Path { get; set; } = "";
        public List<FileClass> Files { get; set; } = new List<FileClass>();
    }
}
