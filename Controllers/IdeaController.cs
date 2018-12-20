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
            if(HttpContext.Session.GetString("Login")==null || HttpContext.Session.GetString("Login")!="True")
            {
                return Redirect("/");
            }
            int departId=(int)HttpContext.Session.GetInt32("departId");
            int rank=(int)HttpContext.Session.GetInt32("rank");
            ViewBag.approvers=dbContext.Users;
            int userid=(int)HttpContext.Session.GetInt32("id");
            ViewBag.id=userid;
            ViewBag.creator=dbContext.Users.FirstOrDefault(u=>u.UserId==userid);
            ViewBag.approvers=dbContext.Users.Where(a=>a.departId ==departId && a.Rank > rank);
            Idea idea = dbContext.Ideas.FirstOrDefault(i=>i.IdeaId==id);
            int cid=(int)idea.CreatorId;
            var creator=dbContext.Users.FirstOrDefault(u=>u.UserId==cid);
            ViewBag.creator=creator;
            return View(idea);
        }

        [HttpGet]
        [Route("idea/form")]
        public IActionResult IdeaForm()
        {
            if(HttpContext.Session.GetString("Login")==null || HttpContext.Session.GetString("Login")!="True")
            {
                return Redirect("/");
            }
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
            if(HttpContext.Session.GetString("Login")==null || HttpContext.Session.GetString("Login")!="True")
            {
                return Redirect("/");
            }
            dbContext.Ideas.Add(newIdea);
            dbContext.SaveChanges();
            int id=newIdea.IdeaId;

            return Redirect($"/ideaprofile/{id}");
        }
        /////////////////////////////////////////////////////// All Ideas ///////////////////////

        [HttpGet]
        [Route("idea/all")]
        public IActionResult AllIdeas(int id)
        {   
            if(HttpContext.Session.GetString("Login")==null || HttpContext.Session.GetString("Login")!="True")
            {
                return Redirect("/");
            }
            List <Idea> ideas=dbContext.Ideas.ToList();

            return View(ideas);
        }



/////////////////////////////////////////////////////// GET EXPERITMENT PAGE ///////////////////////

        [HttpGet]
        [Route("experiment/{id}")]
        public IActionResult Experiment(int id)
        {
            if(HttpContext.Session.GetString("Login")==null || HttpContext.Session.GetString("Login")!="True")
            {
                return Redirect("/");
            }
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
            if(HttpContext.Session.GetString("Login")==null || HttpContext.Session.GetString("Login")!="True")
            {
                return Redirect("/");
            }
            dbContext.Add(ExperimentSubmission);
            dbContext.SaveChanges();


            return Redirect($"/Experiment/{id}");

        }

    }
}