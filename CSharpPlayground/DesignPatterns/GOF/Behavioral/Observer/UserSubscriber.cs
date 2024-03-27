using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.Observer
{
    public class UserSubscriber : IObserver
    {
        private readonly string _name;

        public UserSubscriber(string name)
        {
            _name = name;
        }

        public void Update(string? message)
        {
            Console.WriteLine($"{_name} received a message: {message}");
        }
    }
}
