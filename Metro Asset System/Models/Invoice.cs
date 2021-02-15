using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Metro_Asset_System.Models
{
    [Table("TB_T_Invoice")]
    public class Invoice
    {
        [Key, Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(9, ErrorMessage = "Maksimal 9 karakter")]
        public string Id { get; set; }
        [Required]
        public StatusInvoice Status {get; set; } 
        [Required]
        public int RequestId {get; set; }
        [Required, MaxLength(7, ErrorMessage = "Maksimal 7 karakter")]
        public string ProcurementEmployeeId { get; set; }
        public virtual PinaltyHistory PinaltyHistory { get; set; }
        public virtual Request Request { get; set; }

    }

    public enum StatusInvoice 
    {
        On_Going,
        Finished_Fine,
        Finished_With_Problem
    }
}
