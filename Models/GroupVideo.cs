using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduServiceRM.Models
{
    public class GroupVideo
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int VideoId { get; set; }
        public Video Video { get; set; }

        public Priority Priority { get; set; }
    }
}
