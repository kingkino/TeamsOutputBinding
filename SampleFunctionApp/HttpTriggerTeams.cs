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
            message.Title = "�G���[���������܂���";

            message.Text += "�����������@<br>";
            message.Text += "�����������@<br>";
            message.Text += "�����������@<br>";
            message.Text += "�Ȃɂʂ˂́@<br>";
            message.Text += "�����ĂƁ@<br>";
            message.Text += "�͂Ђӂւف@<br>";

            teamsMessage = message;

            return "Ok";
        }
    }
}
