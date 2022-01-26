namespace EStore.Domain.Entities;

public class Product : IEntity
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public Category? Category { get; set; }
}