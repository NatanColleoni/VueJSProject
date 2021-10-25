using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using projectVue.Models;
using projectVue.Data;

namespace projectVue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : Controller
    {
        public IRepository _repo { get; }
        public TeachersController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllTeachersAsync(true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpGet("{TeacherId}")]
        public async Task<IActionResult> GetByTeacherId(int TeacherId)
        {
            try
            {
                var result = await _repo.GetTeacherAsyncById(TeacherId, true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Teacher model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync(model))
                {
                    return Created($"/api/teacher/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

        [HttpPut("{TeacherId}")]
        public async Task<IActionResult> Put(int TeacherId, Teacher model)
        {
            try
            {
                var teacher = await _repo.GetTeacherAsyncById(TeacherId, false);
                if (teacher == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync(model))
                {
                    teacher = await _repo.GetTeacherAsyncById(TeacherId, true);

                    return Created($"api/teacher/{model.Id}", teacher);
                }

                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpDelete("{TeacherId}")]
        public async Task<IActionResult> Delete(int TeacherId)
        {
            try
            {
                var teacher = await _repo.GetTeacherAsyncById(TeacherId, false);
                if (teacher == null) return NotFound();


                _repo.Delete(teacher);
                if (await _repo.SaveChangesAsync(teacher))
                {
                    return Ok();
                }
                else
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }
    }
}
