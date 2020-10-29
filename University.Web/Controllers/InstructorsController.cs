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
    public class InstructorsController : ApiController
    {
        private IMapper mapper;
        private readonly InstructorService instructorService = new InstructorService(new InstructorRepository(UniversityContext.Create()));

        public InstructorsController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Controlador Instructor
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var instructor = await instructorService.GetAll();
            var instructorDTO = instructor.Select(x => mapper.Map<InstructorDTO>(x));

            return Ok(instructorDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var instructor = await instructorService.GetById(id);

            if (instructor == null)
                return NotFound();

            var instructorDTO = mapper.Map<InstructorDTO>(instructor);

            return Ok(instructorDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(InstructorDTO instructorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var instructor = mapper.Map<Instructor>(instructorDTO);
                instructor = await instructorService.Insert(instructor);
                return Ok(instructor);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(InstructorDTO instructorDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (instructorDTO.ID != id)
                return BadRequest();

            var instructor = await instructorService.GetById(id);

            if (instructor == null)
                return NotFound();

            try
            {
                instructor = mapper.Map<Instructor>(instructorDTO);
                instructor = await instructorService.Update(instructor);
                return Ok(instructor);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await instructorService.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                await instructorService.Delete(id);
                return Ok();
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }


        }
    }
}
