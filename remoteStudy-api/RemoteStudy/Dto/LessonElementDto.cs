using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Dto
{
    public class LessonElementDto
    {
        public Guid Id { get; set; }
        public string ElementLink { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
