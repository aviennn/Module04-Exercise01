using System.Diagnostics;
using Module03Exercise01.View;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using System.Net.Http;

namespace Module03Exercise01
{
    public partial class App : Application
    {
        private const string TestUrl = "https://reqbin.com/";

        private readonly IServiceProvider _serviceProvider;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            MainPage = new AppShell();

            _serviceProvider = serviceProvider;
        }
        protected override async void OnStart()
        {
            var current = Connectivity.NetworkAccess;

            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                //MainPage = new LoginPage();
                MainPage = _serviceProvider.GetRequiredService<LoginPage>();
                Debug.WriteLine("Application Started");
            }
            else
            {
                //MainPage = new OfflinePage();
                await Shell.Current.GoToAsync("//OfflinePage");
                Debug.WriteLine("No internet connection or website unreachable");
            }
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("Application Sleeping");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("Application Resumed");
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
