using System.Collections.Generic;
using System.Linq;
using Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Models;

namespace Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new()
        {
            new Student { MaSV = "SV001", HoTen = "Nguyễn Văn An",  DiemTB = 8.5 },
            new Student { MaSV = "SV002", HoTen = "Trần Thị Bình",  DiemTB = 7.2 },
            new Student { MaSV = "SV003", HoTen = "Lê Hoàng Cường", DiemTB = 9.1 },
            new Student { MaSV = "SV004", HoTen = "Phạm Thị Dung",  DiemTB = 6.8 },
            new Student { MaSV = "SV005", HoTen = "Võ Minh Đức",    DiemTB = 8.0 }
        };

        public IEnumerable<Student> GetAll() => _students;

        public void Add(Student student) => _students.Add(student);

        public void Delete(string maSV)
        {
            var sv = _students.FirstOrDefault(s => s.MaSV == maSV);
            if (sv != null) _students.Remove(sv);
        }

        public bool Exists(string maSV) => _students.Any(s => s.MaSV == maSV);

        public IEnumerable<Student> Search(string keyword)
        {
            keyword = keyword.ToLower();
            return _students.Where(s =>
                s.MaSV.ToLower().Contains(keyword) ||
                s.HoTen.ToLower().Contains(keyword));
        }
    }
}