

using AutoMapper;
using DataAccesLayer.Models;
using DTO.DTOs.CategoryDtos;

namespace DTO;

public class AutoMepperProfile:Profile
{
    public AutoMepperProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<AddCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
    }
}
