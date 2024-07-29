using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentApp
{
   public class StudDetails 
    {
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
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _DateOfBirth;

        public string DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }
        private string _Blood_Group;

        public string Blood_Group
        {
            get { return _Blood_Group; }
            set { _Blood_Group = value; }
        }

        private int studid;

        public int Studid
        {
            get { return studid; }
            set { studid = value; }
        }

        public StudDetails(int Class, string Section, string Year, string Name, string DateOfBirth, string Blood_Group)
        {
            this._Class = Class;
            this._Section = Section;
            this._Year = Year;
            this._Name = Name;
            this._DateOfBirth = DateOfBirth;
            this._Blood_Group = Blood_Group;
        }
        public StudDetails(int studid,int Class, string Section, string Year, string Name, string DateOfBirth, string Blood_Group)
        {
            this.studid = studid;
            this._Class = Class;
            this._Section = Section;
            this._Year = Year;
            this._Name = Name;
            this._DateOfBirth = DateOfBirth;
            this._Blood_Group = Blood_Group;
        }
    }
}
