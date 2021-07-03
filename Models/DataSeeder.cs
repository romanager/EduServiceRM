using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EduServiceRM.Models
{
    public class DataSeeder
    {
        static object locker = new object();
        public static void SeedUsers(ApplicationContext context, int count)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>(count);
         
                for (int i = 0; i < count; i++)
                {
                    users.Add(new User { });
                }

                context.AddRange(users);
                context.SaveChanges();
            }
        }

        public static void SeedGroups(ApplicationContext context, int count)
        {
            if (!context.Groups.Any())
            {
                var groups = new List<Group>(count);

                for (int i = 0; i < count; i++)
                {
                    groups.Add(new Group { });
                }
                
                context.AddRange(groups);
                context.SaveChanges();
            }
        }
        
        public static void SeedUserGroups(ApplicationContext context)
        {
            if (!context.UserGroups.Any())
            {
                var userGroups = new List<UserGroup>()
                {
                    new UserGroup { UserId = 2, GroupId = 1 },
                    new UserGroup { UserId = 3, GroupId = 2 },
                    new UserGroup { UserId = 4, GroupId = 3 },
                    new UserGroup { UserId = 4, GroupId = 4 },
                    new UserGroup { UserId = 5, GroupId = 5 },
                    new UserGroup { UserId = 6, GroupId = 6 },
                    new UserGroup { UserId = 7, GroupId = 7 },
                    new UserGroup { UserId = 7, GroupId = 8 },
                    new UserGroup { UserId = 8, GroupId = 7 },
                    new UserGroup { UserId = 8, GroupId = 9 },
                    new UserGroup { UserId = 9, GroupId = 7 },
                    new UserGroup { UserId = 9, GroupId = 8 },
                    new UserGroup { UserId = 10, GroupId = 7 }
                };

                context.AddRange(userGroups);
                context.SaveChanges();
            }
        }

        public static void SeedVideos(ApplicationContext context, int count)
        {
            if (!context.Videos.Any())
            {
                var videos = new List<Video>(count);

                lock(locker)
                {
                    for (int i = 0; i < count; i++)
                    {
                        videos.Add(new Video { Name = $"Video {count - i}" });
                    }
                    Thread.Sleep(100);
                }
                
                context.AddRange(videos);
                context.SaveChanges();
            }
        }

        public static void SeedUserVideos(ApplicationContext context)
        {
            if (!context.UserVideos.Any())
            {
                var userVideos = new List<UserVideo>()
                {
                    new UserVideo { UserId = 1, VideoId = 1, Priority = Priority.low },
                    new UserVideo { UserId = 2, VideoId = 2, Priority = Priority.low },
                    new UserVideo { UserId = 3, VideoId = 3, Priority = Priority.low },
                    new UserVideo { UserId = 4, VideoId = 4, Priority = Priority.low },
                    new UserVideo { UserId = 5, VideoId = 5, Priority = Priority.medium },
                    new UserVideo { UserId = 5, VideoId = 6, Priority = Priority.high },
                    new UserVideo { UserId = 5, VideoId = 7, Priority = Priority.low },
                    new UserVideo { UserId = 7, VideoId = 15, Priority = Priority.medium },
                    new UserVideo { UserId = 7, VideoId = 16, Priority = Priority.low },
                    new UserVideo { UserId = 7, VideoId = 17, Priority = Priority.high },
                    new UserVideo { UserId = 8, VideoId = 16, Priority = Priority.low },
                    new UserVideo { UserId = 8, VideoId = 21, Priority = Priority.medium },
                    new UserVideo { UserId = 8, VideoId = 22, Priority = Priority.low },
                    new UserVideo { UserId = 8, VideoId = 23, Priority = Priority.low },
                    new UserVideo { UserId = 10, VideoId = 30, Priority = Priority.critical },
                };

                context.AddRange(userVideos);
                context.SaveChanges();
            }
        }

        public static void SeedFlows(ApplicationContext context, int count)
        {
            if (!context.Flows.Any())
            {
                var flows = new List<Flow>(count);

                for (int i = 0; i < count; i++)
                {
                    flows.Add(new Flow { });
                }

                context.AddRange(flows);
                context.SaveChanges();
            }
        }

        public static void SeedUserFlows(ApplicationContext context)
        {
            if (!context.UserFlows.Any())
            {
                var userFlows = new List<UserFlow>()
                {
                    new UserFlow { UserId = 3, FlowId = 1, Priority = Priority.critical },
                    new UserFlow { UserId = 4, FlowId = 2, Priority = Priority.critical },
                    new UserFlow { UserId = 5, FlowId = 4, Priority = Priority.medium },
                    new UserFlow { UserId = 6, FlowId = 5, Priority = Priority.low },
                    new UserFlow { UserId = 6, FlowId = 6, Priority = Priority.high },
                    new UserFlow { UserId = 7, FlowId = 7, Priority = Priority.low },
                    new UserFlow { UserId = 7, FlowId = 8, Priority = Priority.low },
                    new UserFlow { UserId = 7, FlowId = 9, Priority = Priority.medium },
                    new UserFlow { UserId = 9, FlowId = 12, Priority = Priority.low },
                    new UserFlow { UserId = 10, FlowId = 11, Priority = Priority.high }
                };

                context.AddRange(userFlows);
                context.SaveChanges();
            }
        }

        public static void SeedGroupVideos(ApplicationContext context)
        {
            if (!context.GroupVideos.Any())
            {
                var groupVideos = new List<GroupVideo>()
                {
                    new GroupVideo { GroupId = 1, VideoId = 2, Priority = Priority.high },
                    new GroupVideo { GroupId = 2, VideoId = 3, Priority = Priority.high },
                    new GroupVideo { GroupId = 3, VideoId = 4, Priority = Priority.high},
                    new GroupVideo { GroupId = 4, VideoId = 8, Priority = Priority.medium },
                    new GroupVideo { GroupId = 6, VideoId = 9, Priority = Priority.high },
                    new GroupVideo { GroupId = 6, VideoId = 12, Priority = Priority.low },
                    new GroupVideo { GroupId = 7, VideoId = 22, Priority = Priority.medium },
                    new GroupVideo { GroupId = 7, VideoId = 24, Priority = Priority.high },
                    new GroupVideo { GroupId = 9, VideoId = 15, Priority = Priority.critical },
                    new GroupVideo { GroupId = 9, VideoId = 16, Priority = Priority.critical },
                    new GroupVideo { GroupId = 9, VideoId = 17, Priority = Priority.critical }
                };

                context.AddRange(groupVideos);
                context.SaveChanges();
            }
        }

        public static void SeedGroupFlows(ApplicationContext context)
        {
            if (!context.GroupFlows.Any())
            {
                var groupFlows = new List<GroupFlow>()
                {
                    new GroupFlow { GroupId = 4, FlowId = 3, Priority = Priority.medium },
                    new GroupFlow { GroupId = 5, FlowId = 4, Priority = Priority.high },
                    new GroupFlow { GroupId = 7, FlowId = 10, Priority = Priority.high },
                    new GroupFlow { GroupId = 8, FlowId = 11, Priority = Priority.medium },
                    new GroupFlow { GroupId = 8, FlowId = 12, Priority = Priority.high },
                };

                context.AddRange(groupFlows);
                context.SaveChanges();
            }
        }

        public static void SeedFlowVideos(ApplicationContext context)
        {
            if (!context.FlowVideos.Any())
            {
                var flowVideos = new List<FlowVideo>()
                {
                    new FlowVideo { FlowId = 1, VideoId = 3 },
                    new FlowVideo { FlowId = 3, VideoId = 4 },
                    new FlowVideo { FlowId = 4, VideoId = 5 },
                    new FlowVideo { FlowId = 4, VideoId = 7 },
                    new FlowVideo { FlowId = 5, VideoId = 9 },
                    new FlowVideo { FlowId = 5, VideoId = 10 },
                    new FlowVideo { FlowId = 5, VideoId = 11 },
                    new FlowVideo { FlowId = 6, VideoId = 12 },
                    new FlowVideo { FlowId = 6, VideoId = 13 },
                    new FlowVideo { FlowId = 6, VideoId = 14 },
                    new FlowVideo { FlowId = 7, VideoId = 18 },
                    new FlowVideo { FlowId = 7, VideoId = 19 },
                    new FlowVideo { FlowId = 7, VideoId = 20 },
                    new FlowVideo { FlowId = 8, VideoId = 21 },
                    new FlowVideo { FlowId = 8, VideoId = 22 },
                    new FlowVideo { FlowId = 8, VideoId = 23 },
                    new FlowVideo { FlowId = 9, VideoId = 23 },
                    new FlowVideo { FlowId = 9, VideoId = 24 },
                    new FlowVideo { FlowId = 9, VideoId = 25 },
                    new FlowVideo { FlowId = 10, VideoId = 26 },
                    new FlowVideo { FlowId = 10, VideoId = 27 },
                    new FlowVideo { FlowId = 10, VideoId = 28 },
                    new FlowVideo { FlowId = 11, VideoId = 15 },
                    new FlowVideo { FlowId = 11, VideoId = 16 },
                    new FlowVideo { FlowId = 11, VideoId = 17 },
                    new FlowVideo { FlowId = 12, VideoId = 29 },
                    new FlowVideo { FlowId = 12, VideoId = 30 },
                };

                context.AddRange(flowVideos);
                context.SaveChanges();
            }
        }
    }
}
