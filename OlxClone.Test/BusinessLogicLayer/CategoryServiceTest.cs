



namespace OlxClone.Test.BusinessLogicLayer;

public class CategoryServiceTest
{
    private DbContextOptions<AppDbContext> options =
     new DbContextOptionsBuilder<AppDbContext>()
     .UseInMemoryDatabase("OlxClone")
     .Options;

    private AppDbContext _dbContext;

    private IMapper _mapper;
    private IUnitOfWork _unitOfWork;

    private CategoryService _categoryService;

    [SetUp]
    public void Setup()
    {
        _dbContext = new AppDbContext(options);
        _mapper = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMepperProfile());
        }).CreateMapper();
        _unitOfWork = new UnitOfWork(_dbContext);
        _categoryService = new CategoryService(_unitOfWork, _mapper);
    }
}
