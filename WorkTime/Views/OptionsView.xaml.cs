using System.Windows;
using WorkTime.ViewModels;

namespace WorkTime.Views
{
	/// <summary>
	/// Interaction logic for OptionsView.xaml
	/// </summary>
	public partial class OptionsView : Window
	{
		public OptionsView( OptionsViewModel viewmodel)
		{
			InitializeComponent();
			DataContext = viewmodel;
		}
	}
}
