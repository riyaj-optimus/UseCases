using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UseCase.Data;

namespace UseCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly UserDbContext _userDbContext;

        public RoleController(UserDbContext userDbContext)
        {
            this._userDbContext = userDbContext;
        }
       

        //fetching all the records of the roles table 
        [HttpGet("")]
        public async Task<IActionResult> GetAllTheRec()
        {
            var res = await _userDbContext.Roles.ToListAsync();
            return Ok(res);
        }
    }
}
