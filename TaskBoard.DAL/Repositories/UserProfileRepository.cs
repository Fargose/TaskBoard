using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskBoard.DAL.EF;
using TaskBoard.DAL.Entities;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.DAL.Repositories
{
    public class UserProfileRepository: IUserProfileRepository
    {
        public TaskBoardContext Database { get; set; }
        public UserProfileRepository(TaskBoardContext db)
        {
            Database = db;
        }

        public void Create(UserProfile item)
        {
            Database.UserProfiles.Add(item);
            Database.SaveChanges();
        }

        public UserProfile GetUserByEmail(string email)
        {
            return Database.UserProfiles.Include(u => u.UserAccount).Where(u => u.UserAccount.Email == email).First();
        }

        

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Update(UserProfile entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Database.UserProfiles.Update(entity);
            Database.SaveChanges();
        }
    }
}

