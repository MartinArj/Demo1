using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentApp
{
  public  class SubjectDetails
    {
        private int _Class;

        public int Class
        {
            get { return _Class; }
            set { _Class = value; }
        }
        private string _SubjectName;

        public string SubjectName
        {
            get { return _SubjectName; }
            set { _SubjectName = value; }
        }

        public SubjectDetails(int Class, string SubjectName)
        {
            this._Class = Class;
            this._SubjectName = SubjectName;
        }
    }
}
