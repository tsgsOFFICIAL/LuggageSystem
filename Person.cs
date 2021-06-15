using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageSystem
{
    public class Person
    {
        // Enum
        public enum Sex
        {
            Male,
            Female
        }

        // Properties
        public string Name { get; private set; }
        public Sex Gender { get; private set; }
        
        // Constructor
        public Person(string name, Sex gender)
        {
            Name = name;
            Gender = gender;
        }
    }
}
