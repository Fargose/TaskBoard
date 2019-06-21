using System;
using System.Collections.Generic;
using System.Text;
using TaskBoard.BLL.DTO;

namespace TaskBoard.BLL.Interfaces
{
    public interface IWorkTaskService
    {
        IEnumerable<WorkTaskDTO> GetWorkTasks();
        WorkTaskDTO GetWorkTask(int id);
        void InsertWorkTask(WorkTaskDTO WorkTask);
        void UpdateWorkTask(WorkTaskDTO WorkTask);
        void DeleteWorkTask(int id);

        void ChangeTaskState(int id, string state, string email);
    }
}
