namespace BlazorCustomConrols.Models
{
    public class Job : IBaseEntity
    {
        public ulong BarID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string this[string propertyName] =>
            propertyName switch
            {
                nameof(BarID) => BarID.ToString(),
                nameof(Title) => Title,
                nameof(Name) => Name,
                _ => throw new ArgumentException($"Invalid property: {propertyName}")
            };
    }
}
