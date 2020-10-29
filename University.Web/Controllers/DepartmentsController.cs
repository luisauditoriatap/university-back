using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.Web.Controllers
{
    [RoutePrefix("api/Departaments")]
    public class DepartmentsController : ApiController
    {
        private IMapper mapper;
        private readonly DepartamentService departamentService = new DepartamentService(new DepartamentRepository(UniversityContext.Create()));

        /// <summary>
        /// Controlador de departamento
        /// </summary>
        public DepartmentsController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var departaments = await departamentService.GetAll();
            var departamentsDTO = departaments.Select(x => mapper.Map<DepartamentDTO>(x));

            return Ok(departamentsDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var departament = await departamentService.GetById(id);

            if (departament == null)
                return NotFound();

            var departamentDTO = mapper.Map<DepartamentDTO>(departament);
            return Ok(departamentDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(DepartamentDTO departamentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var departament = mapper.Map<Departament>(departamentDTO);
                departament = await departamentService.Insert(departament);
                return Ok(departament);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(DepartamentDTO departamentDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (departamentDTO.DepartmentID != id)
                return BadRequest();

            var flag = await departamentService.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                var departarment = mapper.Map<Departament>(departamentDTO);
                departarment = await departamentService.Update(departarment);
                return Ok(departarment);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await departamentService.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                await departamentService.Delete(id);                
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

    }
}
