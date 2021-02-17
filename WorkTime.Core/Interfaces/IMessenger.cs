using System.Threading.Tasks;

namespace WorkTime.Core.Interfaces
{
	public interface IMessenger
	{
		Task PublishAsync<TMessage>(TMessage message) where TMessage : class;
		void Subscribe<T>(ISubscribe<T> Subscriber) where T : class;
	}

	public interface ISubscribe<T>
	{
		Task OnMessage(T message);

	}
}
