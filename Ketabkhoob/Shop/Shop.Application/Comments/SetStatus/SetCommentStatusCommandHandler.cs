using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.SetStatus
{
    public class SetCommentStatusCommandHandler : IBaseCommandHandler<SetCommentStatusCommand>
    {
        private readonly ICommentRepository _repository;

        public SetCommentStatusCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(SetCommentStatusCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetTracking(request.CommentId);
            if (comment == null)
                return OperationResult.NotFound();
            comment.SetStatus(request.CommentStatus);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
