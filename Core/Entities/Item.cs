namespace EStore.Core.Entities;
public class Item
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string BarCode { get; set; }
    public double Price { get; set; }
    public string Link { get; set; }
    public string Image { get; set; }
    public double Weight { get; set; }
}