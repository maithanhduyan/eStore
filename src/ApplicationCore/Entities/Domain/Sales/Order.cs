namespace EStore.Domain.Entities;
public class Order : IEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
}