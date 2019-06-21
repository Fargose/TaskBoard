using System;
using System.Collections.Generic;
using System.Text;
using TaskBoard.DAL.Entities;

namespace TaskBoard.DAL.Interfaces
{
    public interface ITaskStateRepository
    {
            IEnumerable<TaskState> GetAll();
            TaskState Get(string id);

        
    }
}
