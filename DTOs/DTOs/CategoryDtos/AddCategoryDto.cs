

using DataAccesLayer.Models;

namespace DTO.DTOs.CategoryDtos;

public partial class AddCategoryDto
{

    public string? Name { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
