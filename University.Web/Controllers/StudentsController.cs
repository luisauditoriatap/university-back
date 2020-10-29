using AutoMapper;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Http;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.Web.Controllers
{
    [RoutePrefix("api/Students")]
    public class StudentsController : ApiController
    {
        private IMapper mapper;
        private readonly StudentService studentService = new StudentService(new StudentRepository(UniversityContext.Create()));

        public StudentsController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Controlador Estudiante
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var students = await studentService.GetAll();
            var studentsDTO = students.Select(x => mapper.Map<StudentDTO>(x));

            return Ok(studentsDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var student = await studentService.GetById(id);
            if (student == null)
                return NotFound();

            var studentDTO = mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var student = mapper.Map<Student>(studentDTO);
                student = await studentService.Insert(student);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(StudentDTO studentDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (studentDTO.ID != id)
                return BadRequest();

            var flag = await studentService.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                var student = mapper.Map<Student>(studentDTO);
                student = await studentService.Update(student);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
         public async Task<IHttpActionResult> Delete(int id) 
        {
            var flag = await studentService.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                await studentService.Delete(id);
                return Ok();
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
                        
        }
        
    }
}

