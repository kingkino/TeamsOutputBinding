using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsOutputBinding
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class TeamsAttribute:Attribute
    {
        [AppSetting(Default = "TeamsWebHookKeyName")]
        public string WebHookUrl { get; set; }
        
        [AutoResolve]
        public string Title { get; set; }

        [AutoResolve]
        public string Text { get; set; }

        [AutoResolve]
        public string Sections { get; set; }

        [AutoResolve]
        public string PotentialAction { get; set; }
    }
}
