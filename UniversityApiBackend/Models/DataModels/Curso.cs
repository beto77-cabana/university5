using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{

    public enum Level
    {
        Basic,
        Medium,
        Advanced,
        Expert
    }

    public class Curso: BaseEntity
    {
        [Required, StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string DescripcionCorta { get; set; } = string.Empty;

        [Required]
        public string DescripcionLarga { get; set; } = string.Empty;

        public string PublicoObjetivo { get; set; } = string.Empty;

        public string Objetivos { get; set; } = string.Empty;


        public string Requisitos { get; set; } = string.Empty;

        public Level Level { get; set; } = Level.Basic;

        [Required]   //lo que dice es que existe una relacion de forma que un curso puede tener varias categorias
        public ICollection<Category> Categories { get; set; } = new List<Category>();//departe de la categoria hay que hacer la inversa
        [Required]
        public Chapter Chapters { get; set; } = new  Chapter();

        [Required]
        public ICollection<Student> students { get; set; } = new List<Student>();

    }
}
