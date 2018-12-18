// using System;
// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Http;
// using Microsoft.EntityFrameworkCore;
// using inkling.Models;
// using System.Linq;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Authorization;
// using System.Threading.Tasks;

// namespace inkling.Controllers
// {

// [HttpPost]
// [AllowAnonymous]
// [ValidateAntiForgeryToken]
// public async Task<IActionResult> Register(RegisterViewModel model)
// {
//     ViewData["ReturnUrl"] = returnUrl;
//     if  (ModelState.IsValid)
//     {
//         var user = new ApplicationUser {
//         UserName = model.Email,
//         Email = model.Email
//         };
//         using (var memoryStream = new MemoryStream())
//         {
//             await model.AvatarImage.CopyToAsync(memoryStream);
//             user.AvatarImage = memoryStream.ToArray();
//         }
//     // additional logic omitted

//     // Don't rely on or trust the model.AvatarImage.FileName property 
//     // without validation.
// }
// }
// }