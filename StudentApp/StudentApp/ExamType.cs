using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentApp
{
   public class ExamType
    {
        private string _Exam_Type;

        public string Exam_Type
        {
            get { return _Exam_Type; }
            set { _Exam_Type = value; }
        }
       private int _Class;

        public int Class
        {
            get { return _Class; }
            set { _Class = value; }
        }
        private float _Maxmark;

        public float Maxmark
        {
            get { return _Maxmark; }
            set { _Maxmark = value; }
        }
        private int _examid;

        public int Examid
        {
            get { return _examid; }
            set { _examid = value; }
        }
       
        public ExamType()
        { 
        }
        public ExamType(int Examid,string ExamType, int Class, float Maxmark)
        {
            this._examid = Examid;
            this._Exam_Type = ExamType;
            this._Class = Class;
            this._Maxmark = Maxmark;
        }
        public ExamType(string ExamType, int Class, float Maxmark)
        {
            this._Exam_Type = ExamType;
            this._Class=Class;
            this._Maxmark = Maxmark;
        }
       
    }
}
