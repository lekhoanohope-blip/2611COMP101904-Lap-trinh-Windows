using System;
using System.Linq;
using Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Models;
using Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Repositories;
using Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Views;

namespace Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Presenters
{
    public class StudentPresenter
    {
        private readonly IStudentView _view;
        private readonly IStudentRepository _repository;

        public StudentPresenter(IStudentView view)
        {
            _view = view;
            _repository = new StudentRepository();
        }

        public void LoadStudents() => _view.SetStudentList(_repository.GetAll());

        public void AddStudent()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.MaSV) ||
                    string.IsNullOrWhiteSpace(_view.HoTen) ||
                    string.IsNullOrWhiteSpace(_view.DiemTBText))
                {
                    _view.ShowMessage("Vui lòng nhập đầy đủ Mã SV, Họ tên và Điểm TB.");
                    return;
                }

                if (!double.TryParse(_view.DiemTBText, out double diem))
                {
                    _view.ShowMessage("Điểm TB phải là số hợp lệ.");
                    return;
                }

                if (_repository.Exists(_view.MaSV))
                {
                    _view.ShowMessage("Mã sinh viên đã tồn tại. Vui lòng nhập mã khác.");
                    return;
                }

                _repository.Add(new Student
                {
                    MaSV = _view.MaSV,
                    HoTen = _view.HoTen,
                    DiemTB = diem
                });

                _view.ShowMessage("Thêm sinh viên thành công.");
                _view.ClearInput();
                LoadStudents();
            }
            catch (Exception ex) { _view.ShowMessage("Lỗi: " + ex.Message); }
        }

        public void DeleteStudent()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.MaSV))
                {
                    _view.ShowMessage("Vui lòng nhập Mã SV cần xóa.");
                    return;
                }

                if (!_repository.Exists(_view.MaSV))
                {
                    _view.ShowMessage("Không tìm thấy sinh viên có mã: " + _view.MaSV);
                    return;
                }

                _repository.Delete(_view.MaSV);
                _view.ShowMessage("Xóa sinh viên thành công.");
                _view.ClearInput();
                LoadStudents();
            }
            catch (Exception ex) { _view.ShowMessage("Lỗi: " + ex.Message); }
        }

        public void SearchStudent()
        {
            try
            {
                string keyword = string.IsNullOrWhiteSpace(_view.HoTen)
                                 ? _view.MaSV
                                 : _view.HoTen;

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    _view.ShowMessage("Vui lòng nhập Tên hoặc Mã SV để tìm kiếm.");
                    return;
                }

                var results = _repository.Search(keyword);
                if (results == null || !results.Any())
                    _view.ShowMessage("Không tìm thấy sinh viên phù hợp.");
                else
                    _view.SetStudentList(results);
            }
            catch (Exception ex) { _view.ShowMessage("Lỗi: " + ex.Message); }
        }
    }
}