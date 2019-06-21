using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.DAL.Entities;


namespace TaskBoard.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        UserManager<UserAccount> UserAccountManager { get; }
        IUserProfileRepository UserProfileManager { get; }

        IWorkTaskRepository WorkTaskManager { get; }

        ITaskStateRepository TaskStateManager { get;  }
        Task SaveAsync();
    }
}
