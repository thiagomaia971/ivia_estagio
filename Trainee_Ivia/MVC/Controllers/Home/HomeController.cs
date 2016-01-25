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

            agendamentoVM.isValid = true; // ModelState.IsValidField("NovoAgendamento");
            

            agendamentoVM.HandleRequest();

            if (ModelState.IsValid)
            {
                ModelState.Clear();

            }
           
            if (Request.IsAjaxRequest())
            {
                if (agendamentoVM.IsAgendamentoMode)
                {
                    return PartialView("_NovoAgendamento", agendamentoVM);
                }

                return PartialView("_ListaAgendamentos", agendamentoVM);
            }
            

            return View(agendamentoVM);
        }

      
    }
}