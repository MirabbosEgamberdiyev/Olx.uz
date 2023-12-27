
using DataAccesLayer.Models;

namespace BusinessLogicLayer.Extended;

public static class Validator
{
    public static bool IsValid(this Category category)
        => category != null
           && !string.IsNullOrEmpty(category.Name);

    public static bool IsExist(this Category category, IEnumerable<Category> categories)
        => categories.Any(c => c.Name == category.Name && c.Id != category.Id);



    public static bool IsValid(this SubCategory subCategory)
        => subCategory != null
           && !string.IsNullOrEmpty(subCategory.Name)
           && subCategory.CategoryId > 0 ;

    public static bool IsExist(this SubCategory subCategory, IEnumerable<SubCategory> subCategories)
        => subCategories.Any(c => c.Name == subCategory.Name && c.Id != subCategory.Id);
}
