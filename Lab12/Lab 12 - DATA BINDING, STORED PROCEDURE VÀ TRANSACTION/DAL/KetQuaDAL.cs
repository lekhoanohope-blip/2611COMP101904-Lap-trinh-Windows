using System.Data;
using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL
{
    public class KetQuaDAL
    {
        public DataTable GetLop()
        {
            using var conn = new SqlConnection(Database.ConnectionString);
            using var cmd = new SqlCommand("sp_Lop_GetAll", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            using var adapter = new SqlDataAdapter(cmd);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable GetMonHoc()
        {
            using var conn = new SqlConnection(Database.ConnectionString);
            using var cmd = new SqlCommand("sp_MonHoc_GetAll", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            using var adapter = new SqlDataAdapter(cmd);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable GetKetQuaByLopMon(string maLop, string maMon)
        {
            using var conn = new SqlConnection(Database.ConnectionString);
            using var cmd = new SqlCommand("sp_KetQua_GetByLopMon", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@MaLop", SqlDbType.NVarChar, 20).Value = maLop;
            cmd.Parameters.Add("@MaMon", SqlDbType.NVarChar, 20).Value = maMon;

            using var adapter = new SqlDataAdapter(cmd);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public int SaveAll(string maMon, DataTable table)
        {
            using var conn = new SqlConnection(Database.ConnectionString);
            conn.Open();

            using var trans = conn.BeginTransaction();

            try
            {
                int count = 0;

                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState == DataRowState.Deleted)
                        continue;

                    string maSV = row["MaSV"].ToString() ?? "";
                    double diem = Convert.ToDouble(row["Diem"]);
                    string ghiChu = row["GhiChu"] == DBNull.Value
                        ? ""
                        : row["GhiChu"].ToString() ?? "";

                    using var cmd = new SqlCommand("sp_KetQua_Save", conn, trans)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar, 20).Value = maSV;
                    cmd.Parameters.Add("@MaMon", SqlDbType.NVarChar, 20).Value = maMon;
                    cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = diem;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 255).Value = ghiChu;

                    cmd.ExecuteNonQuery();
                    count++;
                }

                trans.Commit();
                return count;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
    }
}