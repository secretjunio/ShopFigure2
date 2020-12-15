using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
  
    public class Setting
    {
        public long ID { get; set; }
        
        public string Code { get; set; }
        
        public string Value { get; set; }
        
        public string Description { get; set; }
        
        public bool? IsHTML { get; set; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }


    }

}
