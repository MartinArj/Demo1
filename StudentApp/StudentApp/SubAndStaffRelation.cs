using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentApp
{
  public  class SubAndStaffRelation
    {
        private int _SubjectId;

        public int SubjectId
        {
            get { return _SubjectId; }
            set { _SubjectId = value; }
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
        private int _StaffId;

        public int StaffId
        {
            get { return _StaffId; }
            set { _StaffId = value; }
        }
        private bool _Isclassteacher;

        public bool Isclassteacher
        {
            get { return _Isclassteacher; }
            set { _Isclassteacher = value; }
        }
        public SubAndStaffRelation(int SubjectId, int Class, string Section, string Year, int StaffId,bool isclassteacher)
        {
            this._SubjectId = SubjectId;
            this._Class = Class;
            this._Section = Section;
            this._Year = Year;
            this._StaffId = StaffId;
            this._Isclassteacher = isclassteacher;
            
        }
    }
}
