using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_14___Entity_Framework_và_mô_hình_ba_lớp.Models
{
    /// <summary>
    /// Entity ánh xạ bảng MONHOC.
    /// </summary>
    [Table("MONHOC")]
    public class MonHoc
    {
        [Key]
        [Column("MaMonHoc")]
        [StringLength(10)]
        public string MaMonHoc { get; set; } = string.Empty;

        [Column("TenMonHoc")]
        [Required]
        [StringLength(100)]
        public string TenMonHoc { get; set; } = string.Empty;

        [Column("SoTinChi")]
        public int SoTinChi { get; set; }

        [Column("TrangThai")]
        public bool TrangThai { get; set; } = true;
    }
}