using ERDMaker.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using NuGet.Packaging;

namespace ERDMaker.Services
{
    public static class CRMService
    {
        private static readonly Dictionary<string, EntityMetadata> MetadataCache = new Dictionary<string, EntityMetadata>();
        private static readonly Dictionary<string, OptionSetMetadata> OptionSets = new Dictionary<string, OptionSetMetadata>();

        private static readonly List<Predicate<AttributeMetadata>> FieldPredicates = new List<Predicate<AttributeMetadata>>()
        {
            a => a.AttributeType != AttributeTypeCode.Picklist,
            a => a.AttributeType != AttributeTypeCode.Virtual,
            a => a.IsCustomAttribute == true || a.IsCustomAttribute == false && a.AttributeType == AttributeTypeCode.Uniqueidentifier && a.IsPrimaryId == false
        };

        public static ICollection<string> RetrieveAllEntities(IOrganizationService service)
        {
            var request = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true
            };
            var response = (RetrieveAllEntitiesResponse)service.Execute(request);
            return response.EntityMetadata.Select(md => md.LogicalName).ToArray();
        }

        internal static IEnumerable<SchemaDefinition> DefineEnums()
        {
            return OptionSets.Values.Select(DefineOptionSet);
        }

        private static OptionSet DefineOptionSet(OptionSetMetadata optionSet)
        {
            var optionSetDefinition = new OptionSet
            {
                Name = optionSet.Name
            };

            optionSetDefinition.Values.AddRange(optionSet.Options.Select(option => option.Label.UserLocalizedLabel.Label));

            return optionSetDefinition;
        }

        internal static IEnumerable<SchemaDefinition> DefineTables(IOrganizationService service, ICollection<string> relevantTables, Settings settings)
        {
            foreach (var relevantTable in relevantTables)
                RetrieveEntityMetadata(service, relevantTable);

            foreach (var relevantTable in relevantTables)
                yield return DefineTable(service, relevantTable, relevantTables, settings);
        }

        private static Table DefineTable(IOrganizationService service, string entity, ICollection<string> relevantTables, Settings settings)
        {
            var metadata = RetrieveEntityMetadata(service, entity);
            var table = new Table
            {
                Name = entity,
                Alias = entity,
            };

            DefinePrimaryKey(metadata, table);
            if (settings.GenerateFields)             
                DefineFields(metadata, table);
            if (settings.GenerateOptionSets)
                DefinePickLists(metadata, table);
            if (settings.GenerateRelationships)
            {
                DefineOneToManyRelationships(relevantTables, metadata, table);
                DefineManyToManyRelationships(relevantTables, metadata, table);
            }

            return table;
        }

        private static void DefinePrimaryKey(EntityMetadata metadata, Table table)
        {
            var attribute = metadata.Attributes.Single(a => a.LogicalName == metadata.PrimaryIdAttribute);
            var fieldFromAttribute = Adapter.FieldFromAttribute(attribute);
            fieldFromAttribute.Decoration = "[pk]";
            table.Fields.Add(fieldFromAttribute);
        }

        private static void DefineFields(EntityMetadata metadata, Table table)
        {
            var fields = metadata.Attributes.FindAll(FieldPredicates);
            foreach (var field in fields)
            {             
                var fieldFromAttribute = Adapter.FieldFromAttribute(field);

                if (field.IsPrimaryId != null && field.IsPrimaryId.Value)
                    fieldFromAttribute.Decoration = "[pk]";

                table.Fields.Add(fieldFromAttribute);
            }
        }

        private static void DefinePickLists(EntityMetadata metadata,
            Table table)
        {
            var picklists = metadata.Attributes.Where(a => a.AttributeType == AttributeTypeCode.Picklist && a.IsCustomAttribute == true).Cast<PicklistAttributeMetadata>();
            foreach (var picklist in picklists)
            {
                if (!OptionSets.ContainsKey(picklist.OptionSet.Name))
                    OptionSets.Add(picklist.OptionSet.Name, picklist.OptionSet);

                table.Fields.Add(Adapter.FieldFromAttribute(picklist));
            }
        }

        private static void DefineOneToManyRelationships(ICollection<string> relevantTables, EntityMetadata metadata,
            Table table)
        {
            if (metadata.OneToManyRelationships == null) return;
            
            foreach (var relationship in metadata.OneToManyRelationships)
            {
                if (!(relevantTables.Contains(relationship.ReferencingEntity) && relevantTables.Contains(relationship.ReferencedEntity)))
                    continue;

                var field = Adapter.FieldFromOneToManyRelationship(relationship);
                if (relevantTables.Contains(relationship.ReferencingEntity))
                    field.Decoration = $"[ref: < {relationship.ReferencingEntity}.{relationship.ReferencingAttribute}]";

                table.Fields.Add(field);
            }
        }

        private static void DefineManyToManyRelationships(ICollection<string> relevantTables, EntityMetadata metadata,
            Table table)
        {
            if (metadata.ManyToManyRelationships == null) return;
            
            foreach (var relationship in metadata.ManyToManyRelationships)
            {
                if (!(relevantTables.Contains(relationship.Entity1LogicalName) && relevantTables.Contains(relationship.Entity2LogicalName)))
                    continue;

                if (table.Name == relationship.IntersectEntityName) continue;
                
                var field = Adapter.FieldFromManyToManyRelationship(relationship);
                if (relevantTables.Contains(relationship.IntersectEntityName))
                    field.Decoration = $"[ref: {(relationship.RelationshipType == RelationshipType.OneToManyRelationship ? '<' : '>')} {relationship.IntersectEntityName}.{relationship.IntersectEntityName}id]";

                table.Fields.Add(field);
            }
        }

        private static EntityMetadata RetrieveEntityMetadata(IOrganizationService service, string entity)
        {
            if (MetadataCache.TryGetValue(entity, out EntityMetadata metadata))
                return metadata;

            var request = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Attributes | EntityFilters.Relationships,
                LogicalName = entity,
                RetrieveAsIfPublished = true,
            };
            var response = (RetrieveEntityResponse)service.Execute(request);
            MetadataCache.Add(entity, response.EntityMetadata);
            return response.EntityMetadata;
        }
    }
}
