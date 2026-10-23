using System.Collections.Generic;
using Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Models;

namespace Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        void Add(Student student);
        void Delete(string maSV);
        bool Exists(string maSV);
        IEnumerable<Student> Search(string keyword);
    }
}