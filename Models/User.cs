using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduServiceRM.Models
{
    public class User
    {
        public int Id { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }
        public ICollection<UserVideo> UserVideos { get; set; }
        public ICollection<UserFlow> UserFlows { get; set; }

    }
}
