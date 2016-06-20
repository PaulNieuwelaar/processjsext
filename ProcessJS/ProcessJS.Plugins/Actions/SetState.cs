using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessJS.Plugins.Actions
{
    /// <summary>
    /// Trigger: mag_SetState (action/process) - post - sync
    /// 
    /// Input: EntityMoniker (EntityReference), State (int), Status (int)
    /// </summary>
    public class SetState : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            EntityReference target = (EntityReference)context.InputParameters["EntityMoniker"];
            int state = (int)context.InputParameters["State"];
            int status = (int)context.InputParameters["Status"];

            service.Execute(new SetStateRequest
            {
                EntityMoniker = target,
                State = new OptionSetValue(state),
                Status = new OptionSetValue(status)
            });
        }
    }
}
