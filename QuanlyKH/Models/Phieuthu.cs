using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanlyKH.Models
{
    [Table("PhieuThu")]
    public class Phieuthu
    {
        [Key]
        [DisplayName("Mã phiếu thu")]
        [StringLength(50)]
        public string MsPT { get; set; }
        [DisplayName("Ngày thu")]
        [DataType(DataType.Date)]
        public DateTime NgayThu { get; set; }
        [Required, DisplayName("Số tiền")]
        public Double SoTien { get; set; }
        [Required]
        public  virtual Khachhang Khachhang { get; set; }
  
    }
}
