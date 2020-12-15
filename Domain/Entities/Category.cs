
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ShopMohinh.Models
{
    public class Category
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int IDCategory { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
        public int Number { get; set; }
        public string Describe { get; set; }
        public int ParentIDCategory { get; set; }
    }
}