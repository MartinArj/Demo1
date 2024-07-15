using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentApp
{
   public class StaffAddress
    {
        private int _StaffId;

        public int StaffId
        {
            get { return _StaffId; }
            set { _StaffId = value; }
        }
        private string _DoorNo;

        public string DoorNo
        {
            get { return _DoorNo; }
            set { _DoorNo = value; }
        }
        private string _Street;

        public string Street
        {
            get { return _Street; }
            set { _Street = value; }
        }
        private string _Village;

        public string Village
        {
            get { return _Village; }
            set { _Village = value; }
        }
        private string _City;

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        private string _State;

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        private string _Pin_Code;

        public string Pin_Code
        {
            get { return _Pin_Code; }
            set { _Pin_Code = value; }
        }
        private string _Mail_Id;

        public string Mail_Id
        {
            get { return _Mail_Id; }
            set { _Mail_Id = value; }
        }
        private Byte type;

        public Byte Type
        {
            get { return type; }
            set { type = value; }
        }
        public StaffAddress() { }

        public StaffAddress(int StaffId, string DoorNo, string Street, string Village, string City, string State, string Pin_Code, string Mail_Id,Byte type)
        {
            this._StaffId = StaffId;
            this._DoorNo = DoorNo;
            this._Street = Street;
            this._Village = Village;
            this._City = City;
            this._State = State;
            this._Pin_Code = Pin_Code;
            this._Mail_Id = Mail_Id;
            this.type = type;

        }

    }
}
