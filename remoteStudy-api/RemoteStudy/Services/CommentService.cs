using RemoteStudy.Models;
using RemoteStudy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services
{
    public class CommentService : ICommentService
    {
        private readonly RemoteStudyContext _commentcontext;

        public CommentService(RemoteStudyContext commentcontext)
        {
            _commentcontext = commentcontext;
        }

        public IEnumerable<Comment> GetComments()
        {
            return _commentcontext.Comments;
        }

        public IEnumerable<Comment> GetCommentsByLessonId(Guid lessonId)
        {
            var comments = GetComments().Where(x => x.LessonId == lessonId);
            return comments;
        }

        public Comment GetCommentById(Guid id)
        {
            var comment = GetComments().Where(x => x.Id == id).First();
            return comment;
        }

        public Comment CreateComment(Comment comment)
        {
            _commentcontext.Comments.Add(comment);
            _commentcontext.SaveChanges();

            return comment;
        }

        public Comment UpdateComment(Comment comment, Guid userId)
        {
            if (_commentcontext.Comments.First(x => x.Id == comment.Id).UserId == userId)
            {
                _commentcontext.Comments.Update(comment);
                _commentcontext.SaveChanges();
            }

            return comment;
        }

        public void Delete(Guid Id, Guid userId)
        {
            var comment = GetCommentById(Id);
            if (comment != null && _commentcontext.Comments.First(x=>x.Id == Id).UserId == userId)
            {
                _commentcontext.Comments.Remove(comment);
                _commentcontext.SaveChanges();
            }   
        }
    }
}
