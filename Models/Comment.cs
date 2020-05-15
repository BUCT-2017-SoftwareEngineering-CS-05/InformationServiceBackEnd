using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformationServiceBackEnd.Models
{
    public class Comment
    {
        [Key, Column(Order = 0)]
        public int midex { get; set; }
        [Key, Column(Order = 1)]
        public string userid { get; set; }
        public int exhscore { get; set; }
        public int serscore { get; set; }
        public int envscore { get; set; }
        public string msg { get; set; }
    }
}
