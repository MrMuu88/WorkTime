using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkTime.Components;
using WorkTime.Interfaces;

namespace WorkTime.Tests
{
	[TestClass]
	public class MessengerComponentTest
	{
		public static MessengerComponent Messenger { get; private set; }

		[ClassInitialize]
		public static void InitializeClass(TestContext context)
		{
			Messenger = new MessengerComponent();
		}


		[TestInitialize]
		public void InitializeTest()
		{
			MessageReciever.MessageRecieved = false;
		}

		[TestMethod]
		public void MessageRecievedTest()
		{
			var reciever = new MessageReciever(Messenger);

			Messenger.Publish(new TestMessage(2));

			Assert.IsTrue(reciever.GotValue == 2);
		}

		[TestMethod]
		public void MessageRecieverRemovedTest()
		{
			var reciever = new MessageReciever(Messenger); // subscribes
			Messenger.UnSubscribe<TestMessage>(reciever); 

			Messenger.Publish(new TestMessage(2));
			Assert.IsTrue(MessageReciever.MessageRecieved == false);
		}
	}


	public class MessageReciever {
		public IMessenger Messenger { get; }
		public static bool MessageRecieved {get;set;} = false;
		public int GotValue { get; set; }

		public MessageReciever(IMessenger messenger)
		{
			Messenger = messenger;
			Messenger.Subscribe<TestMessage>((m) => { MessageRecieved = true; GotValue = m.Property; });
		}

	}

	public class TestMessage {

		public int Property { get; set; }

		public TestMessage(int property)
		{
			Property = property;
		}

	}
}
