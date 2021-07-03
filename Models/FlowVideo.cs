using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduServiceRM.Models
{
    public class FlowVideo
    {
        public int FlowId { get; set; }
        public Flow Flow { get; set; }

        public int VideoId { get; set; }
        public Video Video { get; set; }
    }
}
