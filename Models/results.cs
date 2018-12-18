
// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.IO;
// using System.Threading;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Identity;

// namespace inkling.Models

// {
// public interface IFormFile
// {
//     string ContentType { get; }
//     string ContentDisposition { get; }
//     IHeaderDictionary Headers { get; }
//     long Length { get; }
//     string Name { get; }
//     string FileName { get; }
//     Stream OpenReadStream();
//     void CopyTo(Stream target);
//     Task CopyToAsync(Stream target, CancellationToken cancellationToken = null);
// }

// public class ApplicationUser : IdentityUser
// {
//     public byte[] AvatarImage { get; set; }
// }

// public class RegisterViewModel
// {
//     // other properties omitted

//     public IFormFile AvatarImage { get; set; }
// }
// }