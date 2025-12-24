using MediatR;

namespace WebSport24hNews.HoangNam.Core.CQRS
{
    public interface ICommandBase<T> : IRequest<T>, IBaseRequest
    {
    }
}
