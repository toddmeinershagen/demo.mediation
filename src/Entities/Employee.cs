using MediatR;

namespace Demo.Mediation.Entities
{
    public class Employee : Entity<Employee>
    {
        public Employee(IMediator mediator) : base(mediator)
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
