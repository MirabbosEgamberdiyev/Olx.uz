

using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;

namespace DataAccesLayer.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;

    public IAdsElonInterface AdsElonInterface => new AdsElonRepository(_dbContext);

    public ICategoryInterface CategoryInterface => new CategoryRepository(_dbContext);

    public IChatInterface ChatInterface => new ChatRepository(_dbContext);

    public IImageInterface ImageInterface => new ImageRepository(_dbContext);

    public IMessageInterface MessageInterface => new MessageRepository(_dbContext);

    public IRegionInterface RegionInterface => new RegionRepository(_dbContext);

    public ISubCategoryInterface SubCategoryInterface => new SubCategoryRepository(_dbContext);

    public ISubRegionInterface SubRegionInterface => new SubRegionRepository(_dbContext);

    public void Dispose()
        => GC.SuppressFinalize(this);

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}