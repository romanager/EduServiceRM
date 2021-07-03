using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduServiceRM.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<UserVideo> UserVideos { get; set; }
        public DbSet<Flow> Flows { get; set; }
        public DbSet<UserFlow> UserFlows { get; set; }
        public DbSet<GroupVideo> GroupVideos { get; set; }
        public DbSet<GroupFlow> GroupFlows { get; set; }
        public DbSet<FlowVideo> FlowVideos { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>().HasKey(ug => new { ug.UserId, ug.GroupId });
            modelBuilder.Entity<UserVideo>().HasKey(uv => new { uv.UserId, uv.VideoId });
            modelBuilder.Entity<UserFlow>().HasKey(uf => new { uf.UserId, uf.FlowId });
            modelBuilder.Entity<GroupVideo>().HasKey(gv => new { gv.GroupId, gv.VideoId });
            modelBuilder.Entity<GroupFlow>().HasKey(gf => new { gf.GroupId, gf.FlowId });
            modelBuilder.Entity<FlowVideo>().HasKey(fv => new { fv.FlowId, fv.VideoId });
        }
    }
}
