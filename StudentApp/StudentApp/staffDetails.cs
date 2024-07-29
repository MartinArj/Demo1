using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace StudentApp
{
    public class staffDetails : INotifyPropertyChanged
    {
        public List<StaffAddress> AddressList  = new List<StaffAddress>();
        public List<staffMobileNumber> mobilenumbers = new List<staffMobileNumber>();

        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    OnPropertyChanged("Id");
                }
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

        private string _Dob;
        public string Dob
        {
            get { return _Dob; }
            set
            {
                if (_Dob != value)
                {
                    _Dob = value;
                    OnPropertyChanged("Dob");
                }
            }
        }

        private string _Qualification;
        public string Qualification
        {
            get { return _Qualification; }
            set
            {
                if (_Qualification != value)
                {
                    _Qualification = value;
                    OnPropertyChanged("Qualification");
                }
            }
        }

        private string _JoiningYear;
        public string JoiningYear
        {
            get { return _JoiningYear; }
            set
            {
                if (_JoiningYear != value)
                {
                    _JoiningYear = value;
                    OnPropertyChanged("JoiningYear");
                }
            }
        }

        private string _PreviousExperience;
        public string PreviousExperience
        {
            get { return _PreviousExperience; }
            set
            {
                if (_PreviousExperience != value)
                {
                    _PreviousExperience = value;
                    OnPropertyChanged("PreviousExperience");
                }
            }
        }

        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set
            {
                if (_Gender != value)
                {
                    _Gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

        private string _SubjectsTaught;
        public string SubjectsTaught
        {
            get { return _SubjectsTaught; }
            set
            {
                if (_SubjectsTaught != value)
                {
                    _SubjectsTaught = value;
                    OnPropertyChanged("SubjectsTaught");
                }
            }
        }

        private int _Class;
        public int Class
        {
            get { return _Class; }
            set
            {
                if (_Class != value)
                {
                    _Class = value;
                    OnPropertyChanged("Class");
                }
            }
        }

        private bool _isactive;
        public bool Isactive
        {
            get { return _isactive; }
            set
            {
                if (_isactive != value)
                {
                    _isactive = value;
                    OnPropertyChanged("Isactive");
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

        public staffDetails() { }

        public staffDetails(string Name, string dob, string Qualification, string JoiningYear, string PreviousExperience, string Gender, string SubjectsTaught, int Class, bool isactive)
        {
            this._Name = Name;
            this._Dob = dob;
            this._Qualification = Qualification;
            this._JoiningYear = JoiningYear;
            this._PreviousExperience = PreviousExperience;
            this._Gender = Gender;
            this._SubjectsTaught = SubjectsTaught;
            this._Class = Class;
            this._isactive = isactive;
        }

        public staffDetails(int id, string Name, string dob, string Qualification, string JoiningYear, string PreviousExperience, string Gender, string SubjectsTaught, int Class, bool isactive)
        {
            this._Id = id;
            this._Name = Name;
            this._Dob = dob;
            this._Qualification = Qualification;
            this._JoiningYear = JoiningYear;
            this._PreviousExperience = PreviousExperience;
            this._Gender = Gender;
            this._SubjectsTaught = SubjectsTaught;
            this._Class = Class;
            this._isactive = isactive;
        }
    }
}
