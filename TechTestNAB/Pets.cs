using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestNAB
{
    class Pets
    {
        public string Name { get; set; }
        public PetType Type { get; set; }
    }

    enum PetType
    {
        Cat,
        Dog,
        Fish
    }
}
