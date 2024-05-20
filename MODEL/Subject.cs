using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Subject
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
