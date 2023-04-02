using System.Text.Json;

namespace EAV.api.Entities.EAV.ValueObjects
{
    public class CustomValue
    {
        public CustomValue()
        {
        }

        public CustomValue(object valueData) : this()
        {
            ValueData = JsonSerializer.Serialize(valueData);
        }

        public string ValueData { get; init; } = default!;
    }
}