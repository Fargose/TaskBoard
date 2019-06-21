using System;
using System.Collections.Generic;
using System.Text;

namespace TaskBoard.DAL.Entities
{
    public class WorkTask
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int TaskStateId { get; set; }

        public TaskState TaskState { get; set; }

        public string AuthorUserId { get; set; }

        public UserProfile AuthorUser { get; set; }

        public string LastModifiedUserId { get; set; }

        public UserProfile LastModifiedUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
