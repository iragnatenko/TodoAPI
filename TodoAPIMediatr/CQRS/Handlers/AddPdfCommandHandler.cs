using MediatR;
using TodoAPIMediatr.CQRS.Commands;
using TodoAPIMediatr.Interfaces;
using TodoAPIMediatr.Entity;


namespace TodoAPIMediatr.CQRS.Handlers
{
    public class AddPdfCommandHandler : IRequestHandler <AddPdfCommand, DataClsEntity>
    {

        private IFileRepository _fileRepository { get; set; } = default!;
        public AddPdfCommandHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<DataClsEntity> Handle(AddPdfCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _fileRepository.StringToPdfAsync(request.data.Base64);

                DataClsEntity x = new DataClsEntity();
                x.Base64 = result;
 //               x.Fileextension = ".pdf";
 //               x.Filename = "newfile.pdf";
                return await Task.FromResult(x);


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

 
    }
}
