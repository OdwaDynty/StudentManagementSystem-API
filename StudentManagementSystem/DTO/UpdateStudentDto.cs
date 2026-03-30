using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTOs
{
    public class UpdateStudentDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Range(18, 100)]
        public int Age { get; set; }

        [Range(0, 100)]
        public decimal Mark { get; set; }
    }
}