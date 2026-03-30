namespace StudentManagementSystem.Models
    {
    using System.ComponentModel.DataAnnotations;
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(16, 100)]
        public int Age { get; set; }

        [Range(0, 100)]
        public decimal Mark { get; set; }
    }
}
