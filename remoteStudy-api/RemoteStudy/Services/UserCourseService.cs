using RemoteStudy.Models;
using RemoteStudy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services
{
    public class UserCourseService : IUserCourseService
    { 
        private readonly RemoteStudyContext _usercoursecontext;

        public UserCourseService(RemoteStudyContext coursetagcontext)
        {
            _usercoursecontext = coursetagcontext;
        }

        public IEnumerable<UserCourse> GetUserCourses()
        {
            return _usercoursecontext.UserCourses;
        }

        public UserCourse GetUserCourseById(Guid id)
        {
            return _usercoursecontext.UserCourses.Where(x => x.Id == id).First();
        }

        public UserCourse CreateUserCourse(UserCourse userCourse)
        {
            _usercoursecontext.UserCourses.Add(userCourse);
            _usercoursecontext.SaveChanges();

            return userCourse;
        }

        public void Delete(Guid id)
        {
            var coursetag = GetUserCourseById(id);
            if (coursetag != null)
            {
                _usercoursecontext.UserCourses.Remove(coursetag);
                _usercoursecontext.SaveChanges();
            }
        }

        public UserCourse AddCourseToFavourites(Guid userId, Guid courseId)
        {
            var userCourse = _usercoursecontext.UserCourses
                .Where(x => x.UserId == userId && x.CourseId == courseId).First();
            userCourse.IsFavourite = true;

            _usercoursecontext.UserCourses.Update(userCourse);
            _usercoursecontext.SaveChanges();
            return userCourse;
        }

        public IEnumerable<UserCourse> GetFavouriteCourses(Guid userId)
        {
            return _usercoursecontext.UserCourses.Where(x => x.IsFavourite).ToList();
        }
    }
}
