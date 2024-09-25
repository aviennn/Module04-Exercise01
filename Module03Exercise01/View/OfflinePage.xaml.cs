using System.Diagnostics;
using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Threading.Tasks;

namespace Module03Exercise01.View
{
    public partial class OfflinePage : ContentPage
    {
        private const string OnlineUrl = "https://www.google.com/";

        public OfflinePage()
        {
            InitializeComponent();

        }
        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            Application.Current.Quit();
        }

        private async void OnRetryButtonClicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;

            bool isWebsiteReachable = await IsWebsiteReachable(OnlineUrl);

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                await DisplayAlert("Online", "Connection successful! Redirecting you to the Login Page now.", "OK");
                //Application.Current.MainPage = new LoginPage();
                
                 await Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                await DisplayAlert("Offline", "Still offline. Please try again later.", "OK");
            }
        }

        private async Task<bool> IsWebsiteReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in IsWebsiteReachable: {ex.Message}");
                return false;
            }
        }
    }
}
