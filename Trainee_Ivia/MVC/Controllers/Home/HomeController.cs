using MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            AgendamentoViewModel agendamentoVM = new AgendamentoViewModel();
            agendamentoVM.HandleRequest();

            return View(agendamentoVM);
        }

        [HttpPost]
        public ActionResult Index(AgendamentoViewModel agendamentoVM)
        {
            
            agendamentoVM.isValid = ModelState.IsValidField("NovoAgendamento");

            var i = ModelState.Select(m => m.Key == "NovoAgendamento").ToList();
                
            var a = ModelState.Values
                .Where(v => v.Errors.Count > 0)
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);

            agendamentoVM.HandleRequest();

            if (ModelState.IsValid)
            {
                ModelState.Clear();

            }
           
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Pacientes", agendamentoVM);
            }
            

            return View(agendamentoVM);
        }

      
    }
}