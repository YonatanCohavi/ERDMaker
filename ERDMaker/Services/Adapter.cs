using ERDMaker.Models;
using Microsoft.Xrm.Sdk.Metadata;

namespace ERDMaker.Services
{
    public static class Adapter
    {
        private static string GetAttributeTypeName(AttributeTypeCode? attributeType) => $"{attributeType}".ToLower();
        public static Field FieldFromAttribute(AttributeMetadata attribute)
        {
            return new Field
            {
                Name = attribute.LogicalName,
                Type = GetAttributeTypeName(attribute.AttributeType)
            };
        }

        public static Field FieldFromAttribute(PicklistAttributeMetadata attribute)
        {
            return new Field
            {
                Name = attribute.LogicalName,
                Type = $"{attribute.OptionSet.Name}_enum"
            };
        }

        public static Field FieldFromManyToManyRelationship(ManyToManyRelationshipMetadata manyToManyRelationship)
        {
            return new Field
            {
                Name = manyToManyRelationship.SchemaName,
                Type = manyToManyRelationship.IntersectEntityName
            };
        }

        public static Field FieldFromOneToManyRelationship(OneToManyRelationshipMetadata oneToManyRelationship)
        {
            return new Field
            {
                Name = oneToManyRelationship.SchemaName,
                Type = oneToManyRelationship.ReferencedEntity
            };
        }
    }
}
