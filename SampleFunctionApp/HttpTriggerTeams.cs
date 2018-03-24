using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using TeamsOutputBinding;

namespace SampleFunctionApp
{
    public static class HttpTriggerTeams
    {
        [FunctionName("HttpTriggerTeams")]
        public static string Run(
            [HttpTrigger] TeamsMessage message,
            [Teams(WebHookUrl = "TeamsWebHook")] out TeamsMessage teamsMessage,
            TraceWriter log)
        {
            message.Title = "エラーが発生しました";

            message.Text += "あいうえお　<br>";
            message.Text += "かきくけこ　<br>";
            message.Text += "さしすせそ　<br>";
            message.Text += "なにぬねの　<br>";
            message.Text += "たちつてと　<br>";
            message.Text += "はひふへほ　<br>";

            teamsMessage = message;

            return "Ok";
        }
    }
}
