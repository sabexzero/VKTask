using Microsoft.AspNetCore.Mvc;
using VKTaskOne.Entities.Concrete;
using VKTaskOne.Services.Concrete;
using VKTaskOne.Services.Abstract;

namespace VKTaskOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("AllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> Index()
        {
            var list = await _userService.GetAllUsers();
            return Json(list);
        }
        [HttpGet("OneUser")]
        public async Task<ActionResult<User>> Details(Guid id)
        {
            var user = await _userService.GetUser(id);
            return Json(user);
        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult<User>> Create(User user)
        {
            await _userService.CreateUser(user);
            await _userService.SaveChanges();
            return Ok(user);
        }
        [HttpDelete("DeleteUser")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _userService.DeleteUser(id);
            await _userService.SaveChanges();
            return Ok();
        }
    }
}