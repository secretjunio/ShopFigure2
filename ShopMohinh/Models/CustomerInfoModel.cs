using ShopMohinh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class CustomerInfoModel
    {
        public long CustomerInfoID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập đầy đủ họ tên!")]
        public string FullName { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn tỉnh/thành phố!")]
        public int? ProviceID { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn quận/huyện!")]
        public int? DistrictID { get; set; }

        [Required(ErrorMessage = "Vui lòng huyện/xã!")]
        public int? WardID { get; set; }

        public string Avarta { get; set; }

        public string Note { get; set; }

        public double Total { get; set; }

        public double? ShipFee { get; set; }

        public string Email { get; set; }
    }
}
