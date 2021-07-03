using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduServiceRM.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<UserVideo> UserVideos { get; set; }
        public ICollection<GroupVideo> GroupVideos { get; set; }
        public ICollection<FlowVideo> FlowVideos { get; set; }
    }
}
