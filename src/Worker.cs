using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Mediation.Entities;
using Demo.Mediation.Inputs;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace Demo.Mediation
{
    public class Worker : IHostedService
    {
        private readonly IMediator _mediator;
        private readonly IHostApplicationLifetime _appLifetime;

        public Worker(IMediator mediator, IHostApplicationLifetime appLifeTime)
        {
            _mediator = mediator;
            _appLifetime = appLifeTime;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(OnStarted);
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _appLifetime.ApplicationStopped.Register(OnStopped);

            var employee = new Employee(_mediator) {FirstName = "Todd", LastName = "Meinershagen", Age = 48};
            
            Console.WriteLine($"Employee:  {employee.FirstName} {employee.LastName}");
            var input = new SampleInput {FirstName = "Adolfo", LastName = "Solis"};
            await employee.Handle(input);
            Console.WriteLine($"Employee:  {employee.FirstName} {employee.LastName}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            Console.WriteLine("OnStarted has been called.");

            // Perform post-startup activities here
        }

        private void OnStopping()
        {
            Console.WriteLine("OnStopping has been called.");

            // Perform on-stopping activities here
        }

        private void OnStopped()
        {
            Console.WriteLine("OnStopped has been called.");

            // Perform post-stopped activities here
        }
    }
}