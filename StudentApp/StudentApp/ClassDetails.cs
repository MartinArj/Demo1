using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentApp
{
   public class ClassDetails
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
        private int _Class_Teacher;

        public int Class_Teacher
        {
            get { return _Class_Teacher; }
            set { _Class_Teacher = value; }
        }

        public ClassDetails(int Class, string Section, int Class_Teacher)
        {
            this._Class = Class;
            this._Section = Section;
            this._Class_Teacher = Class_Teacher;
        }
    }
}
