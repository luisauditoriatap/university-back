using University.BL.Models;
using University.BL.Data;

namespace University.BL.Repositories.Implements
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(UniversityContext universityContext) : base(universityContext)
        {

        }
    }
}
 