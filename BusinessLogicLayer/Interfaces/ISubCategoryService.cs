

using BusinessLogicLayer.Extended;
using DTO.DTOs.CategoryDtos;
using DTO.DTOs.SubCategoryDtos;

namespace BusinessLogicLayer.Interfaces;

public interface ISubCategoryService
{
    Task<List<SubCategoryDto>> GetAllAsync();
    Task<SubCategoryDto> GetByIdAsync(int id);
    Task AddAsync(AddSubCategoryDto categoryDto);

    Task Delete(int id);
    Task Update(UpdateSubCategoryDto categoryDto);

    Task<PagedList<SubCategoryDto>> GetAllPaged(int pageSize, int pageNumber);
}
