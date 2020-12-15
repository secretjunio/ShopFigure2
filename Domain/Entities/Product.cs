using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShopMohinh.Models
{
    public class Product
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDProduct { get; set; }
        public string ProductName { get; set; }
        public DateTime ReleaseDate { get; set; }        
        public string Describe { get; set; }             
        public int Number { get; set; }      
        public float Price { get; set; }
        public float? NewPrice { get; set; }
        public string ImagePath { get; set; }     
        public string Image1 { get; set; }      
        public string Image2 { get; set; }        
        public string Image3 { get; set; }        
        public int IDCategory { get; set; }    
        public int IDSupplier { get; set; }
        public bool isNew { get; set; }
        public int Phantrang { get; set; }
        //public string CategoryName { get; set; } // thêm 1 cột này nữa nha 
    }
}
