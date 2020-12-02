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
    }
}
