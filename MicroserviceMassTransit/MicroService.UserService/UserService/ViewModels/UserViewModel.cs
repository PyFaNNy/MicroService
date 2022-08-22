using MassTransit.Contracts.ViewModels;

namespace UserService.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}
