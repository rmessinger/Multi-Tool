using System;
using System.Collections.Generic;
using System.Threading;
using Framework;

namespace MessageHub
{
    public sealed class MessageHub
    {
        private Dictionary<Type, HashSet<Action<Message>>> subscribers;

        public MessageHub()
        {
            subscribers = new Dictionary<Type, HashSet<Action<Message>>>();
        }

        public void Subscribe(Type t, Action<Message> handler)
        {
            if (!subscribers.ContainsKey(t))
            {
                subscribers.Add(t, new HashSet<Action<Message>>());
            }

            subscribers[t].Add(handler);
        }

        public void Unsubscribe(Type t, Action<Message> handler)
        {
            if (subscribers.ContainsKey(t))
            {
                subscribers[t].Remove(handler);
            }
        }

        public void Publish(Message message)
        {
            Thread loopThread = new Thread(() => NotifySubscribers(message));
            loopThread.Start(message);
        }

        private void NotifySubscribers(Message message)
        {
            foreach (Action<Message> subscriber in subscribers[message.GetType()])
            {
                Thread invokeThread = new Thread(() => InvokeHandler(subscriber, message));
                invokeThread.Start();
            }
        }

        private void InvokeHandler(Action<Message> subscriber, Message message)
        {
            try
            {
                subscriber.Invoke(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
