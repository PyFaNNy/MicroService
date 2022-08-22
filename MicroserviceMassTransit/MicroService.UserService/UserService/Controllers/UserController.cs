using AutoMapper;
using MassTransit;
using MassTransit.Contracts.ViewModels;
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
        private readonly IRequestClient<OrderRequest> _requestClient;

        public UserController(IMapper mapper, IApplicationDbContext dbContext, IRequestClient<OrderRequest> requestClient)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _requestClient = requestClient;
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

        /// <summary>
        /// Get user with orders
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]/{userId:guid}")]
        public async Task<IActionResult> GetUserWithOrders(Guid userId)
        {
            var user = await _dbContext.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
            if (User == null)
            {
                return BadRequest();
            }

            var orders =await _requestClient.GetResponse<OrderResponse>(new OrderRequest { UserId = userId });

            var model = _mapper.Map<UserViewModel>(user);
            model.Orders = orders.Message.Orders;
            return Ok(model);
        }
    }
}
