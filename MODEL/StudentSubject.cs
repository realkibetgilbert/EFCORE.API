﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class StudentSubject
    {
        public long StudentId { get; set; }
        public Student Student { get; set; }
        public long SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
