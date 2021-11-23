using ERDMaker.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace ERDMaker.Services
{
    public class CRMService
    {
        private static readonly Dictionary<string, EntityMetadata> _metadatas = new Dictionary<string, EntityMetadata>();

        public static ICollection<string> GetAllEntities(IOrganizationService service)
        {
            var request = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true
            };
            var response = (RetrieveAllEntitiesResponse)service.Execute(request);
            return response.EntityMetadata.Select(md => md.LogicalName).ToArray();
        }

        internal static IEnumerable<Table> MapTables(IOrganizationService service, ICollection<string> relevantTables)
        {
            foreach (var relevantTable in relevantTables)
                GetEntityMetadata(service, relevantTable);

            foreach (var relevantTable in relevantTables)
                yield return GetTable(service, relevantTable, relevantTables);
        }

        public static Table GetTable(IOrganizationService service, string entity, ICollection<string> relevantTables)
        {
            var metadata = GetEntityMetadata(service, entity);
            var table = new Table
            {
                Name = entity,
                Alias = entity,
            };
            var primaryId = metadata.Attributes.Single(a => a.LogicalName == metadata.PrimaryIdAttribute);
            var primaryKey = Adapter.FieldFromAttribute(primaryId);
            primaryKey.Decoration = "[pk]";
            table.Fields.Add(primaryKey);

            var lookups = metadata.Attributes.Where(a => a.AttributeType == AttributeTypeCode.Lookup).Cast<LookupAttributeMetadata>();
            foreach (var lookup in lookups)
            {
                var targets = lookup.Targets.Intersect(relevantTables);
                if (!targets.Any())
                    continue;

                var field = Adapter.FieldFromAttribute(lookup);
                foreach (var target in targets)
                {
                    var targetMetadata = GetEntityMetadata(service, target);
                    field.References.Add($"{target}.{targetMetadata.PrimaryIdAttribute}");
                }
                table.Fields.Add(field);
            }
            return table;
        }

        private static EntityMetadata GetEntityMetadata(IOrganizationService service, string entity)
        {
            if (_metadatas.TryGetValue(entity, out EntityMetadata metadata))
                return metadata;

            var request = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Attributes,
                LogicalName = entity,
                RetrieveAsIfPublished = true,
            };
            var response = (RetrieveEntityResponse)service.Execute(request);
            _metadatas.Add(entity, response.EntityMetadata);
            return response.EntityMetadata;
        }
    }
}
