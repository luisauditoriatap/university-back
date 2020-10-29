using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;


namespace University.Web.Controllers
{
    //[Authorize]
    [RoutePrefix ("api/Courses")]
    public class CoursesController : ApiController
    {
        private IMapper mapper;
        private readonly CourseService courseService = new CourseService(new CourseRepository(UniversityContext.Create()));

        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }


        /// <summary>
        /// obtiene los objetos del curso
        /// </summary>
        /// <returns>Listaod de los objetos del curso</returns>
        /// <response code="200" >Ok. Devuelve el listado de objetos solicitado.</response> 
        [HttpGet]
        [ResponseType(typeof(IEnumerable<CourseDTO>))]       
        public async Task<IHttpActionResult> Get()
        {
            var courses = await courseService.GetAll();
            var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));


            return Ok(coursesDTO); //estatus codigo 200
        }

        /// <summary>
        /// obtiene un objeto por su Id
        /// </summary>
        /// <remarks>
        /// Aquí una descripción mas larga si fuera necesario. Obtiene un objeto por su Id.
        /// <param name="id"> Id del objeto </param>
        /// <returns> Objeto Course </returns>
        /// <response code="200" >Ok. Devuelve el objeto solicitado.</response> 
        /// <response code="404" >NotFount. No se a encontrado el objeto solicitado.</response> 
        [HttpGet]        
        [ResponseType(typeof(CourseDTO))]      
        public async Task<IHttpActionResult> Get(int id)
        {
            var course = await courseService.GetById(id);
            var courseDTO = mapper.Map<CourseDTO>(course);

            return Ok(courseDTO); //estatus codigo 200
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Insert(course);
                return Ok(courseDTO);
            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(CourseDTO courseDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // status code 400

            if (courseDTO.CourseID != id)
                return BadRequest();

            var flag = await courseService.GetById(id);
            if (flag == null)
                return NotFound(); // status code 404

            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Update(course);
                return Ok(courseDTO); // status code  200
            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await courseService.GetById(id);
            if (flag == null)
                return NotFound(); // status code 404

            try
            {
                if (!await courseService.DeleteCheckOnEntity(id))
                    await courseService.Delete(id);

                else
                    throw new Exception("Llaves foraneas");

                await courseService.Delete(id);
                return Ok(); // status code  200
            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }
        }


    }
}
