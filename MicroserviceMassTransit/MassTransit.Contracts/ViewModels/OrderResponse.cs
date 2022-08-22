namespace MassTransit.Contracts.ViewModels
{
    public class OrderResponse
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}
