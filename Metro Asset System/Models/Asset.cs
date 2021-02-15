using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Metro_Asset_System.Models
{
    [Table("TB_M_Asset")]
    public class Asset
    {
        [Key, Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(10, ErrorMessage = "Maksimal 10 karakter"), RegularExpression(@"^\d+$", ErrorMessage = "Harus berupa angka")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(50, ErrorMessage = "Maksimal 50 karakter"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Harus berupa huruf")]
        public string Name { get; set; }
        [Required]
        public StatusAsset AssetStatus { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(4, ErrorMessage = "Maksimal 4 karakter")]
        public string CategoryId { get; set; }
        public virtual Pinalty Pinalty { get; set; }
        public virtual Category Category { get; set; }
        public virtual ItemRequest ItemRequest { get; set; }
    }

    public enum StatusAsset 
    { 
        Fine,
        Problem,
        Lost
    }
}
