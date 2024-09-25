namespace Module03Exercise01.View;
using Module03Exercise01.Services;

public partial class LoginPage : ContentPage
{
    private readonly IMyService _myService; //Field for the service

	public LoginPage(IMyService myService)
	{
		InitializeComponent();
        _myService = myService;

        var message = _myService.GetMessage();
        MyLabel.Text = message;
	}

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Login Success", "Redirecting you to the Employee page...", "OK");
        await Shell.Current.GoToAsync("//EmployeePage");
    }
}