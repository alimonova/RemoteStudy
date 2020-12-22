using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services.Interfaces
{
    public interface ICourseTagService
    {
        IEnumerable<CourseTag> GetCourseTags();
        CourseTag GetCourseTagById(Guid id);
        CourseTag CreateCourseTag(CourseTag courseTag);
        void Delete(Guid id, Guid userId);
    }
}
