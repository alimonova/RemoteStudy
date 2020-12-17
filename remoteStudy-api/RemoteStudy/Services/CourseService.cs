﻿using Microsoft.AspNetCore.Http;
using RemoteStudy.Models;
using RemoteStudy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public IEnumerable<Course> GetCourses(PageFilterSortModel parameters)
        {
            var courses = _coursecontext.Courses.ToList();
            if (parameters.Name != "")
            {
                courses = courses.Where(x => x.Name.Contains(parameters.Name)).ToList();
            }
            
            if (parameters.TeacherId != "")
            {
                courses = courses.Where(x => x.TeacherId == Guid.Parse(parameters.TeacherId)).ToList();
            }

            if (parameters.SubjectId != "")
            {
                courses = courses.Where(x => x.SubjectId == Guid.Parse(parameters.SubjectId)).ToList();
            }

            if (parameters.TagIds != "")
            {
                List<string> tags = parameters.TagIds.Split(",").ToList();
                List<string> courseTags = parameters.TagIds.Split(",").ToList();

                foreach (var tag in tags)
                {
                    var courseTagsIds = _coursecontext.CourseTags.Where(x => x.TagId == Guid.Parse(tag)).ToList();
                    var courseIds = new List<Guid>();
                    courseTagsIds.ForEach(x => courseIds.Add(x.CourseId));

                    courses = courses.Where(y => courseIds.Contains(y.Id)).ToList();
                }
            }

            if (parameters.DateCreationAsc)
            {
                courses = courses.OrderBy(x=>x.CreationDateTime).ToList();
            }
            else if (parameters.DateCreationDesc)
            {
                courses = courses.OrderByDescending(x => x.CreationDateTime).ToList();
            }

            if (parameters.NameAsc)
            {
                courses = courses.OrderBy(x => x.Name).ToList();
            }
            else if (parameters.NameDesc)
            {
                courses = courses.OrderByDescending(x => x.Name).ToList();
            }

            if (parameters.RatingAsc)
            {
                courses = courses.OrderBy(x => x.Rating).ToList();
            }
            else if (parameters.RatingDesc)
            {
                courses = courses.OrderByDescending(x => x.Rating).ToList();
            }

            courses = courses.Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize).ToList();

            return courses;
        }

        public Course GetCourseById(Guid id)
        {
            var course = _coursecontext.Courses.Where(x => x.Id == id).First();
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
            _coursecontext.SaveChanges();

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

        public IEnumerable<Course> GetFavouriteCourses(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Course AddCourseToFavourites(Guid CourseId)
        {
            throw new NotImplementedException();
        }
    }
}
