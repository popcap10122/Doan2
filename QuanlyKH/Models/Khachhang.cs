using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanlyKH.Models
{
    [Table("KhachHang")]
    public class Khachhang
    {
        [Key]
        [Required,DisplayName("Mã khách hàng")]
        [StringLength(50)]
        public string MsKH { get; set; }
        [Required,DisplayName("Tên khách hàng")]
        [StringLength(255)]
        public string TenKH { get; set; }
        [DisplayName("Nợ đầu")]
        public double Nodau { get; set; }

        
    }
}
