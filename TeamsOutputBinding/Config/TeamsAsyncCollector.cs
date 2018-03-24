using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamsOutputBinding.Config
{
    class TeamsAsyncCollector : IAsyncCollector<TeamsMessage>
    {
        private TeamsConfiguration config;
        private TeamsAttribute attr;
        private static HttpClient client = new HttpClient();

        public TeamsAsyncCollector(TeamsConfiguration config, TeamsAttribute attr)
        {
            this.config = config;
            this.attr = attr;
        }

        public async Task AddAsync(TeamsMessage item, CancellationToken cancellationToken = default(CancellationToken))
        {
            var mergedItem = MergeMessageProperties(item, config, attr);
            await SendTeamsMessage(mergedItem, attr);
        }

        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }

        // combine properties to create final message that will be sent
        private static TeamsMessage MergeMessageProperties(TeamsMessage item, TeamsConfiguration config, TeamsAttribute attr)
        {
            var result = new TeamsMessage();

            result.Text = FirstOrDefault(item.Text, attr.Text);
            result.Title = FirstOrDefault(item.Title, attr.Title);

            return result;
        }

        private static string FirstOrDefault(params string[] values)
        {
            return values.FirstOrDefault(v => !string.IsNullOrEmpty(v));
        }

        private static async Task SendTeamsMessage(TeamsMessage mergedItem, TeamsAttribute attribute)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsJsonAsync(attribute.WebHookUrl, mergedItem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
