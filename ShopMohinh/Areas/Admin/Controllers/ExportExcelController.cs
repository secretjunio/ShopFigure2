using Microsoft.AspNetCore.Mvc;
using ShopMohinh.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml.Style;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;

namespace ShopMohinh.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Sale,Admin")]
    public class ExportExcelController : Controller
    {
        // nhớ nha, làm cái Export Excel thì nhớ cài nuget là EPPlus cho nó nha
        private readonly EFContext ctx;
        public ExportExcelController(EFContext db)
        {
            ctx = db;
        }

        public IActionResult Export()
        {
            var data = ctx.OrderDetails.ToList();
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var sheet = package.Workbook.Worksheets.Add("OrderDetails");
                // đổ dữ liệu vào sheet
                //sheet.Cells.LoadFromCollection(data, true);
                // trong excel cột bắt đầu từ 1 nha
                sheet.Cells["A1:E1"].Merge = true;
                sheet.Cells[1,1].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                sheet.Cells[1, 1].Style.Font.Size = 16;
                sheet.Cells[1, 1].Style.Font.Color.SetColor(Color.Red);
                sheet.Cells[1, 1].Style.Font.Bold = true;
                sheet.Cells[1, 1].Value = "Chi tiết đơn hàng";
                sheet.Cells[2,1].Value = "Mã đơn hàng";// tên cột của dòng 1 cột 1 trong excel
                sheet.Cells[2,2].Value = "Mã sản phẩm";
                sheet.Cells[2,3].Value = "Số lượng sản phẩm";
                sheet.Cells[2,4].Value = "Mô tả";
                sheet.Cells[2,5].Value = "Tổng tiền";
                int rowIndex = 3; // bắt đầu từ dòng số 2 trong excel
                foreach(var l in data)
                {
                    sheet.Cells[rowIndex, 1].Value = l.IDOrder; // dòng 2 cột 1
                    sheet.Cells[rowIndex, 2].Value = l.IDProduct; // dòng 2 cột 2
                    sheet.Cells[rowIndex, 3].Value = l.Number; // dòng 2 cột 3
                    sheet.Cells[rowIndex, 4].Value = l.Describe; // dòng 2 cột 4
                    sheet.Cells[rowIndex, 5].Value = l.TotalPrice; // dòng 2 cột 5
                    rowIndex++; // để nó tăng số dòng lên cho nó lặp
                }
                // save 
                package.Save();
            }
            stream.Position = 0;
            var fileName = $"ChiTietDonHang_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",fileName);
            //lên mạng search excel content type rồi copy cái application/vnd.openxmlformats-officedocument.spreadsheetml.sheet về gắn vào như trên nha
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
