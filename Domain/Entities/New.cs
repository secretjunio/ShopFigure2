using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class New
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNew { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Preview { get; set; }
        public string Link { get; set; }
    }
}
