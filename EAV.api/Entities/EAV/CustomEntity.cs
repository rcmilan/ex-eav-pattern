using EAV.api.Entities.Base;
using EAV.api.Entities.EAV.ValueObjects;

namespace EAV.api.Entities.EAV
{
    public class CustomEntity : BaseEntity<Guid>
    {
        public ICollection<CustomAttribute> Attributes { get; set; } = new List<CustomAttribute>();
    }
}