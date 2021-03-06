using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EStore.Domain.Entities;

public class Category : IEntity
{
    public string CategoryId { get; set; }
    public string Name { get; set; }

    public List<Product> Products { get; set; }

    [DefaultValueAttribute(typeof(DateTime))]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Enrollment Date")]
    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}