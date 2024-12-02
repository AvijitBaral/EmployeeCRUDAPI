namespace EmployeeCRUDAPI.DAL.DTOs
{
    public class EmployeeDetailsDTO
    {
        public int EmpNo { get; set; }
        public string? FirstName { get; set; }
        public string? DeptName { get; set; }
        public int Salary { get; set; }

        public string ? Title { get; set; }

    }
}
