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



    }
}