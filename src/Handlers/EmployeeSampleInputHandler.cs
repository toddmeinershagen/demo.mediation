using System.Threading;
using System.Threading.Tasks;
using Demo.Mediation.Entities;
using Demo.Mediation.Inputs;
using MediatR;

namespace Demo.Mediation.Handlers
{
    public class EmployeeSampleInputHandler : AsyncRequestHandler<Request<Employee, SampleInput>>
    {
        protected override Task Handle(Request<Employee, SampleInput> request, CancellationToken cancellationToken)
        {
            request.Entity.FirstName = request.Input.FirstName;
            request.Entity.LastName = request.Input.LastName;
            return Task.CompletedTask;
        }
    }
}