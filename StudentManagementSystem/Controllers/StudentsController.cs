using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;
using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        
       public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/students/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetById(id);

            if (student == null)
                return NotFound();

            var dto = new StudentDto
            {
                Id = student.Id,
                FullName = (student.FirstName ?? "") + " " + (student.LastName ?? ""),
                Mark = student.Mark
            };

            return Ok(dto);
        }

        // GET: api/students
        [HttpGet]
        public async Task<IActionResult> GetAll(string? name, decimal? minMark, int page = 1, int pageSize = 5)
        {
            var students = await _studentService.GetAll(name, minMark, page, pageSize);
            var total = await _studentService.GetTotalCount(name, minMark);

            if (students == null)
                return Ok(new { page, pageSize, totalRecords = 0, data = new List<StudentDto>() });

            var result = students.Select(s => new StudentDto
            {
                Id = s.Id,
                FullName = (s.FirstName ?? "") + " " + (s.LastName ?? ""),
                Mark = s.Mark
            }).ToList();

            return Ok(new
            {
                page,
                pageSize,
                totalRecords = total,
                data = result
            });
        }

        // GET: api/students/average-mark
        [HttpGet("average-mark")]
        public async Task<IActionResult> GetAverageMark()
        {
            var average = await _studentService.GetAverageMark();

            if (average == null)
                return NotFound("No students found");

            return Ok(new { averageMark = average });
        }

        //GET: api/students/pass-fail-report
       [HttpGet("pass-fail-report")]
       public async Task<IActionResult> GetPassFailReport()
       {
          var report = await _studentService.GetPassFailReport();

          if (report == null)
              return NotFound("No students found");

              return Ok(report);
             }

        // GET: api/students/top-student
        [HttpGet("top-student")]
        public async Task<IActionResult> GetTopStudent()
        {
            var student = await _studentService.GetTopStudent();

            if (student == null)
                return NotFound("No students found");

            return Ok(student);
        }


        [HttpPost]
        public async Task<IActionResult> AddStudent(CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Age = dto.Age,
                Mark = dto.Mark
            };

            var created = await _studentService.Add(student);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/students/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Age = dto.Age,
                Mark = dto.Mark
            };

            var updated = await _studentService.Update(id, student);

            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/students/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentService.Delete(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }


    }
}