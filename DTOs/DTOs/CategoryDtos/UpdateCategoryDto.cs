

using DataAccesLayer.Models;

namespace DTO.DTOs.CategoryDtos;

public partial class UpdateCategoryDto:BaseDto
{
    public string? Name { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
