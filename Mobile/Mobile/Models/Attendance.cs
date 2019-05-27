using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models
{
    public class Attendance
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> finger_id { get; set; }
        public string time_stamp { get; set; }
        public string end_time_stamp { get; set; }
        public string subject_id { get; set; }
        public string present_time { get; set; }
        public string COMMENTS { get; set; }
    }
}
