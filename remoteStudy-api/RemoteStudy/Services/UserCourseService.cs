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

        public double RateCourse(Guid userId, Guid courseId, double rate)
        {
            _usercoursecontext.UserCourses.Where(x => x.CourseId == courseId && x.UserId == userId).First().Rate = rate;
            return CalculateCourseRating(courseId);
        }
        public double CalculateCourseRating(Guid courseId)
        {
            var userCourses = _usercoursecontext.UserCourses.Where(x => x.CourseId == courseId).ToList();

            var sum = 0.0;
            var num = 0;
            foreach (var x in userCourses)
            {
                if (x.Rate != 0.0)
                {
                    sum += x.Rate;
                    num++;
                }
            }
            if (num > 0)
            {
                var rating = sum / num;
                _usercoursecontext.Courses.Where(x => x.Id == courseId).First().Rating = rating;
                _usercoursecontext.SaveChanges();
                return rating;
            }

            return 0.0;
        }

        public UserCourse GetRequests(Guid courseId)
        {
            return _usercoursecontext.UserCourses.Where(x => x.Id == courseId && x.HasAccess == false).First();
        }

        public void AcceptRequest(Guid userCourseId)
        {
            _usercoursecontext.UserCourses.Where(x => x.Id == userCourseId).First().HasAccess = true;
            _usercoursecontext.SaveChanges();
        }

        public bool UserHasAccessToCourse(Guid userId, Guid courseId)
        {
            return _usercoursecontext.UserCourses.First(x => x.UserId == userId && x.CourseId == courseId).HasAccess;
        }
    }
}
