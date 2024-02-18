namespace Pizza_delivery.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Category> AllCategories => _db.Categories;
    }
}
