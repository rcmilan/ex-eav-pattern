using EAV.api.Entities.Base;
using EAV.api.Entities.EAV;
using EAV.api.Entities.EAV.ValueObjects;

namespace EAV.api.Builder
{
    public static class CustomEntityBuilder
    {
        public static CustomEntity Build(this CustomEntity entity, string name)
        {
            entity ??= new CustomEntity();

            if (!entity.Active)
                entity.SwitchActive();

            entity.Name = name;

            return entity;
        }

        public static CustomEntity AddAttribute(this CustomEntity entity, string name, object valueData)
        {
            AttributeValType avType = GetAttributeValueType(valueData);

            var customAttribute = new CustomAttribute
            {
                Name = name,
                ValueType = avType,
                Values = new List<CustomValue>()
            };

            if (valueData.GetType().IsArray)
            {
                var arrData = (Array)valueData;

                System.Collections.IList list = arrData;
                for (int i = 0; i < list.Count; i++)
                {
                    object? item = list[i];
                    customAttribute.Values.Add(new CustomValue(item));
                }
            }
            else
            {
                customAttribute.Values.Add(new CustomValue(valueData));
            }

            entity.Attributes ??= new List<CustomAttribute>();

            entity.Attributes.Add(customAttribute);

            return entity;
        }

        private static AttributeValType GetAttributeValueType(object valueData) => valueData switch
        {
            string => AttributeValType.Text,
            int => AttributeValType.Integer,
            bool => AttributeValType.Boolean,
            DateTime => AttributeValType.Date,
            decimal => AttributeValType.Decimal,
            _ => AttributeValType.CustomObject,
        };
    }
}