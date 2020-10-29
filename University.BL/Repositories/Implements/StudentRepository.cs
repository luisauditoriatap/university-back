﻿using University.BL.Data;
using University.BL.Models;

namespace University.BL.Repositories.Implements
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository 
    {
        public StudentRepository(UniversityContext universityContext) : base(universityContext)
        {

        }
    }
}


