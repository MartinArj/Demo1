using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentApp
{
  public  class staffMobileNumber
    {
       private int _StaffId;

        public int StaffId
        {
            get { return _StaffId; }
            set { _StaffId = value; }
        }
        private string _Mobile_Number;

        public string Mobile_Number
        {
            get { return _Mobile_Number; }
            set { _Mobile_Number = value; }
        }
        private string _Type;

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public staffMobileNumber(int SatffId, string Mobile_Number)
        {
            this._StaffId = StaffId;
            this._Mobile_Number = Mobile_Number;
        }
    }
}
