using RemoteStudy.Models;
using RemoteStudy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services
{
    public class CourseTagService : ICourseTagService
    {
        private readonly RemoteStudyContext _coursetagcontext;

        public CourseTagService(RemoteStudyContext coursecontext)
        {
            _coursetagcontext = coursecontext;
        }

        public IEnumerable<CourseTag> GetCourseTags()
        {
            return _coursetagcontext.CourseTags;
        }

        public CourseTag GetCourseTagById(Guid id)
        {
            return _coursetagcontext.CourseTags.Where(x => x.Id == id).First();
        }

        public CourseTag CreateCourseTag(CourseTag courseTag)
        {
            _coursetagcontext.CourseTags.Add(courseTag);
            _coursetagcontext.SaveChanges();

            return courseTag;
        }

        public void Delete(Guid id, Guid userId)
        {
            var coursetag = GetCourseTagById(id);
            if (coursetag != null && _coursetagcontext.Courses.First(x=>x.Id == id).TeacherId == userId)
            {
                _coursetagcontext.CourseTags.Remove(coursetag);
                _coursetagcontext.SaveChanges();
            }
        }
    }
}
