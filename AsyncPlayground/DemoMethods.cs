using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncPlayground
{
    public static class DemoMethods
    {
        public static List<WebsiteDataModel> RunDownloadSync()
        {
            var output = new List<WebsiteDataModel>();

            var websites = PrepData();
            foreach (var site in websites)
            {
                output.Add(DownloadWebsite(site));
            }

            return output;
        }

        public static List<WebsiteDataModel> RunDownloadParallelSync()
        {
            var output = new List<WebsiteDataModel>();

            var websites = PrepData();

            Parallel.ForEach<string>(websites, (site) =>
            {
                output.Add(DownloadWebsite(site));
            });

            return output;
        }

        public static async Task<List<WebsiteDataModel>> RunDownloadParallelAsyncV2(IProgress<ProgressReportModel> progress)
        {
            var output = new List<WebsiteDataModel>();
            var report = new ProgressReportModel();

            var websites = PrepData();

            await Task.Run(() =>
            {
                Parallel.ForEach<string>(websites, (site) =>
                {
                    output.Add(DownloadWebsite(site));
                    report.SitesDownloaded = output;
                    report.PercentageComplete = (output.Count * 100) / websites.Count;
                    progress.Report(report);
                });
            });

            return output;
        }

        public static async Task<List<WebsiteDataModel>> RunDownloadAsync(IProgress<ProgressReportModel> progress, CancellationToken cancellationToken)
        {
            var output = new List<WebsiteDataModel>();
            var report = new ProgressReportModel();

            var websites = PrepData();
            foreach (var site in websites)
            {
                output.Add(await DownloadWebsiteAsync(site));

                cancellationToken.ThrowIfCancellationRequested();

                report.SitesDownloaded = output;
                report.PercentageComplete = (output.Count * 100) / websites.Count;
                progress.Report(report);
            }

            return output;
        }

        public static async Task<List<WebsiteDataModel>> RunDownloadParallelAsync()
        {
            var websites = PrepData();
            var tasks = new List<Task<WebsiteDataModel>>();

            foreach (var site in websites)
            {
                tasks.Add(DownloadWebsiteAsync(site));
            }

            var results = await Task.WhenAll(tasks);

            return results.ToList();
        }

        private static List<string> PrepData()
        {
            var output = new List<string>
            {
                "https://www.yahoo.com",
                "https://www.google.com",
                "https://www.facebook.com",
                "https://www.bing.com/",
                "https://duckduckgo.com/",
                "https://www.startpage.com/",
                "https://www.qwant.com/?l=en",
                "https://swisscows.com/en"
            };

            return output;
        }

        private static WebsiteDataModel DownloadWebsite(string url)
        {
            var output = new WebsiteDataModel();
            var client = new WebClient();

            output.WebsiteUrl = url;
            output.WebsiteData = client.DownloadString(url);

            return output;
        }

        private static async Task<WebsiteDataModel> DownloadWebsiteAsync(string url)
        {
            var output = new WebsiteDataModel();
            var client = new HttpClient();

            output.WebsiteUrl = url;
            output.WebsiteData = await client.GetStringAsync(url);

            return output;
        }
    }
}
