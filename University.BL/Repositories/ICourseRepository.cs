using University.BL.Models;
using System.Threading.Tasks;

namespace University.BL.Repositories
{
    public interface ICourseRepository : IGenericRepository <Course>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
