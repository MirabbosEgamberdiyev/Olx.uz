

using DataAccesLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace DTO.DTOs.SubCategoryDtos;

public class UpdateSubCategoryDto:BaseDto
{
    [Required]
    public int CategoryId { get; set; }

    [MinLength(3), MaxLength(500)]
    public string Name { get; set; } = string.Empty;

}
