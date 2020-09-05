using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElementarySchoolQuizzer.Data.Persistence
{
    public interface IQuizz
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Owner { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; }
        bool Published { get; set; }
    }
}
