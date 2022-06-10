using System.ComponentModel.DataAnnotations;

namespace ClassRoomApplication.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Comment { get; set; } 
        public int Grade { get; set; }  
        public DateTime DateTime { get; set; }  
        public Proiecte? Proiecte { get; set; }  
        ICollection<Proiecte> ListProiectes { get; set; }

    }
}
