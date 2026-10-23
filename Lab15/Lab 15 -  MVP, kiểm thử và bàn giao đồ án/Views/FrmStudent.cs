using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Models;
using Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Presenters;

namespace Lab_15____MVP__kiểm_thử_và_bàn_giao_đồ_án.Views
{
    public partial class FrmStudent : Form, IStudentView
    {
        private readonly StudentPresenter _presenter;

        public FrmStudent()
        {
            InitializeComponent();
            _presenter = new StudentPresenter(this);
            this.Text = "Lab 15 - MVP, kiểm thử và bàn giao đồ án";
        }

        public string MaSV => txtMaSV.Text.Trim();
        public string HoTen => txtHoTen.Text.Trim();
        public string DiemTBText => txtDiemTB.Text.Trim();

        public void SetStudentList(IEnumerable<Student> students)
        {
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = students.ToList();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ClearInput()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();
            txtMaSV.Focus();
        }

        private void FrmStudent_Load(object sender, EventArgs e) => _presenter.LoadStudents();
        private void btnLoad_Click(object sender, EventArgs e) => _presenter.LoadStudents();
        private void btnAdd_Click(object sender, EventArgs e) => _presenter.AddStudent();
        private void btnDelete_Click(object sender, EventArgs e) => _presenter.DeleteStudent();
        private void btnSearch_Click(object sender, EventArgs e) => _presenter.SearchStudent();
    }
}