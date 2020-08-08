using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using iLearnApi.Repository;

namespace iLearnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        public ITeacherRepository TeacherRepository { get; }

        public TeachersController(ITeacherRepository teacherRepository)
        {
            TeacherRepository = teacherRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var teachers = await TeacherRepository.GetTeachers();
                if (teachers != null && teachers.Any())
                    return Ok(teachers);
                else
                    return NotFound("Data not found");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try { 
            var teacher = await TeacherRepository.GetTeacherById(id);
                if (teacher != null && teacher.Id > 0)
                    return Ok(teacher);
                else
                    return NotFound("Data not found");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Teacher teacher)
        {
            try
            {
                var teachers = await TeacherRepository.AddTeachers(teacher);
                if (teachers != null)
                    return Ok(teachers);
                else
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}