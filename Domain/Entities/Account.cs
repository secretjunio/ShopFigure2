using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ShopMohinh.Models
{
    public class Account
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDAccount { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Permission { get; set; }
        public string Email { get; set; }
    }
}
