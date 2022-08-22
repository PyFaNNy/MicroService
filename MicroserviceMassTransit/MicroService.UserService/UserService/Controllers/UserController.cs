using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.DbContext;
using UserService.ViewModels;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public UserController(IMapper mapper, IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get request to get all people
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetModels()
        {
            var users = _mapper.Map<List<UserViewModel>>(await _dbContext.Users.ToListAsync());
            return Ok(users);
        }
    }
}
