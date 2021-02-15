using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Metro_Asset_System.Models
{
    [Table("TB_M_Pinalty")]
    public class Pinalty
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public int LowPinalty { get; set; }
        [Required]
        public int MiddlePinalty { get; set; }
        [Required]
        public int HighPinalty { get; set; }
        [Required]
        public int LostPinalty { get; set; }
        [Required, MaxLength(10, ErrorMessage = "Maksimal 10 karakter")]
        public string AssetId { get; set; }
        public virtual Asset Asset { get; set; }

    }
}
