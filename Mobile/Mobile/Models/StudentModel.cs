using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models
{
    public class StudentModel
    {
        public int ID { get; set; }
        public string FNAME { get; set; }
        public string LNAME { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public Nullable<int> STUDENT_NO { get; set; }
        public Nullable<int> FINGER_ID { get; set; }

        public static implicit operator List<object>(StudentModel v)
        {
            throw new NotImplementedException();
        }
    }
}
