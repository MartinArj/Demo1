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
        private bool _IsActive;

        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        public ClassDetails()
        { 
        }
        public ClassDetails(int Class, string Section,bool a=true)
        {
            this._Class = Class;
            this._Section = Section;
            this._IsActive = a;
        }
    }
}
