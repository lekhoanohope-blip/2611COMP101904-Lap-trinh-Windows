using Lab_14___Entity_Framework_và_mô_hình_ba_lớp.DAL;
using Lab_14___Entity_Framework_và_mô_hình_ba_lớp.Models;

namespace Lab_14___Entity_Framework_và_mô_hình_ba_lớp.BLL
{
    /// <summary>
    /// Lớp nghiệp vụ – nơi đặt validation trước khi gọi DAL.
    /// </summary>
    public class MonHocBLL
    {
        private readonly MonHocDAL _dal = new MonHocDAL();

        public List<MonHoc> GetAll() => _dal.GetAll();

        public List<MonHoc> Search(string keyword)
            => string.IsNullOrWhiteSpace(keyword) ? _dal.GetAll() : _dal.Search(keyword);

        // ---------------- Validation dùng chung ----------------
        private static void Validate(MonHoc mh)
        {
            if (string.IsNullOrWhiteSpace(mh.MaMonHoc))
                throw new ArgumentException("Mã môn học không được để trống.");

            if (mh.MaMonHoc.Trim().Length > 10)
                throw new ArgumentException("Mã môn học tối đa 10 ký tự.");

            if (string.IsNullOrWhiteSpace(mh.TenMonHoc))
                throw new ArgumentException("Tên môn học không được để trống.");

            if (mh.TenMonHoc.Trim().Length > 100)
                throw new ArgumentException("Tên môn học tối đa 100 ký tự.");

            if (mh.SoTinChi < 1 || mh.SoTinChi > 6)
                throw new ArgumentException("Số tín chỉ phải nằm trong khoảng từ 1 đến 6.");
        }

        // ---------------- CRUD ----------------
        public void Add(MonHoc mh)
        {
            mh.MaMonHoc = mh.MaMonHoc.Trim();
            mh.TenMonHoc = mh.TenMonHoc.Trim();

            Validate(mh);

            if (_dal.Exists(mh.MaMonHoc))
                throw new InvalidOperationException($"Mã môn học '{mh.MaMonHoc}' đã tồn tại.");

            _dal.Add(mh);
        }

        public void Update(MonHoc mh)
        {
            mh.MaMonHoc = mh.MaMonHoc.Trim();
            mh.TenMonHoc = mh.TenMonHoc.Trim();

            Validate(mh);

            if (!_dal.Exists(mh.MaMonHoc))
                throw new InvalidOperationException($"Không tìm thấy môn học có mã '{mh.MaMonHoc}'.");

            _dal.Update(mh);
        }

        public void Delete(string maMonHoc)
        {
            if (string.IsNullOrWhiteSpace(maMonHoc))
                throw new ArgumentException("Vui lòng chọn môn học cần xóa.");

            if (!_dal.Exists(maMonHoc))
                throw new InvalidOperationException($"Không tìm thấy môn học có mã '{maMonHoc}'.");

            _dal.Delete(maMonHoc);
        }
    }
}
