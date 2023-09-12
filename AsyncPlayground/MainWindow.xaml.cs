using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncPlayground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void executeSync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            RunDownloadSync();

            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;

            resultsWindow.Text += $"Total execution time: {elapsedMs}";
        }

        private async void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //await RunDownloadAsync();

            await RunDownloadParallelAsync2();

            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;

            resultsWindow.Text += $"Total execution time: {elapsedMs} {Environment.NewLine}";
        }

        private List<string> PrepData()
        {
            var output = new List<string>();

            resultsWindow.Text = $"Retrieving data...{ Environment.NewLine }";

            output.Add("https://www.yahoo.com");
            output.Add("https://www.google.com");

            return output;
        }

        private void RunDownloadSync()
        {
            var websites = PrepData();
            foreach (var site in websites) 
            {
                var results = DownloadWebsite(site);
                ReportWebsiteInfo(results);
            }
        }

        private async Task RunDownloadAsync()
        {
            var websites = PrepData();
            foreach (var site in websites)
            {
                var results = await Task.Run(() => DownloadWebsite(site));
                ReportWebsiteInfo(results);
            }
        }

        private async Task RunDownloadParallelAsync()
        {
            var websites = PrepData();
            var tasks = new List<Task<WebsiteDataModel>>();

            foreach (var site in websites)
            {
                tasks.Add(DownloadWebsiteAsync(site));
            }

            var results = await Task.WhenAll(tasks);

            foreach (var item in results)
            {
                ReportWebsiteInfo(item);
            }
        }

        private async Task RunDownloadParallelAsync2()
        {
            var websites = PrepData();
            var tasks = new List<Task<WebsiteDataModel>>();

            foreach (var site in websites)
            {
                tasks.Add(DownloadWebsiteAsync2(site));
            }

            var results = await Task.WhenAll(tasks);

            foreach (var item in results)
            {
                ReportWebsiteInfo(item);
            }
        }

        private WebsiteDataModel DownloadWebsite(string url)
        {
            var output = new WebsiteDataModel();
            var client = new WebClient();

            output.WebsiteUrl = url;
            output.WebsiteData = client.DownloadString(url);

            return output;
        }

        private async Task<WebsiteDataModel> DownloadWebsiteAsync(string url)
        {
            var output = new WebsiteDataModel();
            var client = new WebClient();

            output.WebsiteUrl = url;
            output.WebsiteData = await client.DownloadStringTaskAsync(url);

            return output;
        }

        private async Task<WebsiteDataModel> DownloadWebsiteAsync2(string url)
        {
            var output = new WebsiteDataModel();
            var _httpClient = new HttpClient();

            output.WebsiteUrl = url;
            output.WebsiteData = await _httpClient.GetStringAsync(url);

            return output;
        }

        private void ReportWebsiteInfo(WebsiteDataModel data)
        {
            resultsWindow.Text += $"{ data.WebsiteUrl } downloaded: { data.WebsiteData.Length } characters long.{ Environment.NewLine }";
        }
    }
}
