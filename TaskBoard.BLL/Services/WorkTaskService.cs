using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.BLL.DTO;
using TaskBoard.BLL.Interfaces;
using TaskBoard.DAL.Entities;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.BLL.Services
{
    public class WorkTaskService: IWorkTaskService
    {
        IUnitOfWork Database { get; set; }

        private IMapper MapConfig()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<WorkTask, WorkTaskDTO>().
         ForMember(dest => dest.TaskState, opt => opt.MapFrom(src => src.TaskState.TaskStateTitle)).
         ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.AuthorUser.Name + " " + src.AuthorUser.Surname)).
         ForMember(dest => dest.LastModifiedUserName, opt => opt.MapFrom(src => src.LastModifiedUser.Name + " " + src.LastModifiedUser.Surname))).
         CreateMapper();
        }
        
        public WorkTaskService(IUnitOfWork uow)
        {
            this.Database = uow;

        }

        public IEnumerable<WorkTaskDTO> GetWorkTasks()
        {
            var mapper = MapConfig();
            return mapper.Map<IEnumerable<WorkTask>, List<WorkTaskDTO>>(Database.WorkTaskManager.GetAll());
   
        }

        public WorkTaskDTO GetWorkTask(int id)
        {
            var mapper = MapConfig();
            return mapper.Map<WorkTask, WorkTaskDTO>(Database.WorkTaskManager.Get(id));
       
        }

        public void InsertWorkTask(WorkTaskDTO workTaskDto)
        {

            var WorkTask = new WorkTask
            {
                Title = workTaskDto.Title,
                Description = workTaskDto.Description,
                CreatedDate = workTaskDto.CreatedDate,
                UpdatedDate = workTaskDto.UpdatedDate,
                AuthorUserId = Database.UserProfileManager.GetUserByEmail(workTaskDto.AuthorUserId).Id,
                LastModifiedUserId = Database.UserProfileManager.GetUserByEmail(workTaskDto.AuthorUserId).Id,
                TaskStateId = Database.TaskStateManager.Get(workTaskDto.TaskState).TaskStateId

            };
            Database.WorkTaskManager.Insert(WorkTask);
            Database.SaveAsync();
        }

        public void UpdateWorkTask(WorkTaskDTO workTaskDto)
        {
            var WorkTask = Database.WorkTaskManager.Get(workTaskDto.Id);
            WorkTask.Title = workTaskDto.Title;
            WorkTask.Description = workTaskDto.Description;
            WorkTask.CreatedDate = workTaskDto.CreatedDate;
            WorkTask.UpdatedDate = workTaskDto.UpdatedDate;
            WorkTask.AuthorUserId = workTaskDto.AuthorUserId;
            WorkTask.LastModifiedUserId = Database.UserProfileManager.GetUserByEmail(workTaskDto.LastModifiedUserId).Id;
            WorkTask.TaskStateId = Database.TaskStateManager.Get(workTaskDto.TaskState).TaskStateId;
            Database.WorkTaskManager.Update(WorkTask);
            Database.SaveAsync();
        }


        public void DeleteWorkTask(int id)
        {
            WorkTask workTask = Database.WorkTaskManager.Get(id);
            Database.WorkTaskManager.Delete(workTask);
            Database.SaveAsync();
        }

        public void ChangeTaskState(int id, string state, string email)
        {
            var WorkTask = Database.WorkTaskManager.Get(id);
            WorkTask.TaskStateId = Database.TaskStateManager.Get(state).TaskStateId;
            WorkTask.UpdatedDate = DateTime.Now;
            WorkTask.LastModifiedUserId = Database.UserProfileManager.GetUserByEmail(email).Id;
            Database.WorkTaskManager.Update(WorkTask);
            Database.SaveAsync();
        }
    }
}
