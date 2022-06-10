using System.ComponentModel.DataAnnotations;

namespace ClassRoomApplication.Models
{
    public class Proiecte
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        




    }
}
