using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Models.DataModels;
using Index = UniversityApiBackend.Models.DataModels.Chapter;

namespace UniversityApiBackend.DataAccess
{
    public class UniversityDBContext: DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options)    //ESTABLECEMOS EL CONSTRUCTOR
        {


        }
        // Add DbSets (Tables of ours DB)
        public DbSet<User>? Users { get; set; }  //LA INTERROGACION ES PQ PUEDE QUE EXISTA O NO. COLOCAMOS UN NOMBRE A LA TABLA "USER"
        public DbSet<Curso>? Cursos { get; set; } //SE CREARAN TABLAS DENTRO DE LA BD
        public  DbSet<Chapter>? Chapters { get; set; } //
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
    }
}
