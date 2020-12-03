using RemoteStudy.Models;
using RemoteStudy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services
{
    public class LessonService : ILessonService
    {
        private readonly RemoteStudyContext _lessoncontext;

        public LessonService(RemoteStudyContext lessoncontext)
        {
            _lessoncontext = lessoncontext;
        }

        public IEnumerable<Lesson> GetLessons()
        {
            return _lessoncontext.Lessons;
        }

        public IEnumerable<Lesson> GetLessonsByCourseId(Guid courseId)
        {
            return _lessoncontext.Lessons.Where(x=>x.CourseId == courseId);
        }

        public Lesson GetLessonById(Guid id)
        {
            var lesson = GetLessons().Where(x => x.Id == id).First();
            return lesson;
        }

        public Lesson CreateLesson(Lesson lesson)
        {
            _lessoncontext.Lessons.Add(lesson);
            _lessoncontext.SaveChanges();

            return lesson;
        }

        public Lesson UpdateLesson(Lesson lesson)
        {
            _lessoncontext.Lessons.Update(lesson);
            _lessoncontext.SaveChanges();
            return lesson;
        }

        public void Delete(Guid Id)
        {
            var lesson = GetLessonById(Id);
            if (lesson != null)
            {
                _lessoncontext.Lessons.Remove(lesson);
                _lessoncontext.SaveChanges();
            }
        }
    }
}
