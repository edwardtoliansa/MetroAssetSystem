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
        [Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(20, ErrorMessage = "Maksimal 20 karakter"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Harus berupa huruf")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(50, ErrorMessage = "Maksimal 50 karakter"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Harus berupa huruf")]
        public string LastName { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Required, Phone, MaxLength(12, ErrorMessage = "Maksimal 12 karakter")]
        public string Phone { get; set; }
        [Required, EmailAddress, MaxLength(100, ErrorMessage = "Maksimal 100 karakter")]
        public string Email { get; set; }
        [Required]
        public EmployeeRole Role { get; set; }
    }

    public enum EmployeeRole 
    { 
        Employee,
        Manager,
        Procurement_Manager,
        Procurement_Employee
    }
}
