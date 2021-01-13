using System.Threading.Tasks;
using Demo.Mediation.Handlers;
using MediatR;

namespace Demo.Mediation.Entities
{
    public abstract class Entity<TEntity> where TEntity : class
    {
        private readonly IMediator _mediator;

        protected Entity(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle<TInput>(TInput input)
        {
            var request = new Request<TEntity, TInput>(this as TEntity, input);
            await _mediator.Send(request);
        }
    }
}