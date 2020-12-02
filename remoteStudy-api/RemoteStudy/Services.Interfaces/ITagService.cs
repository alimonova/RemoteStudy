using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services.Interfaces
{
    public interface ITagService
    {
        IEnumerable<Tag> GetTags();
        Tag GetTagById(Guid id);
        Tag CreateTag(Tag tag);
        Tag UpdateTag(Tag tag);
        void Delete(Guid id);
        //IEnumerable<Tag> GetTagsByCourseId(Guid courseId);
    }
}
