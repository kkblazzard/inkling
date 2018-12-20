using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using inkling.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace inkling.Controllers
{
    public class IdeaController : Controller
    {
        private InklingContext dbContext;
        // here we can "inject" our context service into the constructor
        public IdeaController(InklingContext context)
        {
            dbContext = context;
        }
/////////////////////////////////////////////////////// GET IDEA PROFILE PAGE ///////////////////////
        
        [HttpGet]
        [Route("ideaprofile/{id}")]
        public IActionResult IdeaProfile(int id)
        {


            return View();
        }

        [HttpGet]
        [Route("idea/form")]
        public IActionResult IdeaForm()
        {
            int departId=(int)HttpContext.Session.GetInt32("departId");
            int rank=(int)HttpContext.Session.GetInt32("rank");
            ViewBag.approvers=dbContext.Users;
            int id=(int)HttpContext.Session.GetInt32("id");
            ViewBag.id=id;
            ViewBag.creator=dbContext.Users.FirstOrDefault(u=>u.UserId==id);
            ViewBag.approvers=dbContext.Users.Where(a=>a.departId ==departId && a.Rank > rank);

            return View("newidea");
        }
        [HttpPost]
        [Route("idea/form/process")]
        public IActionResult IdeaFormProcess(Idea newIdea)
        {   
            dbContext.Ideas.Add(newIdea);
            dbContext.SaveChanges();
            int id=newIdea.IdeaId;

            return Redirect($"/ideaprofile/{id}");
        }
        [HttpGet]
        [Route("idea/{id}")]
        public IActionResult IdeaFormProcess(int id)
        {   
            var anidea=dbContext.Ideas.FirstOrDefault(i=>i.IdeaId == id);

            return View(anidea);
        }



/////////////////////////////////////////////////////// GET EXPERITMENT PAGE ///////////////////////

        [HttpGet]
        [Route("experiment/{id}")]
        public IActionResult Experiment(int id)
        {
            var Experiment =dbContext.Experiment.FirstOrDefault( u => u.IdeaId == id);
            ViewBag.Experiment = Experiment;
            ViewBag.Id=id;

            return View();
        }
/////////////////////////////////////////////////////// POST EXPERITMENT ///////////////////////

        [HttpPost]
        [Route("addexperiment/{id}")]
        public IActionResult AddExperiment(Experiment ExperimentSubmission, int id)
        {
            dbContext.Add(ExperimentSubmission);
            dbContext.SaveChanges();
            return Redirect($"/Experiment/{id}");
        }

    }
}