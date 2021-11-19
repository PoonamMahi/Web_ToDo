using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_todo.Database;
using Web_todo.Models;

namespace Web_todo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<ToDoModel> data;
        private readonly ReaderWriter dataaccess;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            data = new List<ToDoModel>();
            dataaccess = new ReaderWriter();
        }

        public IActionResult Index()
        {
            data = dataaccess.Reader();
            return View();
        }

        public IActionResult Manage()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            dataaccess.Delete(id);
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public IActionResult ToggleDone(int id)
        {
            var records = dataaccess.Reader();
            if (records.Where(x => x.Id == id) != null)
            {
                ToDoModel model = new ToDoModel();
                model = (ToDoModel)records.Where(x => x.Id == id);
                model.IsCompleted = !model.IsCompleted;
                dataaccess.Update(id, model.IsCompleted);
                
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public IActionResult Create(ToDoModel model)
        {
            ReaderWriter Writer = new ReaderWriter();
            Writer.Writer(model);
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}
           
    

