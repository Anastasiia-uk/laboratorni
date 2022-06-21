using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace lab3
{
    class Downloader
    {
        public delegate void Progress(int percent, long bytesReceived);
        public WebClient webClient { get; set; }
        public Progress ProgressHandler { get; set; }
        public Uri uri { get; set; } = null;
        public string fileName { get; set; } = null;
        public Downloader(Uri uri, string fileName)
        {
            this.uri = uri;
            this.fileName = fileName;
        }
        async public void DownloadFile()
        {
            await Task.Run(() =>
            {
                using (webClient = new WebClient())
                {
                    webClient.DownloadProgressChanged += (s, e) =>
                    {
                        ProgressHandler(e.ProgressPercentage, e.BytesReceived);
                    };
                    webClient.DownloadFileAsync(uri, fileName);
                                   }
            });
        }
        public void CancelDownloadingFile()
        {
            webClient.CancelAsync();
        }
        async public void DownloadPage()
        {
            HttpClient client = new HttpClient();
            using (HttpResponseMessage response = await client.GetAsync(uri))
            {
                using (HttpContent content = response.Content)
                {
                    System.IO.File.WriteAllText(fileName, await content.ReadAsStringAsync());
                }
            }
        }
    }
}
