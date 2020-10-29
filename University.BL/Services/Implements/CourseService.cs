using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Repositories;
using University.BL.Repositories.Implements;

namespace University.BL.Services.Implements
{
    public class CourseService : GenericService<Course>, ICourseRepository
    {       
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository) : base(courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await courseRepository.DeleteCheckOnEntity(id); 
        }
    }
}

