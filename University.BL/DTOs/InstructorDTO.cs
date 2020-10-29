using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class InstructorDTO
    {
        //[Required(ErrorMessage ="Este campo es requerido")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(50)]
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }

        public string FullNane
        {
            get { return string.Format("{0} {1}", FirstMidName, LastName); }
        }


    }
}
