using MediatR;

namespace RailroadStation.TestTask.Application.Contracts.Messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
