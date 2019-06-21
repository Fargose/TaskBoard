using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskBoard.DAL.Entities;

namespace TaskBoard.DAL.EF
{
    public class TaskBoardContext: IdentityDbContext<UserAccount>
    {
        public TaskBoardContext(DbContextOptions<TaskBoardContext> options): base(options)
        { }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<WorkTask> Tasks { get; set; }
        public DbSet<TaskState> TaskStates { get; set; }

    }
}
