using System;
using System.Collections.Generic;
using System.Text;
using TaskBoard.DAL.Entities;

namespace TaskBoard.DAL.Interfaces
{
    public interface IWorkTaskRepository
    {
        IEnumerable<WorkTask> GetAll();
        WorkTask Get(int id);
        void Insert(WorkTask workTask);
        void Update(WorkTask workTask);
        void Delete(WorkTask workTask);
        void SaveChanges();
    }
}
