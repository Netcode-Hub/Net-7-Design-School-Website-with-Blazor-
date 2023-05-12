using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Api.Data;
using SchoolApp.Logic.Models;
using SchoolApp.Logic.Response;
using SchoolApp.Logic.ViewModels;

namespace SchoolApp.Api.Controllers
{
    [Route("codem/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public ContactController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddComment(ContactViewModels model)
        {
            if(model != null)
            {
                var m = new Contact
                {
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message
                };
                appDbContext.Contacts.Add(m);
                await appDbContext.SaveChangesAsync();
                return Ok(new ServiceResponse { Message = "Message Sent!" });
            }
            return BadRequest(new ServiceResponse { Success = false, Message = "Error Occured!" }); 
        }

    }
}
