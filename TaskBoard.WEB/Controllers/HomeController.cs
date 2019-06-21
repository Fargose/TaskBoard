using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.WEB.Models;
using TaskBoard.BLL.Interfaces;
using AutoMapper;
using TaskBoard.BLL.DTO;
using TaskBoard.WEB.ViewModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace TaskBoard.WEB.Controllers
{       
    [Authorize]
    public class HomeController : Controller
    {
        IWorkTaskService workTaskService;
        private readonly IStringLocalizer _localizer;

        public HomeController(IWorkTaskService _workTaskService, IStringLocalizer strlocalize)
        {

            workTaskService = _workTaskService;
            _localizer = strlocalize;
        }
        public IActionResult Index()
        {
         
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<WorkTaskDTO, WorkTaskViewModel>()).
     CreateMapper();
            var Tasks = mapper.Map<IEnumerable<WorkTaskDTO>, List<WorkTaskViewModel>>(workTaskService.GetWorkTasks());

            return View(Tasks);
        }

        public ActionResult Create()
        {
           
                return View();
       
        }
        [HttpPost]
        public ActionResult Create(WorkTaskViewModel workTask)
        {

            if (workTask.Title != null && workTask.Description != null)
            {
                var WorkTaskDto = new WorkTaskDTO
                {
                    Title = workTask.Title,
                    Description = workTask.Description,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    AuthorUserId = workTask.AuthorUserId,
                    LastModifiedUserId = workTask.AuthorUserId,
                    TaskState = "ToDo"
                };

                workTaskService.InsertWorkTask(WorkTaskDto);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
         
            WorkTaskDTO workTask = workTaskService.GetWorkTask(id);
            if(workTask == null)
            {
                return NotFound();
            }
            WorkTaskViewModel model;
            model =  new WorkTaskViewModel()
                {
                    Title = workTask.Title,
                    Description = workTask.Description,
                    CreatedDate = workTask.CreatedDate,
                    AuthorUserId = workTask.AuthorUserId,
                    TaskState = workTask.TaskState
                };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(WorkTaskViewModel model)
        {
            WorkTaskDTO workTask = workTaskService.GetWorkTask(model.Id);
            if (workTask == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                workTask.Title = model.Title;
                workTask.Description = model.Description;
                workTask.CreatedDate = model.CreatedDate;
                workTask.AuthorUserId = model.AuthorUserId;
                workTask.TaskState = model.TaskState;
                workTask.UpdatedDate = DateTime.Now;
                workTask.LastModifiedUserId = model.LastModifiedUserId;
                workTaskService.UpdateWorkTask(workTask);
                return RedirectToAction("index");
            }
            else return View(model);

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            WorkTaskDTO workTask = workTaskService.GetWorkTask(id);
            if (workTask == null)
            {
                return NotFound();
            }
            WorkTaskViewModel model;

            
            model = new WorkTaskViewModel()
            {
                Title = workTask.Title,
                Description = workTask.Description,
                CreatedDate = workTask.CreatedDate,
            };
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            workTaskService.DeleteWorkTask(id);
            return RedirectToAction("Index");
        }

        public ActionResult ChangeState(int id, string state, string email)
        {
            workTaskService.ChangeTaskState(id, state, email);
            return RedirectToAction("Index");
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}
