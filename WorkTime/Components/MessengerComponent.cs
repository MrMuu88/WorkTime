using System;
using System.Collections.Generic;
using System.Linq;
using WorkTime.Interfaces;
using WorkTime.Messages;

namespace WorkTime.Components
{
	public class MessengerComponent:IMessenger
	{
		//canot cast Action<T> to Action<BaseMessage> hence a boxing is needed
		private Dictionary<Type,List<object>> SubscriberStore { get; set; } = new Dictionary<Type,List<object>>();

		public void Subscribe<TMessage>(Action<TMessage> action) where TMessage: class
		{
			if (SubscriberStore.ContainsKey(typeof(TMessage)))
				SubscriberStore[typeof(TMessage)].Add(action);
			else
				SubscriberStore.Add(typeof(TMessage),new List<object>() {action});
		}

		public void Publish<TMessage>(TMessage message) where TMessage : class
		{
			foreach (var action in SubscriberStore[typeof(TMessage)]) {
					((Action<TMessage>)action).Invoke(message);
			}
		}

		public void UnSubscribe<TMessage>(object subscriber) where TMessage : class
		{
			var shouldRemove = SubscriberStore[typeof(TMessage)].Where(action => ((Action<TMessage>)action).Target == subscriber).ToList();
			shouldRemove.ForEach(removeItem => SubscriberStore[typeof(TMessage)].Remove(removeItem));
		}
	}
}
