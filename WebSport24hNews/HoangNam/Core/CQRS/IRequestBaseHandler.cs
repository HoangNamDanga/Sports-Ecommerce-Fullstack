using MediatR;

namespace WebSport24hNews.HoangNam.Core.CQRS
{
    public interface IRequestBaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }
}
