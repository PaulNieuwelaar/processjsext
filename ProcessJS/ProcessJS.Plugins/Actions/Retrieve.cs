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
    /// Trigger: mag_Retrieve (action/process) - post - sync
    /// 
    /// Input: Target (EntityReference), ColumnSet (string of cols separated by comma)
    /// Output: Entity (containing selected columns)
    /// </summary>
    public class Retrieve : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);
            ITracingService tracer = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            EntityReference target = (EntityReference)context.InputParameters["Target"];
            string columnsString = (string)context.InputParameters["ColumnSet"];

            tracer.Trace("id={0}, cols={1}", target.Id, columnsString);

            ColumnSet cols = new ColumnSet(true);

            if (!string.IsNullOrWhiteSpace(columnsString))
            {
                string[] columnsArray = columnsString.Split(',').Select(a => a.Trim()).Where(a => !string.IsNullOrEmpty(a)).ToArray();
                if (columnsArray.Length > 0)
                {
                    cols = new ColumnSet(columnsArray);
                }
            }

            Entity entity = service.Retrieve(target.LogicalName, target.Id, cols);

            context.OutputParameters["Entity"] = entity;
        }
    }
}
