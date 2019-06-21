using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskBoard.DAL.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("UserAccount")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Language { get; set; }
        public virtual UserAccount UserAccount { get; set; }

    }
}
