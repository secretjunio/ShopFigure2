using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using ShopMohinh.Models;

namespace ShopMohinh.Models
{
    public class EFContext: IdentityDbContext<AppUser>
    {
        public EFContext(DbContextOptions<EFContext> options)
           : base(options)
        {
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            
           
        //    modelBuilder.Entity<OrderDetail>().HasKey(p => new
        //    {
        //        p.IDOrder,
        //        p.IDProduct
               
        //    });
           
        //}
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerInfo> CustomerInfo { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<OrderBill> OrderBills { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Setting> Settings { get; set; }


        public DbSet<CT_District> CT_Districts { get; set; }
        public DbSet<CT_Ward> CT_Wards { get; set; }
        public DbSet<CT_Province> CT_Provinces { get; set; }
        public DbSet<CT_Color> CT_Colors { get; set; }
        public DbSet<CT_Size> CT_Sizes { get; set; }
        public DbSet<CT_Material> CT_Materials { get; set; }
        public DbSet<CT_WarrantyTime> CT_WarrantyTimes { get; set; }
    }
    
}
