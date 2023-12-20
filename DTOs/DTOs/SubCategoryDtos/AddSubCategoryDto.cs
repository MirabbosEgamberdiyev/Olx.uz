
using DataAccesLayer.Models;

namespace DTO.DTOs.SubCategoryDtos;

public partial class AddSubCategoryDto
{
    public int? CategoryId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<AdsElon> AdsElons { get; set; } = new List<AdsElon>();

    public virtual Category? Category { get; set; }
}
