using System;
using System.Windows.Input;

namespace WorkTime.Helpers
{
	public class Command<T> : ICommand where T : class
	{
		public Action<T> Action { get; } = (T) => Console.WriteLine("Command Executed");
		public Func<bool> PredicatecanExecute { get; } = () => true;

		public event EventHandler CanExecuteChanged;

		public Command(Action<T> action)
		{
			Action = action;
		}
		public Command(Action<T> action, Func<bool> predicatecanExecute) : this(action)
		{
			PredicatecanExecute = predicatecanExecute;
		}

		public bool CanExecute(object parameter)
		{
			return PredicatecanExecute.Invoke();
		}

		public void Execute(object parameter)
		{
			Action.Invoke(parameter as T);
		}
	}

}
