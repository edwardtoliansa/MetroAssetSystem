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
        [Key, Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(10, ErrorMessage = "Maksimal 10 karakter")]
        public string Id { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime LoanDate { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
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
        public virtual Invoice Invoice { get; set; }
        public virtual ItemRequest ItemRequest { get; set; }
        public virtual Employee Employee { get; set; }
    }

    public enum Status 
    {
        Inactive,
        Active
    }

    public enum RequestStatus
    { 
        Waiting_Approval_Level_1,
        Waiting_Approval_Level_2,
        Approved,
        Processed
    }
}
