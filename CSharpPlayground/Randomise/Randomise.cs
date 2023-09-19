using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Randomise
{
    public class Randomise
    {
        public void Driver()
        {
            GeneratePeople();
        }

        private void PseudoRandomInts()
        {
            // Not thread safe so you would need to wrap in a thread safe manner.
            var random = new Random();
            for (int i = 0; i < 10; i++) 
            {
                GeneratePseudoRandomNumber(random);
            }
            Console.ReadLine();
        }

        private void GeneratePseudoRandomNumber(Random random)
        {
            Console.WriteLine(random.Next(11));
        }

        private void PseudoRandomDoubles()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                GeneratePseudoRandomDouble(random);
            }
            Console.ReadLine();
        }

        private void GeneratePseudoRandomDouble(Random random)
        {
            Console.WriteLine(random.NextDouble() * 10);
        }

        private void GeneratePeople()
        {
            var random = new Random();
            var people = new List<PersonModel>
            {
                new PersonModel { FirstName = "Tim" },
                new PersonModel { FirstName = "Sue" },
                new PersonModel { FirstName = "Mary" },
                new PersonModel { FirstName = "George" },
                new PersonModel { FirstName = "Jane" },
                new PersonModel { FirstName = "Nancy" },
                new PersonModel { FirstName = "Bob" },
            };

            var shuffledPeople = people.OrderBy(x => random.Next());

            foreach (var person in shuffledPeople) 
            {
                Console.WriteLine(person.FirstName);
            }
        }

        public class PersonModel
        {
            public string FirstName { get; set; }
        }
    }    
}
