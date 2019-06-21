using System;
using System.Collections.Generic;
using System.Text;

namespace TaskBoard.BLL.DTO
{
    public class WorkTaskDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string TaskState { get; set; }


        public string AuthorUserId { get; set; }

        public string AuthorName { get; set; }


        public string LastModifiedUserId { get; set; }

        public string LastModifiedUserName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
