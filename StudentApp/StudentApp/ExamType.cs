using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentApp
{
   public class ExamType
    {
        private string _ExamType;

        public string ExamType1
        {
            get { return _ExamType; }
            set { _ExamType = value; }
        }

        public ExamType(string ExamType)
        {
            this._ExamType = ExamType;
        }
    }
}
