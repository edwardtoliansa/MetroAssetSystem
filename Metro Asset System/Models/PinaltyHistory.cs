using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Metro_Asset_System.Models
{
    [Table("TB_M_PinaltyHistory")]
    public class PinaltyHistory
    {
        [Key, Required]
        public int Id { get; set; }
        [Required, MaxLength(9, ErrorMessage = "Maksimal 9 karakter")]
        public string InvoiceId { get; set; }
    }
}
