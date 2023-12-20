using AutoMapper;
using BusinessLogicLayer.Extended;
using BusinessLogicLayer.Interfaces;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;
using DTO.DTOs.SubCategoryDtos;

namespace BusinessLogicLayer.Services;

public class SubCategoryService : ISubCategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task AddAsync(AddSubCategoryDto subCategoryDto)
    {
        if (subCategoryDto == null)
        {
            throw new ArgumentNullException("SubCategory is already exist!");
        }

        var subCategory = _mapper.Map<SubCategory>(subCategoryDto);
        if (!subCategory.IsValid())
        {
            throw new CustomException("Invalid SubCategory");
        }

        var subCategories = await _unitOfWork.SubCategoryInterface.GetAllAsync();
        if (subCategory.IsExist(subCategories))
        {
            throw new CustomException($"{subCategory.Name} is already exist!");
        }

        await _unitOfWork.SubCategoryInterface.AddAsync(subCategory);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var subCategory = await _unitOfWork.SubCategoryInterface.GetByIdAsync(id);
        if (subCategory == null)
        {
            throw new ArgumentNullException("Bunday subCategory mavjud emas");
        }
        await _unitOfWork.SubCategoryInterface.DeleteAsync(subCategory);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<SubCategoryDto>> GetAllAsync()
    {
        var subCategories = await _unitOfWork.SubCategoryInterface.GetAllAsync();
        return subCategories.Select(c => _mapper.Map<SubCategoryDto>(c)).ToList();
    }

    public async Task<PagedList<SubCategoryDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        var subCategories = await GetAllAsync();
        PagedList<SubCategoryDto> pagedList = new(subCategories, subCategories.Count, pageNumber, pageSize);

        return pagedList.ToPagedList(subCategories, pageSize, pageNumber);
    }

    public async Task<SubCategoryDto> GetByIdAsync(int id)
    {
        var subCategory = await _unitOfWork.SubCategoryInterface.GetByIdAsync(id);

        if (subCategory == null)
        {
            throw new ArgumentNullException("SubCategory is null here");
        }

        return _mapper.Map<SubCategoryDto>(subCategory);
    }

    public async Task Update(UpdateSubCategoryDto subCategoryDto)
    {
        if (subCategoryDto == null)
        {
            throw new ArgumentNullException("SubCategoryDto is null here");
        }

        var subCategories = await _unitOfWork.SubCategoryInterface.GetAllAsync();
        var subCategory = subCategories.FirstOrDefault(c => c.Id == subCategoryDto.Id);

        if (subCategory == null)
        {
            throw new ArgumentNullException("SubCategory is null here");
        }

        var updateSubCategory = _mapper.Map<SubCategory>(subCategoryDto);
        if (!updateSubCategory.IsValid())
        {
            throw new CustomException("SubCategory is invalid ");
        }

        if (updateSubCategory.IsExist(subCategories))
        {
            throw new CustomException("SubCategory is already exist ");
        }

        await _unitOfWork.SubCategoryInterface.UpdateAsync(updateSubCategory);
        await _unitOfWork.SaveAsync();
    }
}
