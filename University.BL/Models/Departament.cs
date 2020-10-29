﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.BL.Models
{
    [Table("Department", Schema = "dbo")]
    public class Departament
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }

        [ForeignKey ("Instructor")]
        public int InstructorID { get; set; }

        public Instructor Instructor { get; set; }
    }
}
