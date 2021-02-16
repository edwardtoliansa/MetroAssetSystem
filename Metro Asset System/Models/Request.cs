using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Metro_Asset_System.Models
{
    [Table("TB_M_Request")]
    public class Request
    {
        [Key, Required]
        public int Id { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime LoanDate { get; set; }
        [Required, DataType(DataType.Date)]
        public string ReturnDate { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public RequestStatus RequestStatus { get; set; }
        [Required, MaxLength(7, ErrorMessage = "Maksimal 7 karakter")]
        public string RequesterId { get; set; }
        [Required, MaxLength(15, ErrorMessage = "Maksimal 15 karakter")]
        public string RequesterManagerId { get; set; }
        [Required, MaxLength(15, ErrorMessage = "Maksimal 15 karakter")]
        public string ProcurementManagerId { get; set; }
        public virtual ICollection<ItemRequest> ItemRequests { get; set; }
    }

    public enum Status 
    {
        [Display(Name ="Inactive")]
        Inactive =0,
        [Display(Name = "Active")]
        Active =1
    }

    public enum RequestStatus
    {
        [Display(Name = "Waiting for approval Level 1")]
        Approve_Level_1 =0,
        [Display(Name = "Waiting for approval Level 2")]
        Approve_Level_2 = 1,
        [Display(Name = "Approved")]
        Approved =2,
        [Display(Name = "Processed")]
        Processed =3
    }
}
