﻿using System;
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
        [Required(ErrorMessage = "Tidak boleh kosong"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public string LoanDate { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public string ReturnDate { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public Status Status { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public RequestStatus RequestStatus { get; set; }
        [ForeignKey("Employee"), Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(7, ErrorMessage = "Maksimal 7 karakter")]
        public string RequesterId { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual ICollection<ItemRequest> ItemRequest { get; set; }
        public virtual Employee Employee { get; set; }
    }

    public enum Status 
    {
        [Display(Name = "Inactive")]
        Inactive = 0,
        [Display(Name = "Active")]
        Active = 1
    }

    public enum RequestStatus
    {
        [Display(Name = "Waiting Approval Level 1")]
        Waiting_Approval_Level_1 = 0,
        [Display(Name = "Waiting Approval Level 2")]
        Waiting_Approval_Level_2 = 1,
        [Display(Name = "Approved")]
        Approved = 2,
        [Display(Name = "Processed")]
        Processed = 3
    }
}
