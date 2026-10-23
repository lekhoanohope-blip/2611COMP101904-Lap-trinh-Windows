using System.Collections.Generic;
using Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Models;

namespace Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Views
{
    public interface IStudentView
    {
        string MaSV { get; }
        string HoTen { get; }
        string DiemTBText { get; }

        void SetStudentList(IEnumerable<Student> students);
        void ShowMessage(string message);
        void ClearInput();
    }
}