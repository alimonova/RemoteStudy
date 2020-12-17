using Microsoft.AspNetCore.Http;
using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCourses(PageFilterSortModel parameter);
        Course GetCourseById(Guid id);
        IEnumerable<Course> GetCoursesByTeacherId(Guid teacherId);
        Course CreateCourse(Course channel);
        Course UpdateCourse(Course channel);
        void Delete(Guid id);
    }
}
