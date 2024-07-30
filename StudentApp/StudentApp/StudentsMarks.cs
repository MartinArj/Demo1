using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private string _TypeOfExam;

        public string TypeOfExam
        {
            get { return _TypeOfExam; }
            set
            {
                if (_TypeOfExam != value)
                {
                    _TypeOfExam = value;
                    OnPropertyChanged("TypeOfExam");
                };
            }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private float _Mark;

        public float Mark
        {
            get { return _Mark; }
            set
            {
              
                    _Mark = value;
                    OnPropertyChanged("Mark");
                
               }
        }
        private string _subject;

        public string Subject
        {
            get { return _subject; }
            set
            {
                if (_subject != value)
                {
                    _subject = value;
                    OnPropertyChanged("Subject");
                }
            }
        }
        private bool _Ispresent;

        public bool Ispresent
        {
            get { return _Ispresent; }
            set
            {
                if (_Ispresent != value)
                {
                    _Ispresent = value;
                    OnPropertyChanged("Ispresent");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public StudentsMarks() { }

        public StudentsMarks(int StudId, int Class, string Section, string Year,string sub, string TypeOfExam, string Name, float Mark,bool ispres)
        {
            this._StudId = StudId;
            this._Class = Class;
            this._Section = Section;
            this._Year = Year;
            this.Subject = sub;
            this._TypeOfExam = TypeOfExam;
            this._Name = Name;
            this._Mark = Mark;
            this.Ispresent = ispres;
        }
 
    }
}
