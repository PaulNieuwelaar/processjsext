using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessJS.Plugins.Actions
{
    /// <summary>
    /// Trigger: mag_Associate (action/process) - post - sync
    /// 
    /// Input: Target (EntityReference), RelatedEntity (EntityReference), Relationship (string schema name)
    /// </summary>
    public class Associate : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            EntityReference target = (EntityReference)context.InputParameters["Target"];
            EntityReference relatedEntity = (EntityReference)context.InputParameters["RelatedEntity"];
            string relationship = (string)context.InputParameters["Relationship"];

            EntityReferenceCollection collection = new EntityReferenceCollection();
            collection.Add(relatedEntity);

            service.Associate(target.LogicalName, target.Id, new Relationship(relationship), collection);
        }
    }
}
