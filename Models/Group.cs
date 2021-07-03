using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduServiceRM.Models
{
    public class Group
    {
        public int Id { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }
        public ICollection<GroupVideo> GroupVideos { get; set; }
        public ICollection<GroupFlow> GroupFlows { get; set; }
    }
}
