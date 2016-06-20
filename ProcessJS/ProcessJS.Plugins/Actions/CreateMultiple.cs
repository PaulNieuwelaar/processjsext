using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessJS.Plugins.Actions
{
    /// <summary>
    /// Trigger: mag_CreateMultiple (action/process) - post - sync
    /// 
    /// Input: Entities (EntityCollection)
    /// </summary>
    public class CreateMultiple : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            EntityCollection entities = (EntityCollection)context.InputParameters["Entities"];

            if (entities != null)
            {
                foreach (Entity e in entities.Entities)
                {
                    service.Create(e);
                }
            }
        }
    }
}
