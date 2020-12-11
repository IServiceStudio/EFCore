using EFCore.Entity.Model;
using EFCore.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (userService.AddUser(user))
            {
                return Ok("ok");
            }
            return NotFound("添加失败");
        }
        public IActionResult Get(int id)
        {
            var user = userService.Find(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
