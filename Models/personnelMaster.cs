using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YC_Test.Models
{
    public class personnelMaster
    {
        public string ChineseName { get; set; }
        public string EnglishName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}