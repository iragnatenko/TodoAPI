using MediatR;
using TodoAPIMediatr.Entity;
using TodoAPIMediatr.Model;

namespace TodoAPIMediatr.CQRS.Commands
{
    public class AddPdfCommand : IRequest<DataClsEntity>
    {
        public DataCls data { get; set; } = default!;

    }
}
