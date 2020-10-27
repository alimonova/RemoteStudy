using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Dto
{
    public class LessonDto
    {
        public Guid Id { get; set; }
        public DateTime DateTimeCreation { get; set; }
        public string Text { get; set; }
    }
}
