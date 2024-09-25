using Module03Exercise01.ViewModel;

namespace Module03Exercise01.View;


public partial class EmployeePage : ContentPage
{
	public EmployeePage()
	{
		InitializeComponent();
        BindingContext = new EmployeeViewModel();

    }
    private async void OnButtonClickedAddEmployee(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AddEmployee");
    }

}