using ENITY.Models;
using Microsoft.AspNetCore.Mvc;

namespace ENITY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext userContext;
        public UserController(UserContext userContext)
        {
            this.userContext = userContext;
        }

        [HttpGet]
        public List<UserModel> Get()
        {
            return userContext.Users.ToList();
        }

        [HttpGet("Get_by_id")]
        public IActionResult GetbyId(int id)
        {
            var result = userContext.Users.FirstOrDefault(x => x.Id == id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddUser(UserModel model)
        {
            userContext.Add(model);
            userContext.SaveChanges();
            return Ok();
        }

        [HttpPut("edit")]
        public IActionResult EditUser(UserModel model)
        {
            var toEdit = userContext.Users.FirstOrDefault(x => x.Id == model.Id);
            toEdit.Name = model.Name;
            toEdit.Place = model.Place;
            userContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var toDelete = userContext.Users.FirstOrDefault(x => x.Id == id);
            userContext.Users.Remove(toDelete);
            userContext.SaveChanges();
            return NoContent();
        }
    }
}
