using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using inkling.Models;
using System.Linq;

namespace inkling.Controllers
{
    public class UsersController : Controller
    {
        private InklingContext dbContext;
        // here we can "inject" our context service into the constructor
        public UsersController(InklingContext context)
        {
            dbContext = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
