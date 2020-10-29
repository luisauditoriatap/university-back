using System.Data.Entity;
using System.Threading.Tasks;
using University.BL.Data;
using University.BL.Models;

namespace University.BL.Repositories.Implements
{
    public class DepartamentRepository : GenericRepository<Departament>, IDepartamentRepository
    {
        private readonly UniversityContext universityContext;
        public DepartamentRepository(UniversityContext universityContext) : base(universityContext)
        {
            this.universityContext = universityContext;
        }
    }
}
