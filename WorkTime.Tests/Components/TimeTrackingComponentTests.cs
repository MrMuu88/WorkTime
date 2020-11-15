using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkTime.Models;
using System.Collections.Generic;
using System.Linq;

namespace WorkTime.Components.Tests
{
	[TestClass]
	public class TimeTrackingComponentTests
	{
		public static IEnumerable<object[]> OnTimerElapsedTestData
		{
			get => new List<object[]> {
			new object[]{new WorkDay(DateTime.Now,DateTime.Now),1,0,1 },
			new object[]{ GetaWorkDay(DateTime.Now.AddMinutes(-5), DateTime.Now,5),6,0,6 },
			new object[]{ GetaWorkDay(DateTime.Now.AddMinutes(-10), DateTime.Now.AddMinutes(-5),5),11,5,6 }
		};
		}

		public static MessengerComponent Messanger { get; private set; }
		public static TimeTrackingComponent TimeTracker { get; private set; }

		[ClassInitialize]
		public static void InitializeClass(TestContext context)
		{
			Messanger = new MessengerComponent();
			TimeTracker = new TimeTrackingComponent(Messanger);
		}

		[TestMethod]
		[DynamicData(nameof(OnTimerElapsedTestData))]
		public void OnTimerElapsedTest(WorkDay workday, int expLength, int expBreak, int expWork)
		{
			TimeTracker.OnTimerElapsed(workday);
			Assert.IsTrue(workday.Minutes.Count == expLength,$"Length incorrect, exp:{expLength}, got:{workday.Minutes.Count}");
			Assert.IsTrue(workday.Minutes.Where(m => !m).Count() == expBreak, $"Break incorrect, exp:{expBreak}, got:{workday.Minutes.Where(m => !m).Count()}");
			Assert.IsTrue(workday.Minutes.Where(m => m).Count() == expWork, $"Work incorrect, exp:{expWork}, got:{workday.Minutes.Where(m => m).Count()}");
		}

		private static WorkDay GetaWorkDay(DateTime started, DateTime lastWorked, int minutes=0, int breaks=0)
		{
			var wd =  new WorkDay();
			wd.Started = started;
			wd.LastWorked = lastWorked;
			wd.Minutes.AddRange(Enumerable.Repeat(true,minutes));
			wd.Minutes.AddRange(new bool[breaks]);
			return wd;
		}

	}
}