using DataAccesLayer.Repositories;

namespace OlxClone.Test.DataAccesLayer;

public class SubCategoryTest
{
    private DbContextOptions<AppDbContext> options =
     new DbContextOptionsBuilder<AppDbContext>()
     .UseInMemoryDatabase("OlxClone")
     .Options;

    private AppDbContext _dbContext;

     SubCategoryRepository _subCategoryRepository;
    [SetUp]
    public void Setup()
    {
        _dbContext = new AppDbContext(options);

        _dbContext.Database.EnsureCreated();

        _subCategoryRepository = new SubCategoryRepository(_dbContext);
    }

    [Test]
    public async Task AddAsync_AddNewSubCategoryToDatabase()
    {
        SubCategory subCategory = new SubCategory()
        {
            CategoryId = 1,
            Name = "SubCategory1"

        };
        await _subCategoryRepository.AddAsync(subCategory);
        await _dbContext.SaveChangesAsync();

        Assert.That(_dbContext.SubCategories.Count(), Is.EqualTo(1));
    }
    [Test]

    public async Task GetAllAsync_ReturnAllSubCategories()
    {
        var subCategories =   await _subCategoryRepository.GetAllAsync();
        await _dbContext.SaveChangesAsync();

        Assert.That(subCategories.Count(), Is.EqualTo(1));
    }

    [Test]

    public async Task GetByIdAsync_ReturnSubCategoryById()
    {
        var category = await _subCategoryRepository.GetByIdAsync(1);
        Assert.That(category!.Name, Is.EqualTo("SubCategory1"));
    }
    [Test]
    public async Task UpdateAsync_UpdateSubCategory()
    {
        var category = await _subCategoryRepository.GetByIdAsync(1);
        category!.Name = "Test2";
        await _subCategoryRepository.UpdateAsync(category);
        await _dbContext.SaveChangesAsync();

        Assert.That(_dbContext.Categories.First().Name, Is.EqualTo("Test2"));
    }

    [Test]
    public async Task DeleteAsync_DeleteCategory()
    {
        SubCategory category = new SubCategory() { Name = "Test123" };
        await _subCategoryRepository.AddAsync(category);
        await _dbContext.SaveChangesAsync();
        await _subCategoryRepository.DeleteAsync(category);
        await _dbContext.SaveChangesAsync();

        Assert.That(_dbContext.Categories.Count(), Is.EqualTo(1));
    }
}

