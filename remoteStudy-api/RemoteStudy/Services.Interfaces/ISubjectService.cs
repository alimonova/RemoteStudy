using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubjects();
        Subject GetSubjectById(Guid id);
        Subject CreateSubject(Subject subject);
        Subject UpdateSubject(Subject subject);
        void Delete(Guid id);
    }
}
