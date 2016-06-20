using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessJS.Plugins.Actions
{
    /// <summary>
    /// Trigger: mag_RetrieveMultiple (action/process) - post - sync
    /// 
    /// Input: Query (string containing fetch XML query)
    /// Output: EntityCollection (containing results)
    /// </summary>
    public class RetrieveMultiple : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            string fetchXml = (string)context.InputParameters["Query"];

            EntityCollection results = service.RetrieveMultiple(new FetchExpression(fetchXml));

            context.OutputParameters["EntityCollection"] = results;
        }
    }
}
