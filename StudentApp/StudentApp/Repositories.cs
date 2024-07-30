using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;

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
         public static List<ClassDetails> GetAllClassDetails()
       {
        List<ClassDetails> classDetailsList = new List<ClassDetails>();
        try
        {
            using (SqlConnection con = new SqlConnection(path))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT Class, Section, IsActive FROM ClassDetails";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClassDetails classDetails = new ClassDetails
                            {
                                Class = reader.GetInt32(0),
                                Section = reader.GetString(1),
                                IsActive = reader.GetBoolean(2)
                            };
                            classDetailsList.Add(classDetails);
                        }
                    }
                }
            }
        }
        catch 
        {
            MessageBox.Show("wrong...");
        }

        return classDetailsList;
    }


    public static void InsertStudDetails(StudDetails student)
        {
            int Class = student.Class;
            string Section = student.Section;
            string Year = DateTime.Now.Year.ToString();
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
      public static Dictionary<int, List<char>> GetClassSections()
        {
            Dictionary<int, List<char>> classSectionsDict = new Dictionary<int, List<char>>();

           

            using (SqlConnection connection = new SqlConnection(path))
            {
                connection.Open();
                string query = "SELECT Class, Section FROM ClassDetails WHERE IsActive = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int classNum = reader.GetInt32(0);
                            string section = reader.GetString(1);

                            if (!classSectionsDict.ContainsKey(classNum))
                            {
                                classSectionsDict[classNum] = new List<char>();
                            }

                            classSectionsDict[classNum].AddRange(section.ToCharArray());
                        }
                    }
                }
            }

            return classSectionsDict;
        }
    
        public static void InsertClassDetails(ClassDetails cls)
        {
            int Class = cls.Class;
            string Section = cls.Section;
       
            try
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into ClassDetails(Class,Section) values('" + Class + "','" + Section + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("sucsess");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" ***Already have this section or invalied data...***");
            }
        }
        public static int GetStaffIdByName(string name)
        {
            int staffId = -1;

            using (SqlConnection connection = new SqlConnection(path))
            {
                string query = "SELECT StaffId FROM StaffDetails WHERE Name = @Name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        staffId = Convert.ToInt32(result);
                    }
                }
            }

            return staffId;
        }
        public static Dictionary<int, List<string>> GetClassDetailsForStaffdic(int staffId)
        {
            Dictionary<int, List<string>> classDetailsDict = new Dictionary<int, List<string>>();

            string query = "SELECT Class, Section FROM SubAndStaffRelation WHERE StaffId = @StaffId";

            using (SqlConnection connection = new SqlConnection(path))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffId", staffId);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int classValue = reader.GetInt32(reader.GetOrdinal("Class"));
                            string section = reader.GetString(reader.GetOrdinal("Section"));

                            if (!classDetailsDict.ContainsKey(classValue))
                            {
                                classDetailsDict[classValue] = new List<string>();
                            }

                            classDetailsDict[classValue].Add(section);
                        }
                    }
                }
            }

            return classDetailsDict;
        }
        public static List<ClassDetails> GetClassDetailsForStaff(int staffId)
        {
            List<ClassDetails> classDetailsList = new List<ClassDetails>();

            string query = "SELECT Class, Section FROM SubAndStaffRelation WHERE StaffId = @StaffId";

            using (SqlConnection connection = new SqlConnection(path))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffId", staffId);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int classValue = reader.GetInt32(reader.GetOrdinal("Class"));
                            string section = reader.GetString(reader.GetOrdinal("Section"));

                            // Assuming IsActive is true if the record exists
                            ClassDetails classDetails = new ClassDetails(classValue, section, true);
                            classDetailsList.Add(classDetails);
                        }
                    }
                }
            }

            return classDetailsList;
        }
        public static int GetStaffId(staffDetails details)
        {
            int id = -1;
            using (SqlConnection con = new SqlConnection(path))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT staffid FROM StaffDetails WHERE Name = @Name AND Dob = @Dob AND Qualification = @Qualification AND JoiningYear = @JoiningYear AND PreviousExperience = @PreviousExperience";

                    cmd.Parameters.AddWithValue("@Name", details.Name);
                    cmd.Parameters.AddWithValue("@Dob", details.Dob);
                    cmd.Parameters.AddWithValue("@Qualification", details.Qualification);
                    cmd.Parameters.AddWithValue("@JoiningYear", details.JoiningYear);
                    cmd.Parameters.AddWithValue("@PreviousExperience",details.PreviousExperience);
                  

                    // ExecuteScalar returns the first column of the first row in the result set
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        id = Convert.ToInt32(result);
                        // Use the id as needed
                    }
                  
                }

            }
            return id;
        }
        public static void InsertStaffAdress(staffDetails staff)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    foreach (var ad in staff.AddressList)
                    {
                        int id = staff.Id;
                        string door = ad.DoorNo;
                        string street = ad.Street;
                        string village = ad.Village;
                        string city = ad.City;
                        string state = ad.State;
                        string pincode = ad.Pin_Code;
                        string mailid = ad.Mail_Id;

                        cmd.CommandText = "insert into StaffAddress values(" + id + ",'" + door + "','" + street + "','" + village + "','" + city + "','" + state + "','" + pincode + "','" + mailid + "',"+ad.Type+")";
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch(Exception ex) { }
           
        
        }
        public static List<int> GetAllClasses()
        {
            List<int> classList = new List<int>();

            // Define the SQL query to get all class numbers
            string query = "SELECT Class FROM Class;";

            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Read the class number and add it to the list
                        int classNumber = reader.GetInt32(0);
                        classList.Add(classNumber);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return classList;
        }
        public static List<staffDetails> GetStaffBySubject(string subjectName)
        {
            List<staffDetails> staffList = new List<staffDetails>();

            string query = @"
            SELECT StaffId, Name, Dob, Qualification, JoiningYear, PreviousExperience, Gender, SubjectsTaught, UptoClass, IsActive
            FROM StaffDetails
            WHERE SubjectsTaught LIKE '%' + @SubjectName + '%'";

            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubjectName", subjectName);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        staffDetails staff = new staffDetails
                        {
                            
                            Name = reader.GetString(1),
                            Dob = reader.GetString(2),
                            Qualification = reader.GetString(3),
                            JoiningYear = reader.GetString(4),
                            PreviousExperience = reader.GetString(5),
                            Gender = reader.GetString(6),
                            SubjectsTaught = reader.GetString(7),
                            Class = reader.GetInt32(8),
                            Isactive = reader.GetBoolean(9)
                        };
                        staffList.Add(staff);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return staffList;
        }
        public static bool InsertStaffDetails(staffDetails staffDetails)
        {
            string query = @"
            INSERT INTO StaffDetails (Name, Dob, Qualification, JoiningYear, PreviousExperience, Gender, SubjectsTaught, UptoClass, IsActive)
            VALUES (@Name, @Dob, @Qualification, @JoiningYear, @PreviousExperience, @Gender, @SubjectsTaught, @UptoClass, @IsActive)";

            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", staffDetails.Name);
                command.Parameters.AddWithValue("@Dob", staffDetails.Dob);
                command.Parameters.AddWithValue("@Qualification", staffDetails.Qualification);
                command.Parameters.AddWithValue("@JoiningYear", staffDetails.JoiningYear);
                command.Parameters.AddWithValue("@PreviousExperience", staffDetails.PreviousExperience);
                command.Parameters.AddWithValue("@Gender", staffDetails.Gender);
                command.Parameters.AddWithValue("@SubjectsTaught", staffDetails.SubjectsTaught);
                command.Parameters.AddWithValue("@UptoClass", staffDetails.Class);
                command.Parameters.AddWithValue("@IsActive", staffDetails.Isactive);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
        public static void InsertStaffMobile(staffDetails staff)
        {
          
            using (SqlConnection con = new SqlConnection(path))
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                foreach (var item in staff.mobilenumbers)
                {
                    string Mobile = item.Mobile_Number;
                    int id = staff.Id;
                    string type = item.Type;
               
                cmd.CommandText = "insert into StaffMobile_Number values("+id+",'" + Mobile+ "','"+type+"')";
                cmd.ExecuteNonQuery();
                }
            }
        
        }
        public static void InsertSection(ClassDetails s)
        {

            using (SqlConnection con = new SqlConnection(path))
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into ClassDetails(Class,Section) values('" + s.Class + "','" + s.Section + "')";
                cmd.ExecuteNonQuery();
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
                    cmd.CommandText = "INSERT INTO SubjectDetails (Class, SubjectName) VALUES (@Class, @SubjectName)";
                    cmd.Parameters.AddWithValue("@Class", Class);
                    cmd.Parameters.AddWithValue("@SubjectName", SubjectName);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show(Class + ":" + SubjectName + "sucsess");
            }
            catch 
            {
                MessageBox.Show("invalid");
            }
        }
        public static Dictionary<int, List<string>> GetSubjectDetails()
        {
            Dictionary<int, List<string>> subjectDetailsDict = new Dictionary<int, List<string>>();

            string query = "SELECT Class, SubjectName FROM SubjectDetails";

            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int classValue = reader.GetInt32(reader.GetOrdinal("Class"));
                        string subjectName = reader.GetString(reader.GetOrdinal("SubjectName"));

                        if (!subjectDetailsDict.ContainsKey(classValue))
                        {
                            subjectDetailsDict[classValue] = new List<string>();
                        }

                        subjectDetailsDict[classValue].Add(subjectName);
                    }
                }
            }

            return subjectDetailsDict;
        }
        public static int GetSubjectId(int classValue, string subjectName)
        {
            int subjectId = -1;

            using (SqlConnection connection = new SqlConnection(path))
            {
                string query = "SELECT SubjectId FROM SubjectDetails WHERE Class = @Class AND SubjectName = @SubjectName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Class", classValue);
                    command.Parameters.AddWithValue("@SubjectName", subjectName);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        subjectId = Convert.ToInt32(result);
                    }
                }
            }

            return subjectId;
        }

      //update
        public static void UpdateSubjectName(int Class, string oldSubjectName, string newSubjectName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    con.Open();

                    // Check if the old record exists
                    string checkQuery = "SELECT COUNT(*) FROM SubjectDetails WHERE Class = @Class AND SubjectName = @OldSubjectName";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@Class", Class);
                        checkCmd.Parameters.AddWithValue("@OldSubjectName", oldSubjectName);

                        object result = checkCmd.ExecuteScalar();

                        if (result != null && Convert.ToInt32(result) > 0)
                        {
                            // Ensure the new subject name does not already exist for the same class
                            string duplicateCheckQuery = "SELECT COUNT(*) FROM SubjectDetails WHERE Class = @Class AND SubjectName = @NewSubjectName";
                            using (SqlCommand duplicateCheckCmd = new SqlCommand(duplicateCheckQuery, con))
                            {
                                duplicateCheckCmd.Parameters.AddWithValue("@Class", Class);
                                duplicateCheckCmd.Parameters.AddWithValue("@NewSubjectName", newSubjectName);

                                object duplicateResult = duplicateCheckCmd.ExecuteScalar();

                                if (duplicateResult != null && Convert.ToInt32(duplicateResult) == 0)
                                {
                                    string updateQuery = "UPDATE SubjectDetails SET SubjectName = @NewSubjectName WHERE Class = @Class AND SubjectName = @OldSubjectName";
                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                                    {
                                        updateCmd.Parameters.AddWithValue("@Class", Class);
                                        updateCmd.Parameters.AddWithValue("@OldSubjectName", oldSubjectName);
                                        updateCmd.Parameters.AddWithValue("@NewSubjectName", newSubjectName);

                                        updateCmd.ExecuteNonQuery();
                                        MessageBox.Show(Class + ": " + oldSubjectName + " updated to " + newSubjectName + " successfully");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("A subject with the new name already exists for this class.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Subject not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
      //del
        public static void DeactivateSubject(int Class, string SubjectName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    con.Open();

                    // Check if the record exists and is active
                    string checkQuery = "SELECT COUNT(*) FROM SubjectDetails WHERE Class = @Class AND SubjectName = @SubjectName AND IsActive = 1";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@Class", Class);
                        checkCmd.Parameters.AddWithValue("@SubjectName", SubjectName);

                        object result = checkCmd.ExecuteScalar();

                        if (result != null && Convert.ToInt32(result) > 0)
                        {
                            // If the record exists and is active, deactivate it
                            string deactivateQuery = "UPDATE SubjectDetails SET IsActive = 0 WHERE Class = @Class AND SubjectName = @SubjectName";
                            using (SqlCommand deactivateCmd = new SqlCommand(deactivateQuery, con))
                            {
                                deactivateCmd.Parameters.AddWithValue("@Class", Class);
                                deactivateCmd.Parameters.AddWithValue("@SubjectName", SubjectName);

                                deactivateCmd.ExecuteNonQuery();
                                MessageBox.Show(Class + ": " + SubjectName + " deactivated successfully");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Subject not found or already inactive.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


      public static void InsertSubAndStaffRelation(SubAndStaffRelation substaff)
{
    int subjectId = substaff.SubjectId;
    int classGrade = substaff.Class;
    string section = substaff.Section;
    string year = substaff.Year;
    int staffId = substaff.StaffId;
    bool isclassteacher = substaff.Isclassteacher;

    string query = "INSERT INTO SubAndStaffRelation (SubjectId, Class, Section, Year, StaffId,IsClassTeacher) VALUES (@SubjectId, @Class, @Section, @Year, @StaffId,@IsClassTeacher)";

    try
    {
        using (SqlConnection con = new SqlConnection(path))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                cmd.Parameters.AddWithValue("@Class", classGrade);
                cmd.Parameters.AddWithValue("@Section", section);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@StaffId", staffId);
                cmd.Parameters.AddWithValue("@IsClassTeacher", isclassteacher);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record inserted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
    catch (SqlException sqlEx)
    {
        MessageBox.Show("SQL Error: " + sqlEx.Message, "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
      public static bool UpdateStudentMarkAndPresence(StudentsMarks studentMark)
      {
          string query = @"
            UPDATE StudentMarks
            SET Mark = @Mark, present = @Present
            WHERE StudId = @StudId AND Class = @Class AND Section = @Section AND Year = @Year AND subjectname = @SubjectName AND examtype = @ExamType";

          using (SqlConnection connection = new SqlConnection(path))
          {
              SqlCommand command = new SqlCommand(query, connection);
              command.Parameters.AddWithValue("@StudId", studentMark.StudId);
              command.Parameters.AddWithValue("@Class", studentMark.Class);
              command.Parameters.AddWithValue("@Section", studentMark.Section);
              command.Parameters.AddWithValue("@Year", studentMark.Year);
              command.Parameters.AddWithValue("@SubjectName", studentMark.Subject);
              command.Parameters.AddWithValue("@ExamType", studentMark.TypeOfExam);
              command.Parameters.AddWithValue("@Mark", studentMark.Mark);
              command.Parameters.AddWithValue("@Present", studentMark.Ispresent);

              try
              {
                  connection.Open();
                  int rowsAffected = command.ExecuteNonQuery();
                  return rowsAffected > 0; // Return true if at least one row was updated
              }
              catch (Exception ex)
              {
                  // Handle exception (log it, rethrow it, or show message)
                  Console.WriteLine("Error updating student marks: " + ex.Message);
                  return false;
              }
          }
      }
         
        public static void InsertStudentMarks(StudentsMarks mar)
        {

            int studId = mar.StudId;
            int classId = mar.Class;
            string section = mar.Section;
            string year = mar.Year;
            string subjectName = mar.Subject;
            string examType = mar.TypeOfExam;
            string name = mar.Name;
            float mark = mar.Mark;
            bool pres = mar.Ispresent;
            // SQL query with parameters
            string query = @"
        INSERT INTO StudentMarks (StudId, Class, Section, Year, subjectname, examtype, Name, Mark,present)
        VALUES (@StudId, @Class, @Section, @Year, @SubjectName, @ExamType, @Name, @Mark,@Present)";

            // Using statement to ensure proper resource management
            using (SqlConnection connection = new SqlConnection(path))
            {
                // Create the SQL command
                SqlCommand command = new SqlCommand(query, connection);

                // Define the parameters and assign values
                command.Parameters.Add("@StudId", SqlDbType.Int).Value = studId;
                command.Parameters.Add("@Class", SqlDbType.Int).Value = classId;
                command.Parameters.Add("@Section", SqlDbType.VarChar, 2).Value = section;
                command.Parameters.Add("@Year", SqlDbType.VarChar, 4).Value = year;
                command.Parameters.Add("@SubjectName", SqlDbType.VarChar, 25).Value = subjectName;
                command.Parameters.Add("@ExamType", SqlDbType.VarChar, 25).Value = examType;
                command.Parameters.Add("@Name", SqlDbType.VarChar, 25).Value = name;
                command.Parameters.Add("@Mark", SqlDbType.Float).Value = mark;
                command.Parameters.AddWithValue("@Present", pres);
                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Optionally, check if the insertion was successful
                    if (rowsAffected > 0)
                    {
                    }
                    else
                    {
                        MessageBox.Show("No record was inserted.");
                    }
                }
                catch (SqlException ex)
                {
                    // Handle SQL exceptions
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        public  static List<StudentsMarks> GetStudentMarksByCriteria(int classId, string section, string year, string subject, string examType)
        {
            List<StudentsMarks> studentMarksList = new List<StudentsMarks>();

            // SQL query with parameters
            string query = @"
            SELECT StudId, Class, Section, Year, subjectname, examtype, Name, Mark,present
            FROM StudentMarks
            WHERE Class = @Class
              AND subjectname = @Subject
              AND Section = @Section
              AND Year = @Year
              AND examtype = @ExamType";

            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Define parameters and assign values
                command.Parameters.Add("@Class", SqlDbType.Int).Value = classId;
                command.Parameters.Add("@Subject", SqlDbType.VarChar, 25).Value = subject;
                command.Parameters.Add("@Section", SqlDbType.VarChar, 2).Value = section;
                command.Parameters.Add("@Year", SqlDbType.VarChar, 4).Value = year;
                command.Parameters.Add("@ExamType", SqlDbType.VarChar, 25).Value = examType;

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int studId = reader.GetInt32(reader.GetOrdinal("StudId"));
                        int @class = reader.GetInt32(reader.GetOrdinal("Class"));
                        string sectionFromDb = reader.GetString(reader.GetOrdinal("Section"));
                        string yearFromDb = reader.GetString(reader.GetOrdinal("Year"));
                        string subjectFromDb = reader.GetString(reader.GetOrdinal("subjectname"));
                        string examTypeFromDb = reader.GetString(reader.GetOrdinal("examtype"));
                        string name = reader.GetString(reader.GetOrdinal("Name"));
                        float mark = reader.IsDBNull(reader.GetOrdinal("Mark")) ? 0 : (float)reader.GetDouble(reader.GetOrdinal("Mark"));
                        bool ispres = reader.GetBoolean(reader.GetOrdinal("present"));
                        StudentsMarks studentMark = new StudentsMarks(studId, @class, sectionFromDb, yearFromDb, subjectFromDb, examTypeFromDb, name, mark,ispres);
                        studentMarksList.Add(studentMark);
                    }
                }
                catch (SqlException ex)
                {
                    // Handle SQL exceptions
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return studentMarksList;
        }
      






       public static void InsertExamType(ExamType examType)
        {
            string query = "INSERT INTO ExamType (Class, ExamType, MaxMark) VALUES (@Class, @ExamType, @MaxMark)";

            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand cmd= new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Class", examType.Class);
                cmd.Parameters.AddWithValue("@ExamType", examType.Exam_Type);
                cmd.Parameters.AddWithValue("@MaxMark", examType.Maxmark);

                try
                {
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Data inserted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Data insertion failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
       public static List<ClassDetails> GetClassDetails(staffDetails s)
       {
           List<ClassDetails> classDetailsList = new List<ClassDetails>();

           string query = @"
        SELECT cd.Class, cd.Section, cd.IsActive
        FROM StaffDetails sd
        JOIN SubAndStaffRelation ssr ON sd.StaffId = ssr.StaffId
        JOIN ClassDetails cd ON ssr.Class = cd.Class AND ssr.Section = cd.Section
        WHERE sd.Name = @Name AND sd.Dob = @Dob";

           using (SqlConnection connection = new SqlConnection(path))
           {
               SqlCommand command = new SqlCommand(query, connection);
               command.Parameters.AddWithValue("@Name", s.Name);
               command.Parameters.AddWithValue("@Dob", s.Dob);

               try
               {
                   connection.Open();
                   SqlDataReader reader = command.ExecuteReader();

                   while (reader.Read())
                   {
                       ClassDetails classDetails = new ClassDetails
                       {
                           Class = reader.GetInt32(0),
                           Section = reader.GetString(1),
                           IsActive = reader.GetBoolean(2)
                       };
                       classDetailsList.Add(classDetails);
                   }
                   reader.Close();
               }
               catch (Exception ex)
               {
                   Console.WriteLine(ex.Message);
               }
           }

           return classDetailsList;
       }

       public static List<staffDetails> GetAllStaffDetails()
       {
           List<staffDetails> staffDetailsList = new List<staffDetails>();

           using (SqlConnection connection = new SqlConnection(path))
           {
               string query = "SELECT StaffId, Name, Dob, Qualification, JoiningYear, PreviousExperience, Gender, SubjectsTaught, UptoClass, IsActive FROM StaffDetails";

               using (SqlCommand command = new SqlCommand(query, connection))
               {
                   connection.Open();
                   using (SqlDataReader reader = command.ExecuteReader())
                   {
                       while (reader.Read())
                       {
                           int id = reader["StaffId"] != DBNull.Value ? Convert.ToInt32(reader["StaffId"]) : 0;

                           string name = reader["Name"].ToString();
                           string dob = reader["Dob"].ToString();
                           string qualification = reader["Qualification"].ToString();
                           string joiningYear = reader["JoiningYear"].ToString();
                           string previousExperience = reader["PreviousExperience"].ToString();
                           string gender = reader["Gender"].ToString();
                           string subjectsTaught = reader["SubjectsTaught"].ToString();
                           int @class = reader["UptoClass"] != DBNull.Value ? Convert.ToInt32(reader["UptoClass"]) : 0;
                           bool isActive = Convert.ToBoolean(reader["IsActive"]);

                           staffDetails staff = new staffDetails(id,name, dob, qualification, joiningYear, previousExperience, gender, subjectsTaught, @class, isActive);
                           staffDetailsList.Add(staff);
                       }
                   }
               }
           }

           return staffDetailsList;
       }
       public static ObservableCollection<ExamType> GetExamTypesByClass(int classId)
       {
           ObservableCollection<ExamType> examTypes = new ObservableCollection<ExamType>();

           string query = @"SELECT  ExamId,ExamType, Class, MaxMark FROM ExamType WHERE Class = @Class";

           using (SqlConnection connection = new SqlConnection(path))
           {
               SqlCommand command = new SqlCommand(query, connection);
               command.Parameters.AddWithValue("@Class", classId);

               try
               {
                   connection.Open();
                   SqlDataReader reader = command.ExecuteReader();

                   while (reader.Read())
                   {
                       int id = reader.GetInt32(0);
                       string examType = reader.GetString(1);
                       int classValue = reader.GetInt32(2);
                       float maxMark = (float)reader.GetDouble(3); // Use GetDouble and cast to float

                       ExamType examTypeObj = new ExamType(id,examType, classValue, maxMark);
                       examTypes.Add(examTypeObj);
                   }
                   reader.Close();
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.ToString());
               }
           }

           return examTypes;
       }
       static void InsertClassStud(string connectionString, string year, int studId, int classNum, string section)
       {
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               connection.Open();
               string query = "INSERT INTO classStud (Year, StudId, Class, Section) VALUES (@Year, @StudId, @Class, @Section)";

               using (SqlCommand command = new SqlCommand(query, connection))
               {
                   command.Parameters.AddWithValue("@Year", year);
                   command.Parameters.AddWithValue("@StudId", studId);
                   command.Parameters.AddWithValue("@Class", classNum);
                   command.Parameters.AddWithValue("@Section", section);

                   try
                   {
                       int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show ("Rows affected: " + rowsAffected);
                   }
                   catch (SqlException ex)
                   {
                       MessageBox.Show("Error: " + ex.Message);
                   }
               }
           }
       }
       public static ObservableCollection<StudDetails> GetStudentsByClassSection(int classNum, string section)
       {
           ObservableCollection<StudDetails> students = new ObservableCollection<StudDetails>();

           using (SqlConnection connection = new SqlConnection(path))
           {
               connection.Open();
               string query = "SELECT StudId, Class, Section, Year, Name, DateOfBirth, Blood_Group FROM StudDetails WHERE Class = @Class AND Section = @Section";

               using (SqlCommand command = new SqlCommand(query, connection))
               {
                   command.Parameters.AddWithValue("@Class", classNum);
                   command.Parameters.AddWithValue("@Section", section);
                   

                   using (SqlDataReader reader = command.ExecuteReader())
                   {
                       while (reader.Read())
                       {
                           int studid = reader.GetInt32(0);
                           int classNumFromDb = reader.GetInt32(1);
                           string sectionFromDb = reader.GetString(2);
                           string yearFromDb = reader.GetString(3);
                           string name = reader.GetString(4);
                           string dateOfBirth = reader.GetString(5);
                           string bloodGroup = reader.IsDBNull(6) ? null : reader.GetString(6);

                           StudDetails student = new StudDetails(studid, classNumFromDb, sectionFromDb, yearFromDb, name, dateOfBirth, bloodGroup);
                           students.Add(student);
                       }
                   }
               }
           }

           return students;
       }
    }
}
