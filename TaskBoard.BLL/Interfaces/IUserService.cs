using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.BLL.DTO;
using TaskBoard.BLL.Infrastracture;

namespace TaskBoard.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateUser(UserDTO userDto);
        UserDTO GetUser(string email);
        void SetLanguage(string email, string lang);

 


    }
}
