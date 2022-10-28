using MediatR;
using TodoAPIMediatr.Converter;
using TodoAPIMediatr.CQRS.Queries;
using TodoAPIMediatr.Interfaces;

namespace TodoAPIMediatr.CQRS.Handlers
{
    public class GetBase64StringQueryHandler : IRequestHandler<GetBase64StringQuery, String>
    {
        private IFileRepository _fileRepository { get; set; } = default!;

        public GetBase64StringQueryHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public Task<string> Handle(GetBase64StringQuery request, CancellationToken cancellationToken)
        {
            var result = _fileRepository.PdfToStringAsync();
            return Task.FromResult(result);
        }
    }
}
