using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduServiceRM.Models
{
    public class UserFlow
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int FlowId { get; set; }
        public Flow Flow { get; set; }

        public Priority Priority { get; set; }
    }
}
