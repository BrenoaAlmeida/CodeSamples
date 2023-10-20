using System.Net;

namespace Visual_Code
{
    public class AsyncMethods
    {
        public static List<string> PrepData()
        {
            List<string> output = new List<string>
            {
                "https://www.yahoo.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.cnn.com",
                "https://www.amazon.com",
                "https://www.facebook.com",
                "https://www.twitter.com",
                "https://www.codeproject.com",
                "https://www.stackoverflow.com",
                "https://en.wikipedia.org/wiki/.NET_Framework"
            };

            return output;
        }

        public static List<Website> RunDownloadSync()
        {
            List<string> websites = PrepData();
            List<Website> output = new List<Website>();

            foreach (string site in websites)
            {
                Website results = DownloadWebsite(site);
                output.Add(results);
            }

            return output;
        }

        public static List<Website> RunDownloadParallelSync()
        {
            List<string> websites = PrepData();
            List<Website> output = new List<Website>();

            Parallel.ForEach<string>(websites, (site) =>
            {
                Website results = DownloadWebsite(site);
                output.Add(results);
            });

            return output;
        }



        public static async Task<List<Website>> RunDownloadParallelAsyncV2(IProgress<ProgressoDoRelatorio> progress)
        {
            List<string> websites = PrepData();
            List<Website> output = new List<Website>();
            ProgressoDoRelatorio report = new ProgressoDoRelatorio();

            await Task.Run(() =>
            {
                Parallel.ForEach<string>(websites, (site) =>
                {
                    Website results = DownloadWebsite(site);
                    output.Add(results);

                    report.SitesBaixados = output;
                    report.PorcemtagemCompleta = (output.Count * 100) / websites.Count;
                    progress.Report(report);
                });
            });

            return output;
        }

        public static async Task<List<Website>> RunDownloadAsync(IProgress<ProgressoDoRelatorio> progress, CancellationToken cancellationToken)
        {
            List<string> websites = PrepData();
            List<Website> output = new List<Website>();
            ProgressoDoRelatorio report = new ProgressoDoRelatorio();

            foreach (string site in websites)
            {
                Website results = await DownloadWebsiteAsync(site);
                output.Add(results);

                cancellationToken.ThrowIfCancellationRequested();

                report.SitesBaixados = output;
                report.PorcemtagemCompleta = (output.Count * 100) / websites.Count;
                progress.Report(report);
            }

            return output;
        }

        public static async Task<List<Website>> RunDownloadParallelAsync()
        {
            List<string> websites = PrepData();
            List<Task<Website>> tasks = new List<Task<Website>>();

            foreach (string site in websites)
            {
                tasks.Add(DownloadWebsiteAsync(site));
            }

            var results = await Task.WhenAll(tasks);

            return new List<Website>(results);
        }

        private static async Task<Website> DownloadWebsiteAsync(string websiteURL)
        {
            Website output = new Website();
            WebClient client = new WebClient();

            output.WebsiteUrl = websiteURL;
            output.WebsiteData = await client.DownloadStringTaskAsync(websiteURL);

            return output;
        }

        private static Website DownloadWebsite(string websiteURL)
        {
            Website output = new Website();
            WebClient client = new WebClient();

            output.WebsiteUrl = websiteURL;
            output.WebsiteData = client.DownloadString(websiteURL);

            return output;
        }
    }
}
