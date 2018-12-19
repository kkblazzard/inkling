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
        [Route("ideaprofile")]
        public IActionResult IdeaProfile()
        {


            return View();
        }

        [HttpGet]
        [Route("idea/form")]
        public IActionResult IdeaForm()
        {



            return View();
        }
        [HttpPost]
        [Route("idea/form/process")]
        public IActionResult IdeaFormProcess(Idea newIdea)
        {   
            dbContext.Ideas.Add(newIdea);
            dbContext.SaveChanges();
            int id=newIdea.IdeaId;

            return Redirect($"/idea/{id}");
        }
        [HttpGet]
        [Route("idea/{id}")]
        public IActionResult IdeaFormProcess(int id)
        {   
            var anidea=dbContext.Ideas.FirstOrDefault(i=>i.IdeaId == id);

            return View(anidea);
        }



/////////////////////////////////////////////////////// GET EDD PAGE ///////////////////////

        [HttpGet]
        [Route("edd")]
        public IActionResult Edd()
        {


            return View();
        }
    }
}