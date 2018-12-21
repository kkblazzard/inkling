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
            int userid=(int)HttpContext.Session.GetInt32("id");
            ViewBag.id=userid;
            ViewBag.creator=dbContext.Users.FirstOrDefault(u=>u.UserId==userid);
            ViewBag.approvers=dbContext.Users.Where(a=>a.departId ==departId && a.Rank < rank).OrderByDescending(r=> r.Rank).ToList();

            ViewBag.messages= dbContext.Message
            .Include(I => I.Creator)
            .Where(F => F.IdeaId == id).OrderByDescending(c=> c.created_at).ToList();
            ViewBag.Idea = dbContext.Ideas.FirstOrDefault(i=>i.IdeaId==id);
            int cid=(int)ViewBag.Idea.CreatorId;
            var creator=dbContext.Users.FirstOrDefault(u=>u.UserId==cid);
            ViewBag.creator=creator;
            return View();
        }
        /////////////////////////////////////////////////////// POST Idea Approval Process///////////////////////

        [HttpPost]
        [Route("idea/{id}/approvalprocess")]
        public IActionResult IdeaApproval( string AR, int id)
        {
            System.Console.WriteLine("************************************** Enters Function ***********************");
            if(HttpContext.Session.GetString("Login")==null || HttpContext.Session.GetString("Login")!="True")
                {
                    return Redirect("/");
                }
            int departId=(int)HttpContext.Session.GetInt32("departId");
            int rank=(int)HttpContext.Session.GetInt32("rank");
            User newapprover=dbContext.Users.FirstOrDefault(a=>a.departId ==departId && a.Rank <= rank-1);
            Idea Idea = dbContext.Ideas.FirstOrDefault(i=>i.IdeaId==id);
            int caseSwitch = rank;
            switch (caseSwitch)
            {
                case 0:
                    Idea.zeroAD=AR;
                    break;
                case 1:
                    Idea.oneAD=AR;
                    Idea.ApproverId=newapprover.UserId;
                    break;
                case 2:
                    Idea.twoAD=AR;
                    Idea.ApproverId=newapprover.UserId;
                    break;
                case 3:
                    Idea.threeAD=AR;
                    Idea.ApproverId=newapprover.UserId;
                    break;
                case 4:
                    Idea.fourAD=AR;
                    Idea.ApproverId=newapprover.UserId;
                    break;
                case 5:
                    Idea.fiveAD=AR;
                    Idea.ApproverId=newapprover.UserId;
                    break;
                default:
                    break;
            }
            dbContext.Update(Idea);
            dbContext.SaveChanges();
            return Redirect($"/ideaprofile/{id}");

        }
/////////////////////////////////////////////////////// POST PROFILE PAGE MESSAGE BOARD ///////////////////////

        [HttpPost]
        [Route("messages/{id}")]
        public IActionResult Messages(Message Submission, int id)
            {
                System.Console.WriteLine("0000000000000000000000000 enter function 000000000000000000000000000000000");
                dbContext.Message.Add(Submission);
                dbContext.SaveChanges();
                return Redirect($"/ideaprofile/{id}");
            }

///////////////////////////////////////////////////////Form for new Idea Submision  ///////////////////////

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
            ViewBag.approvers=dbContext.Users.Where(a=>a.departId ==departId && a.Rank < rank).OrderByDescending(r=> r.Rank);

            return View("newidea");
        }
                /////////////////////////////////////////////////////// Proccess New Idea Form ///////////////////////

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
            List <Experiment> Experiment =dbContext.Experiment.Where( u => u.IdeaId == id).ToList();
            ViewBag.Experiment = Experiment;
            ViewBag.id=id;
     
            

            return View();
        }
/////////////////////////////////////////////////////// POST EXPERITMENT ///////////////////////

        [HttpPost]
        [Route("addexperiment/{id}")]
        public IActionResult AddExperiment(Experiment ExperimentSubmission, int id)
        {
            System.Console.WriteLine("************************************** Enters Function ***********************");
            if(HttpContext.Session.GetString("Login")==null || HttpContext.Session.GetString("Login")!="True")
                {
                    return Redirect("/");
                }
            dbContext.Add(ExperimentSubmission);
            dbContext.SaveChanges();
            System.Console.WriteLine("************************************** Saves Data ***********************");



            return Redirect($"/Experiment/{id}");

        }
        
    }
}