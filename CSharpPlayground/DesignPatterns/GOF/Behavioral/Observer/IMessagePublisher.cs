using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.Observer
{
    public interface IMessagePublisher
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void NotifySubscribers();
    }
}
