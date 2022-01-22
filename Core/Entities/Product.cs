namespace EStore.Core.Entities;

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int InStock { get; set; }
    public double Price { get; set; }

}