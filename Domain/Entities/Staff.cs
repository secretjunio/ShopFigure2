using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMohinh.Models
{
    public class Staff
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDStaff { get; set; }
        public string StaffName { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public int IDPosition { get; set; }
        public int IDAccount { get; set; }
        
    }
}