using System;
using System.Collections.Generic;
using System.Text;
using TaskBoard.DAL.Entities;

namespace TaskBoard.DAL.Interfaces
{
    public interface IUserProfileRepository: IDisposable
    {
       
        void Create(UserProfile item);
        UserProfile GetUserByEmail(string email);

        void Update(UserProfile entity);


    }
}
