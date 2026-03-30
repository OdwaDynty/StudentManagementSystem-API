using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAll(string? name, decimal? minMark, int page, int pageSize);
        Task<int> GetTotalCount(string? name, decimal? minMark);
        Task<Student?> GetById(int id);
        Task<Student> Add(Student student);
        Task<Student?> Update(int id, Student student);
        Task<bool> Delete(int id);
        Task<Student?> GetTopStudent();
        Task<decimal?> GetAverageMark();
        Task<PassFailReportDto?> GetPassFailReport();
    }
}