namespace StudentManagementSystem.DTOs
{
    public class PassFailReportDto
    {
        public int TotalStudents { get; set; }
        public int PassedStudents { get; set; }
        public int FailedStudents { get; set; }
        public double PassPercentage { get; set; }
        public double FailPercentage { get; set; }
    }
}