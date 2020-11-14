using System;

namespace WorkTime.Interfaces
{
	public interface IMessenger
	{
		void Publish<TMessage>(TMessage message) where TMessage : class;
		void Subscribe<TMessage>(Action<TMessage> action) where TMessage : class;
		void UnSubscribe<TMessage>(object subscriber) where TMessage : class;
	}
}
