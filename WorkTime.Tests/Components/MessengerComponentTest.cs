using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkTime.Components;

namespace WorkTime.Tests.Components
{
	[TestClass]
	public class MessengerComponentTest
	{
		public static MessengerComponent Messenger { get; private set; }
		public bool MessageRecieved { get; set; }
		public int ValueRecieved { get; set; }

		[ClassInitialize]
		public static void InitializeClass(TestContext context)
		{
			Messenger = new MessengerComponent();
		}

		[TestMethod]
		public void SubscribeTest()
		{
			Messenger.Subscribe<TestMessage>((m) => ValueRecieved = m.Value);

			Messenger.Publish(new TestMessage(2));

			Assert.IsTrue(ValueRecieved == 2);
		}

		[TestMethod]
		public void UnsubscribeTest()
		{
			Messenger.Subscribe<TestMessage>((m) => MessageRecieved = true);
			Messenger.UnSubscribe<TestMessage>(this);
			Messenger.Publish(new TestMessage(2));
			Assert.IsTrue(!MessageRecieved);
		}

	}

	public class TestMessage
	{

		public int Value { get; set; }

		public TestMessage(int value)
		{
			Value = value;
		}

	}
}
