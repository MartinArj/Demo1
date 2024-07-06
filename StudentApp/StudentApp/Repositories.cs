using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace StudentApp
{
  public  class Repositories
    {
      public static string path = @"Server=.\SQLEXPRESS;Database=temp_school;Integrated Security=True";
    public static int GetStudId(StudDetails student)
    {
        int id = -1;
        int Class = student.Class;
        string Section = student.Section;
        string Year = student.Year;
        string Name = student.Name;
        string DateOfBirth = student.DateOfBirth;
        string Blood_Group = student.Blood_Group;
        using (SqlConnection con = new SqlConnection(path))
        {
            con.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT studId FROM StudDetails WHERE Class = @Class AND Section = @Section AND Year = @Year AND Name = @Name AND DateOfBirth = @DateOfBirth AND Blood_Group = @Blood_Group";

                cmd.Parameters.AddWithValue("@Class", Class);
                cmd.Parameters.AddWithValue("@Section", Section);
                cmd.Parameters.AddWithValue("@Year", Year);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                cmd.Parameters.AddWithValue("@Blood_Group", Blood_Group);

                // ExecuteScalar returns the first column of the first row in the result set
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    id = Convert.ToInt32(result);
                    // Use the id as needed
                }
                else
                {
                    // Handle the case where no matching record is found
                }
            }
            
        }
        return id;
    }

    public static void InsertStudDetails(StudDetails student)
        {
            int Class = student.Class;
            string Section = student.Section;
            string Year = student.Year;
            string Name = student.Name;
            string DateOfBirth = student.DateOfBirth;
            string Blood_Group = student.Blood_Group;

            try
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;

                    cmd.CommandText = "insert into StudDetails(Class,Section,Year,Name,DateOfBirth,Blood_Group) values('" + Class + "','" + Section + "','" + Year + "','" + Name + "','" + DateOfBirth + "','" + Blood_Group + "')";

                   
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
               //
            }
        }

        public static void Insert_Address(Address add)
        {
            int StudId = add.StudId;
          
            string DoorNo = add.DoorNo;
            string Street = add.Street;
            string Village = add.Village;
            string City = add.City;
            string State = add.State;
            string Pin_Code = add.Pin_Code;
            string Mobile_Number = add.Mobile_Number;
            string Mail_Id = add.Mail_Id;
            try
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into _Address values("+StudId+",'" + DoorNo + "','" + Street + "','" + Village + "','" + City + "','" + State + "','" + Pin_Code + "','" + Mobile_Number + "','" + Mail_Id + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void InsertClassDetails(ClassDetails cls)
        {
            int Class = cls.Class;
            string Section = cls.Section;
            int Class_Teacher = cls.Class_Teacher;
            try
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into ClassDetails values('" + Class + "','" + Section + "','" + Class_Teacher + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void InsertStaffDetails(staffDetails staff)
        {
            string Name = staff.Name;
            string Qualification = staff.Qualification;
            string JoiningYear = staff.JoiningYear;
            string PreviousExperience = staff.PreviousExperience;
            try
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;

                    cmd.CommandText = "insert into StaffDetails values('" + Name + "','" +Name + "','" + Qualification + "','" + JoiningYear + "','" + PreviousExperience + "')";

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void InsertClass(int Class)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into Class values('" + Class + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void InsertSubjectDetails(SubjectDetails subdtl)
        {
            int Class = subdtl.Class;
            string SubjectName = subdtl.SubjectName;
            try
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into SubjectDetails values('" + Class + "','" + SubjectName + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void InsertSubAndStaffRealation(SubAndStaffRelation substaff)
        {
            int SubjectId = substaff.SubjectId;
            int Class = substaff.Class;
            string Section = substaff.Section;
            string Year = substaff.Year;
            int StaffId = substaff.StaffId;
            try
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into SubAndStaffRelation values('" + SubjectId + "','" + Class + "','" + Section + "','" + Year + "','" + StaffId + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void InsertExamType(ExamType et)
        {
            string ExamType = et.ExamType1;
            try
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into ExamType values('" + ExamType + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void InsertStudentMarks(StudentsMarks mar)
        {
            int StudId = mar.StudId;
            int Class = mar.Class;
            string Section = mar.Section;
            string Year = mar.Year;
            int SubjectId = mar.SubjectId;
            int TypeOfExam = mar.TypeOfExam;
            string Name = mar.Name;
            float Mark = mar.Mark;
            try
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into StudentMarks values('" + StudId + "','" + Class + "','" + Section + "','" + Year + "','" + SubjectId + "','" + TypeOfExam + "','" + Name + "','" + Mark + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
