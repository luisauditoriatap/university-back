using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class CourseInstructorDTO
    {
       // [Required(ErrorMessage = "Este campo es requerido")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int InstructorID { get; set; }

    }
}
