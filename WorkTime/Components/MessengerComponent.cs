using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkTime.Core.Interfaces;

namespace WorkTime.Components
{
	public class MessengerComponent : IMessenger
	{

		private Dictionary<Type, List<WeakReference>> SubscriberStore { get; } = new Dictionary<Type, List<WeakReference>>();

		public Task PublishAsync<T>(T message) where T : class
		{
			return Task.Factory.StartNew(async () =>
			{
				if (SubscriberStore.TryGetValue(typeof(T), out var subScribers))
				{
					var shouldremove = new List<WeakReference>();
					foreach (WeakReference subscriber in subScribers)
					{
						if (subscriber.IsAlive)
							//the subscriber exists
							await ((ISubscribe<T>)subscriber.Target).OnMessage(message);
						else
							// the subscriber already destroyed
							shouldremove.Add(subscriber);
						
					}
					shouldremove.ForEach(wr => subScribers.Remove(wr));
				}
			});
		}

		public void Subscribe<T>(ISubscribe<T> Subscriber) where T : class
		{
			if (SubscriberStore.TryGetValue(typeof(T), out var subScribers))
			{
				subScribers.Add(new WeakReference(Subscriber));
			}
			else
			{
				subScribers = new List<WeakReference>();
				subScribers.Add(new WeakReference(Subscriber));
				SubscriberStore.Add(typeof(T), subScribers);
			}
		}
	}
}
