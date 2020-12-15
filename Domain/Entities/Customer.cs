using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class Customer
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDCustomer { get; set; }
        public string CustomerName { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        

        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public int IDAccount { get; set; }


        public string FullName { get; set; }
        public string UserName { get; set; }
        public int? ProviceID { get; set; }
        public int? DistrictID { get; set; }
        public int? WardID { get; set; }
        public string Avatar { get; set; }
        public string Note { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
    }
}
