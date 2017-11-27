using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Concurrency.ClassLibrary
{
    public class TempClass
    {
        public static async Task<T> DelayResult<T>(T result, TimeSpan delay)
        {
            await Task.Delay(delay);
            return result;
        }

        public static async Task<string> DownloadStringWithRetries(string uri)
        {
            using (var client = new HttpClient())
            {
                var nextDelay = TimeSpan.FromSeconds(1);
                for (int i = 0; i != 3; i++)
                {
                    try
                    {
                        return await client.GetStringAsync(uri);
                    }
                    catch
                    {
                    }
                    await Task.Delay(nextDelay);
                    nextDelay = nextDelay + nextDelay;
                }
                return await client.GetStringAsync(uri);
            }
        }

        public static async Task<string> DownloadStringWithTimeout(string uri)
        {
            using (var client = new HttpClient())
            {
                var downloadTask = client.GetStringAsync(uri);
                var timeoutTask = Task.Delay(3000);

                var completedTask = await Task.WhenAny(downloadTask, timeoutTask);
                if (completedTask == timeoutTask)
                    return null;
                return await downloadTask;
            }
        }
    }
}
