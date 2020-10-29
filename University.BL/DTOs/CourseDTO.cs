using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class CourseDTO
    {
        [Required(ErrorMessage = "El Campo ID es requerido")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "El Campo Titulo es requerido")]

        [StringLength(50)]
        public string Title { get; set; }
        

        [Required(ErrorMessage = "El Campo Crédito es requerido")]
        public int Credits { get; set; }
    }
}
