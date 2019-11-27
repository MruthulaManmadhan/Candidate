using Candidate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate.DataAccess
{
    public class TeacherDA
    {
        public string path = @"Data Source=MMANMADHAN01\SQLEXPRESS;Initial Catalog=Candidate;Integrated Security=SSPI";
        public void UpdateMark(ExamMark examMark)
        {
            using (SqlConnection con = new SqlConnection(path))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"sp_UpdateMark", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", examMark.UserID);
                cmd.Parameters.AddWithValue("@Malayalam", examMark.Malayalam);
                cmd.Parameters.AddWithValue("@English", examMark.English);
                cmd.Parameters.AddWithValue("@Hindi", examMark.Hindi);
                cmd.Parameters.AddWithValue("@Mathematics", examMark.Mathematics);
                cmd.Parameters.AddWithValue("@Science", examMark.Science);
                cmd.Parameters.AddWithValue("@SocialScience", examMark.SocialScience);
                cmd.Parameters.AddWithValue("@Total", examMark.Total);
                cmd.Parameters.AddWithValue("@Percentage", examMark.Percentage);
                cmd.Parameters.AddWithValue("@Grade", examMark.Grade);

                int RowCount = cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
