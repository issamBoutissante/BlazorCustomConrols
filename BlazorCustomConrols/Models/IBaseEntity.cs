namespace BlazorCustomConrols.Models
{
    public interface IBaseEntity
    {
        ulong BarID { get; set; }
        string Title { get; set; }
        string Name { get; set; }
        string this[string propertyName] { get; }
    }
}
