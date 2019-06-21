using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.DAL.EF;
using TaskBoard.DAL.Entities;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.DAL.Repositories
{
    public class TaskBoardUnitOfWork: IUnitOfWork
    {
        private TaskBoardContext Database;

        private UserManager<UserAccount> userManager;
        private IUserProfileRepository userProfileRepository;
        private IWorkTaskRepository workTaskRepository;
        private ITaskStateRepository taskStateRepository;


        public TaskBoardUnitOfWork(DbContextOptions<TaskBoardContext> options, UserManager<UserAccount> _userManager)
        {
            Database = new TaskBoardContext(options);
            userManager = _userManager;
         
            userProfileRepository = new UserProfileRepository(Database);
            workTaskRepository = new WorkTaskRepository(Database);
            taskStateRepository = new TaskStateRepository(Database);
        }

        public UserManager<UserAccount> UserAccountManager
        {
            get { return userManager; }
        }

        public IUserProfileRepository UserProfileManager
        {
            get { return userProfileRepository; }
        }

        public IWorkTaskRepository WorkTaskManager
        {
            get { return workTaskRepository; }
        }

        public ITaskStateRepository TaskStateManager
        {
            get { return taskStateRepository; }
        }

        public async Task SaveAsync()
        {
            await Database.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    userProfileRepository.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
