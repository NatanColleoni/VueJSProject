using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using projectVue.Data;
using projectVue.Models;

namespace projectVue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        public IRepository _repo { get; }
        public StudentsController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllStudentsAsync(true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpGet("{StudentId}")]
        public async Task<IActionResult> GetByStudentId(int StudentId)
        {
            try
            {
                var result = await _repo.GetStudentAsyncById(StudentId, true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpGet("ByTeacher/{TeacherId}")]
        public async Task<IActionResult> GetByTeacherId(int TeacherId)
        {
            try
            {
                var result = await _repo.GetStudentsAsyncByTeacherId(TeacherId, true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync(model))
                {
                    return Created($"/api/student/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

        [HttpPut("{StudentId}")]
        public async Task<IActionResult> Put(int StudentId, Student model)
        {
            try
            {
                var student = await _repo.GetStudentAsyncById(StudentId, false);

                if (student == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync(model))
                {
                    student = await _repo.GetStudentAsyncById(StudentId, true);

                    return Created($"/api/student/{model.Id}", student);
                }
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpDelete("{StudentId}")]
        public async Task<IActionResult> Delete(int StudentId)
        {
            try
            {
                var student = await _repo.GetStudentAsyncById(StudentId, false);
                if (student == null) return NotFound();

                _repo.Delete(student);

                if (await _repo.SaveChangesAsync(student))
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
