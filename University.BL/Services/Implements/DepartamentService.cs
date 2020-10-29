using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Repositories;

namespace University.BL.Services.Implements
{
    public class DepartamentService : GenericService<Departament>, IDepartamentService
    {
        private readonly IDepartamentRepository departamentRepository;
        public DepartamentService(IDepartamentRepository departamentRepository) : base(departamentRepository)
        {
            this.departamentRepository = departamentRepository;
        }
    }
}
