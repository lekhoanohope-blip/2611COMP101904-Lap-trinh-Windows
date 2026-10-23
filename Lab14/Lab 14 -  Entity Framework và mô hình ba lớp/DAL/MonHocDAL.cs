using Lab_14___Entity_Framework_và_mô_hình_ba_lớp.Data;
using Lab_14___Entity_Framework_và_mô_hình_ba_lớp.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_14___Entity_Framework_và_mô_hình_ba_lớp.DAL
{
    /// <summary>
    /// Lớp truy cập dữ liệu – chỉ làm việc với EF Core.
    /// Không chứa logic nghiệp vụ.
    /// </summary>
    public class MonHocDAL
    {
        public List<MonHoc> GetAll()
        {
            using var context = new Lab14Context();
            return context.MonHocs
                          .AsNoTracking()
                          .OrderBy(m => m.MaMonHoc)
                          .ToList();
        }

        public List<MonHoc> Search(string keyword)
        {
            using var context = new Lab14Context();
            var k = keyword.Trim().ToLower();
            return context.MonHocs
                          .AsNoTracking()
                          .Where(m => m.MaMonHoc.ToLower().Contains(k)
                                   || m.TenMonHoc.ToLower().Contains(k))
                          .OrderBy(m => m.MaMonHoc)
                          .ToList();
        }

        public MonHoc? GetById(string maMonHoc)
        {
            using var context = new Lab14Context();
            return context.MonHocs
                          .AsNoTracking()
                          .FirstOrDefault(m => m.MaMonHoc == maMonHoc);
        }

        public bool Exists(string maMonHoc)
        {
            using var context = new Lab14Context();
            return context.MonHocs.Any(m => m.MaMonHoc == maMonHoc);
        }

        public void Add(MonHoc mh)
        {
            using var context = new Lab14Context();
            context.MonHocs.Add(mh);
            context.SaveChanges();
        }

        public void Update(MonHoc mh)
        {
            using var context = new Lab14Context();
            var existing = context.MonHocs.FirstOrDefault(m => m.MaMonHoc == mh.MaMonHoc);
            if (existing == null)
                throw new InvalidOperationException($"Không tìm thấy môn học có mã '{mh.MaMonHoc}'.");

            existing.TenMonHoc = mh.TenMonHoc;
            existing.SoTinChi = mh.SoTinChi;
            existing.TrangThai = mh.TrangThai;

            context.SaveChanges();
        }

        public void Delete(string maMonHoc)
        {
            using var context = new Lab14Context();
            var existing = context.MonHocs.FirstOrDefault(m => m.MaMonHoc == maMonHoc);
            if (existing == null)
                throw new InvalidOperationException($"Không tìm thấy môn học có mã '{maMonHoc}'.");

            context.MonHocs.Remove(existing);
            context.SaveChanges();
        }
    }
}