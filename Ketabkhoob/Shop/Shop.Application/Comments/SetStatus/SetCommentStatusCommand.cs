using Common.Application;
using Shop.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.SetStatus
{
    public record SetCommentStatusCommand(long CommentId, CommentStatus CommentStatus) :IBaseCommand;
}
