namespace AppLoad3images
{
    public partial class Form1 : Form
    {
        private List<string> fileUrls = new List<string>
        {
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTjBJHwR_cHlcl7hfOokTXfHDeLq4VFdtMpUA&s",
            "https://i.insider.com/627ea537e7446d0018cc6ed1?width=700",
            "https://www.searchenginejournal.com/wp-content/uploads/2022/04/reverse-image-search-627b7e49986b0-sej.png",
        };

        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            progressBarOverall.Value = 0;
            listBoxProgress.Items.Clear();

            var overallProgress = new Progress<int>(value => progressBarOverall.Value = value);
            await DownloadFilesAsync(fileUrls, overallProgress);
        }

        private async Task DownloadFilesAsync(List<string> urls, IProgress<int> overallProgress)
        {
            int totalFiles = urls.Count;
            int completedFiles = 0;
            var httpClient = new HttpClient();

            var downloadTasks = new List<Task>();

            foreach (var url in urls)
            {
                var progress = new Progress<int>(percent =>
                {
                    listBoxProgress.Items.Add($"Downloading {url}: {percent}%");
                    listBoxProgress.TopIndex = listBoxProgress.Items.Count - 1;
                });

                downloadTasks.Add(Task.Run(async () =>
                {
                    await DownloadFileAsync(httpClient, url, progress);
                    completedFiles++;
                    int overallPercent = (int)((double)completedFiles / totalFiles * 100);
                    overallProgress.Report(overallPercent);
                }));
            }

            await Task.WhenAll(downloadTasks);
        }

        private async Task DownloadFileAsync(HttpClient httpClient, string url, IProgress<int> progress)
        {
            var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            var contentLength = response.Content.Headers.ContentLength.GetValueOrDefault();

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                var buffer = new byte[8192];
                long totalRead = 0;
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    totalRead += bytesRead;
                    int percentComplete = (int)((double)totalRead / contentLength * 100);
                    progress.Report(percentComplete);
                }
            }
        }
    }
}
