using EAV.api.Entities.Base;

namespace EAV.api.Entities.EAV.ValueObjects
{
    public class CustomAttribute
    {
        public string Name { get; init; } = default!;
        public ICollection<CustomValue> Values { get; init; } = default!;
        public AttributeValueType ValueType { get; init; } = default!;
    }
}