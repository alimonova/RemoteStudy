using RemoteStudy.Models;
using RemoteStudy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services
{
    public class CourseService : ICourseService
    {
        private readonly RemoteStudyContext _coursecontext;

        public CourseService(RemoteStudyContext coursecontext)
        {
            _coursecontext = coursecontext;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _coursecontext.Courses;
        }

        public Course GetCourseById(Guid id)
        {
            var course = GetCourses().Where(x => x.Id == id).First();
            return course;
        }

        public Course CreateCourse(Course course)
        {
            _coursecontext.Courses.Add(course);
            _coursecontext.SaveChanges();
            
            return course;
        }

        public Course UpdateCourse(Course course)
        {
            _coursecontext.Courses.Update(course);
            return course;
        }

        public void Delete(Guid Id)
        {
            var course = GetCourseById(Id);
            if (course != null)
            {
                _coursecontext.Courses.Remove(course);
                _coursecontext.SaveChanges();
            }
        }

        public IEnumerable<Course> GetCoursesByTeacherId(Guid userId)
        {
            return _coursecontext.Courses.Where(x => x.TeacherId == userId);
        }
    }
}
