using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskBoard.DAL.EF;
using TaskBoard.DAL.Entities;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.DAL.Repositories
{
    public class TaskStateRepository : ITaskStateRepository
    {
        private readonly TaskBoardContext Database;
        public TaskStateRepository(TaskBoardContext db)
        {
            Database = db;
        }
        public TaskState Get(string id)
        {
            var result = Database.TaskStates.Where(u => u.TaskStateTitle == id).First();
            return result;
        }

        public IEnumerable<TaskState> GetAll()
        {
            return Database.TaskStates.AsEnumerable();
            
        }
    }
}
