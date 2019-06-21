using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskBoard.DAL.Entities
{
    public class UserAccount: IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}
