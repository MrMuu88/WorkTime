using System.Windows;
using WorkTime.ViewModels;

namespace WorkTime.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class ReportView : Window
	{
		public ReportView(ReportsViewModel viewModel)
		{
			InitializeComponent();
		}
	}
}
