using System;
using System.ComponentModel.DataAnnotations;

namespace ShopMohinh.Models
{
    public class CT_WarrantyTime
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
    }

    public class CT_Material
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
    }

    public class CT_Color
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string CSS { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
    }

    public class CT_Size
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
    }

    public class CT_Province
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Order { get; set; }
    }

    public class CT_District
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ProvinceID { get; set; }        
        public int Order { get; set; }
    }

    public class CT_Ward
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string DistrictID { get; set; }
        public int Order { get; set; }
    }
}