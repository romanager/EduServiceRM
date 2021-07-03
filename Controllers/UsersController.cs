using EduServiceRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EduServiceRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ApplicationContext context;

        public UsersController(ApplicationContext context)
        {
            this.context = context;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await context.Users.ToListAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<UsersController>/5
        [HttpGet("{userId}/videos/{priority?}")]
        public async Task<ActionResult<User>> Get(int userId, Order priority)
        {
            var user = await context.Users
                //.FirstOrDefaultAsync(x => x.Id == userId)
                .Include(i => i.UserVideos)
                    .ThenInclude(j => j.Video)
                .Include(i => i.UserFlows)
                    .ThenInclude(j => j.Flow)
                    .ThenInclude(k=>k.FlowVideos)
                    .ThenInclude(l=>l.Video)
                .Include(i => i.UserGroups)
                    .ThenInclude(j => j.Group)
                    .ThenInclude(k => k.GroupVideos)
                    .ThenInclude(l => l.Video)
                    .ThenInclude(l => l.FlowVideos)
                    .ThenInclude(l => l.Video)
                .Where(x => x.Id == userId)
                .SingleOrDefaultAsync();

            Dictionary<string, Priority> videoPriorities = new Dictionary<string, Priority>();

            var allVideos1 = user.UserVideos.Select(u => new { VideoName = u.Video.Name, VideoPriority = u.Priority }).ToList();
            
            var allVideos2 = user.UserFlows.Select(u => new
            {
                VideoName = u.Flow.FlowVideos.SelectMany(v => v.Video.Name),
                VideoPriority = u.Priority}).ToList();
            
            var allVideos3 = user.UserGroups.Select(u => new
            {
                VideoName = u.Group.GroupVideos.SelectMany(v => v.Video.Name),
                VideoPriority = u.Group.GroupVideos.Select(v => v.Priority)
            });

            //var allVideos4 = user.UserGroups.SelectMany(u => u.Group.GroupFlows);
            var allVideos4 = user.UserGroups.Select(u => new
            {
                VideoName = u.Group.GroupFlows.SelectMany(v => v.Flow.FlowVideos.Select(w => w.Video.Name)),
                VideoPriority = u.Group.GroupFlows.Select(v => v.Priority)
            });

            foreach (var video in allVideos1)
            {
                Priority value;

                videoPriorities.TryGetValue(video.VideoName, out value);

                if ((int)value >= 0)
                {
                    videoPriorities[video.VideoName] = video.VideoPriority;
                }
                else if (video.VideoPriority > value)
                {
                    videoPriorities[video.VideoName] = video.VideoPriority;
                }
            }
                                
            return new JsonResult(videoPriorities);
        }
    }
}
