using Candidate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate.DataAccess
{
    public class AdminDA
    {
        public string path = @"Data Source=MMANMADHAN01\SQLEXPRESS;Initial Catalog=Candidate;Integrated Security=SSPI";

        public void AddStudent(UserInfo user)
        {
            using (SqlConnection con = new SqlConnection(path))
            {
                //name class mail password
                con.Open();
                SqlCommand cmd = new SqlCommand($"sp_AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@class", user.Class);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@password", user.Password);

                int RowCount = cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public List<UserInfo> GetStudents()
        {
            List<UserInfo> StudentList = new List<UserInfo>();
            using (SqlConnection con = new SqlConnection(path))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"sp_studentList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    UserInfo student = new UserInfo();
                    student.UserID = Convert.ToInt32(dr["UserID"]);
                    student.Name = Convert.ToString(dr["Name"]);
                    student.Class = Convert.ToInt32(dr["Class"]);
                    student.Email = Convert.ToString(dr["Email"]);
                    StudentList.Add(student);
                }
            }
            return StudentList;
        }
        public UserInfo GetStudent(int studentId)
        {
            UserInfo student = new UserInfo();
            using (SqlConnection con = new SqlConnection(path))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"sp_StudentDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", studentId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    student.UserID = Convert.ToInt32(dr["UserID"]);
                    student.Name = Convert.ToString(dr["Name"]);
                    student.Class = Convert.ToInt32(dr["Class"]);
                    student.Email = Convert.ToString(dr["Email"]);
                    student.Password = Convert.ToString(dr["Password"]);

                }
            }
            return student;
        }
        public string DeleteStudent(int studentId)
        {
            SqlConnection con = new SqlConnection(path);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_deleteStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", studentId);
            string delete = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return delete;
        }
        public void UpdateStudent(UserInfo userInfo)
        {
            using (SqlConnection con = new SqlConnection(path))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"sp_UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userInfo.UserID);
                cmd.Parameters.AddWithValue("@Name", userInfo.Name);
                cmd.Parameters.AddWithValue("@Class", userInfo.Class);
                cmd.Parameters.AddWithValue("@Email", userInfo.Email);
                int RowCount = cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
