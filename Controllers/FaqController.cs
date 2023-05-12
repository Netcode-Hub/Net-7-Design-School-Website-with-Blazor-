using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Api.Data;
using SchoolApp.Logic.Models;
using SchoolApp.Logic.Response;
using SchoolApp.Logic.ViewModels;

namespace SchoolApp.Api.Controllers
{
    [Route("codem/[controller]")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public FaqController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddFaq(FaqViewModel model)
        {
            if(model != null)
            {
                var m = new Faq
                {
                    Question = model.Question,
                    Explanation = model.Explanation
                };
                appDbContext.Questions.Add(m);
                await appDbContext.SaveChangesAsync();
                return Ok(new ServiceResponse { Success = false, Message = "FAQ created!" });
            }
            return BadRequest(new ServiceResponse { Success = false, Message = "Error Occured!" });
        }

        [HttpGet]
        public async Task<ActionResult<List<Faq>>> GetFaqs()
        {
            return Ok(await appDbContext.Questions.ToListAsync());
        }
    }
}
