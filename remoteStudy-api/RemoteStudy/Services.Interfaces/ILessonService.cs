using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services.Interfaces
{
    public interface ILessonService
    {
        IEnumerable<Lesson> GetLessons();
        Lesson GetLessonById(Guid id);
        Lesson CreateLesson(Lesson lesson);
        Lesson UpdateLesson(Lesson lesson);
        IEnumerable<Lesson> GetLessonsByCourseId(Guid courseId);
        void Delete(Guid id);
    }
}
