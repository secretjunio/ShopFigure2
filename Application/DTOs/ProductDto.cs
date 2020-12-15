using Microsoft.AspNetCore.Http;
using ShopMohinh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hãy điền tên sản phẩm!")]
        [StringLength(100, ErrorMessage = "Không nhập quá 100 ký tự!")]
        public string ProductName { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required( ErrorMessage = "Hãy chọn ngày ra mắt sản phẩm!")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Hãy điền mô tả sản phẩm!")]
        public string Describe { get; set; }

        [Required(ErrorMessage = "Hãy nhập số lượng sản phẩm!")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Hãy điền đơn giá sản phẩm!")]
        [Range(50000, 10000000, ErrorMessage = "Giá sản phẩm phải trong khoảng từ 50.000 đến 10.000.000")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Hãy điền đơn giá sản phẩm!")]
        [Range(50000, 10000000, ErrorMessage = "Giá sản phẩm phải trong khoảng từ 50.000 đến 10.000.000")]
        public float? NewPrice { get; set; }

        [Required(ErrorMessage = "Hãy chọn hình ảnh đại diện của sản phẩm!")]
        public IFormFile ImagePath { get; set; }

        //[Required(ErrorMessage = "Hãy chọn hình ảnh chi tiết của sản phẩm!")]
        public string Image1 { get; set; }
        
        //[Required(ErrorMessage = "Hãy chọn hình ảnh chi tiết của sản phẩm!")]
        public string Image2 { get; set; }
        
        //[Required(ErrorMessage = "Hãy chọn hình ảnh chi tiết của sản phẩm!")]
        public string Image3 { get; set; }

        //[Required(ErrorMessage = "Hãy chọn tên thể loại!")]
        public int IDCategory { get; set; }

        //[Required(ErrorMessage = "Hãy chọn nhà cung cấp!")]
        public int IDSupplier { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng chọn mục này!")]
        public int isNew { get; set; }
        
        
      
    }
}