using System.ComponentModel.DataAnnotations;

namespace ClassRoomApplication.Models
{
    public class Materie
    {
        [Key]
        public int MaterieId { get; set; }
        public string Name { get; set; } 
        public string Semester { get; set; }   
        public Proiecte? Proiecte { get; set; } 
        public int ProjectId { get; set; }  
        ICollection<Proiecte> ListProiectes { get; set; }    




    }
}
