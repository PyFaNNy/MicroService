using AutoMapper;
using MassTransit;
using MassTransit.Contracts.ViewModels;
using OrderService.DbContext;
using System.Collections.Generic;

namespace OrderService.MassTrasit
{
    public class OrderConsumer : IConsumer<OrderRequest>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public OrderConsumer(IMapper mapper, IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<OrderRequest> context)
        {
            var userId = context.Message.UserId;
            var orders = _dbContext.Orders.Where(o => o.UserId == userId).ToList();

            var models = _mapper.Map<IEnumerable<OrderViewModel>>(orders);

            await context.RespondAsync<OrderResponse>(new OrderResponse
            {
                Orders = models
            });
        }
    }
}
