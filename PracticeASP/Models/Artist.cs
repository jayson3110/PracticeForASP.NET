using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeASP.Models
{
    public class Artist
    {
        public int Artist_id { get; set; }
        public string Artist_Name { get; set; }
        public DateTime Artist_date { get; set; }
        public string Artist_roles { get; set; }
        public DateTime Artist_join { get; set; }
        public int Artist_contact { get; set; }

    }
}