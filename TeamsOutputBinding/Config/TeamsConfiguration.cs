using Microsoft.Azure.WebJobs.Host.Config;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsOutputBinding.Config
{
    /// <summary>
    /// Extension for binding <see cref="TeamsMessage"/>.
    /// </summary>
    public class TeamsConfiguration: IExtensionConfigProvider
    {
        #region Global configuration defaults
        public string Text { get; set; }
        public string Title { get; set; }
        #endregion

        public void Initialize(ExtensionConfigContext context)
        {
            // add converter between JObject and SlackMessage
            // Allows a user to bind to IAsyncCollector<JObject>, and the sdk will convert that to IAsyncCollector<SlackMessage>
            context.AddConverter<JObject, TeamsMessage>(input => input.ToObject<TeamsMessage>());

            // Add a binding rule for Collector
            context.AddBindingRule<TeamsAttribute>()
                .BindToCollector<TeamsMessage>(attr => new TeamsAsyncCollector(this, attr));
        }
    }
}