using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduServiceRM.Models
{
    public class Flow
    {
        public int Id { get; set; }
        public ICollection<UserFlow> UserFlows { get; set; }
        public ICollection<GroupFlow> GroupFlows { get; set; }
        public ICollection<FlowVideo> FlowVideos { get; set; }
    }
}
