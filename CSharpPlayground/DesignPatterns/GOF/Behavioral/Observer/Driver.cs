/* In this example, MessagePublisher acts as the subject that notifies its 
* subscribers (UserSubscriber) whenever a new message is posted. 
* Subscribers implement the IObserver interface, allowing them to be notified. 
* This pattern decouples the publisher from its subscribers; 
* new subscribers can be added or removed at any time without changing the publisher's code, 
* adhering to the open/closed principle. */

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.Observer
{
    public static class Driver
    {
        public static void Run()
        {
            MessagePublisher publisher = new MessagePublisher();

            UserSubscriber alice = new UserSubscriber("Alice");
            UserSubscriber bob = new UserSubscriber("Bob");

            publisher.Subscribe(alice);
            publisher.Subscribe(bob);

            publisher.PostMessage("First message");

            publisher.Unsubscribe(bob);

            publisher.PostMessage("Second message");
        }
    }
}
