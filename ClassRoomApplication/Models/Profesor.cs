using System.ComponentModel.DataAnnotations;

namespace ClassRoomApplication.Models
{
    public class Profesor
    {
        [Key]
        public int ProfesorId { get; set; }
        [Display(Name =("Name"))]

        public string ProfesorName { get; set; }    
        [DataType(DataType.Password)]
        public string? Password { get; set; }    
        public string Email { get; set; }   
        public int Telephone { get; set; }  
        public string? PhotoURL { get; set; } 
        public Materie? Materie { get; set; }
        ICollection<Materie> ListMateries { get; set; }


        




    }
}
