using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Course_Management.DTOs;
using Student_Course_Management.Models;
using Student_Course_Management.Repositories;

namespace Student_Course_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _repository.GetStudentsAsync();
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _repository.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(_mapper.Map<StudentDto>(student));
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> AddStudent(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _repository.AddStudentAsync(student);
            await _repository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, studentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentDto studentDto)
        {
            var student = await _repository.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            _mapper.Map(studentDto, student);
            await _repository.UpdateStudentAsync(student);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _repository.DeleteStudentAsync(id);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}
