using System.ComponentModel.DataAnnotations;

namespace EmployeeCRUDAPI.DAL.DTOs
{
    public class EmployeeDTO
    {
        public DateOnly BirthDate { get; set; }

        [StringLength(14)]
        public string FirstName { get; set; } = null!;

        [StringLength(16)]
        public string LastName { get; set; } = null!;

        [MaxLength(1)]
        public string  Gender { get; set; }

        public DateOnly HireDate { get; set; }

    }
}
