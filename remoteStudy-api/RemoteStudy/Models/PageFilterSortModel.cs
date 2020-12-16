using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class PageFilterSortModel
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string TagIds { get; set; } = "";
        public string SubjectId { get; set; } = "";
        public string TeacherId { get; set; } = "";
        public string Name { get; set; } = "";
        public bool RatingAsc { get; set; } = false;
        public bool RatingDesc { get; set; } = false;
        public bool DateCreationAsc { get; set; } = false;
        public bool DateCreationDesc { get; set; } = false;
        public bool NameAsc { get; set; } = false;
        public bool NameDesc { get; set; } = false;
    }
}
