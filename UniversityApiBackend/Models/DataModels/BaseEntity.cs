using System.ComponentModel.DataAnnotations;  //NOS  PERMITE ESTABLCER UN CAMPO PARA CLAVE NOMBRE ETC 

namespace UniversityApiBackend.Models.DataModels
{
    public class BaseEntity      //ES UNA CLASE QUE NOS VA A PERMITIR ESTABLECER REQUISITOS O CAMPOS QUE QUEREMOS QUE TODAS NUESTRAS TABLAS 
                                // QUEREMOS QUE TENGAN
    {
        [Required]                                                //VAN CAMPOS QUE VAN A TENER TODAS NUESTRAS TABLAS DE BASE D EDATOS
        [Key]
        public int Id { get; set; }
        public string CreateBy { get; set; } = String.Empty;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string UpdateBy { get; set; } = String.Empty;
        public DateTime? UpdateAt { get; set; }
        public string DeleteBy { get; set; } = String.Empty;
        public DateTime? DeleteAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
