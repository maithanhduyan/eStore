using System.ComponentModel.DataAnnotations;

namespace EStore.Domain.Entities;

public class Product : IEntity
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public int InStock { get; set; }
    public double SalePrice { get; set; }
    public double CostPrice { get; set; }
    public double PromotionPrice { get; set; }
    [Display(Name = "Created Date")]
    public DateTime CreatedDate { get; set; }
    [Display(Name = "Updated Date")]
    public DateTime UpdatedDate { get; set; }
    public Category Category { get; set; }
    public string CategoryId { get; set; }
}