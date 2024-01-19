

using BusinessLogicLayer.Extended;
using DTO.DTOs.CategoryDtos;

namespace BusinessLogicLayer.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(int id);
    Task AddAsync(AddCategoryDto categoryDto);
    Task Delete(int id);
    Task Update(UpdateCategoryDto categoryDto);

    Task<PagedList<CategoryDto>> GetAllPaged( int pageSize, int pageNumber);
}
