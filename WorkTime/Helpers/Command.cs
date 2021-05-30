using System;
using System.Windows.Input;

namespace WorkTime.Helpers
{
	public class Command : ICommand
	{
		public Action Action { get; } = () => Console.WriteLine("Command Executed");
		public Func<bool> PredicatecanExecute { get; } = () => true;

		public event EventHandler CanExecuteChanged;

		public Command(Action action)
		{
			Action = action;
		}
		public Command(Action action, Func<bool> predicatecanExecute) : this(action)
		{
			PredicatecanExecute = predicatecanExecute;
		}

		public bool CanExecute(object parameter)
		{
			return PredicatecanExecute.Invoke();
		}

		public void Execute(object parameter)
		{
			Action.Invoke();
		}
	}
}
