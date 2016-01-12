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
            agendamentoVM.isValid = ModelState.IsValid;
            agendamentoVM.HandleRequest();

            if (ModelState.IsValid)
            {
                ModelState.Clear();
            }

            if (Request.IsAjaxRequest())
            {
                /*if (agendamentoVM.EventCommand == "opcao")
                {
                }*/
                    return PartialView("_Modals", agendamentoVM);
                //return PartialView("_Pacientes", agendamentoVM);
            }

            return View(agendamentoVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}