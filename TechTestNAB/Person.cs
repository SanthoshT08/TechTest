using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestNAB
{
    class Person
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public List<Pets> Pets { get; set; }
    }

    enum Gender
    {
        Male,
        Female
    }
}
