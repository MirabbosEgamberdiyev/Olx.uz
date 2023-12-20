

using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;

namespace DataAccesLayer.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryInterface
{
    public CategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
