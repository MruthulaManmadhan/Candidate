using Candidate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate.DataAccess
{
    public class StudentDA
    {
        public string path = @"Data Source=MMANMADHAN01\SQLEXPRESS;Initial Catalog=Candidate;Integrated Security=SSPI";
        public ExamMark GetMark(int studentId)
        {
            ExamMark examMark = new ExamMark();
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
                    examMark.UserID = Convert.ToInt32(dr["UserID"]);
                    examMark.Name = Convert.ToString(dr["Name"]);
                    examMark.Class = Convert.ToInt32(dr["Class"]);
                    examMark.Malayalam = Convert.ToInt32(dr["Malayalam"]);
                    examMark.English = Convert.ToInt32(dr["English"]);
                    examMark.Hindi = Convert.ToInt32(dr["Hindi"]);
                    examMark.Mathematics = Convert.ToInt32(dr["Mathematics"]);
                    examMark.Science = Convert.ToInt32(dr["Science"]);
                    examMark.SocialScience = Convert.ToInt32(dr["SocialScience"]);
                    examMark.Total = Convert.ToInt32(dr["Total"]);
                    examMark.Percentage = Convert.ToInt32(dr["Percentage"]);
                    examMark.Grade = Convert.ToString(dr["Grade"]);
                }
            }
            return examMark;
        }
    }
}
