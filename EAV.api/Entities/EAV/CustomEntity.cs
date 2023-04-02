using EAV.api.Entities.Base;

namespace EAV.api.Entities.EAV
{
    public class CustomEntity : BaseEntity<Guid>
    {
        public ICollection<CustomAttribute> Attributes { get; set; } = new List<CustomAttribute>();
    }

    public record CustomAttribute(string Name, AttributeValueType ValueType, ICollection<CustomValue> Values);

    public record CustomValue(string ValueData);
}
