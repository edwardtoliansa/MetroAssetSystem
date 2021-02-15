using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Metro_Asset_System.Models
{
    [Table("TB_M_Employee")]
    public class Employee
    {
        [Key, Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(7, ErrorMessage = "Maksimal 7 karakter"), MinLength(5, ErrorMessage = "Minimal 5 karakter"), RegularExpression(@"^\d+$", ErrorMessage = "Harus berupa angka")]
        public string NIK { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(20, ErrorMessage = "Maksimal 20 karakter")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(50, ErrorMessage = "Maksimal 50 karakter")]
        public string LastName { get; set; }
        [Required, DataType(DataType.Date)]
        public string Birthday { get; set; }
        [Required, MaxLength(12, ErrorMessage = "Maksimal 12 karakter"), RegularExpression(@"^08[0-9]{9,10}$", ErrorMessage = "Harus berupa angka diawali 08")]
        public string Phone { get; set; }
        [Required, EmailAddress, MaxLength(100, ErrorMessage = "Maksimal 100 karakter")]
        public string Email { get; set; }
        [Required]
        public EmployeeRole Role { get; set; }

        public virtual Account Account { get; set; }
        public virtual Department Department { get; set; }
        public virtual Request Request { get; set; }
        public virtual Invoice Invoice { get; set; }
    }

    public enum EmployeeRole 
    { 
        Employee,
        Manager,
        Procurement_Manager,
        Procurement_Employee
    }
}
