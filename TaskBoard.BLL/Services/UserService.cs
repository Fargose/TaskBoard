using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.BLL.DTO;
using TaskBoard.BLL.Infrastracture;
using TaskBoard.BLL.Interfaces;
using TaskBoard.DAL.Entities;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.BLL.Services
{
    public class UserService: IUserService
    {
        IUnitOfWork Database { get; set; }


        public UserService(IUnitOfWork uow)
        {
            Database = uow;

        }

      
        public async Task<OperationDetails> CreateUser(UserDTO userDto)
        {
            UserAccount user = await Database.UserAccountManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new UserAccount { Email = userDto.Email, UserName = userDto.Email};
                var result = await Database.UserAccountManager.CreateAsync(user, userDto.Password);
                if (result.Errors.ToList().Count() > 0)
                    return new OperationDetails(false, "PasswordError", "");

                UserProfile clientProfile = new UserProfile { Id = user.Id, Name = userDto.Name, Surname = userDto.SurName, Language = userDto.Language };
                Database.UserProfileManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Completed", "");
            }
            else
            {
                return new OperationDetails(false, "UserExist", "Email");
            }
        }


        public void Dispose()
        {
            Database.Dispose();
        }

        public UserDTO GetUser(string email)
        {
            var user = Database.UserProfileManager.GetUserByEmail(email);
            var userDto = new UserDTO
            {
                Id = user.Id,
                Language = user.Language,
                Email = user.UserAccount.Email,
                Name = user.Name,
                SurName = user.Surname,
                UserName = user.UserAccount.Email


            };
            return userDto;
        }

        public void SetLanguage(string email, string lang)
        {
            var user = Database.UserProfileManager.GetUserByEmail(email);
            user.Language = lang;
            Database.UserProfileManager.Update(user);
            Database.SaveAsync();
        }
    }
}
