using MediatR;

namespace TodoAPIMediatr.CQRS.Queries
{
    public record GetBase64StringQuery : IRequest<String>;

}
