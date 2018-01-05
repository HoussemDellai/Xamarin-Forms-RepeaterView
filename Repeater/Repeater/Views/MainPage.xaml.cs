using System;
using Repeater.ViewModels;
using Xamarin.Forms;

namespace Repeater.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

	    private void Employee_Tapped(object sender, EventArgs e)
	    {
	        var view = sender as View;

	        var employee = view?.BindingContext as string;

	        DisplayAlert("Tap Event", "You have selected " + employee, "Ok");
	    }

	    private void Student_Tapped(object sender, EventArgs e)
	    {
	        var view = sender as View;

	        var student = view?.BindingContext as string;

	        var vm = BindingContext as MainViewModel;

            vm.SelectStudentCommand.Execute(student);
	    }
	}
}
