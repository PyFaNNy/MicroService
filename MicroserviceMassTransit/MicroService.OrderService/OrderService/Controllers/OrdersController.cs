using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.DbContext;
using OrderService.ViewModel;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public OrdersController(IMapper mapper, IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet("[action]/{userId:guid}")]
        public async Task<IActionResult> GetOrdersForUser(Guid userId)
        {
            var orders = _mapper.Map<IEnumerable<OrderViewModel>>(await _dbContext.Orders.Where(x => x.UserId == userId).ToListAsync());

            return Ok(orders);
        }
    }
}
