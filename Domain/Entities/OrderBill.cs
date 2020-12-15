using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class OrderBill
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDOrder { get; set; }
        public int IDCustomer { get; set; }
        public string Address { get; set; }
        public double? Total { get; set; }
        public string Phone { get; set; }

        public DateTime? OrderDate { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int? ProviceID { get; set; }
        public int? DistrictID { get; set; }
        public int? WardID { get; set; }
        public double? ShipFee { get; set; }
        public bool? IsDeleted { get; set; }
        public string Trangthai { get; set; }
    }
}
