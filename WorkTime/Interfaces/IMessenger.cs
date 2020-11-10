using System;

namespace WorkTime.Interfaces
{
	public interface IMessenger
	{
		void Publish<T>(T message) where T : class;
		void Subscribe<T>(Action<dynamic> action) where T : class;
		void UnSubscribe<TMessage>(object subscriber) where TMessage : class;
	}
}
