using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationServiceBackEnd.Models
{
    public class User
    {
        public string userid { get; set; }
        public string nickname { get; set; }
        public string userpwd { get; set; }
        public int coright { get; set; }
    }
}
