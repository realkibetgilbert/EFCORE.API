using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class StudentDetails
    {
        public long Id { get; set; }

        public string Address { get; set; }

        public string AddressInformation { get; set; }

        public long StudentId { get; set; }
        public Student Student { get; set; }
    }
}
