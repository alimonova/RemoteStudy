using RemoteStudy.Models;
using RemoteStudy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services
{
    public class TagService : ITagService
    {
        private readonly RemoteStudyContext _tagcontext;

        public TagService(RemoteStudyContext tagcontext)
        {
            _tagcontext = tagcontext;
        }

        public IEnumerable<Tag> GetTags()
        {
            return _tagcontext.Tags;
        }

        public Tag GetTagById(Guid id)
        {
            var tag = GetTags().Where(x => x.Id == id).First();
            return tag;
        }

        public Tag CreateTag(Tag tag)
        {
            _tagcontext.Tags.Add(tag);
            _tagcontext.SaveChanges();

            return tag;
        }

        public Tag UpdateTag(Tag tag)
        {
            _tagcontext.Tags.Update(tag);
            _tagcontext.SaveChanges();

            return tag;
        }

        public void Delete(Guid Id)
        {
            var tag = GetTagById(Id);
            if (tag != null)
            {
                _tagcontext.Tags.Remove(tag);
                _tagcontext.SaveChanges();
            }
        }

        public IEnumerable<Tag> GetTagsByCourseId(Guid courseId)
        {
            IEnumerable<Tag> tags = new List<Tag>();
            var courseTags = _tagcontext.CourseTags.Where(x => x.CourseId == courseId);

            foreach (var courseTag in courseTags)
            {
                tags.Append(_tagcontext.Tags.First(x => x.Id == courseTag.TagId));
            }

            return tags;
        }
    }
}
