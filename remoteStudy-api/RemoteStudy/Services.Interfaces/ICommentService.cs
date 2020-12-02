using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetComments();
        Comment GetCommentById(Guid id);
        Comment CreateComment(Comment comment);
        Comment UpdateComment(Comment comment);
        IEnumerable<Comment> GetCommentsByLessonId(Guid lessonId);
        void Delete(Guid id);
    }
}
