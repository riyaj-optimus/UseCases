using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UseCase.Data;

namespace UseCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _userDbContext;
        public UserController(UserDbContext userDbContext)
        {
            this._userDbContext = userDbContext;
        }

        //user record insertion 
        [HttpPost("")]
        public async Task<IActionResult> UserRecordInsertion([FromBody] User us)
        {
            _userDbContext.Users.Add(us);
            await _userDbContext.SaveChangesAsync();
            return Ok();
        }
        //fetching all the records of the user table 
        [HttpGet("")]
        public async Task<IActionResult> GetAllTheRec()
        {
            var res = await _userDbContext.Users.ToListAsync();
            return Ok(res);
        }

        //fetching user by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var res = await _userDbContext.Users.FindAsync(id);
            if (res == null)
            {
                return NotFound(new { message = $"User with ID {id} not found." });
            }
            return Ok(res);
        }
        //updating the user
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserDetail([FromRoute] int id, [FromBody] User us) {

            var data = await _userDbContext.Users.FirstOrDefaultAsync(x => x.ID == id);

            if (data == null)
            {
                return NotFound();
            }

            data.Name = us.Name;
            await _userDbContext.SaveChangesAsync();
            return Ok(us);


        }

        //deleting the user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var us = await _userDbContext.Users.FirstOrDefaultAsync(u => u.ID == id);
            if(us == null)
            {
                return NotFound();  
            }
            _userDbContext.Users.Remove(us);    
            await _userDbContext.SaveChangesAsync();
            return Ok();
        }

        //get Role associated with each user - 
        [HttpGet("roles")]
        public async Task<IActionResult> GetRolesWithUsers()
        {
            
            var roles = await _userDbContext.Roles.Include(r => r.User).ToListAsync();

            return Ok(roles);
        }



    }
}
