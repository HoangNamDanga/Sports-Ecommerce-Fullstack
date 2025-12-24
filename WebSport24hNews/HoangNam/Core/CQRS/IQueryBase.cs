using MediatR;

namespace WebSport24hNews.HoangNam.Core.CQRS
{
    public interface IQueryBase<T> : IRequest<T>, IBaseRequest
    {
    }
}
