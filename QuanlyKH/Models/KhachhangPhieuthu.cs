using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanlyKH.Models
{
    public class KhachhangPhieuthu
    {
         public Khachhang khachhang { get; set; }
         public ICollection<Phieuthu> Phieuthus { get; set; }
         public string MsKH { get; set; }
         public string MsPT { get; set; }
         public DateTime NgayThu { get; set; }
         public Double SoTien { get; set; }
    }
}
