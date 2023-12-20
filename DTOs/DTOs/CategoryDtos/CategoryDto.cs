

using DataAccesLayer.Models;

namespace DTO.DTOs.CategoryDtos;

public partial class CategoryDto:BaseDto
{

    public string? Name { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
