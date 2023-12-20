

using DataAccesLayer.Models;

namespace DTO.DTOs.SubCategoryDtos;

public partial class SubCategoryDto:BaseDto
{
    public int? CategoryId { get; set; }

    public string Name { get; set; }

    public ICollection<AdsElon> AdsElons { get; set; } = new List<AdsElon>();
}
