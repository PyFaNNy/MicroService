namespace OrderService.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}
