using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClassRoomApplication.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Telephone { get; set; }
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Date_of_Birth { get; set; }
        [Display(Name = ("Academic year"))]
        public int Year { get; set; }
        public string? PhotoURL { get; set; }
        public  Materie? Materie { get; set; }  
        ICollection<Materie> ListMateries { get; set; }
     
        

        
    }
}
