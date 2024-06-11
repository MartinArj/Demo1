using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentApp
{
  public  class StudentsMarks
    {
        private int _StudId;

        public int StudId
        {
            get { return _StudId; }
            set { _StudId = value; }
        }
        private int _Class;

        public int Class
        {
            get { return _Class; }
            set { _Class = value; }
        }
        private string _Section;

        public string Section
        {
            get { return _Section; }
            set { _Section = value; }
        }
        private string _Year;

        public string Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        private int _SubjectId;

        public int SubjectId
        {
            get { return _SubjectId; }
            set { _SubjectId = value; }
        }
        private int _TypeOfExam;

        public int TypeOfExam
        {
            get { return _TypeOfExam; }
            set { _TypeOfExam = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private float _Mark;

        public float Mark
        {
            get { return _Mark; }
            set { _Mark = value; }
        }


        public StudentsMarks(int StudId, int Class, string Section, string Year, int SubjectId, int TypeOfExam, string Name, float Mark)
        {
            this._StudId = StudId;
            this._Class = Class;
            this._Section = Section;
            this._Year = Year;
            this._SubjectId = SubjectId;
            this._TypeOfExam = TypeOfExam;
            this._Name = Name;
            this._Mark = Mark;
        }
 
    }
}
