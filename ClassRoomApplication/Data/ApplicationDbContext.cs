using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClassRoomApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace ClassRoomApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ClassRoomApplication.Models.Profesor>? Profesor { get; set; }
        public DbSet<ClassRoomApplication.Models.Materie>? Materie { get; set; }
        public DbSet<ClassRoomApplication.Models.Review>? Review { get; set; }
        public DbSet<ClassRoomApplication.Models.Proiecte>? Proiecte { get; set; }
        public DbSet<ClassRoomApplication.Models.Student>? Student { get; set; }
        public DbSet<ClassRoomApplication.Models.FileClass>? Continut { get; set; }
        


    }
}