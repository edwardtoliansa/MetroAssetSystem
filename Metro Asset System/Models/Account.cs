﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Metro_Asset_System.Models
{
    [Table("TB_M_Account")]
    public class Account
    {
        [Key, Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(11, ErrorMessage = "Maksimal 11 karakter"), MinLength(10, ErrorMessage = "Minimal 10 karakter"), RegularExpression(@"^\d+$", ErrorMessage = "Harus berupa angka")]
        public string NIK { get; set; }
        [Required(ErrorMessage ="Tidak boleh kosong"), MaxLength(10, ErrorMessage = "Maksimal 10 karakter")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public StatusAccount Status { get; set; }
        public virtual Employee Employee { get; set; }
    }

    public enum StatusAccount
    {
        [Display(Name = "Restricted")]
        Restricted = 0,
        [Display(Name = "Active")]
        Active =1
    }
}
