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
    public class WorkTaskRepository : IWorkTaskRepository
    {
        private readonly TaskBoardContext Database;
        
        public WorkTaskRepository(TaskBoardContext context)
        {
            Database = context;
        }
        public IEnumerable<WorkTask> GetAll()
        {
            var result = Database.Tasks.Include(t => t.TaskState).Include(t => t.AuthorUser).Include(t => t.LastModifiedUser).AsEnumerable();
            return result;

        }

        public WorkTask Get(int id)
        {
            return Database.Tasks.Include(t => t.TaskState).Include(t => t.AuthorUser).Include(t => t.LastModifiedUser).SingleOrDefault(s => s.Id == id);
        }
        public void Insert(WorkTask workTask)
        {
            if (workTask == null)
            {
                throw new ArgumentNullException("entity");
            }
            Database.Tasks.Add(workTask);
            Database.SaveChanges();
        }

        public void Update(WorkTask workTask)
        {
            if (workTask == null)
            {
                throw new ArgumentNullException("entity");
            }
            Database.Tasks.Update(workTask);
            Database.SaveChanges();
        }

        public void Delete(WorkTask workTask)
        {
            if (workTask == null)
            {
                throw new ArgumentNullException("entity");
            }
            Database.Tasks.Remove(workTask);
            Database.SaveChanges();
        }
      

        public void SaveChanges()
        {
            Database.SaveChanges();
        }
    }
}
