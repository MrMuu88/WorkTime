using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WorkTime.ViewModels
{
	public class ViewModelBase:INotifyPropertyChanged {
		
		public event PropertyChangedEventHandler PropertyChanged;

		public void Changed([CallerMemberName] string property = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}

	}
}
