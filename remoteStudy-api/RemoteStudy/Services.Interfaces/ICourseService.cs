using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCourses();
        Course GetCourseById(Guid id);
        IEnumerable<Course> GetCoursesByTeacherId(Guid teacherid);
       // IEnumerable<Tag> GetTagsByTagId(Guid tagId);
        Course CreateCourse(Course channel);
        Course UpdateCourse(Course channel);
        void Delete(Guid id);
    }
}
