using EAV.api.Entities.Base;
using EAV.api.Entities.EAV.ValueObjects;

namespace EAV.api.Entities.EAV
{
    public class CustomEntity : BaseEntity<Guid>
    {
        public string Name { get; set; } = default!;
        public ICollection<CustomAttribute> Attributes { get; set; } = new List<CustomAttribute>();
    }
}