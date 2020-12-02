using RemoteStudy.Models;
using RemoteStudy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly RemoteStudyContext _subjectcontext;

        public SubjectService(RemoteStudyContext subjectcontext)
        {
            _subjectcontext = subjectcontext;
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _subjectcontext.Subjects;
        }

        public Subject GetSubjectByCourseId(Guid courseId)
        {
            var subjectId = _subjectcontext.Courses.Where(x=>x.Id == courseId).First().SubjectId;
            return _subjectcontext.Subjects.Where(x=>x.Id == subjectId).First();
        }

        public Subject GetSubjectById(Guid id)
        {
            var subject = GetSubjects().Where(x => x.Id == id).First();
            return subject;
        }

        public Subject CreateSubject(Subject subject)
        {
            _subjectcontext.Subjects.Add(subject);
            _subjectcontext.SaveChanges();

            return subject;
        }

        public Subject UpdateSubject(Subject subject)
        {
            _subjectcontext.Subjects.Update(subject);
            _subjectcontext.SaveChanges();

            return subject;
        }

        public void Delete(Guid Id)
        {
            var subject = GetSubjectById(Id);
            if (subject != null)
            {
                _subjectcontext.Subjects.Remove(subject);
                _subjectcontext.SaveChanges();
            }
        }
    }
}
