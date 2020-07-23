using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanlyKH.Models;

namespace QuanlyKH.Data
{
    public class QLkhContext : DbContext
    {
        public QLkhContext(DbContextOptions<QLkhContext> options) : base(  options)
        {

        }
        public DbSet<Khachhang> KhachHang { get; set; }
        public DbSet<Phieuthu> PhieuThu { get; set; }
    }
}
