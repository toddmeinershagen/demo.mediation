using MediatR;

namespace Demo.Mediation.Handlers
{
    public class Request<TEntity, TInput> : IRequest
    {
        public Request(TEntity entity, TInput input)
        {
            Entity = entity;
            Input = input;
        }

        public TEntity Entity { get; }
        public TInput Input { get; }
    }
}