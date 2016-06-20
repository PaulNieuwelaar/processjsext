using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessJS.Plugins.Actions
{
    /// <summary>
    /// Trigger: mag_Create (action/process) - post - sync
    /// 
    /// Input: Target (Entity)
    /// Output: Id (string containing GUID of created record)
    /// </summary>
    public class Create : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            Entity target = (Entity)context.InputParameters["Target"];
            Guid id = service.Create(target);

            context.OutputParameters["Id"] = id;
        }
    }
}
