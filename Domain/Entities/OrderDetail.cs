using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class OrderDetail
    {
        [Key]
        public int IDOrderDetail { get; set; }

        public int IDOrder { get; set; }
        public int IDProduct { get; set; }
        public int Number { get; set; } 
        public string Describe { get; set; }
       // public float TotalPrice { get; set; }// thanh tien
        public string ProductName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public double TotalPrice { get; set; }
        public double? Price { get; set; }
        public string ColorSize { get; set; }



    }
}
