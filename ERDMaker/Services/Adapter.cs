using ERDMaker.Models;
using Microsoft.Xrm.Sdk.Metadata;

namespace ERDMaker.Services
{
    public class Adapter
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
    }
}
