using Candidate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate.DataAccess
{
    public class UserDA
    {
        public string path = @"Data Source=MMANMADHAN01\SQLEXPRESS;Initial Catalog=Candidate;Integrated Security=SSPI";
        public UserInfo Login(string email, string password)
        {
            //string Status;
            UserInfo student = new UserInfo();
            using (SqlConnection con = new SqlConnection(path))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"sp_LoginCheck", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    student.Role = Convert.ToString(dr["Role"]);
                    student.UserID = Convert.ToInt32(dr["UserID"]);
                }
            }
            return student;


            //con.Open();
            //    SqlCommand cmd = new SqlCommand($"sp_LoginCheck", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@email", email);
            //    cmd.Parameters.AddWithValue("@password", password);
            //    Status = Convert.ToString(cmd.ExecuteScalar());
            //    con.Close();
            //}
            //return Status;
        }

        public string ChangePassword(UserInfo userInfo)
        {
            SqlConnection con = new SqlConnection(path);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_changePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId",userInfo.UserID);
            cmd.Parameters.AddWithValue("@Password", userInfo.Password);
            cmd.Parameters.AddWithValue("@NewPassword", userInfo.NewPassword);
            string Change = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return Change;
        }
    }
}
