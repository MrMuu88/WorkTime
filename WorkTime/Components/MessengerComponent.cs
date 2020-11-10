using System;
using System.Collections.Generic;
using System.Linq;
using WorkTime.Interfaces;

namespace WorkTime.Components
{
	public class MessengerComponent:IMessenger
	{
		public Dictionary<Type,List<Action<object>>> SubscriberStore { get; private set; } = new Dictionary<Type,List<Action<object>>>();

		public void Subscribe<TMessage>(Action<dynamic> action) where TMessage:class
		{
			if (SubscriberStore.ContainsKey(typeof(TMessage)))
				SubscriberStore[typeof(TMessage)].Add(action);
			else
				SubscriberStore.Add(typeof(TMessage),new List<Action<object>>() {action});
		}

		public void Publish<TMessage>(TMessage message) where TMessage : class
		{
			foreach (var action in SubscriberStore[typeof(TMessage)]) {
					action(message);
			}
		}

		public void UnSubscribe<TMessage>(object subscriber) where TMessage : class 
		{
			var shouldRemove = SubscriberStore[typeof(TMessage)].Where(action => action.Target == subscriber).ToList();
			shouldRemove.ForEach(removeItem => SubscriberStore[typeof(TMessage)].Remove(removeItem));
		}
	}
}
