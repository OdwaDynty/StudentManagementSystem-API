using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAll(string? name, decimal? minMark, int page, int pageSize)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s =>
                    s.FirstName.Contains(name) ||
                    s.LastName.Contains(name));
            }

            if (minMark.HasValue)
            {
                query = query.Where(s => s.Mark >= minMark.Value);
            }

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCount(string? name, decimal? minMark)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s =>
                    s.FirstName.Contains(name) ||
                    s.LastName.Contains(name));
            }

            if (minMark.HasValue)
            {
                query = query.Where(s => s.Mark >= minMark.Value);
            }

            return await query.CountAsync();
        }

        public async Task<Student?> GetById(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> Add(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> Update(int id, Student updatedStudent)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null) return null;

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.Email = updatedStudent.Email;
            student.Age = updatedStudent.Age;
            student.Mark = updatedStudent.Mark;

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Student?> GetTopStudent()
        {
            return await _context.Students
                .OrderByDescending(s => s.Mark)
                .FirstOrDefaultAsync();
        }

        public async Task<decimal?> GetAverageMark()
        {
            if (!await _context.Students.AnyAsync())
                return null;

            return await _context.Students.AverageAsync(s => s.Mark);
        }

        public async Task<PassFailReportDto?> GetPassFailReport()
        {
            var students = await _context.Students.ToListAsync();

            if (!students.Any())
                return null;

            var total = students.Count;
            var passed = students.Count(s => s.Mark >= 50);
            var failed = students.Count(s => s.Mark < 50);

            return new PassFailReportDto
            {
                TotalStudents = total,
                PassedStudents = passed,
                FailedStudents = failed,
                PassPercentage = Math.Round((double)passed / total * 100, 2),
                FailPercentage = Math.Round((double)failed / total * 100, 2)
            };
        }
      }
    }
